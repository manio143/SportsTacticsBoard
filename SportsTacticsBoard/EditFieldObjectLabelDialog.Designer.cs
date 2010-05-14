namespace SportsTacticsBoard
{
  partial class EditFieldObjectLabelDialog
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
      System.Windows.Forms.Label label1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFieldObjectLabelDialog));
      System.Windows.Forms.Button okButton;
      System.Windows.Forms.Button cancelButton;
      this.label2 = new System.Windows.Forms.Label();
      this.customLabelTextBox = new System.Windows.Forms.TextBox();
      this.fieldObjectNameTextBox = new System.Windows.Forms.TextBox();
      this.revertToDefaultButton = new System.Windows.Forms.Button();
      label1 = new System.Windows.Forms.Label();
      okButton = new System.Windows.Forms.Button();
      cancelButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      resources.ApplyResources(label1, "label1");
      label1.Name = "label1";
      // 
      // okButton
      // 
      resources.ApplyResources(okButton, "okButton");
      okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      okButton.Name = "okButton";
      okButton.UseVisualStyleBackColor = true;
      okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      resources.ApplyResources(cancelButton, "cancelButton");
      cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      cancelButton.Name = "cancelButton";
      cancelButton.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // customLabelTextBox
      // 
      resources.ApplyResources(this.customLabelTextBox, "customLabelTextBox");
      this.customLabelTextBox.Name = "customLabelTextBox";
      // 
      // fieldObjectNameTextBox
      // 
      resources.ApplyResources(this.fieldObjectNameTextBox, "fieldObjectNameTextBox");
      this.fieldObjectNameTextBox.Name = "fieldObjectNameTextBox";
      this.fieldObjectNameTextBox.ReadOnly = true;
      this.fieldObjectNameTextBox.TabStop = false;
      // 
      // revertToDefaultButton
      // 
      resources.ApplyResources(this.revertToDefaultButton, "revertToDefaultButton");
      this.revertToDefaultButton.DialogResult = System.Windows.Forms.DialogResult.No;
      this.revertToDefaultButton.Name = "revertToDefaultButton";
      this.revertToDefaultButton.UseVisualStyleBackColor = true;
      // 
      // EditFieldObjectLabelDialog
      // 
      this.AcceptButton = okButton;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = cancelButton;
      this.Controls.Add(this.revertToDefaultButton);
      this.Controls.Add(this.fieldObjectNameTextBox);
      this.Controls.Add(this.customLabelTextBox);
      this.Controls.Add(cancelButton);
      this.Controls.Add(okButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EditFieldObjectLabelDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox customLabelTextBox;
    private System.Windows.Forms.TextBox fieldObjectNameTextBox;
    private System.Windows.Forms.Button revertToDefaultButton;
  }
}