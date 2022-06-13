using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace Ripped_Music_Splitter {

   public partial class frmRippedMusicSplitter : Form {
      // private static string strBaseSourceDir = @"D:\zSplitterTestSource";
      private static string strBaseSourceDir = @"C:\zSource";
      private static string strBaseTargetDir = @"D:\zSplitterTestTarget";
      private static List<MusicGroupAndAlbums> lMusicGroupAndAlbums;
      private static string strLogFilename = "Ripped Music Splitter [Log].txt";
      private bool bProcessFilesFLAC = true;
      private bool bProcessFilesmp3 = true;
      private bool bProcessFileswav = true;

      private void vValidateSourceAndTargetDirsAndProcessFilesCBs() {
         // Assume that "Go" is disabled until all tests verify that it should be enabled
         // (at the bottom of this method).
         btnGo.Enabled = false;

         bool btxtbxBaseSourceDirExists = Directory.Exists(txtbxBaseSourceDir.Text);
         if (btxtbxBaseSourceDirExists == true) {
            btnAnalyzeBaseSourceDir.Enabled = true;
            txtbxBaseSourceDir.BackColor = Color.White;
            txtbxBaseSourceDir.ForeColor = Color.Blue;
            txtbxBaseSourceDir.Font = new Font(txtbxBaseSourceDir.Font, FontStyle.Regular);
            txtbxBaseSourceDir.ReadOnly = false;
         }
         else {
            btnAnalyzeBaseSourceDir.Enabled = false;
            txtbxBaseSourceDir.BackColor = Color.White;
            txtbxBaseSourceDir.ForeColor = Color.Red;
            txtbxBaseSourceDir.Font = new Font(txtbxBaseSourceDir.Font, FontStyle.Bold ^ FontStyle.Italic);
            txtbxBaseSourceDir.ReadOnly = true;
         }

         bool btxtbxBaseTargetDirExists = Directory.Exists(txtbxBaseTargetDir.Text);
         if (btxtbxBaseTargetDirExists == true) {
            txtbxBaseTargetDir.BackColor = Color.White;
            txtbxBaseTargetDir.ForeColor = Color.Blue;
            txtbxBaseTargetDir.Font = new Font(txtbxBaseTargetDir.Font, FontStyle.Regular);
            txtbxBaseTargetDir.ReadOnly = false;
         }
         else {
            // The background color was originally gray, but tthat's very difficult to read.
            // txtbxBaseTargetDir.BackColor = Color.Gray;
            txtbxBaseTargetDir.BackColor = Color.White;
            txtbxBaseTargetDir.ForeColor = Color.Red;
            txtbxBaseTargetDir.Font = new Font(txtbxBaseTargetDir.Font, FontStyle.Bold ^ FontStyle.Italic);
            txtbxBaseTargetDir.ReadOnly = true;
         }

         // Move will only be allowed when all three of the files types have been selected,
         // so force 'Copy' if any of the three have been unchecked.
         if (!bProcessFilesFLAC || !bProcessFilesmp3 || !bProcessFileswav) {
            rbCopyOrMoveMove.Checked = false;
            rbCopyOrMoveCopy.Checked = true;
         }

         bool bSourceTargetDrivesAreSame = txtbxBaseSourceDir.Text.Substring(0, 1) == txtbxBaseTargetDir.Text.Substring(0, 1);

         // The btnGo button needs to be Enabled (or Disabled); Enable only when:
         // * Both SourceDir and TargetDir are valid *and*
         // * The SourceDir and TargetDir are both on the same drive *and*
         // * At least one of the process-File-type checkboxes is selected *and*
         // * "Analyze" has been done (as determined that rtbAnalysisBaseSourceDir.Text.Length > 0)
         btnGo.Enabled = (btxtbxBaseSourceDirExists && btxtbxBaseTargetDirExists) &&
                         bSourceTargetDrivesAreSame &&
                         (bProcessFilesFLAC || bProcessFilesmp3 || bProcessFileswav) &&
                         (rtbAnalysisBaseSourceDir.Text.Length > 0);
      }

      static bool bReadSetting(string strKey, ref string strValue) {
         // https://docs.microsoft.com/en-us/dotnet/api/system.configuration.configurationmanager.appsettings?view=net-5.0
         bool bResult = false;
         string strResult = "";
         try {
            strResult = ConfigurationManager.AppSettings.Get(strKey);
            if (strResult == null) {
               strResult = "No value found";
            }
            else {
               strValue = strResult;
               bResult = true;
            }
         }
         catch (ConfigurationErrorsException) {
            // Console.WriteLine("Error reading app settings");
         }
         return bResult;
      }

      static void vAddUpdateAppSettings(string strKey, string strValue) {
         // https://docs.microsoft.com/en-us/dotnet/api/system.configuration.configurationmanager.appsettings?view=net-5.0
         try {
            Configuration cConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection kvcAllSettings = cConfigFile.AppSettings.Settings;
            if (kvcAllSettings[strKey] == null) {
               kvcAllSettings.Add(strKey, strValue);
            }
            else {
               kvcAllSettings[strKey].Value = strValue;
            }
            cConfigFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(cConfigFile.AppSettings.SectionInformation.Name);
         }
         catch (ConfigurationErrorsException) {
            //Console.WriteLine("Error writing app nvcAllSettings");
         }
      }

      public frmRippedMusicSplitter() {
         // Originally, the values of both txtbxBaseSourceDir and txtbxBaseTargetDir were blank;
         // but, since the addition of the TextChanged event, their contents are validated
         // upon the inital .Text value set calls (when the previous settins are retrieved).
         // Therefore, set their initial values (in the designer) to SOMETHING, even if
         // they're not valid directories -- just anything that's non-null.

         InitializeComponent();

         txtbxBaseSourceDir.Text = strBaseSourceDir;
         txtbxBaseTargetDir.Text = strBaseTargetDir;

         string strResult = "";
         bool bResult;
         // Load the current value of the key "txtbxBaseSourceDir".
         bResult = bReadSetting("txtbxBaseSourceDir", ref strResult);
         // If it was found okay, then store it in the control.
         if (bResult == true) {
            txtbxBaseSourceDir.Text = strResult;
         }
         // Ooops, the key wasn't found; store it for later use.
         else {
            vAddUpdateAppSettings("txtbxBaseSourceDir", strBaseSourceDir);
         }

         // Load the current value of the key "txtbxBaseTargetDir".
         bResult = bReadSetting("txtbxBaseTargetDir", ref strResult);
         // If it was found okay, then store it in the control.
         if (bResult == true) {
            txtbxBaseTargetDir.Text = strResult;
         }
         // Ooops, the key wasn't found; store it for later use.
         else {
            vAddUpdateAppSettings("txtbxBaseTargetDir", strBaseTargetDir);
         }

         // Load the current value of the key "bProcessFilesFLAC".
         bResult = bReadSetting("bProcessFilesFLAC", ref strResult);
         // If it was found okay, then store it in the control.
         if (bResult == true) {
            cbProcessFilesFLAC.Checked = (strResult == "true");
            bProcessFilesFLAC = cbProcessFilesFLAC.Checked;
         }
         // Ooops, the key wasn't found; store it for later use.
         else {
            vAddUpdateAppSettings("bProcessFilesFLAC", cbProcessFilesFLAC.Checked ? "true" : "false");
         }

         // Load the current value of the key "bProcessFilesmp3".
         bResult = bReadSetting("bProcessFilesmp3", ref strResult);
         // If it was found okay, then store it in the control.
         if (bResult == true) {
            cbProcessFilesmp3.Checked = (strResult == "true");
            bProcessFilesmp3 = cbProcessFilesmp3.Checked;
         }
         // Ooops, the key wasn't found; store it for later use.
         else {
            vAddUpdateAppSettings("bProcessFilesmp3", cbProcessFilesmp3.Checked ? "true" : "false");
         }

         // Load the current value of the key "bProcessFileswav".
         bResult = bReadSetting("bProcessFileswav", ref strResult);
         // If it was found okay, then store it in the control.
         if (bResult == true) {
            cbProcessFileswav.Checked = (strResult == "true");
            bProcessFileswav = cbProcessFileswav.Checked;
         }
         // Ooops, the key wasn't found; store it for later use.
         else {
            vAddUpdateAppSettings("bProcessFileswav", cbProcessFileswav.Checked ? "true" : "false");
         }

         vValidateSourceAndTargetDirsAndProcessFilesCBs();
         
         rbCopyOrMoveMove.Checked = true;
         rbCopyOrMoveCopy.Checked = false;
         cbVerifyFiles.Checked = false;
         cbForceCopyMoveSameDrive.Checked = true;
         btnGo.Enabled = false;

         // Clear all of the UseWaitCurso settings
         txtbxBaseSourceDir.UseWaitCursor = false;
         btnGetBaseSourceDir.UseWaitCursor = false;
         txtbxBaseTargetDir.UseWaitCursor = false;
         btnGetBaseTargetDir.UseWaitCursor = false;
         rbCopyOrMoveCopy.UseWaitCursor = false;
         rbCopyOrMoveMove.UseWaitCursor = false;
         cbLogOperationsToFile.UseWaitCursor = false;
         cbVerifyFiles.UseWaitCursor = false;
         cbForceCopyMoveSameDrive.UseWaitCursor = false;
         btnAnalyzeBaseSourceDir.UseWaitCursor = false;
         btnGo.UseWaitCursor = false;
         rtbAnalysisBaseSourceDir.UseWaitCursor = false;
         rtbPreviewBaseTargetDir.UseWaitCursor = false;
         rtbMessagesToUser.UseWaitCursor = false;
      }

      private void btnGetBaseSourceDir_Click(object sender, EventArgs e) {
         folderBrowserDialog1.SelectedPath = txtbxBaseSourceDir.Text;
         if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
            txtbxBaseSourceDir.Text = folderBrowserDialog1.SelectedPath;
         }

         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void btnGetBaseTargetDir_Click(object sender, EventArgs e) {
         folderBrowserDialog1.SelectedPath = txtbxBaseTargetDir.Text;
         if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
            txtbxBaseTargetDir.Text = folderBrowserDialog1.SelectedPath;
         }

         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void btnAnalyzeBaseSourceDir_Click(object sender, EventArgs e) {
         // Get the top-level list of directories (which should be the Groups).
         IEnumerable<String> straDirectoryArray = Directory.GetDirectories(txtbxBaseSourceDir.Text, "*", SearchOption.TopDirectoryOnly);

         // Initialize the List of MusicGroupAndAlbums
         lMusicGroupAndAlbums = new List<MusicGroupAndAlbums>();
         foreach (string strFileDirItem in straDirectoryArray) {
            lMusicGroupAndAlbums.Add(new MusicGroupAndAlbums(strFileDirItem));
         }

         rtbAnalysisBaseSourceDir.Text = "";
         rtbMessagesToUser.Text = "";
         rtbMessagesToUser.Visible = false;
         string strWorkString = "";
         string strCountString = "";
         Font fFontReg = new Font(rtbAnalysisBaseSourceDir.Font, FontStyle.Regular);
         Font fFontBold = new Font(rtbAnalysisBaseSourceDir.Font, FontStyle.Bold);
         foreach (MusicGroupAndAlbums oMusicGroupAndAlbums in lMusicGroupAndAlbums) {
            rtbAnalysisBaseSourceDir.AppendText(oMusicGroupAndAlbums.strGroupName + Environment.NewLine, Color.DarkSlateBlue, fFontBold);
            foreach (Album olAlbum in oMusicGroupAndAlbums.lAlbums) {
               rtbAnalysisBaseSourceDir.AppendText("      ", Color.Black, fFontReg);
                    // strWorkString = String.Format("{0} [{1} | {2} | {3}]", olAlbum.strAlbumName, olAlbum.iAlbumNumberOfFLAC, olAlbum.iAlbumNumberOfmp3, olAlbum.iAlbumNumberOfwav);
               strCountString = String.Format("[{0:00} | {1:00} | {2:00}]", olAlbum.iAlbumNumberOfFLAC, olAlbum.iAlbumNumberOfmp3, olAlbum.iAlbumNumberOfwav);
               strWorkString = String.Format("{0} -- {1}", strCountString, olAlbum.strAlbumName);
               if (olAlbum.bIsAlbumValid) {
                  rtbAnalysisBaseSourceDir.AppendText(strWorkString, Color.Black, fFontReg);
               }
               else {
                  rtbAnalysisBaseSourceDir.AppendText(strWorkString + " - *Bad*", Color.OrangeRed, fFontReg);
                  if (rtbMessagesToUser.Text.Length == 0) {
                     rtbMessagesToUser.AppendText("Errors encountered during analysis:" + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  }
                  // rtbMessagesToUser.AppendText("* Cannot process album '" + strWorkString + "'", Color.OrangeRed, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  rtbMessagesToUser.AppendText("\r\n* Cannot process band's album: '" + oMusicGroupAndAlbums.strGroupName + "'; '" + olAlbum.strAlbumName + "' due to song miscount " + strCountString, Color.OrangeRed, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  String strMessageString = "* Cannot process band's album: '" + oMusicGroupAndAlbums.strGroupName + "'; '" + olAlbum.strAlbumName + "' due to song miscount " + strCountString;
                  //MessageBox.Show(strMessageString);
                  FormDavesMessageBoxForm fDMBFDavesMessageBox = new FormDavesMessageBoxForm();
                  fDMBFDavesMessageBox.StartPosition = FormStartPosition.CenterParent;
                  fDMBFDavesMessageBox.rtbMessage.Text = strMessageString;
                  fDMBFDavesMessageBox.Text = "Album Song Count Mismatch";
                  fDMBFDavesMessageBox.ShowDialog();
                  }
               rtbAnalysisBaseSourceDir.AppendText(Environment.NewLine, Color.Black, fFontReg);
            }
         }

         // If there were no errors encountered, then the MessagesToUser box will be empty,
         // which means that everything is okay and we can enable the Go! button; otherwise,
         // disable the Go! button and display the MessagesToUser box.
         if (rtbMessagesToUser.Text.Length == 0) {
            btnGo.Enabled = true;
            rtbMessagesToUser.Visible = false;
         }
         else {
            btnGo.Enabled = false;
            rtbMessagesToUser.Visible = true;
         }
         btnGo.Enabled = true;
      }

      private void rbCopyOrMoveCopy_CheckedChanged(object sender, EventArgs e) {
         // According to the documentation, adding radio buttons directly to a form
         // causes them to act as if they're in a 'group' (where the group is
         // the form), which means that selecting one will automatically
         // deselect the other. So, there's nothing here, but we allow for 
         // stuff to be added, later.
         // Old code that deselects the other radio button.
         // rbCopyOrMoveMove.Checked = false;
         // Since we're changing settings, verify that everything (newly) selected
         // is okay.
         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void rbCopyOrMoveMove_CheckedChanged(object sender, EventArgs e) {
         // According to the documentation, adding radio buttons directly to a form
         // causes them to act as if they're in a 'group' (where the group is
         // the form), which means that selecting one will automatically
         // deselect the other. So, there's nothing here, but we allow for 
         // stuff to be added, later.
         // Old code that deselects the other radio button.
         // rbCopyOrMoveCopy.Checked = false;
         // Since we're changing settings, verify that everything (newly) selected
         // is okay.
         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void cbForceCopyMoveSameDrive_CheckedChanged(object sender, EventArgs e) {
         // When the value is checked, then the Source and Target drives must be the same;
         // if they're not, then disable the Go! button.
         if (cbForceCopyMoveSameDrive.Checked) {
            if (txtbxBaseSourceDir.Text.Substring(0, 1) != txtbxBaseTargetDir.Text.Substring(0, 1)) {
               btnGo.Enabled = false;
            }
         }
      }

      private bool bTryToCreateDirectory(string strDirectory) {
         // This method will attempt to create a directory, returning:
         // * true if successful
         // * false if unsuccessful (which is determined by any type of exception)
         bool bReturnVal = true;

         try {
            // Determine whether the directory exists; if so, there's nothing
            // else to do, so return true.
            if (Directory.Exists(strDirectory)) {
               return bReturnVal;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(strDirectory);
         }
         catch (Exception eException) {
            Font fFontBold = new Font(rtbAnalysisBaseSourceDir.Font, FontStyle.Bold);
            rtbMessagesToUser.AppendText("*** Error creating directory " + strDirectory + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
            bReturnVal = false;
         }
         finally { }

         return bReturnVal;
      }

      private bool bCopyOrMoveAllAlbumFilesOfTypeAndCopyjpgs(string strSourceDirectory, string strTargetDirectory, string strOfType) {

         bool bAllFilesMoved = false;
         Font fFontReg = new Font(rtbPreviewBaseTargetDir.Font, FontStyle.Regular);
         Font fFontBold = new Font(rtbPreviewBaseTargetDir.Font, FontStyle.Bold);

         if (bTryToCreateDirectory(strTargetDirectory) == true) {
            bAllFilesMoved = true;
            rtbPreviewBaseTargetDir.AppendText(">       " + strTargetDirectory + Environment.NewLine, Color.DarkSlateBlue, fFontReg);
            rtbMessagesToUser.AppendText("*    GroupAlbum created: " + strTargetDirectory + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
            foreach (string strSourceFilePathSong in Directory.GetFiles(strSourceDirectory, strOfType)) {
               try {
                  if (rbCopyOrMoveMove.Checked == true) {
                     File.Move(strSourceFilePathSong, strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong));
                     rtbMessagesToUser.AppendText("*    GroupAlbumSong moved: " + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
                  }
                  else if (rbCopyOrMoveCopy.Checked == true) {
                     File.Copy(strSourceFilePathSong, strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong));
                     rtbMessagesToUser.AppendText("*    GroupAlbumSong copied: " + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
                  }
               }
               catch (Exception eException) {
                  if (rbCopyOrMoveMove.Checked == true) {
                     rtbMessagesToUser.AppendText("*** Error moving song file from " + strSourceFilePathSong + " to " + strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  }
                  else if (rbCopyOrMoveCopy.Checked == true) {
                     rtbMessagesToUser.AppendText("*** Error copying song file from " + strSourceFilePathSong + " to " + strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  }
                  bAllFilesMoved = false;
               }
            }
            foreach (string strSourceFilePathSong in Directory.GetFiles(strSourceDirectory, "*.jpg")) {
               try {
                  File.Copy(strSourceFilePathSong, strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong));
                  rtbMessagesToUser.AppendText("*    GroupAlbumSongJPG copied: " + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
               }
               catch (Exception eException) {
                  rtbMessagesToUser.AppendText("*** Error copying jpg image file from " + strSourceFilePathSong + " to " + strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  bAllFilesMoved = false;
               }
            }
         }
         else {
            rtbMessagesToUser.AppendText("*    GroupAlbum creation ERROR: " + strTargetDirectory + Environment.NewLine, Color.Red, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
         }

         return bAllFilesMoved;
      }

      private void btnGo_Click(object sender, EventArgs e) {
         // Entry here can (should?) only be possible once the Analysis has been successfully
         // completed, resulting in a fully populated lMusicGroupAndAlbums List.

         // Since we're about to start the "Go!" work, save the current paths for later use;
         // we could save them AFTER everything is processed, but we want the paths saved
         // NOW in case something happens during the processing.
         vAddUpdateAppSettings("txtbxBaseSourceDir", txtbxBaseSourceDir.Text);
         vAddUpdateAppSettings("txtbxBaseTargetDir", txtbxBaseTargetDir.Text);

         string strTargetDirGroup = "";
         rtbMessagesToUser.Text = "";
         // rtbMessagesToUser.Visible = false;
         Font fFontReg = new Font(rtbPreviewBaseTargetDir.Font, FontStyle.Regular);
         Font fFontBold = new Font(rtbPreviewBaseTargetDir.Font, FontStyle.Bold);
         rtbMessagesToUser.AppendText("Groups and Albums Directory and File Processing:" + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);

         foreach (MusicGroupAndAlbums oMusicGroupAndAlbums in lMusicGroupAndAlbums) {
            rtbPreviewBaseTargetDir.AppendText(oMusicGroupAndAlbums.strGroupName + Environment.NewLine, Color.DarkSlateBlue, fFontBold);
            strTargetDirGroup = txtbxBaseTargetDir.Text + "\\" + oMusicGroupAndAlbums.strGroupName;
            rtbPreviewBaseTargetDir.AppendText("> " + strTargetDirGroup + Environment.NewLine, Color.DarkSlateBlue, fFontBold);
            if (bTryToCreateDirectory(strTargetDirGroup) == true) {
               rtbMessagesToUser.AppendText("* GroupDir created: " + strTargetDirGroup + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
            }
            else {
               rtbMessagesToUser.AppendText("* GroupDir creation ERROR: " + strTargetDirGroup + Environment.NewLine, Color.Red, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
            }

            // For each album:
            // * Move-or-copy the *.flac files & copy the .jpg files, then verify the # of files
            // * Move-or-copy the *.mp3 files & copy the .jpg files, then verify the # of files
            // * Move-or-copy the *.wav files & copy the .jpg files, then verify the # of files
            string[] straTargetSongListOfType;
            string[] straTargetSongListOfjpg;
            bool bCopiedOrMovedNumberOfFilesMatchFLAC, bCopiedOrMovedNumberOfFilesMatchmp3, bCopiedOrMovedNumberOfFilesMatchwav;
            bCopiedOrMovedNumberOfFilesMatchFLAC = bCopiedOrMovedNumberOfFilesMatchmp3 = bCopiedOrMovedNumberOfFilesMatchwav = false;
            foreach (Album olAlbum in oMusicGroupAndAlbums.lAlbums) {
               if (olAlbum.bIsAlbumValid == true) {
                  // If FLAC files are selected to be processed, then:
                  // * Move-or-copy all of the FLAC files and copy the jpg files
                  // * Verify that the # files at the target is the same as the # at the source
                  if (bProcessFilesFLAC == true) {
                     bool bAlbumFilesAllMovedFLAC = false;
                     string strTargetDirAlbumFLAC = strTargetDirGroup + "\\" + olAlbum.strAlbumName + " [FLAC]";
                     bAlbumFilesAllMovedFLAC = bCopyOrMoveAllAlbumFilesOfTypeAndCopyjpgs(olAlbum.strAlbumDirectory, strTargetDirAlbumFLAC, "*.flac");
                     // Verify files by file count(s):
                     // * #SourceFLAC + #Sourcejpg == #TargetFLAC + #Targetjpg
                     straTargetSongListOfType = Directory.GetFiles(strTargetDirAlbumFLAC, "*.flac");
                     straTargetSongListOfjpg = Directory.GetFiles(strTargetDirAlbumFLAC, "*.jpg");
                     bCopiedOrMovedNumberOfFilesMatchFLAC = ((straTargetSongListOfType.Length == olAlbum.iAlbumNumberOfFLAC) && (straTargetSongListOfjpg.Length == olAlbum.iAlbumNumberOfjpg));
                  }

                  // If mp3 files are selected to be processed, then:
                  // * Move-or-copy all of the mp3 files and copy the jpg files
                  // * Verify that the # files at the target is the same as the # at the source
                  if (bProcessFilesmp3 == true) {
                     bool bAlbumFilesAllMovedmp3 = false;
                     string strTargetDirAlbummp3 = strTargetDirGroup + "\\" + olAlbum.strAlbumName + " [320kbps mp3]";
                     bAlbumFilesAllMovedmp3 = bCopyOrMoveAllAlbumFilesOfTypeAndCopyjpgs(olAlbum.strAlbumDirectory, strTargetDirAlbummp3, "*.mp3");
                     // Verify files by file count(s):
                     // * #Sourcemp3 + #Sourcejpg == #Targetmp3 + #Targetjpg
                     straTargetSongListOfType = Directory.GetFiles(strTargetDirAlbummp3, "*.mp3");
                     straTargetSongListOfjpg = Directory.GetFiles(strTargetDirAlbummp3, "*.jpg");
                     bCopiedOrMovedNumberOfFilesMatchmp3 = ((straTargetSongListOfType.Length == olAlbum.iAlbumNumberOfmp3) && (straTargetSongListOfjpg.Length == olAlbum.iAlbumNumberOfjpg));
                  }

                  // If wav files are selected to be processed, then:
                  // * Move-or-copy all of the wav files and copy the jpg files
                  // * Verify that the # files at the target is the same as the # at the source
                  if (bProcessFileswav == true) {
                     bool bAlbumFilesAllMovedwav = false;
                     string strTargetDirAlbumwav = strTargetDirGroup + "\\" + olAlbum.strAlbumName + " [wav]";
                     bAlbumFilesAllMovedwav = bCopyOrMoveAllAlbumFilesOfTypeAndCopyjpgs(olAlbum.strAlbumDirectory, strTargetDirAlbumwav, "*.wav");
                     // Verify files by file count(s):
                     // * #Sourcewav + #Sourcejpg == #Targetwav + #Targetjpg
                     straTargetSongListOfType = Directory.GetFiles(strTargetDirAlbumwav, "*.wav");
                     straTargetSongListOfjpg = Directory.GetFiles(strTargetDirAlbumwav, "*.jpg");
                     bCopiedOrMovedNumberOfFilesMatchwav = ((straTargetSongListOfType.Length == olAlbum.iAlbumNumberOfwav) && (straTargetSongListOfjpg.Length == olAlbum.iAlbumNumberOfjpg));
                  }

                  // If all process-file-types are selected, and all files have been moved-or-copied, then
                  // do the file-and-directory clean-up. We don't need to test for the three different
                  // process-file-types -- the bool bCopiedOrMovedNumberOfFilesMatch flags will tell us what we
                  // need to know, since they all start as false and only become true if their
                  // corresponding file-type is successfully processed.
                  // * If they're all true AND all
                  // * All files have been copied-or-moved AND
                  // * rbCopyOrMoveMove.Checked == true, then:
                  // * Delete original .jpg files
                  // * Delete SourceAlbumDir
                  if (bCopiedOrMovedNumberOfFilesMatchFLAC && bCopiedOrMovedNumberOfFilesMatchmp3 && bCopiedOrMovedNumberOfFilesMatchwav && rbCopyOrMoveMove.Checked == true) {
                     straTargetSongListOfjpg = Directory.GetFiles(olAlbum.strAlbumDirectory, "*.jpg");
                     foreach (string strFilename in straTargetSongListOfjpg) {
                        try {
                           System.IO.File.SetAttributes(strFilename, FileAttributes.Normal);
                        }
                        catch (Exception eException) {
                           rtbMessagesToUser.AppendText("*** Error setting file attributes on jpg image file " + strFilename + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                        }
                        finally { }
                        try {
                           File.Delete(strFilename);
                        }
                        catch (Exception eException) {
                           rtbMessagesToUser.AppendText("*** Error deleting jpg image file " + strFilename + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                        }
                        finally { }
                     }
                  }

                  if (bCopiedOrMovedNumberOfFilesMatchFLAC && bCopiedOrMovedNumberOfFilesMatchmp3 && bCopiedOrMovedNumberOfFilesMatchwav && rbCopyOrMoveMove.Checked == true) {
                     // All of the files have been moved out of the Album directory, so delete it.
                     try {
                        Directory.Delete(olAlbum.strAlbumDirectory);
                        rtbMessagesToUser.AppendText("* Successfully deleted Album directory : " + olAlbum.strAlbumDirectory + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
                     }
                     catch (Exception eException) {
                        rtbMessagesToUser.AppendText("*** Error deleting Album directory " + olAlbum.strAlbumDirectory + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                     }
                     finally { }
                  }
               }
            }

            // Here, the MessagesToUser box contains the results of all attempted directory
            // and file I/I. While it's almost certainly not going to be empty, there's
            // still a remote chance. So, only make it visible if it's not empty.
            if (rtbMessagesToUser.Text.Length == 0) {
               rtbMessagesToUser.Visible = false;
            }
            else {
               rtbMessagesToUser.Visible = true;
            }

            if (bCopiedOrMovedNumberOfFilesMatchFLAC && bCopiedOrMovedNumberOfFilesMatchmp3 && bCopiedOrMovedNumberOfFilesMatchwav && rbCopyOrMoveMove.Checked == true) {
               // All of the Albums have been moved from the Group, so delete the Group.
               try {
                  Directory.Delete(oMusicGroupAndAlbums.strGroupDirectory);
                  rtbMessagesToUser.AppendText("* Successfully deleted Group directory : " + oMusicGroupAndAlbums.strGroupDirectory + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
               }
               catch (Exception eException) {
                  rtbMessagesToUser.AppendText("*** Error deleting Group directory " + oMusicGroupAndAlbums.strGroupDirectory + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
               }
               finally { }
            }
         }
      }

      private void cbProcessFilesFLAC_CheckedChanged(object sender, EventArgs e) {
         bProcessFilesFLAC = cbProcessFilesFLAC.Checked;
         // Save the checkbox setting for later use.
         vAddUpdateAppSettings("bProcessFilesFLAC", cbProcessFilesFLAC.Checked ? "true" : "false");
         // The setting for the ProcessFilesFLAC checkbox has changed, so re-verify
         // if btnGo should be enabled.
         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void cbProcessFilesmp3_CheckedChanged(object sender, EventArgs e) {
         bProcessFilesmp3 = cbProcessFilesmp3.Checked;
         // Save the checkbox setting for later use.
         vAddUpdateAppSettings("bProcessFilesmp3", cbProcessFilesmp3.Checked ? "true" : "false");
         // The setting for the ProcessFilesmp3 checkbox has changed, so re-verify
         // if btnGo should be enabled.
         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void cbProcessFileswav_CheckedChanged(object sender, EventArgs e) {
         bProcessFileswav = cbProcessFileswav.Checked;
         // Save the checkbox setting for later use.
         vAddUpdateAppSettings("bProcessFileswav", cbProcessFileswav.Checked ? "true" : "false");
         // The setting for the ProcessFileswav checkbox has changed, so re-verify
         // if btnGo should be enabled.
         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void txtbxBaseSourceDir_TextChanged(object sender, EventArgs e) {
         // Allow the user to enter whatever they want (including a paste from
         // the clipboard), but be sure to validate if it's valid (along with
         // everything else).
         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }

      private void txtbxBaseTargetDir_TextChanged(object sender, EventArgs e) {
         // Allow the user to enter whatever they want (including a paste from
         // the clipboard), but be sure to validate if it's valid (along with
         // everything else).
         vValidateSourceAndTargetDirsAndProcessFilesCBs();
      }
   }

   // BEGIN Class MusicGroupAndAlbums
   // This class is designed to hold (information about) the Group and (information about) all of its albums:
   // * Group name
   // * Group directory (full path)
   // * Number of Albums
   // * List of Album objects
   public class MusicGroupAndAlbums {
      public string strGroupName { get; }
      public string strGroupDirectory { get; }
      public int iNumberOfAlbums { get; }
      public ICollection<String> straAlbumDirectoryArray { get; }
      public List<Album> lAlbums { get; }

      public MusicGroupAndAlbums(string strDirectoryOfGroup) {
         // This constructor takes the full path to the Group's directory and then:
         // * Stores the full path
         // * Extracts the trailing GroupName
         // * Gets the list of albums (i.e., subdirectories) contained within that GroupName
         // * Determines how many albums (i.e., subdirectories) are contained within that GroupName

         this.strGroupDirectory = strDirectoryOfGroup;
         this.strGroupName = strDirectoryOfGroup.Substring(strDirectoryOfGroup.LastIndexOf('\\') + 1);
         this.iNumberOfAlbums = 0;
         this.straAlbumDirectoryArray = Directory.GetDirectories(strDirectoryOfGroup, "*", SearchOption.TopDirectoryOnly);
         this.iNumberOfAlbums = straAlbumDirectoryArray.Count();

         // Initialize the lAlbums list, and then add a new Album object for each one
         // (based on its AlbumDirectory entry).
         this.lAlbums = new List<Album>();
         foreach (string strAlbumDirectory in this.straAlbumDirectoryArray) {
            this.lAlbums.Add(new Album(strAlbumDirectory));

         }
      }
   }

   public class Album {
      // This Album class contains information pertinent to a ripped Album stored:
      // * Album title
      // * Album directory (full path)
      // * # of FLAC tracks
      // * # of mp3 tracks
      // * # of wav tracks
      // * # of jpg images
      // * bIsAlbumValid: bool which indicates if this is "valid", as determined by its contents.
      //                  This is true when:
      //                  (#FLAC == #mp3 == #wav) AND (#Subdirectories == 0)
      public string strAlbumName;
      public string strAlbumDirectory;
      public bool bIsAlbumValid;
      public int iAlbumNumberOfFLAC;
      public int iAlbumNumberOfmp3;
      public int iAlbumNumberOfwav;
      public int iAlbumNumberOfjpg;
      public int iAlbumNumberOfSubdirectories;

      public Album(string strDirectoryOfAlbum) {
         this.strAlbumDirectory = strDirectoryOfAlbum;
         this.strAlbumName = strDirectoryOfAlbum.Substring(strDirectoryOfAlbum.LastIndexOf('\\') + 1);

         ICollection<string> straFileList;

         // Get the # FLAC files
         straFileList = Directory.GetFiles(strAlbumDirectory, "*.flac");
         this.iAlbumNumberOfFLAC = straFileList.Count();

         // Get the # mp3 files
         straFileList = Directory.GetFiles(strAlbumDirectory, "*.mp3");
         this.iAlbumNumberOfmp3 = straFileList.Count();

         // Get the # wav files
         straFileList = Directory.GetFiles(strAlbumDirectory, "*.wav");
         this.iAlbumNumberOfwav = straFileList.Count();

         // Get the # jpg files
         straFileList = Directory.GetFiles(strAlbumDirectory, "*.jpg");
         this.iAlbumNumberOfjpg = straFileList.Count();

         ICollection<string> straSubdirectoryList;
         straSubdirectoryList = Directory.GetDirectories(strAlbumDirectory, "*", SearchOption.TopDirectoryOnly);
         this.iAlbumNumberOfSubdirectories = straSubdirectoryList.Count();

         // Is this Album considered valid for processing?
         this.bIsAlbumValid = (this.iAlbumNumberOfFLAC == this.iAlbumNumberOfmp3) && (this.iAlbumNumberOfmp3 == this.iAlbumNumberOfwav) && (this.iAlbumNumberOfSubdirectories == 0);
      }

   }

   public static class RichTextBoxExtensions {
      // https://stackoverflow.com/questions/1926264/color-different-parts-of-a-richtextbox-string
      public static void AppendText(this RichTextBox box, string text, Color color, Font font, bool bAddToLogfile, string strLogfilename) {
         box.SelectionStart = box.TextLength;
         box.SelectionLength = 0;

         box.SelectionColor = color;
         box.SelectionFont = font;
         box.AppendText(text);
         box.SelectionColor = box.ForeColor;

         if (bAddToLogfile == true) {
            try {
               using (StreamWriter swLogfile = File.AppendText(strLogfilename)) {
                  swLogfile.Write(DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "   " + text);
               }
            }
            catch (Exception eException) {
            }
            finally { }
         }
      }

      public static void AppendText(this RichTextBox box, string text, Color color, Font font) {
         box.SelectionStart = box.TextLength;
         box.SelectionLength = 0;

         box.SelectionColor = color;
         box.SelectionFont = font;
         box.AppendText(text);
         box.SelectionColor = box.ForeColor;
      }

      public static void AppendText(this RichTextBox box, string text, Color color) {
         box.SelectionStart = box.TextLength;
         box.SelectionLength = 0;

         box.SelectionColor = color;
         box.AppendText(text);
         box.SelectionColor = box.ForeColor;
      }
   }

}