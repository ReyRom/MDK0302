namespace PR6
{
    partial class EncryptForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.RenewKeyButton = new System.Windows.Forms.Button();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ResetButton = new System.Windows.Forms.Button();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // FileButton
            // 
            this.PathButton.Location = new System.Drawing.Point(266, 12);
            this.PathButton.Name = "FileButton";
            this.PathButton.Size = new System.Drawing.Size(69, 23);
            this.PathButton.TabIndex = 0;
            this.PathButton.Text = "Обзор";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(236, 72);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(99, 23);
            this.DecryptButton.TabIndex = 1;
            this.DecryptButton.Text = "Расшифровать";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // FileTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(12, 12);
            this.PathTextBox.Name = "FileTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(248, 23);
            this.PathTextBox.TabIndex = 2;
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(12, 101);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(142, 23);
            this.KeyTextBox.TabIndex = 3;
            // 
            // RenewKeyButton
            // 
            this.RenewKeyButton.Location = new System.Drawing.Point(195, 100);
            this.RenewKeyButton.Name = "RenewKeyButton";
            this.RenewKeyButton.Size = new System.Drawing.Size(140, 23);
            this.RenewKeyButton.TabIndex = 4;
            this.RenewKeyButton.Text = "Сгенерировать ключ";
            this.RenewKeyButton.UseVisualStyleBackColor = true;
            this.RenewKeyButton.Click += new System.EventHandler(this.RenewKeyButton_Click);
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(12, 72);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(101, 23);
            this.EncryptButton.TabIndex = 5;
            this.EncryptButton.Text = "Зашифровать";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(160, 100);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(29, 23);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "↺";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 131);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.RenewKeyButton);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.PathButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EncryptForm";
            this.Text = "Побитовое шифрование файлов";
            this.Load += new System.EventHandler(this.EncryptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PathButton;
        private Button DecryptButton;
        private TextBox PathTextBox;
        private TextBox KeyTextBox;
        private Button RenewKeyButton;
        private Button EncryptButton;
        private OpenFileDialog OpenFileDialog;
        private Button ResetButton;
        private FolderBrowserDialog FolderBrowserDialog;
    }
}