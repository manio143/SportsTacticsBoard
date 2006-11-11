// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2006 Robert Turner
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace SportsTacticsBoard
{
  public partial class MainForm : Form
  {
    private List<SavedLayout> savedLayouts = null;
    private FieldObjectLayoutSequence currentSequence = null;
    private int positionInSequence;
    private string fileName = "";
    private string fileFilter = Properties.Resources.ResourceManager.GetString("FileFilter");
    private string originalCaption;

    public MainForm()
    {
      savedLayouts = new List<SavedLayout>();
      InitializeComponent();
      originalCaption = Text;
      fieldControl.IsDirtyChanged += new EventHandler(fieldControl_IsDirtyChanged);
    }

    private void recordNewPositionButton_Click(object sender, EventArgs e)
    {
      if (null != currentSequence) {
        positionInSequence = RecordPositionToSequence(false, positionInSequence + 1, currentSequence);
        fieldControl.SetNextLayout(currentSequence.GetLayout(positionInSequence + 1));
        UpdateSequenceControls();
      }
    }

    private void fieldControl_IsDirtyChanged(object sender, EventArgs e)
    {
      UpdateSequenceControls();
      UpdateFileMenuItems();
    }

    private void RestoreSavedLayout(string name)
    {
      foreach (SavedLayout savedLayout in savedLayouts)
      {
        if (savedLayout.Name == name)
        {
          fieldControl.SetLayout(savedLayout.Layout);
          return;
        }
      }
    }

    private void savedLayoutMenuItem_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem mi = (ToolStripMenuItem)sender;
      RestoreSavedLayout(mi.Text);
    }

    private void UpdateFileMenuItems()
    {
      saveAsToolStripMenuItem.Enabled = (fieldControl.FieldType != null);
      saveToolStripMenuItem.Enabled   = (fieldControl.FieldType != null);
    }

    private void UpdateLayoutMenuItems()
    {
      savedCurrentLayoutMenuItem.Enabled = (fieldControl.FieldType != null);
    }

    private void UpdateSavedLayoutMenuItems()
    {
      savedLayoutsMenuItem.DropDownItems.Clear();
      bool itemsInserted = false;
      if (savedLayouts.Count > 0)
      {
        foreach (SavedLayout savedLayout in savedLayouts)
        {
          if (savedLayout.FieldTypeTag == fieldControl.FieldType.Tag) {
            ToolStripMenuItem mi = new ToolStripMenuItem(savedLayout.Name, null, new EventHandler(savedLayoutMenuItem_Click));
            if (savedLayout.Description.Length > 0) {
              mi.ToolTipText = savedLayout.Description;
            }
            savedLayoutsMenuItem.DropDownItems.Add(mi);
            itemsInserted = true;
          }
        }
      }
      if (itemsInserted) {
        removeSavedLayoutMenuItem.Enabled = true;
      } else {
        string menuItemStr = Properties.Resources.ResourceManager.GetString("NoSavedLayoutsMenuItemText");
        ToolStripMenuItem mi = new ToolStripMenuItem(menuItemStr);
        mi.Enabled = false;
        savedLayoutsMenuItem.DropDownItems.Add(mi);
        removeSavedLayoutMenuItem.Enabled = false;
      }
    }

    private void SaveCurrentLayout()
    {
      FieldObjectLayout layout = fieldControl.GetLayout();
      SavedLayoutInformation dialog = new SavedLayoutInformation();
      foreach (FieldObjectLayout.Entry entry in layout.entries) {
        dialog.entriesListBox.Items.Add(entry.tag, true);
      }
      if (dialog.ShowDialog() == DialogResult.OK)
      {
        for (int index = 0; index < dialog.entriesListBox.Items.Count; index++)
        {
          if (!dialog.entriesListBox.GetItemChecked(index))
          {
            layout.RemoveEntry((string)(dialog.entriesListBox.Items[index]));
          }
        }
        SavedLayout sl = new SavedLayout(dialog.nameTextBox.Text, dialog.descriptionTextBox.Text, layout, fieldControl.FieldType.Tag);
        savedLayouts.Add(sl);
      }
      UpdateSavedLayoutMenuItems();
    }

    private void UpdateSequenceControls()
    {
      if (null != currentSequence) {
        if (currentSequence.NumberOfLayouts == 0) {
          currentLayoutNumber.Text = "";
        } else {
          currentLayoutNumber.Text = (positionInSequence + 1).ToString() + "/" + currentSequence.NumberOfLayouts.ToString();
        }
        previousLayoutInSequence.Enabled = (positionInSequence > 0);
        nextLayoutInSequence.Enabled = ((positionInSequence + 1) < currentSequence.NumberOfLayouts);
        revertCurrentLayoutToSavedButton.Enabled = (currentSequence.NumberOfLayouts > 0) && (fieldControl.IsDirty);
        removeCurrentPositionFromSequenceButton.Enabled = (currentSequence.NumberOfLayouts > 0);
        showMovementButton.Checked = fieldControl.ShowMovementLines;
        showMovementButton.Enabled = true;
        recordOverCurrentPositionButton.Enabled = true;
        recordNewPositionButton.Enabled = true;
      } else {
        previousLayoutInSequence.Enabled = false;
        nextLayoutInSequence.Enabled = false;
        revertCurrentLayoutToSavedButton.Enabled = false;
        removeCurrentPositionFromSequenceButton.Enabled = false;
        showMovementButton.Checked = false;
        showMovementButton.Enabled = false;
        recordOverCurrentPositionButton.Enabled = false;
        recordNewPositionButton.Enabled = false;
      }
    }

    private void previousLayoutInSequence_Click(object sender, EventArgs e)
    {
      MoveToPreviousLayout();
    }

    private void MoveToPreviousLayout()
    {
      if (null == currentSequence) {
        return;
      }
      if (positionInSequence > 0) {
        if ((currentSequence.NumberOfLayouts > 0) && (fieldControl.IsDirty))
        {
          DialogResult dr = 
            MessageBox.Show(Properties.Resources.ResourceManager.GetString("SaveSequenceEntryBeforeSwitchingEntries"),
                            this.Text, MessageBoxButtons.YesNoCancel);
          switch (dr)
          {
            case DialogResult.Yes:
              RecordPositionToSequence(true, positionInSequence, currentSequence);
              break;
            case DialogResult.Cancel:
              return;
          }
        }
        positionInSequence--;
        RestorePositionFromSequence(positionInSequence, currentSequence, currentSequence.GetLayout(positionInSequence + 1));
        UpdateSequenceControls();
      }
    }

    private void nextLayoutInSequence_Click(object sender, EventArgs e)
    {
      MoveToNextLayout();
    }

    private void MoveToNextLayout()
    {
      if (null == currentSequence) {
        return;
      }
      if (positionInSequence < currentSequence.NumberOfLayouts) {
        if ((currentSequence.NumberOfLayouts > 0) && (fieldControl.IsDirty))
        {
          DialogResult dr =
            MessageBox.Show(Properties.Resources.ResourceManager.GetString("SaveSequenceEntryBeforeSwitchingEntries"),
                            this.Text, MessageBoxButtons.YesNoCancel);
          switch (dr)
          {
            case DialogResult.Yes:
              RecordPositionToSequence(true, positionInSequence, currentSequence);
              break;
            case DialogResult.Cancel:
              return;
          }
        }
        positionInSequence++;
        RestorePositionFromSequence(positionInSequence, currentSequence, currentSequence.GetLayout(positionInSequence + 1));
        UpdateSequenceControls();
      }
    }

    private void recordOverCurrentPositionButton_Click(object sender, EventArgs e)
    {
      if (null != currentSequence) {
        RecordPositionToSequence(true, positionInSequence, currentSequence);
        UpdateSequenceControls();
      }
    }

    private void removeCurrentPositionFromSequenceButton_Click(object sender, EventArgs e)
    {
      if (null != currentSequence) {
        currentSequence.RemoveFromSequence(positionInSequence);
        if (positionInSequence >= currentSequence.NumberOfLayouts) {
          positionInSequence--;
        }
        fieldControl.SetNextLayout(currentSequence.GetLayout(positionInSequence + 1));
        UpdateSequenceControls();
      }
    }

    private void revertCurrentLayoutToSavedButton_Click(object sender, EventArgs e)
    {
      if (null != currentSequence) {
        RestorePositionFromSequence(positionInSequence, currentSequence, currentSequence.GetLayout(positionInSequence + 1));
        UpdateSequenceControls();
      }
    }

    private void MoveAllPlayersToBench()
    {
      if (null != fieldControl.FieldType) {
        fieldControl.ApplyLayoutAlgorithm(new LayoutAlgorithms.BenchLayoutAlgorithm(fieldControl.FieldType));
      }
    }

    private void playersonBenchToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MoveAllPlayersToBench();
    }

    private void startingPositionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (null != fieldControl.FieldType) {
        fieldControl.ApplyLayoutAlgorithm(new LayoutAlgorithms.FourFourTwoLayoutAlgorithm_StartPos(fieldControl.FieldType));
      }
    }

    private void gamePositionToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (null != fieldControl.FieldType) {
        fieldControl.ApplyLayoutAlgorithm(new LayoutAlgorithms.FourFourTwoLayoutAlgorithm_GamePos(fieldControl.FieldType));
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void UpdateCaption()
    {
      string title = originalCaption;
      if (fileName != "") {
        int idx = fileName.LastIndexOf('\\');
        string name;
        if (idx >= 0) {
          name = fileName.Substring(idx + 1);
        } else {
          name = fileName;
        }
        title += " - " + name;
      }
      Text = title;
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.CheckFileExists = true;
      openFileDialog.Filter = fileFilter;
      openFileDialog.RestoreDirectory = true;
      openFileDialog.SupportMultiDottedExtensions = true;
      openFileDialog.Multiselect = false;

      DialogResult res = openFileDialog.ShowDialog();
      if (res == DialogResult.OK) {
        XmlSerializer serializer = new XmlSerializer(typeof(FieldObjectLayoutSequence));
        FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
        FieldObjectLayoutSequence seq = (FieldObjectLayoutSequence)serializer.Deserialize(fs);
        if (seq != null) {
          currentSequence = seq;
          positionInSequence = 0;
          RestorePositionFromSequence(positionInSequence, currentSequence, currentSequence.GetLayout(positionInSequence + 1));
          UpdateSequenceControls();
          fileName = openFileDialog.FileName;
          UpdateCaption();
        }
        if (seq == null) {
          string msgFormat = Properties.Resources.ResourceManager.GetString("FailedToOpenFileFormatStr");
          MessageBox.Show(String.Format(msgFormat, openFileDialog.FileName),
            Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (fileName == "") {
        FileSaveAs();
      } else {
        FileSave();
      }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FileSaveAs();
    }

    private void FileSave()
    {
      if (null != currentSequence) {
        XmlSerializer serializer = new XmlSerializer(typeof(FieldObjectLayoutSequence));
        TextWriter writer = new StreamWriter(fileName);
        serializer.Serialize(writer, currentSequence);
        writer.Close();
      }
      UpdateFileMenuItems();
    }

    private void FileSaveAs()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = fileFilter;
      saveFileDialog.RestoreDirectory = true;
      saveFileDialog.SupportMultiDottedExtensions = true;

      DialogResult res = saveFileDialog.ShowDialog();
      if (res == DialogResult.OK) {
        fileName = saveFileDialog.FileName;
        UpdateCaption();
        FileSave();
      }
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FileNew(true, false);
    }

    private List<IFieldType> AvailableFieldTypes
    {
      get
      {
        List<IFieldType> fieldTypes = new List<IFieldType>();

        // TODO: Enumerate these using reflection on the current assembly

        fieldTypes.Add(new FieldTypes.SoccerField());
        fieldTypes.Add(new FieldTypes.HockeyRink_NHL());

        return fieldTypes;
      }
    }

    private IFieldType LoadDefaultFieldType()
    {
      string defaultFieldType = global::SportsTacticsBoard.Properties.Settings.Default.DefaultFieldType;
      if (defaultFieldType.Length == 0) {
        return null;
      };
      List<IFieldType> fieldTypes = AvailableFieldTypes;
      foreach (IFieldType ft in fieldTypes) {
        if (ft.Name == defaultFieldType) {
          return ft;
        }
      }
      return null;
    }

    private IFieldType AskUserForFieldType(bool saveAsDefaultChecked)
    {
      SelectFieldType sftDialog = new SelectFieldType();
      sftDialog.saveAsDefaultCheckBox.Checked = saveAsDefaultChecked;
      sftDialog.fieldTypeComboBox.DataSource = AvailableFieldTypes;
      sftDialog.fieldTypeComboBox.DisplayMember = "Name";
      if (sftDialog.fieldTypeComboBox.Items.Count > 0) {
        string defaultFieldType = global::SportsTacticsBoard.Properties.Settings.Default.DefaultFieldType;
        int selectedIndex = 0;
        if (defaultFieldType.Length > 0) {
          int index = sftDialog.fieldTypeComboBox.FindStringExact(defaultFieldType);
          if (index >= 0) {
            selectedIndex = index;
          } 
        }
        sftDialog.fieldTypeComboBox.SelectedIndex = selectedIndex;
      }
      if (sftDialog.ShowDialog() != DialogResult.OK) {
        return null;
      }
      IFieldType selectedFieldType = (IFieldType)sftDialog.fieldTypeComboBox.SelectedItem;
      if (sftDialog.saveAsDefaultCheckBox.Checked) {
        global::SportsTacticsBoard.Properties.Settings.Default.DefaultFieldType =
          selectedFieldType.Name;
        global::SportsTacticsBoard.Properties.Settings.Default.Save();
      }
      return selectedFieldType;
    }

    private void FileNew(bool saveAsDefaultChecked, bool alwaysAskForFieldType)
    {
      IFieldType newFieldType = fieldControl.FieldType;
      if (newFieldType == null) {
        newFieldType = LoadDefaultFieldType();
      }
      if ((newFieldType == null) || (alwaysAskForFieldType)) {
        newFieldType = AskUserForFieldType(saveAsDefaultChecked);
        if (null == newFieldType) {
          return;
        }
      }

      fileName = "";
      fieldControl.FieldType = newFieldType;
      fieldControl.SetNextLayout(null);
      fieldControl.IsDirty = false;
      positionInSequence = 0;
      currentSequence = new FieldObjectLayoutSequence(fieldControl.FieldType.Tag);
      UpdateCaption();
      UpdateFileMenuItems();
      UpdateLayoutMenuItems();
      UpdateSavedLayoutMenuItems();
      UpdateSequenceControls();
    }

    private void showMovementButton_Click(object sender, EventArgs e)
    {
      ToolStripButton b = (ToolStripButton)sender;
      fieldControl.ShowMovementLines = !fieldControl.ShowMovementLines;
      b.Checked = fieldControl.ShowMovementLines;
    }

    private void fieldControl_KeyDown(object sender, KeyEventArgs e)
    {
      if (!e.Handled && !e.Shift && !e.Alt && !e.Control) {
        if (e.KeyCode == Keys.Left) {
          MoveToPreviousLayout();
        } else if (e.KeyCode == Keys.Right) {
          MoveToNextLayout();
        }
      }
    }

    private int RecordPositionToSequence(bool replace, int index, FieldObjectLayoutSequence sequence)
    {
      FieldObjectLayout layout = fieldControl.GetLayout();
      fieldControl.IsDirty = false;
      if (replace) {
        sequence.SetLayout(index, layout);
        return index;
      } else {
        return sequence.AddNewLayout(index, layout);
      }
    }

    private void RestorePositionFromSequence(int index, FieldObjectLayoutSequence sequence, FieldObjectLayout _nextLayout)
    {
      fieldControl.SetLayouts(sequence.GetLayout(index), _nextLayout);
      fieldControl.IsDirty = false;
    }

    private void savedCurrentLayoutMenuItem_Click(object sender, EventArgs e)
    {
      SaveCurrentLayout();
    }

    private void removeSavedLayoutMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Not implemented yet!");
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBox aboutBox = new AboutBox();
      aboutBox.ShowDialog();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
      UpdateFileMenuItems();
      UpdateLayoutMenuItems();
      UpdateSavedLayoutMenuItems();
      UpdateSequenceControls();
      if (null == fieldControl.FieldType) {
        FileNew(true, false);
      }
    }

    private void newFieldTypeMenuItem_Click(object sender, EventArgs e)
    {
      FileNew(false, true);
    }
    
  }
}