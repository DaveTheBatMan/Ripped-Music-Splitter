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
         this.txtbxTypesOfFiles = new System.Windows.Forms.TextBox();
         this.cbProcessFilesFLAC = new System.Windows.Forms.CheckBox();
         this.cbProcessFilesmp3 = new System.Windows.Forms.CheckBox();
         this.cbProcessFileswav = new System.Windows.Forms.CheckBox();
         this.lblOnlyProcessFilesOfType = new System.Windows.Forms.Label();
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
         this.rtbRippedMusicSplitterIntroText.Size = new System.Drawing.Size(698, 178);
         this.rtbRippedMusicSplitterIntroText.TabIndex = 1;
         this.rtbRippedMusicSplitterIntroText.Text = resources.GetString("rtbRippedMusicSplitterIntroText.Text");
         // 
         // lblBaseSourceDir
         // 
         this.lblBaseSourceDir.AutoSize = true;
         this.lblBaseSourceDir.Location = new System.Drawing.Point(19, 222);
         this.lblBaseSourceDir.Name = "lblBaseSourceDir";
         this.lblBaseSourceDir.Size = new System.Drawing.Size(113, 13);
         this.lblBaseSourceDir.TabIndex = 2;
         this.lblBaseSourceDir.Text = "Base Source Directory";
         // 
         // lblBaseTargetDir
         // 
         this.lblBaseTargetDir.AutoSize = true;
         this.lblBaseTargetDir.Location = new System.Drawing.Point(377, 222);
         this.lblBaseTargetDir.Name = "lblBaseTargetDir";
         this.lblBaseTargetDir.Size = new System.Drawing.Size(110, 13);
         this.lblBaseTargetDir.TabIndex = 3;
         this.lblBaseTargetDir.Text = "Base Target Directory";
         // 
         // txtbxBaseSourceDir
         // 
         this.txtbxBaseSourceDir.Location = new System.Drawing.Point(23, 244);
         this.txtbxBaseSourceDir.Name = "txtbxBaseSourceDir";
         this.txtbxBaseSourceDir.Size = new System.Drawing.Size(326, 20);
         this.txtbxBaseSourceDir.TabIndex = 4;
         this.txtbxBaseSourceDir.Text = "txtbxBaseSourceDir";
         this.txtbxBaseSourceDir.TextChanged += new System.EventHandler(this.txtbxBaseSourceDir_TextChanged);
         // 
         // txtbxBaseTargetDir
         // 
         this.txtbxBaseTargetDir.Location = new System.Drawing.Point(380, 243);
         this.txtbxBaseTargetDir.Name = "txtbxBaseTargetDir";
         this.txtbxBaseTargetDir.Size = new System.Drawing.Size(326, 20);
         this.txtbxBaseTargetDir.TabIndex = 5;
         this.txtbxBaseTargetDir.Text = "txtbxBaseTargetDir";
         this.txtbxBaseTargetDir.TextChanged += new System.EventHandler(this.txtbxBaseTargetDir_TextChanged);
         // 
         // btnGetBaseSourceDir
         // 
         this.btnGetBaseSourceDir.Location = new System.Drawing.Point(352, 244);
         this.btnGetBaseSourceDir.Name = "btnGetBaseSourceDir";
         this.btnGetBaseSourceDir.Size = new System.Drawing.Size(11, 20);
         this.btnGetBaseSourceDir.TabIndex = 6;
         this.btnGetBaseSourceDir.Text = "button1";
         this.btnGetBaseSourceDir.UseVisualStyleBackColor = true;
         this.btnGetBaseSourceDir.Click += new System.EventHandler(this.btnGetBaseSourceDir_Click);
         // 
         // btnGetBaseTargetDir
         // 
         this.btnGetBaseTargetDir.Location = new System.Drawing.Point(709, 243);
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
         this.btnAnalyzeBaseSourceDir.Location = new System.Drawing.Point(294, 282);
         this.btnAnalyzeBaseSourceDir.Name = "btnAnalyzeBaseSourceDir";
         this.btnAnalyzeBaseSourceDir.Size = new System.Drawing.Size(69, 24);
         this.btnAnalyzeBaseSourceDir.TabIndex = 8;
         this.btnAnalyzeBaseSourceDir.Text = "Analyze";
         this.btnAnalyzeBaseSourceDir.UseVisualStyleBackColor = true;
         this.btnAnalyzeBaseSourceDir.Click += new System.EventHandler(this.btnAnalyzeBaseSourceDir_Click);
         // 
         // rtbAnalysisBaseSourceDir
         // 
         this.rtbAnalysisBaseSourceDir.Location = new System.Drawing.Point(25, 325);
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
         this.rbCopyOrMoveCopy.Location = new System.Drawing.Point(23, 277);
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
         this.rbCopyOrMoveMove.Location = new System.Drawing.Point(23, 293);
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
         this.cbVerifyFiles.Location = new System.Drawing.Point(380, 277);
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
         this.cbForceCopyMoveSameDrive.Location = new System.Drawing.Point(380, 293);
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
         this.btnGo.Location = new System.Drawing.Point(651, 282);
         this.btnGo.Name = "btnGo";
         this.btnGo.Size = new System.Drawing.Size(69, 24);
         this.btnGo.TabIndex = 14;
         this.btnGo.Text = "Go!";
         this.btnGo.UseVisualStyleBackColor = true;
         this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
         // 
         // rtbMessagesToUser
         // 
         this.rtbMessagesToUser.Location = new System.Drawing.Point(23, 448);
         this.rtbMessagesToUser.Name = "rtbMessagesToUser";
         this.rtbMessagesToUser.Size = new System.Drawing.Size(698, 46);
         this.rtbMessagesToUser.TabIndex = 15;
         this.rtbMessagesToUser.Text = "";
         this.rtbMessagesToUser.Visible = false;
         // 
         // rtbPreviewBaseTargetDir
         // 
         this.rtbPreviewBaseTargetDir.Location = new System.Drawing.Point(383, 325);
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
         this.cbLogOperationsToFile.Location = new System.Drawing.Point(133, 293);
         this.cbLogOperationsToFile.Name = "cbLogOperationsToFile";
         this.cbLogOperationsToFile.Size = new System.Drawing.Size(130, 17);
         this.cbLogOperationsToFile.TabIndex = 17;
         this.cbLogOperationsToFile.Text = "Log operations to file?";
         this.cbLogOperationsToFile.UseVisualStyleBackColor = true;
         // 
         // txtbxTypesOfFiles
         // 
         this.txtbxTypesOfFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.txtbxTypesOfFiles.Enabled = false;
         this.txtbxTypesOfFiles.Location = new System.Drawing.Point(23, 410);
         this.txtbxTypesOfFiles.Multiline = true;
         this.txtbxTypesOfFiles.Name = "txtbxTypesOfFiles";
         this.txtbxTypesOfFiles.Size = new System.Drawing.Size(340, 30);
         this.txtbxTypesOfFiles.TabIndex = 26;
         // 
         // cbProcessFilesFLAC
         // 
         this.cbProcessFilesFLAC.AutoSize = true;
         this.cbProcessFilesFLAC.Checked = true;
         this.cbProcessFilesFLAC.CheckState = System.Windows.Forms.CheckState.Checked;
         this.cbProcessFilesFLAC.Location = new System.Drawing.Point(181, 417);
         this.cbProcessFilesFLAC.Name = "cbProcessFilesFLAC";
         this.cbProcessFilesFLAC.Size = new System.Drawing.Size(52, 17);
         this.cbProcessFilesFLAC.TabIndex = 18;
         this.cbProcessFilesFLAC.Text = "FLAC";
         this.cbProcessFilesFLAC.UseVisualStyleBackColor = true;
         this.cbProcessFilesFLAC.CheckedChanged += new System.EventHandler(this.cbProcessFilesFLAC_CheckedChanged);
         // 
         // cbProcessFilesmp3
         // 
         this.cbProcessFilesmp3.AutoSize = true;
         this.cbProcessFilesmp3.Checked = true;
         this.cbProcessFilesmp3.CheckState = System.Windows.Forms.CheckState.Checked;
         this.cbProcessFilesmp3.Location = new System.Drawing.Point(253, 417);
         this.cbProcessFilesmp3.Name = "cbProcessFilesmp3";
         this.cbProcessFilesmp3.Size = new System.Drawing.Size(46, 17);
         this.cbProcessFilesmp3.TabIndex = 19;
         this.cbProcessFilesmp3.Text = "mp3";
         this.cbProcessFilesmp3.UseVisualStyleBackColor = true;
         this.cbProcessFilesmp3.CheckedChanged += new System.EventHandler(this.cbProcessFilesmp3_CheckedChanged);
         // 
         // cbProcessFileswav
         // 
         this.cbProcessFileswav.AutoSize = true;
         this.cbProcessFileswav.Checked = true;
         this.cbProcessFileswav.CheckState = System.Windows.Forms.CheckState.Checked;
         this.cbProcessFileswav.Location = new System.Drawing.Point(316, 417);
         this.cbProcessFileswav.Name = "cbProcessFileswav";
         this.cbProcessFileswav.Size = new System.Drawing.Size(46, 17);
         this.cbProcessFileswav.TabIndex = 20;
         this.cbProcessFileswav.Text = "wav";
         this.cbProcessFileswav.UseVisualStyleBackColor = true;
         this.cbProcessFileswav.CheckedChanged += new System.EventHandler(this.cbProcessFileswav_CheckedChanged);
         // 
         // lblOnlyProcessFilesOfType
         // 
         this.lblOnlyProcessFilesOfType.AutoSize = true;
         this.lblOnlyProcessFilesOfType.Location = new System.Drawing.Point(30, 419);
         this.lblOnlyProcessFilesOfType.Name = "lblOnlyProcessFilesOfType";
         this.lblOnlyProcessFilesOfType.Size = new System.Drawing.Size(127, 13);
         this.lblOnlyProcessFilesOfType.TabIndex = 21;
         this.lblOnlyProcessFilesOfType.Text = "Only process files of type:";
         // 
         // frmRippedMusicSplitter
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(743, 502);
         this.Controls.Add(this.lblOnlyProcessFilesOfType);
         this.Controls.Add(this.cbProcessFileswav);
         this.Controls.Add(this.cbProcessFilesmp3);
         this.Controls.Add(this.cbProcessFilesFLAC);
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
         this.Controls.Add(this.txtbxTypesOfFiles);
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
      private System.Windows.Forms.TextBox txtbxTypesOfFiles;
      private System.Windows.Forms.CheckBox cbProcessFilesFLAC;
      private System.Windows.Forms.CheckBox cbProcessFilesmp3;
      private System.Windows.Forms.CheckBox cbProcessFileswav;
      private System.Windows.Forms.Label lblOnlyProcessFilesOfType;
   }
}

