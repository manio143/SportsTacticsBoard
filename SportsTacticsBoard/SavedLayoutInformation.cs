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

namespace SportsTacticsBoard
{
  public partial class SavedLayoutInformation : Form
  {
    public SavedLayoutInformation()
    {
      InitializeComponent();
    }

    internal static SavedLayout AskUserForSavedLayoutDetails(FieldObjectLayout layout, string fieldTypeTag, string[] existingLayoutCategories)
    {
      SavedLayoutInformation dialog = new SavedLayoutInformation();
      foreach (string entryTag in layout.Tags) {
        dialog.entriesListBox.Items.Add(entryTag, true);
      }
      dialog.categoryComboBox.DataSource = existingLayoutCategories;
      dialog.categoryComboBox.SelectedIndex = -1; // make sure nothing is specified at first

      if (dialog.ShowDialog() == DialogResult.OK) {
        for (int index = 0; index < dialog.entriesListBox.Items.Count; index++) {
          if (!dialog.entriesListBox.GetItemChecked(index)) {
            layout.RemoveEntry((string)(dialog.entriesListBox.Items[index]));
          }
        }
        return new SavedLayout(dialog.nameTextBox.Text, dialog.categoryComboBox.Text, dialog.descriptionTextBox.Text, layout, fieldTypeTag);
      }
      return null;
    }

    private void nameTextBox_Validating(object sender, CancelEventArgs e)
    {
      if (nameTextBox.Text.Trim().Length == 0)
      {
        errorProvider.SetError(nameTextBox, "Name must not be blank.");
        e.Cancel = true;
        return;
      }
    }

    private void nameTextBox_Validated(object sender, EventArgs e)
    {
      errorProvider.SetError(nameTextBox, "");
    }

    private void entriesListBox_Validating(object sender, CancelEventArgs e)
    {
      if (entriesListBox.CheckedItems.Count == 0)
      {
        errorProvider.SetError(entriesListBox, "At least one item must be checked.");
        e.Cancel = true;
        return;
      }
    }

    private void entriesListBox_Validated(object sender, EventArgs e)
    {
      errorProvider.SetError(entriesListBox, "");
    }
  }
}