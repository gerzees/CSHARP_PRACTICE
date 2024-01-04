namespace AsyncFileIOWinForm
{
    partial class MainForm
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
            lblSource = new Label();
            lblTarget = new Label();
            txtSource = new TextBox();
            txtTarget = new TextBox();
            btnFindSource = new Button();
            btnFindTarget = new Button();
            btnAsyncCopy = new Button();
            btnSyncCopy = new Button();
            btnCancel = new Button();
            pbCopy = new ProgressBar();
            SuspendLayout();
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(12, 43);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(55, 20);
            lblSource.TabIndex = 0;
            lblSource.Text = "Source";
            // 
            // lblTarget
            // 
            lblTarget.AutoSize = true;
            lblTarget.Location = new Point(15, 88);
            lblTarget.Name = "lblTarget";
            lblTarget.Size = new Size(52, 20);
            lblTarget.TabIndex = 1;
            lblTarget.Text = "Target";
            // 
            // txtSource
            // 
            txtSource.Location = new Point(73, 40);
            txtSource.Name = "txtSource";
            txtSource.Size = new Size(604, 27);
            txtSource.TabIndex = 2;
            // 
            // txtTarget
            // 
            txtTarget.Location = new Point(73, 85);
            txtTarget.Name = "txtTarget";
            txtTarget.Size = new Size(604, 27);
            txtTarget.TabIndex = 3;
            // 
            // btnFindSource
            // 
            btnFindSource.Location = new Point(683, 39);
            btnFindSource.Name = "btnFindSource";
            btnFindSource.Size = new Size(94, 29);
            btnFindSource.TabIndex = 4;
            btnFindSource.Text = "...";
            btnFindSource.UseVisualStyleBackColor = true;
            btnFindSource.Click += this.btnFindSource_Click;
            // 
            // btnFindTarget
            // 
            btnFindTarget.Location = new Point(683, 84);
            btnFindTarget.Name = "btnFindTarget";
            btnFindTarget.Size = new Size(94, 29);
            btnFindTarget.TabIndex = 5;
            btnFindTarget.Text = "...";
            btnFindTarget.UseVisualStyleBackColor = true;
            btnFindTarget.Click += this.btnFindTarget_Click;
            // 
            // btnAsyncCopy
            // 
            btnAsyncCopy.Location = new Point(15, 139);
            btnAsyncCopy.Name = "btnAsyncCopy";
            btnAsyncCopy.Size = new Size(230, 29);
            btnAsyncCopy.TabIndex = 6;
            btnAsyncCopy.Text = "Async Copy";
            btnAsyncCopy.UseVisualStyleBackColor = true;
            btnAsyncCopy.Click += this.btnAsyncCopy_Click;
            // 
            // btnSyncCopy
            // 
            btnSyncCopy.Location = new Point(281, 139);
            btnSyncCopy.Name = "btnSyncCopy";
            btnSyncCopy.Size = new Size(230, 29);
            btnSyncCopy.TabIndex = 7;
            btnSyncCopy.Text = "Sync Copy";
            btnSyncCopy.UseVisualStyleBackColor = true;
            btnSyncCopy.Click += this.btnSyncCopy_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(547, 139);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(230, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += this.btnCancel_Click;
            // 
            // pbCopy
            // 
            pbCopy.Location = new Point(12, 194);
            pbCopy.Name = "pbCopy";
            pbCopy.Size = new Size(765, 29);
            pbCopy.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbCopy);
            Controls.Add(btnCancel);
            Controls.Add(btnSyncCopy);
            Controls.Add(btnAsyncCopy);
            Controls.Add(btnFindTarget);
            Controls.Add(btnFindSource);
            Controls.Add(txtTarget);
            Controls.Add(txtSource);
            Controls.Add(lblTarget);
            Controls.Add(lblSource);
            Name = "MainForm";
            Text = "Async File Copy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSource;
        private Label lblTarget;
        private TextBox txtSource;
        private TextBox txtTarget;
        private Button btnFindSource;
        private Button btnFindTarget;
        private Button btnAsyncCopy;
        private Button btnSyncCopy;
        private Button btnCancel;
        private ProgressBar pbCopy;
    }
}
