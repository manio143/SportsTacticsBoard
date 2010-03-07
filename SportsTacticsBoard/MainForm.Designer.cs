// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2006-2010 Robert Turner
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.sequenceToolString = new System.Windows.Forms.ToolStrip();
      this.goToFirstToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.previousLayoutInSequence = new System.Windows.Forms.ToolStripButton();
      this.currentLayoutNumber = new System.Windows.Forms.ToolStripTextBox();
      this.nextLayoutInSequence = new System.Windows.Forms.ToolStripButton();
      this.goToLastToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
      this.playToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.recordNewPositionButton = new System.Windows.Forms.ToolStripButton();
      this.recordOverCurrentPositionButton = new System.Windows.Forms.ToolStripButton();
      this.removeCurrentPositionFromSequenceButton = new System.Windows.Forms.ToolStripButton();
      this.revertCurrentLayoutToSavedButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.showMovementButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
      this.sequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newSequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openSequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.exportSequenceToImageFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.saveSequenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSequenceAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.printMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.layoutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveTofileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.saveCurrentLayoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removeSavedLayoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.userSavedLayoutsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.commonSavedLayoutsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changeLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.readMeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.licenseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.playingSurfaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changePlayingSurfaceTypeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.playSequenceTimer = new System.Windows.Forms.Timer(this.components);
      this.fieldControl = new SportsTacticsBoard.FieldControl();
      this.sequenceToolString.SuspendLayout();
      this.mainMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // sequenceToolString
      // 
      this.sequenceToolString.AccessibleDescription = null;
      this.sequenceToolString.AccessibleName = null;
      resources.ApplyResources(this.sequenceToolString, "sequenceToolString");
      this.sequenceToolString.BackgroundImage = null;
      this.sequenceToolString.Font = null;
      this.sequenceToolString.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToFirstToolStripButton,
            this.previousLayoutInSequence,
            this.currentLayoutNumber,
            this.nextLayoutInSequence,
            this.goToLastToolStripButton,
            this.toolStripSeparator11,
            this.playToolStripButton,
            this.toolStripSeparator2,
            this.recordNewPositionButton,
            this.recordOverCurrentPositionButton,
            this.removeCurrentPositionFromSequenceButton,
            this.revertCurrentLayoutToSavedButton,
            this.toolStripSeparator1,
            this.showMovementButton,
            this.toolStripSeparator10});
      this.sequenceToolString.Name = "sequenceToolString";
      // 
      // goToFirstToolStripButton
      // 
      this.goToFirstToolStripButton.AccessibleDescription = null;
      this.goToFirstToolStripButton.AccessibleName = null;
      resources.ApplyResources(this.goToFirstToolStripButton, "goToFirstToolStripButton");
      this.goToFirstToolStripButton.BackgroundImage = null;
      this.goToFirstToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.goToFirstToolStripButton.Image = global::SportsTacticsBoard.Properties.Resources.DataContainer_MoveFirstHS;
      this.goToFirstToolStripButton.Name = "goToFirstToolStripButton";
      this.goToFirstToolStripButton.Click += new System.EventHandler(this.goToFirstToolStripButton_Click);
      // 
      // previousLayoutInSequence
      // 
      this.previousLayoutInSequence.AccessibleDescription = null;
      this.previousLayoutInSequence.AccessibleName = null;
      resources.ApplyResources(this.previousLayoutInSequence, "previousLayoutInSequence");
      this.previousLayoutInSequence.BackgroundImage = null;
      this.previousLayoutInSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.previousLayoutInSequence.Image = global::SportsTacticsBoard.Properties.Resources.DataContainer_MovePreviousHS;
      this.previousLayoutInSequence.Name = "previousLayoutInSequence";
      this.previousLayoutInSequence.Click += new System.EventHandler(this.previousLayoutInSequence_Click);
      // 
      // currentLayoutNumber
      // 
      this.currentLayoutNumber.AccessibleDescription = null;
      this.currentLayoutNumber.AccessibleName = null;
      resources.ApplyResources(this.currentLayoutNumber, "currentLayoutNumber");
      this.currentLayoutNumber.Name = "currentLayoutNumber";
      this.currentLayoutNumber.ReadOnly = true;
      // 
      // nextLayoutInSequence
      // 
      this.nextLayoutInSequence.AccessibleDescription = null;
      this.nextLayoutInSequence.AccessibleName = null;
      resources.ApplyResources(this.nextLayoutInSequence, "nextLayoutInSequence");
      this.nextLayoutInSequence.BackgroundImage = null;
      this.nextLayoutInSequence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.nextLayoutInSequence.Image = global::SportsTacticsBoard.Properties.Resources.DataContainer_MoveNextHS;
      this.nextLayoutInSequence.Name = "nextLayoutInSequence";
      this.nextLayoutInSequence.Click += new System.EventHandler(this.nextLayoutInSequence_Click);
      // 
      // goToLastToolStripButton
      // 
      this.goToLastToolStripButton.AccessibleDescription = null;
      this.goToLastToolStripButton.AccessibleName = null;
      resources.ApplyResources(this.goToLastToolStripButton, "goToLastToolStripButton");
      this.goToLastToolStripButton.BackgroundImage = null;
      this.goToLastToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.goToLastToolStripButton.Image = global::SportsTacticsBoard.Properties.Resources.DataContainer_MoveLastHS;
      this.goToLastToolStripButton.Name = "goToLastToolStripButton";
      this.goToLastToolStripButton.Click += new System.EventHandler(this.goToLastToolStripButton_Click);
      // 
      // toolStripSeparator11
      // 
      this.toolStripSeparator11.AccessibleDescription = null;
      this.toolStripSeparator11.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      // 
      // playToolStripButton
      // 
      this.playToolStripButton.AccessibleDescription = null;
      this.playToolStripButton.AccessibleName = null;
      resources.ApplyResources(this.playToolStripButton, "playToolStripButton");
      this.playToolStripButton.BackgroundImage = null;
      this.playToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.playToolStripButton.Image = global::SportsTacticsBoard.Properties.Resources.PlayHS;
      this.playToolStripButton.Name = "playToolStripButton";
      this.playToolStripButton.Click += new System.EventHandler(this.playToolStripButton_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.AccessibleDescription = null;
      this.toolStripSeparator2.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      // 
      // recordNewPositionButton
      // 
      this.recordNewPositionButton.AccessibleDescription = null;
      this.recordNewPositionButton.AccessibleName = null;
      resources.ApplyResources(this.recordNewPositionButton, "recordNewPositionButton");
      this.recordNewPositionButton.BackgroundImage = null;
      this.recordNewPositionButton.Image = global::SportsTacticsBoard.Properties.Resources.RecordHS;
      this.recordNewPositionButton.Name = "recordNewPositionButton";
      this.recordNewPositionButton.Click += new System.EventHandler(this.recordNewPositionButton_Click);
      // 
      // recordOverCurrentPositionButton
      // 
      this.recordOverCurrentPositionButton.AccessibleDescription = null;
      this.recordOverCurrentPositionButton.AccessibleName = null;
      resources.ApplyResources(this.recordOverCurrentPositionButton, "recordOverCurrentPositionButton");
      this.recordOverCurrentPositionButton.BackgroundImage = null;
      this.recordOverCurrentPositionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.recordOverCurrentPositionButton.Name = "recordOverCurrentPositionButton";
      this.recordOverCurrentPositionButton.Click += new System.EventHandler(this.recordOverCurrentPositionButton_Click);
      // 
      // removeCurrentPositionFromSequenceButton
      // 
      this.removeCurrentPositionFromSequenceButton.AccessibleDescription = null;
      this.removeCurrentPositionFromSequenceButton.AccessibleName = null;
      resources.ApplyResources(this.removeCurrentPositionFromSequenceButton, "removeCurrentPositionFromSequenceButton");
      this.removeCurrentPositionFromSequenceButton.BackgroundImage = null;
      this.removeCurrentPositionFromSequenceButton.Image = global::SportsTacticsBoard.Properties.Resources.DeleteHS;
      this.removeCurrentPositionFromSequenceButton.Name = "removeCurrentPositionFromSequenceButton";
      this.removeCurrentPositionFromSequenceButton.Click += new System.EventHandler(this.removeCurrentPositionFromSequenceButton_Click);
      // 
      // revertCurrentLayoutToSavedButton
      // 
      this.revertCurrentLayoutToSavedButton.AccessibleDescription = null;
      this.revertCurrentLayoutToSavedButton.AccessibleName = null;
      resources.ApplyResources(this.revertCurrentLayoutToSavedButton, "revertCurrentLayoutToSavedButton");
      this.revertCurrentLayoutToSavedButton.BackgroundImage = null;
      this.revertCurrentLayoutToSavedButton.Image = global::SportsTacticsBoard.Properties.Resources.Edit_UndoHS;
      this.revertCurrentLayoutToSavedButton.Name = "revertCurrentLayoutToSavedButton";
      this.revertCurrentLayoutToSavedButton.Click += new System.EventHandler(this.revertCurrentLayoutToSavedButton_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.AccessibleDescription = null;
      this.toolStripSeparator1.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      // 
      // showMovementButton
      // 
      this.showMovementButton.AccessibleDescription = null;
      this.showMovementButton.AccessibleName = null;
      resources.ApplyResources(this.showMovementButton, "showMovementButton");
      this.showMovementButton.BackgroundImage = null;
      this.showMovementButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.showMovementButton.Name = "showMovementButton";
      this.showMovementButton.Click += new System.EventHandler(this.showMovementButton_Click);
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.AccessibleDescription = null;
      this.toolStripSeparator10.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      // 
      // mainMenuStrip
      // 
      this.mainMenuStrip.AccessibleDescription = null;
      this.mainMenuStrip.AccessibleName = null;
      resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
      this.mainMenuStrip.BackgroundImage = null;
      this.mainMenuStrip.Font = null;
      this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequenceMenuItem,
            this.layoutsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.playingSurfaceMenuItem});
      this.mainMenuStrip.Name = "mainMenuStrip";
      // 
      // sequenceMenuItem
      // 
      this.sequenceMenuItem.AccessibleDescription = null;
      this.sequenceMenuItem.AccessibleName = null;
      resources.ApplyResources(this.sequenceMenuItem, "sequenceMenuItem");
      this.sequenceMenuItem.BackgroundImage = null;
      this.sequenceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSequenceMenuItem,
            this.openSequenceMenuItem,
            this.toolStripSeparator8,
            this.exportSequenceToImageFilesMenuItem,
            this.toolStripSeparator7,
            this.saveSequenceMenuItem,
            this.saveSequenceAsMenuItem,
            this.toolStripSeparator5,
            this.printMenuItem,
            this.toolStripSeparator9,
            this.exitMenuItem});
      this.sequenceMenuItem.Name = "sequenceMenuItem";
      this.sequenceMenuItem.ShortcutKeyDisplayString = null;
      // 
      // newSequenceMenuItem
      // 
      this.newSequenceMenuItem.AccessibleDescription = null;
      this.newSequenceMenuItem.AccessibleName = null;
      resources.ApplyResources(this.newSequenceMenuItem, "newSequenceMenuItem");
      this.newSequenceMenuItem.BackgroundImage = null;
      this.newSequenceMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.NewDocumentHS;
      this.newSequenceMenuItem.Name = "newSequenceMenuItem";
      this.newSequenceMenuItem.ShortcutKeyDisplayString = global::SportsTacticsBoard.Properties.Resources.CurrentLayoutNumber_Empty;
      this.newSequenceMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // openSequenceMenuItem
      // 
      this.openSequenceMenuItem.AccessibleDescription = null;
      this.openSequenceMenuItem.AccessibleName = null;
      resources.ApplyResources(this.openSequenceMenuItem, "openSequenceMenuItem");
      this.openSequenceMenuItem.BackgroundImage = null;
      this.openSequenceMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.openHS;
      this.openSequenceMenuItem.Name = "openSequenceMenuItem";
      this.openSequenceMenuItem.ShortcutKeyDisplayString = null;
      this.openSequenceMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.AccessibleDescription = null;
      this.toolStripSeparator8.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      // 
      // exportSequenceToImageFilesMenuItem
      // 
      this.exportSequenceToImageFilesMenuItem.AccessibleDescription = null;
      this.exportSequenceToImageFilesMenuItem.AccessibleName = null;
      resources.ApplyResources(this.exportSequenceToImageFilesMenuItem, "exportSequenceToImageFilesMenuItem");
      this.exportSequenceToImageFilesMenuItem.BackgroundImage = null;
      this.exportSequenceToImageFilesMenuItem.Name = "exportSequenceToImageFilesMenuItem";
      this.exportSequenceToImageFilesMenuItem.ShortcutKeyDisplayString = null;
      this.exportSequenceToImageFilesMenuItem.Click += new System.EventHandler(this.saveSequenceToImageFilesToolStripMenuItem_Click);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.AccessibleDescription = null;
      this.toolStripSeparator7.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      // 
      // saveSequenceMenuItem
      // 
      this.saveSequenceMenuItem.AccessibleDescription = null;
      this.saveSequenceMenuItem.AccessibleName = null;
      resources.ApplyResources(this.saveSequenceMenuItem, "saveSequenceMenuItem");
      this.saveSequenceMenuItem.BackgroundImage = null;
      this.saveSequenceMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.saveHS;
      this.saveSequenceMenuItem.Name = "saveSequenceMenuItem";
      this.saveSequenceMenuItem.ShortcutKeyDisplayString = null;
      this.saveSequenceMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // saveSequenceAsMenuItem
      // 
      this.saveSequenceAsMenuItem.AccessibleDescription = null;
      this.saveSequenceAsMenuItem.AccessibleName = null;
      resources.ApplyResources(this.saveSequenceAsMenuItem, "saveSequenceAsMenuItem");
      this.saveSequenceAsMenuItem.BackgroundImage = null;
      this.saveSequenceAsMenuItem.Name = "saveSequenceAsMenuItem";
      this.saveSequenceAsMenuItem.ShortcutKeyDisplayString = null;
      this.saveSequenceAsMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.AccessibleDescription = null;
      this.toolStripSeparator5.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      // 
      // printMenuItem
      // 
      this.printMenuItem.AccessibleDescription = null;
      this.printMenuItem.AccessibleName = null;
      resources.ApplyResources(this.printMenuItem, "printMenuItem");
      this.printMenuItem.BackgroundImage = null;
      this.printMenuItem.Name = "printMenuItem";
      this.printMenuItem.ShortcutKeyDisplayString = null;
      this.printMenuItem.Click += new System.EventHandler(this.printMenuItem_Click);
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.AccessibleDescription = null;
      this.toolStripSeparator9.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      // 
      // exitMenuItem
      // 
      this.exitMenuItem.AccessibleDescription = null;
      this.exitMenuItem.AccessibleName = null;
      resources.ApplyResources(this.exitMenuItem, "exitMenuItem");
      this.exitMenuItem.BackgroundImage = null;
      this.exitMenuItem.Name = "exitMenuItem";
      this.exitMenuItem.ShortcutKeyDisplayString = null;
      this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // layoutsToolStripMenuItem
      // 
      this.layoutsToolStripMenuItem.AccessibleDescription = null;
      this.layoutsToolStripMenuItem.AccessibleName = null;
      resources.ApplyResources(this.layoutsToolStripMenuItem, "layoutsToolStripMenuItem");
      this.layoutsToolStripMenuItem.BackgroundImage = null;
      this.layoutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem,
            this.saveTofileToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveCurrentLayoutMenuItem,
            this.removeSavedLayoutMenuItem,
            this.toolStripSeparator4,
            this.userSavedLayoutsMenuItem,
            this.commonSavedLayoutsMenuItem});
      this.layoutsToolStripMenuItem.Name = "layoutsToolStripMenuItem";
      this.layoutsToolStripMenuItem.ShortcutKeyDisplayString = null;
      // 
      // copyMenuItem
      // 
      this.copyMenuItem.AccessibleDescription = null;
      this.copyMenuItem.AccessibleName = null;
      resources.ApplyResources(this.copyMenuItem, "copyMenuItem");
      this.copyMenuItem.BackgroundImage = null;
      this.copyMenuItem.Name = "copyMenuItem";
      this.copyMenuItem.ShortcutKeyDisplayString = null;
      this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
      // 
      // saveTofileToolStripMenuItem
      // 
      this.saveTofileToolStripMenuItem.AccessibleDescription = null;
      this.saveTofileToolStripMenuItem.AccessibleName = null;
      resources.ApplyResources(this.saveTofileToolStripMenuItem, "saveTofileToolStripMenuItem");
      this.saveTofileToolStripMenuItem.BackgroundImage = null;
      this.saveTofileToolStripMenuItem.Name = "saveTofileToolStripMenuItem";
      this.saveTofileToolStripMenuItem.ShortcutKeyDisplayString = null;
      this.saveTofileToolStripMenuItem.Click += new System.EventHandler(this.saveTofileToolStripMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.AccessibleDescription = null;
      this.toolStripSeparator3.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      // 
      // saveCurrentLayoutMenuItem
      // 
      this.saveCurrentLayoutMenuItem.AccessibleDescription = null;
      this.saveCurrentLayoutMenuItem.AccessibleName = null;
      resources.ApplyResources(this.saveCurrentLayoutMenuItem, "saveCurrentLayoutMenuItem");
      this.saveCurrentLayoutMenuItem.BackgroundImage = null;
      this.saveCurrentLayoutMenuItem.Name = "saveCurrentLayoutMenuItem";
      this.saveCurrentLayoutMenuItem.ShortcutKeyDisplayString = null;
      this.saveCurrentLayoutMenuItem.Click += new System.EventHandler(this.savedCurrentLayoutMenuItem_Click);
      // 
      // removeSavedLayoutMenuItem
      // 
      this.removeSavedLayoutMenuItem.AccessibleDescription = null;
      this.removeSavedLayoutMenuItem.AccessibleName = null;
      resources.ApplyResources(this.removeSavedLayoutMenuItem, "removeSavedLayoutMenuItem");
      this.removeSavedLayoutMenuItem.BackgroundImage = null;
      this.removeSavedLayoutMenuItem.Name = "removeSavedLayoutMenuItem";
      this.removeSavedLayoutMenuItem.ShortcutKeyDisplayString = null;
      this.removeSavedLayoutMenuItem.Click += new System.EventHandler(this.removeSavedLayoutMenuItem_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.AccessibleDescription = null;
      this.toolStripSeparator4.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      // 
      // userSavedLayoutsMenuItem
      // 
      this.userSavedLayoutsMenuItem.AccessibleDescription = null;
      this.userSavedLayoutsMenuItem.AccessibleName = null;
      resources.ApplyResources(this.userSavedLayoutsMenuItem, "userSavedLayoutsMenuItem");
      this.userSavedLayoutsMenuItem.BackgroundImage = null;
      this.userSavedLayoutsMenuItem.Name = "userSavedLayoutsMenuItem";
      this.userSavedLayoutsMenuItem.ShortcutKeyDisplayString = null;
      // 
      // commonSavedLayoutsMenuItem
      // 
      this.commonSavedLayoutsMenuItem.AccessibleDescription = null;
      this.commonSavedLayoutsMenuItem.AccessibleName = null;
      resources.ApplyResources(this.commonSavedLayoutsMenuItem, "commonSavedLayoutsMenuItem");
      this.commonSavedLayoutsMenuItem.BackgroundImage = null;
      this.commonSavedLayoutsMenuItem.Name = "commonSavedLayoutsMenuItem";
      this.commonSavedLayoutsMenuItem.ShortcutKeyDisplayString = null;
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.AccessibleDescription = null;
      this.helpToolStripMenuItem.AccessibleName = null;
      this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
      this.helpToolStripMenuItem.BackgroundImage = null;
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeLogMenuItem,
            this.readMeMenuItem,
            this.licenseMenuItem,
            this.toolStripSeparator6,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Image = global::SportsTacticsBoard.Properties.Resources.Help;
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.ShortcutKeyDisplayString = null;
      // 
      // changeLogMenuItem
      // 
      this.changeLogMenuItem.AccessibleDescription = null;
      this.changeLogMenuItem.AccessibleName = null;
      resources.ApplyResources(this.changeLogMenuItem, "changeLogMenuItem");
      this.changeLogMenuItem.BackgroundImage = null;
      this.changeLogMenuItem.Name = "changeLogMenuItem";
      this.changeLogMenuItem.ShortcutKeyDisplayString = null;
      this.changeLogMenuItem.Click += new System.EventHandler(this.changeLogMenuItem_Click);
      // 
      // readMeMenuItem
      // 
      this.readMeMenuItem.AccessibleDescription = null;
      this.readMeMenuItem.AccessibleName = null;
      resources.ApplyResources(this.readMeMenuItem, "readMeMenuItem");
      this.readMeMenuItem.BackgroundImage = null;
      this.readMeMenuItem.Name = "readMeMenuItem";
      this.readMeMenuItem.ShortcutKeyDisplayString = null;
      this.readMeMenuItem.Click += new System.EventHandler(this.readMeMenuItem_Click);
      // 
      // licenseMenuItem
      // 
      this.licenseMenuItem.AccessibleDescription = null;
      this.licenseMenuItem.AccessibleName = null;
      resources.ApplyResources(this.licenseMenuItem, "licenseMenuItem");
      this.licenseMenuItem.BackgroundImage = null;
      this.licenseMenuItem.Name = "licenseMenuItem";
      this.licenseMenuItem.ShortcutKeyDisplayString = null;
      this.licenseMenuItem.Click += new System.EventHandler(this.licenseMenuItem_Click);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.AccessibleDescription = null;
      this.toolStripSeparator6.AccessibleName = null;
      resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.AccessibleDescription = null;
      this.aboutToolStripMenuItem.AccessibleName = null;
      resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
      this.aboutToolStripMenuItem.BackgroundImage = null;
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.ShortcutKeyDisplayString = null;
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // playingSurfaceMenuItem
      // 
      this.playingSurfaceMenuItem.AccessibleDescription = null;
      this.playingSurfaceMenuItem.AccessibleName = null;
      resources.ApplyResources(this.playingSurfaceMenuItem, "playingSurfaceMenuItem");
      this.playingSurfaceMenuItem.BackgroundImage = null;
      this.playingSurfaceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePlayingSurfaceTypeMenuItem});
      this.playingSurfaceMenuItem.Name = "playingSurfaceMenuItem";
      this.playingSurfaceMenuItem.ShortcutKeyDisplayString = null;
      // 
      // changePlayingSurfaceTypeMenuItem
      // 
      this.changePlayingSurfaceTypeMenuItem.AccessibleDescription = null;
      this.changePlayingSurfaceTypeMenuItem.AccessibleName = null;
      resources.ApplyResources(this.changePlayingSurfaceTypeMenuItem, "changePlayingSurfaceTypeMenuItem");
      this.changePlayingSurfaceTypeMenuItem.BackgroundImage = null;
      this.changePlayingSurfaceTypeMenuItem.Name = "changePlayingSurfaceTypeMenuItem";
      this.changePlayingSurfaceTypeMenuItem.ShortcutKeyDisplayString = null;
      this.changePlayingSurfaceTypeMenuItem.Click += new System.EventHandler(this.newPlayingSurfaceTypeMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.AccessibleDescription = null;
      this.toolStripMenuItem1.AccessibleName = null;
      resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
      this.toolStripMenuItem1.BackgroundImage = null;
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.ShortcutKeyDisplayString = null;
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.AccessibleDescription = null;
      this.toolStripButton1.AccessibleName = null;
      resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
      this.toolStripButton1.BackgroundImage = null;
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Name = "toolStripButton1";
      // 
      // playSequenceTimer
      // 
      this.playSequenceTimer.Interval = 1000;
      this.playSequenceTimer.Tick += new System.EventHandler(this.playSequenceTimer_Tick);
      // 
      // fieldControl
      // 
      this.fieldControl.AccessibleDescription = null;
      this.fieldControl.AccessibleName = null;
      this.fieldControl.AllowInteraction = true;
      resources.ApplyResources(this.fieldControl, "fieldControl");
      this.fieldControl.BackgroundImage = null;
      this.fieldControl.Cursor = System.Windows.Forms.Cursors.Default;
      this.fieldControl.FieldType = null;
      this.fieldControl.Font = null;
      this.fieldControl.IsDirty = false;
      this.fieldControl.Name = "fieldControl";
      this.fieldControl.ShowMovementLines = true;
      // 
      // MainForm
      // 
      this.AccessibleDescription = null;
      this.AccessibleName = null;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = null;
      this.Controls.Add(this.fieldControl);
      this.Controls.Add(this.sequenceToolString);
      this.Controls.Add(this.mainMenuStrip);
      this.Font = null;
      this.KeyPreview = true;
      this.MainMenuStrip = this.mainMenuStrip;
      this.Name = "MainForm";
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.sequenceToolString.ResumeLayout(false);
      this.sequenceToolString.PerformLayout();
      this.mainMenuStrip.ResumeLayout(false);
      this.mainMenuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip sequenceToolString;
    private System.Windows.Forms.ToolStripButton recordNewPositionButton;
    private System.Windows.Forms.ToolStripButton previousLayoutInSequence;
    private System.Windows.Forms.ToolStripTextBox currentLayoutNumber;
    private System.Windows.Forms.ToolStripButton nextLayoutInSequence;
    private System.Windows.Forms.ToolStripButton recordOverCurrentPositionButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton removeCurrentPositionFromSequenceButton;
    private System.Windows.Forms.ToolStripButton revertCurrentLayoutToSavedButton;
    private System.Windows.Forms.MenuStrip mainMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem sequenceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openSequenceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSequenceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSequenceAsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem layoutsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newSequenceMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton showMovementButton;
    private FieldControl fieldControl;
    private System.Windows.Forms.ToolStripMenuItem saveCurrentLayoutMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem commonSavedLayoutsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeSavedLayoutMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripMenuItem playingSurfaceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exportSequenceToImageFilesMenuItem;
    private System.Windows.Forms.ToolStripMenuItem changePlayingSurfaceTypeMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveTofileToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem userSavedLayoutsMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem printMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    private System.Windows.Forms.ToolStripMenuItem licenseMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripMenuItem changeLogMenuItem;
    private System.Windows.Forms.ToolStripMenuItem readMeMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    private System.Windows.Forms.ToolStripButton goToFirstToolStripButton;
    private System.Windows.Forms.ToolStripButton playToolStripButton;
    private System.Windows.Forms.Timer playSequenceTimer;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
    private System.Windows.Forms.ToolStripButton goToLastToolStripButton;
  }
}

