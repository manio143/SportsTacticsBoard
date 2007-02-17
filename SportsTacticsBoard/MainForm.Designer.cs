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
namespace SportsTacticsBoard
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.previousLayoutInSequence = new System.Windows.Forms.ToolStripButton();
      this.currentLayoutNumber = new System.Windows.Forms.ToolStripTextBox();
      this.nextLayoutInSequence = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.recordNewPositionButton = new System.Windows.Forms.ToolStripButton();
      this.recordOverCurrentPositionButton = new System.Windows.Forms.ToolStripButton();
      this.removeCurrentPositionFromSequenceButton = new System.Windows.Forms.ToolStripButton();
      this.revertCurrentLayoutToSavedButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.showMovementButton = new System.Windows.Forms.ToolStripButton();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.playingSurfaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changePlayingSurfaceTypeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newSequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openSequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.exportSequenceToImageFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.saveSequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSequenceAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.layoutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveTofileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.saveCurrentLayoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removeSavedLayoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.savedLayoutsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.playersonBenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.startingPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.gamePositionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.fieldControl = new SportsTacticsBoard.FieldControl();
      this.toolStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previousLayoutInSequence,
            this.currentLayoutNumber,
            this.nextLayoutInSequence,
            this.toolStripSeparator2,
            this.recordNewPositionButton,
            this.recordOverCurrentPositionButton,
            this.removeCurrentPositionFromSequenceButton,
            this.revertCurrentLayoutToSavedButton,
            this.toolStripSeparator1,
            this.showMovementButton});
      resources.ApplyResources(this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      // 
      // previousLayoutInSequence
      // 
      this.previousLayoutInSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.previousLayoutInSequence.Image = global::SportsTacticsBoard.Properties.Resources.GoToPrevious;
      resources.ApplyResources(this.previousLayoutInSequence, "previousLayoutInSequence");
      this.previousLayoutInSequence.Name = "previousLayoutInSequence";
      this.previousLayoutInSequence.Click += new System.EventHandler(this.previousLayoutInSequence_Click);
      // 
      // currentLayoutNumber
      // 
      this.currentLayoutNumber.Name = "currentLayoutNumber";
      this.currentLayoutNumber.ReadOnly = true;
      resources.ApplyResources(this.currentLayoutNumber, "currentLayoutNumber");
      // 
      // nextLayoutInSequence
      // 
      this.nextLayoutInSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.nextLayoutInSequence.Image = global::SportsTacticsBoard.Properties.Resources.GoToNextHS;
      resources.ApplyResources(this.nextLayoutInSequence, "nextLayoutInSequence");
      this.nextLayoutInSequence.Name = "nextLayoutInSequence";
      this.nextLayoutInSequence.Click += new System.EventHandler(this.nextLayoutInSequence_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      // 
      // recordNewPositionButton
      // 
      this.recordNewPositionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      resources.ApplyResources(this.recordNewPositionButton, "recordNewPositionButton");
      this.recordNewPositionButton.Name = "recordNewPositionButton";
      this.recordNewPositionButton.Click += new System.EventHandler(this.recordNewPositionButton_Click);
      // 
      // recordOverCurrentPositionButton
      // 
      this.recordOverCurrentPositionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      resources.ApplyResources(this.recordOverCurrentPositionButton, "recordOverCurrentPositionButton");
      this.recordOverCurrentPositionButton.Name = "recordOverCurrentPositionButton";
      this.recordOverCurrentPositionButton.Click += new System.EventHandler(this.recordOverCurrentPositionButton_Click);
      // 
      // removeCurrentPositionFromSequenceButton
      // 
      this.removeCurrentPositionFromSequenceButton.Image = global::SportsTacticsBoard.Properties.Resources.DeleteHS;
      resources.ApplyResources(this.removeCurrentPositionFromSequenceButton, "removeCurrentPositionFromSequenceButton");
      this.removeCurrentPositionFromSequenceButton.Name = "removeCurrentPositionFromSequenceButton";
      this.removeCurrentPositionFromSequenceButton.Click += new System.EventHandler(this.removeCurrentPositionFromSequenceButton_Click);
      // 
      // revertCurrentLayoutToSavedButton
      // 
      this.revertCurrentLayoutToSavedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      resources.ApplyResources(this.revertCurrentLayoutToSavedButton, "revertCurrentLayoutToSavedButton");
      this.revertCurrentLayoutToSavedButton.Name = "revertCurrentLayoutToSavedButton";
      this.revertCurrentLayoutToSavedButton.Click += new System.EventHandler(this.revertCurrentLayoutToSavedButton_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      // 
      // showMovementButton
      // 
      this.showMovementButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      resources.ApplyResources(this.showMovementButton, "showMovementButton");
      this.showMovementButton.Name = "showMovementButton";
      this.showMovementButton.Click += new System.EventHandler(this.showMovementButton_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playingSurfaceMenuItem,
            this.sequenceMenuItem,
            this.layoutsToolStripMenuItem,
            this.helpToolStripMenuItem});
      resources.ApplyResources(this.menuStrip1, "menuStrip1");
      this.menuStrip1.Name = "menuStrip1";
      // 
      // playingSurfaceMenuItem
      // 
      this.playingSurfaceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePlayingSurfaceTypeMenuItem,
            this.toolStripSeparator9,
            this.exitMenuItem});
      this.playingSurfaceMenuItem.Name = "playingSurfaceMenuItem";
      resources.ApplyResources(this.playingSurfaceMenuItem, "playingSurfaceMenuItem");
      // 
      // changePlayingSurfaceTypeMenuItem
      // 
      this.changePlayingSurfaceTypeMenuItem.Name = "changePlayingSurfaceTypeMenuItem";
      resources.ApplyResources(this.changePlayingSurfaceTypeMenuItem, "changePlayingSurfaceTypeMenuItem");
      this.changePlayingSurfaceTypeMenuItem.Click += new System.EventHandler(this.newPlayingSurfaceTypeMenuItem_Click);
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
      // 
      // exitMenuItem
      // 
      this.exitMenuItem.Name = "exitMenuItem";
      resources.ApplyResources(this.exitMenuItem, "exitMenuItem");
      this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // sequenceMenuItem
      // 
      this.sequenceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSequenceMenuItem,
            this.openSequenceMenuItem,
            this.toolStripSeparator8,
            this.exportSequenceToImageFilesMenuItem,
            this.toolStripSeparator7,
            this.saveSequenceMenuItem,
            this.saveSequenceAsMenuItem});
      this.sequenceMenuItem.Name = "sequenceMenuItem";
      resources.ApplyResources(this.sequenceMenuItem, "sequenceMenuItem");
      // 
      // newSequenceMenuItem
      // 
      this.newSequenceMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.NewDocumentHS;
      this.newSequenceMenuItem.Name = "newSequenceMenuItem";
      this.newSequenceMenuItem.ShortcutKeyDisplayString = global::SportsTacticsBoard.Properties.Resources.CurrentLayoutNumber_Empty;
      resources.ApplyResources(this.newSequenceMenuItem, "newSequenceMenuItem");
      this.newSequenceMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // openSequenceMenuItem
      // 
      this.openSequenceMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.openHS;
      this.openSequenceMenuItem.Name = "openSequenceMenuItem";
      resources.ApplyResources(this.openSequenceMenuItem, "openSequenceMenuItem");
      this.openSequenceMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
      // 
      // exportSequenceToImageFilesMenuItem
      // 
      this.exportSequenceToImageFilesMenuItem.Name = "exportSequenceToImageFilesMenuItem";
      resources.ApplyResources(this.exportSequenceToImageFilesMenuItem, "exportSequenceToImageFilesMenuItem");
      this.exportSequenceToImageFilesMenuItem.Click += new System.EventHandler(this.saveSequenceToImageFilesToolStripMenuItem_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      // 
      // saveSequenceMenuItem
      // 
      this.saveSequenceMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.saveHS;
      this.saveSequenceMenuItem.Name = "saveSequenceMenuItem";
      resources.ApplyResources(this.saveSequenceMenuItem, "saveSequenceMenuItem");
      this.saveSequenceMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // saveSequenceAsMenuItem
      // 
      this.saveSequenceAsMenuItem.Name = "saveSequenceAsMenuItem";
      resources.ApplyResources(this.saveSequenceAsMenuItem, "saveSequenceAsMenuItem");
      this.saveSequenceAsMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
      // 
      // layoutsToolStripMenuItem
      // 
      this.layoutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem,
            this.saveTofileToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveCurrentLayoutMenuItem,
            this.removeSavedLayoutMenuItem,
            this.toolStripSeparator4,
            this.savedLayoutsMenuItem,
            this.toolStripSeparator5,
            this.playersonBenchToolStripMenuItem,
            this.toolStripMenuItem2});
      this.layoutsToolStripMenuItem.Name = "layoutsToolStripMenuItem";
      resources.ApplyResources(this.layoutsToolStripMenuItem, "layoutsToolStripMenuItem");
      // 
      // copyMenuItem
      // 
      this.copyMenuItem.Name = "copyMenuItem";
      resources.ApplyResources(this.copyMenuItem, "copyMenuItem");
      this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
      // 
      // saveTofileToolStripMenuItem
      // 
      this.saveTofileToolStripMenuItem.Name = "saveTofileToolStripMenuItem";
      resources.ApplyResources(this.saveTofileToolStripMenuItem, "saveTofileToolStripMenuItem");
      this.saveTofileToolStripMenuItem.Click += new System.EventHandler(this.saveTofileToolStripMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
      // 
      // savedCurrentLayoutMenuItem
      // 
      this.saveCurrentLayoutMenuItem.Name = "savedCurrentLayoutMenuItem";
      resources.ApplyResources(this.saveCurrentLayoutMenuItem, "savedCurrentLayoutMenuItem");
      this.saveCurrentLayoutMenuItem.Click += new System.EventHandler(this.savedCurrentLayoutMenuItem_Click);
      // 
      // removeSavedLayoutMenuItem
      // 
      this.removeSavedLayoutMenuItem.Name = "removeSavedLayoutMenuItem";
      resources.ApplyResources(this.removeSavedLayoutMenuItem, "removeSavedLayoutMenuItem");
      this.removeSavedLayoutMenuItem.Click += new System.EventHandler(this.removeSavedLayoutMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
      // 
      // savedLayoutsMenuItem
      // 
      this.savedLayoutsMenuItem.Name = "savedLayoutsMenuItem";
      resources.ApplyResources(this.savedLayoutsMenuItem, "savedLayoutsMenuItem");
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      // 
      // playersonBenchToolStripMenuItem
      // 
      this.playersonBenchToolStripMenuItem.Name = "playersonBenchToolStripMenuItem";
      resources.ApplyResources(this.playersonBenchToolStripMenuItem, "playersonBenchToolStripMenuItem");
      this.playersonBenchToolStripMenuItem.Click += new System.EventHandler(this.playersonBenchToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startingPositionToolStripMenuItem,
            this.gamePositionToolStripMenuItem1});
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
      // 
      // startingPositionToolStripMenuItem
      // 
      this.startingPositionToolStripMenuItem.Name = "startingPositionToolStripMenuItem";
      resources.ApplyResources(this.startingPositionToolStripMenuItem, "startingPositionToolStripMenuItem");
      this.startingPositionToolStripMenuItem.Click += new System.EventHandler(this.startingPositionToolStripMenuItem_Click);
      // 
      // gamePositionToolStripMenuItem1
      // 
      this.gamePositionToolStripMenuItem1.Name = "gamePositionToolStripMenuItem1";
      resources.ApplyResources(this.gamePositionToolStripMenuItem1, "gamePositionToolStripMenuItem1");
      this.gamePositionToolStripMenuItem1.Click += new System.EventHandler(this.gamePositionToolStripMenuItem1_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.Help;
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
      this.toolStripButton1.Name = "toolStripButton1";
      // 
      // fieldControl
      // 
      resources.ApplyResources(this.fieldControl, "fieldControl");
      this.fieldControl.FieldType = null;
      this.fieldControl.IsDirty = false;
      this.fieldControl.Name = "fieldControl";
      this.fieldControl.ShowMovementLines = true;
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.fieldControl);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.menuStrip1);
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton recordNewPositionButton;
    private System.Windows.Forms.ToolStripButton previousLayoutInSequence;
    private System.Windows.Forms.ToolStripTextBox currentLayoutNumber;
    private System.Windows.Forms.ToolStripButton nextLayoutInSequence;
    private System.Windows.Forms.ToolStripButton recordOverCurrentPositionButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton removeCurrentPositionFromSequenceButton;
    private System.Windows.Forms.ToolStripButton revertCurrentLayoutToSavedButton;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem sequenceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openSequenceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSequenceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSequenceAsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem layoutsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem playersonBenchToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem startingPositionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem gamePositionToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem newSequenceMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton showMovementButton;
    private FieldControl fieldControl;
    private System.Windows.Forms.ToolStripMenuItem saveCurrentLayoutMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem savedLayoutsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeSavedLayoutMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripMenuItem playingSurfaceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exportSequenceToImageFilesMenuItem;
    private System.Windows.Forms.ToolStripMenuItem changePlayingSurfaceTypeMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveTofileToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
  }
}

