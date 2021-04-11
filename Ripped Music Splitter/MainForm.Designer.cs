namespace Ripped_Music_Splitter
{
    partial class frmRippedMusicSplitter
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRippedMusicSplitter));
         this.lblRippedMusicSplitterTitle = new System.Windows.Forms.Label();
         this.rtbRippedMusicSplitterIntroText = new System.Windows.Forms.RichTextBox();
         this.lblBaseSourceDir = new System.Windows.Forms.Label();
         this.lblBaseTargetDir = new System.Windows.Forms.Label();
         this.txtbxBaseSourceDir = new System.Windows.Forms.TextBox();
         this.txtbxBaseTargetDir = new System.Windows.Forms.TextBox();
         this.btnGetBaseSourceDir = new System.Windows.Forms.Button();
         this.btnGetBaseTargetDir = new System.Windows.Forms.Button();
         this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
         this.btnAnalyzeBaseSourceDir = new System.Windows.Forms.Button();
         this.rtbAnalysisBaseSourceDir = new System.Windows.Forms.RichTextBox();
         this.rbCopyOrMoveCopy = new System.Windows.Forms.RadioButton();
         this.rbCopyOrMoveMove = new System.Windows.Forms.RadioButton();
         this.cbVerifyFiles = new System.Windows.Forms.CheckBox();
         this.cbForceCopyMoveSameDrive = new System.Windows.Forms.CheckBox();
         this.btnGo = new System.Windows.Forms.Button();
         this.rtbMessagesToUser = new System.Windows.Forms.RichTextBox();
         this.rtbPreviewBaseTargetDir = new System.Windows.Forms.RichTextBox();
         this.cbLogOperationsToFile = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // lblRippedMusicSplitterTitle
         // 
         this.lblRippedMusicSplitterTitle.AutoSize = true;
         this.lblRippedMusicSplitterTitle.Location = new System.Drawing.Point(22, 11);
         this.lblRippedMusicSplitterTitle.Name = "lblRippedMusicSplitterTitle";
         this.lblRippedMusicSplitterTitle.Size = new System.Drawing.Size(140, 13);
         this.lblRippedMusicSplitterTitle.TabIndex = 0;
         this.lblRippedMusicSplitterTitle.Text = "Ripped Music Splitter, v1.0β";
         // 
         // rtbRippedMusicSplitterIntroText
         // 
         this.rtbRippedMusicSplitterIntroText.Location = new System.Drawing.Point(22, 34);
         this.rtbRippedMusicSplitterIntroText.Name = "rtbRippedMusicSplitterIntroText";
         this.rtbRippedMusicSplitterIntroText.Size = new System.Drawing.Size(698, 157);
         this.rtbRippedMusicSplitterIntroText.TabIndex = 1;
         this.rtbRippedMusicSplitterIntroText.Text = resources.GetString("rtbRippedMusicSplitterIntroText.Text");
         // 
         // lblBaseSourceDir
         // 
         this.lblBaseSourceDir.AutoSize = true;
         this.lblBaseSourceDir.Location = new System.Drawing.Point(19, 212);
         this.lblBaseSourceDir.Name = "lblBaseSourceDir";
         this.lblBaseSourceDir.Size = new System.Drawing.Size(113, 13);
         this.lblBaseSourceDir.TabIndex = 2;
         this.lblBaseSourceDir.Text = "Base Source Directory";
         // 
         // lblBaseTargetDir
         // 
         this.lblBaseTargetDir.AutoSize = true;
         this.lblBaseTargetDir.Location = new System.Drawing.Point(377, 212);
         this.lblBaseTargetDir.Name = "lblBaseTargetDir";
         this.lblBaseTargetDir.Size = new System.Drawing.Size(110, 13);
         this.lblBaseTargetDir.TabIndex = 3;
         this.lblBaseTargetDir.Text = "Base Target Directory";
         // 
         // txtbxBaseSourceDir
         // 
         this.txtbxBaseSourceDir.Location = new System.Drawing.Point(23, 234);
         this.txtbxBaseSourceDir.Name = "txtbxBaseSourceDir";
         this.txtbxBaseSourceDir.Size = new System.Drawing.Size(326, 20);
         this.txtbxBaseSourceDir.TabIndex = 4;
         // 
         // txtbxBaseTargetDir
         // 
         this.txtbxBaseTargetDir.Location = new System.Drawing.Point(380, 233);
         this.txtbxBaseTargetDir.Name = "txtbxBaseTargetDir";
         this.txtbxBaseTargetDir.Size = new System.Drawing.Size(326, 20);
         this.txtbxBaseTargetDir.TabIndex = 5;
         // 
         // btnGetBaseSourceDir
         // 
         this.btnGetBaseSourceDir.Location = new System.Drawing.Point(352, 234);
         this.btnGetBaseSourceDir.Name = "btnGetBaseSourceDir";
         this.btnGetBaseSourceDir.Size = new System.Drawing.Size(11, 20);
         this.btnGetBaseSourceDir.TabIndex = 6;
         this.btnGetBaseSourceDir.Text = "button1";
         this.btnGetBaseSourceDir.UseVisualStyleBackColor = true;
         this.btnGetBaseSourceDir.Click += new System.EventHandler(this.btnGetBaseSourceDir_Click);
         // 
         // btnGetBaseTargetDir
         // 
         this.btnGetBaseTargetDir.Location = new System.Drawing.Point(709, 233);
         this.btnGetBaseTargetDir.Name = "btnGetBaseTargetDir";
         this.btnGetBaseTargetDir.Size = new System.Drawing.Size(11, 20);
         this.btnGetBaseTargetDir.TabIndex = 7;
         this.btnGetBaseTargetDir.Text = "button1";
         this.btnGetBaseTargetDir.UseVisualStyleBackColor = true;
         this.btnGetBaseTargetDir.Click += new System.EventHandler(this.btnGetBaseTargetDir_Click);
         // 
         // btnAnalyzeBaseSourceDir
         // 
         this.btnAnalyzeBaseSourceDir.Enabled = false;
         this.btnAnalyzeBaseSourceDir.Location = new System.Drawing.Point(294, 272);
         this.btnAnalyzeBaseSourceDir.Name = "btnAnalyzeBaseSourceDir";
         this.btnAnalyzeBaseSourceDir.Size = new System.Drawing.Size(69, 24);
         this.btnAnalyzeBaseSourceDir.TabIndex = 8;
         this.btnAnalyzeBaseSourceDir.Text = "Analyze";
         this.btnAnalyzeBaseSourceDir.UseVisualStyleBackColor = true;
         this.btnAnalyzeBaseSourceDir.Click += new System.EventHandler(this.btnAnalyzeBaseSourceDir_Click);
         // 
         // rtbAnalysisBaseSourceDir
         // 
         this.rtbAnalysisBaseSourceDir.Location = new System.Drawing.Point(25, 315);
         this.rtbAnalysisBaseSourceDir.Name = "rtbAnalysisBaseSourceDir";
         this.rtbAnalysisBaseSourceDir.Size = new System.Drawing.Size(338, 77);
         this.rtbAnalysisBaseSourceDir.TabIndex = 9;
         this.rtbAnalysisBaseSourceDir.Text = "";
         this.rtbAnalysisBaseSourceDir.WordWrap = false;
         // 
         // rbCopyOrMoveCopy
         // 
         this.rbCopyOrMoveCopy.AutoSize = true;
         this.rbCopyOrMoveCopy.Enabled = false;
         this.rbCopyOrMoveCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.rbCopyOrMoveCopy.Location = new System.Drawing.Point(23, 267);
         this.rbCopyOrMoveCopy.Name = "rbCopyOrMoveCopy";
         this.rbCopyOrMoveCopy.Size = new System.Drawing.Size(70, 17);
         this.rbCopyOrMoveCopy.TabIndex = 10;
         this.rbCopyOrMoveCopy.Text = "Copy files";
         this.rbCopyOrMoveCopy.UseVisualStyleBackColor = true;
         this.rbCopyOrMoveCopy.CheckedChanged += new System.EventHandler(this.rbCopyOrMoveCopy_CheckedChanged);
         // 
         // rbCopyOrMoveMove
         // 
         this.rbCopyOrMoveMove.AutoSize = true;
         this.rbCopyOrMoveMove.Location = new System.Drawing.Point(23, 283);
         this.rbCopyOrMoveMove.Name = "rbCopyOrMoveMove";
         this.rbCopyOrMoveMove.Size = new System.Drawing.Size(73, 17);
         this.rbCopyOrMoveMove.TabIndex = 11;
         this.rbCopyOrMoveMove.Text = "Move files";
         this.rbCopyOrMoveMove.UseVisualStyleBackColor = true;
         this.rbCopyOrMoveMove.CheckedChanged += new System.EventHandler(this.rbCopyOrMoveMove_CheckedChanged);
         // 
         // cbVerifyFiles
         // 
         this.cbVerifyFiles.AutoSize = true;
         this.cbVerifyFiles.Enabled = false;
         this.cbVerifyFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.cbVerifyFiles.Location = new System.Drawing.Point(380, 267);
         this.cbVerifyFiles.Name = "cbVerifyFiles";
         this.cbVerifyFiles.Size = new System.Drawing.Size(162, 17);
         this.cbVerifyFiles.TabIndex = 12;
         this.cbVerifyFiles.Text = "Verify files after Copy/Move?";
         this.cbVerifyFiles.UseVisualStyleBackColor = true;
         // 
         // cbForceCopyMoveSameDrive
         // 
         this.cbForceCopyMoveSameDrive.AutoSize = true;
         this.cbForceCopyMoveSameDrive.Enabled = false;
         this.cbForceCopyMoveSameDrive.Location = new System.Drawing.Point(380, 283);
         this.cbForceCopyMoveSameDrive.Name = "cbForceCopyMoveSameDrive";
         this.cbForceCopyMoveSameDrive.Size = new System.Drawing.Size(217, 17);
         this.cbForceCopyMoveSameDrive.TabIndex = 13;
         this.cbForceCopyMoveSameDrive.Text = "Target must be on same drive as Source";
         this.cbForceCopyMoveSameDrive.UseVisualStyleBackColor = true;
         this.cbForceCopyMoveSameDrive.CheckedChanged += new System.EventHandler(this.cbForceCopyMoveSameDrive_CheckedChanged);
         // 
         // btnGo
         // 
         this.btnGo.Enabled = false;
         this.btnGo.Location = new System.Drawing.Point(651, 272);
         this.btnGo.Name = "btnGo";
         this.btnGo.Size = new System.Drawing.Size(69, 24);
         this.btnGo.TabIndex = 14;
         this.btnGo.Text = "Go!";
         this.btnGo.UseVisualStyleBackColor = true;
         this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
         // 
         // rtbMessagesToUser
         // 
         this.rtbMessagesToUser.Location = new System.Drawing.Point(23, 418);
         this.rtbMessagesToUser.Name = "rtbMessagesToUser";
         this.rtbMessagesToUser.Size = new System.Drawing.Size(698, 46);
         this.rtbMessagesToUser.TabIndex = 15;
         this.rtbMessagesToUser.Text = "";
         this.rtbMessagesToUser.Visible = false;
         // 
         // rtbPreviewBaseTargetDir
         // 
         this.rtbPreviewBaseTargetDir.Location = new System.Drawing.Point(383, 315);
         this.rtbPreviewBaseTargetDir.Name = "rtbPreviewBaseTargetDir";
         this.rtbPreviewBaseTargetDir.Size = new System.Drawing.Size(338, 77);
         this.rtbPreviewBaseTargetDir.TabIndex = 16;
         this.rtbPreviewBaseTargetDir.Text = "";
         this.rtbPreviewBaseTargetDir.WordWrap = false;
         // 
         // cbLogOperationsToFile
         // 
         this.cbLogOperationsToFile.AutoSize = true;
         this.cbLogOperationsToFile.Checked = true;
         this.cbLogOperationsToFile.CheckState = System.Windows.Forms.CheckState.Checked;
         this.cbLogOperationsToFile.Location = new System.Drawing.Point(133, 283);
         this.cbLogOperationsToFile.Name = "cbLogOperationsToFile";
         this.cbLogOperationsToFile.Size = new System.Drawing.Size(130, 17);
         this.cbLogOperationsToFile.TabIndex = 17;
         this.cbLogOperationsToFile.Text = "Log operations to file?";
         this.cbLogOperationsToFile.UseVisualStyleBackColor = true;
         // 
         // frmRippedMusicSplitter
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(743, 488);
         this.Controls.Add(this.cbLogOperationsToFile);
         this.Controls.Add(this.rtbPreviewBaseTargetDir);
         this.Controls.Add(this.rtbMessagesToUser);
         this.Controls.Add(this.btnGo);
         this.Controls.Add(this.cbForceCopyMoveSameDrive);
         this.Controls.Add(this.cbVerifyFiles);
         this.Controls.Add(this.rbCopyOrMoveMove);
         this.Controls.Add(this.rbCopyOrMoveCopy);
         this.Controls.Add(this.rtbAnalysisBaseSourceDir);
         this.Controls.Add(this.btnAnalyzeBaseSourceDir);
         this.Controls.Add(this.btnGetBaseTargetDir);
         this.Controls.Add(this.btnGetBaseSourceDir);
         this.Controls.Add(this.txtbxBaseTargetDir);
         this.Controls.Add(this.txtbxBaseSourceDir);
         this.Controls.Add(this.lblBaseTargetDir);
         this.Controls.Add(this.lblBaseSourceDir);
         this.Controls.Add(this.rtbRippedMusicSplitterIntroText);
         this.Controls.Add(this.lblRippedMusicSplitterTitle);
         this.Name = "frmRippedMusicSplitter";
         this.Text = "Ripped Music Splitter";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRippedMusicSplitterTitle;
        private System.Windows.Forms.RichTextBox rtbRippedMusicSplitterIntroText;
        private System.Windows.Forms.Label lblBaseSourceDir;
        private System.Windows.Forms.Label lblBaseTargetDir;
        private System.Windows.Forms.TextBox txtbxBaseSourceDir;
        private System.Windows.Forms.TextBox txtbxBaseTargetDir;
        private System.Windows.Forms.Button btnGetBaseSourceDir;
        private System.Windows.Forms.Button btnGetBaseTargetDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnAnalyzeBaseSourceDir;
        private System.Windows.Forms.RichTextBox rtbAnalysisBaseSourceDir;
      private System.Windows.Forms.RadioButton rbCopyOrMoveCopy;
      private System.Windows.Forms.RadioButton rbCopyOrMoveMove;
      private System.Windows.Forms.CheckBox cbVerifyFiles;
      private System.Windows.Forms.CheckBox cbForceCopyMoveSameDrive;
      private System.Windows.Forms.Button btnGo;
      private System.Windows.Forms.RichTextBox rtbMessagesToUser;
      private System.Windows.Forms.RichTextBox rtbPreviewBaseTargetDir;
      private System.Windows.Forms.CheckBox cbLogOperationsToFile;
   }
}

