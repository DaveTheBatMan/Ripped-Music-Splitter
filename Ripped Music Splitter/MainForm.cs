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
      private static string strBaseSourceDir = @"D:\zSplitterTestSource";
      private static string strBaseTargetDir = @"D:\zSplitterTestTarget";
      private static List<MusicGroupAndAlbums> lMusicGroupAndAlbums;
      private static string strLogFilename = "Ripped Music Splitter [Log].txt";

      private void bValidateSourceAndTargetDirs() {
         if (Directory.Exists(txtbxBaseSourceDir.Text)) {
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

         if (Directory.Exists(txtbxBaseTargetDir.Text)) {
            txtbxBaseTargetDir.BackColor = Color.White;
            txtbxBaseTargetDir.ForeColor = Color.Blue;
            txtbxBaseTargetDir.Font = new Font(txtbxBaseTargetDir.Font, FontStyle.Regular);
            txtbxBaseTargetDir.ReadOnly = false;
         }
         else {
            txtbxBaseTargetDir.BackColor = Color.Gray;
            txtbxBaseTargetDir.ForeColor = Color.Red;
            txtbxBaseTargetDir.Font = new Font(txtbxBaseTargetDir.Font, FontStyle.Bold ^ FontStyle.Italic);
            txtbxBaseTargetDir.ReadOnly = true;
         }
         if (txtbxBaseSourceDir.Text.Substring(0, 1) != txtbxBaseTargetDir.Text.Substring(0, 1)) {
            btnGo.Enabled = false;
         }
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

         bValidateSourceAndTargetDirs();

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

         bValidateSourceAndTargetDirs();
      }

      private void btnGetBaseTargetDir_Click(object sender, EventArgs e) {
         folderBrowserDialog1.SelectedPath = txtbxBaseTargetDir.Text;
         if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
            txtbxBaseTargetDir.Text = folderBrowserDialog1.SelectedPath;
         }

         bValidateSourceAndTargetDirs();
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
         Font fFontReg = new Font(rtbAnalysisBaseSourceDir.Font, FontStyle.Regular);
         Font fFontBold = new Font(rtbAnalysisBaseSourceDir.Font, FontStyle.Bold);
         foreach (MusicGroupAndAlbums oMusicGroupAndAlbums in lMusicGroupAndAlbums) {
            rtbAnalysisBaseSourceDir.AppendText(oMusicGroupAndAlbums.strGroupName + Environment.NewLine, Color.DarkSlateBlue, fFontBold);
            foreach (Album olAlbum in oMusicGroupAndAlbums.lAlbums) {
               rtbAnalysisBaseSourceDir.AppendText("      ", Color.Black, fFontReg);
               strWorkString = String.Format("{0} [{1} | {2} | {3}]", olAlbum.strAlbumName, olAlbum.iAlbumNumberOfFLAC, olAlbum.iAlbumNumberOfmp3, olAlbum.iAlbumNumberOfwav);
               if (olAlbum.bIsAlbumValid) {
                  rtbAnalysisBaseSourceDir.AppendText(strWorkString, Color.Black, fFontReg);
               }
               else {
                  rtbAnalysisBaseSourceDir.AppendText("BAD-" + strWorkString, Color.OrangeRed, fFontReg);
                  if (rtbMessagesToUser.Text.Length == 0) {
                     rtbMessagesToUser.AppendText("Errors encountered during analysis:" + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  }
                  rtbMessagesToUser.AppendText("* Cannot process album '" + strWorkString, Color.OrangeRed, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
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
         rbCopyOrMoveMove.Checked = false;
      }

      private void rbCopyOrMoveMove_CheckedChanged(object sender, EventArgs e) {
         rbCopyOrMoveCopy.Checked = false;
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

      private bool bMoveAllAlbumFilesOfType(string strSourceDirectory, string strTargetDirectory, string strOfType) {

         bool bAllFilesMoved = false;
         Font fFontReg = new Font(rtbPreviewBaseTargetDir.Font, FontStyle.Regular);
         Font fFontBold = new Font(rtbPreviewBaseTargetDir.Font, FontStyle.Bold);

         if (bTryToCreateDirectory(strTargetDirectory) == true) {
            bAllFilesMoved = true;
            rtbPreviewBaseTargetDir.AppendText(">       " + strTargetDirectory + Environment.NewLine, Color.DarkSlateBlue, fFontReg);
            rtbMessagesToUser.AppendText("*    GroupAlbum created: " + strTargetDirectory + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
            foreach (string strSourceFilePathSong in Directory.GetFiles(strSourceDirectory, strOfType)) {
               try {
                  File.Move(strSourceFilePathSong, strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong));
                  rtbMessagesToUser.AppendText("*    GroupAlbumSong moved: " + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Blue, fFontReg, cbLogOperationsToFile.Checked, strLogFilename);
               }
               catch (Exception eException) {
                  rtbMessagesToUser.AppendText("*** Error moving song file from " + strSourceFilePathSong + " to " + strTargetDirectory + '\\' + Path.GetFileName(strSourceFilePathSong) + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
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
            // * Move the *.flac files and copy the .jpg files
            // * Move the *.mp3 files and copy the .jpg files
            // * Move the *.wav files and copy the .jpg files
            foreach (Album olAlbum in oMusicGroupAndAlbums.lAlbums) {
               if (olAlbum.bIsAlbumValid == true) {
                  // Move all of the FLAC files
                  bool bAlbumFilesAllMovedFLAC = false;
                  string strTargetDirAlbumFLAC = strTargetDirGroup + "\\" + olAlbum.strAlbumName + " [FLAC]";
                  bAlbumFilesAllMovedFLAC = bMoveAllAlbumFilesOfType(olAlbum.strAlbumDirectory, strTargetDirAlbumFLAC, "*.flac");

                  // Move all of the mp3 files
                  bool bAlbumFilesAllMovedmp3 = false;
                  string strTargetDirAlbummp3 = strTargetDirGroup + "\\" + olAlbum.strAlbumName + " [320kbps mp3]";
                  bAlbumFilesAllMovedmp3 = bMoveAllAlbumFilesOfType(olAlbum.strAlbumDirectory, strTargetDirAlbummp3, "*.mp3");

                  // Move all of the wav files
                  bool bAlbumFilesAllMovedwav = false;
                  string strTargetDirAlbumwav = strTargetDirGroup + "\\" + olAlbum.strAlbumName + " [wav]";
                  bAlbumFilesAllMovedwav = bMoveAllAlbumFilesOfType(olAlbum.strAlbumDirectory, strTargetDirAlbumwav, "*.wav");

                  // Verify files by file count(s):
                  // * If #SourceFLAC + #Sourcejpg == #TargetFLAC + #Targetjpg
                  // AND
                  // * If #Sourcemp3 + #Sourcejpg == #Targetmp3 + #Targetjpg
                  // AND
                  // * If #Sourcewav + #Sourcejpg == #Targetwav + #Targetjpg
                  // THEN all files moved okay, so:
                  // * Delete original .jpg
                  // * Delete SourceAlbumDir
                  string[] straTargetSongListOfType;
                  string[] straTargetSongListOfjpg;

                  straTargetSongListOfType = Directory.GetFiles(strTargetDirAlbumFLAC, "*.flac");
                  straTargetSongListOfjpg = Directory.GetFiles(strTargetDirAlbumFLAC, "*.jpg");
                  bool bMovedNumberOfFilesMatchFLAC = ((straTargetSongListOfType.Length == olAlbum.iAlbumNumberOfFLAC) && (straTargetSongListOfjpg.Length == olAlbum.iAlbumNumberOfjpg));

                  straTargetSongListOfType = Directory.GetFiles(strTargetDirAlbummp3, "*.mp3");
                  straTargetSongListOfjpg = Directory.GetFiles(strTargetDirAlbummp3, "*.jpg");
                  bool bMovedNumberOfFilesMatchmp3 = ((straTargetSongListOfType.Length == olAlbum.iAlbumNumberOfmp3) && (straTargetSongListOfjpg.Length == olAlbum.iAlbumNumberOfjpg));

                  straTargetSongListOfType = Directory.GetFiles(strTargetDirAlbumwav, "*.wav");
                  straTargetSongListOfjpg = Directory.GetFiles(strTargetDirAlbumwav, "*.jpg");
                  bool bMovedNumberOfFilesMatchwav = ((straTargetSongListOfType.Length == olAlbum.iAlbumNumberOfwav) && (straTargetSongListOfjpg.Length == olAlbum.iAlbumNumberOfjpg));

                  // If the number of all files match, then delete the original .jpg files.
                  if (bMovedNumberOfFilesMatchFLAC && bMovedNumberOfFilesMatchmp3 && bMovedNumberOfFilesMatchwav) {
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
                  // All of the files have been moved out of the Album directory, so delete it.
                  try {
                     Directory.Delete(olAlbum.strAlbumDirectory);
                  }
                  catch (Exception eException) {
                     rtbMessagesToUser.AppendText("*** Error deleting Album directory " + olAlbum.strAlbumDirectory + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
                  }
                  finally { }
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
            // All of the Albums have been moved from the Group, so delete the Group.
            try {
               Directory.Delete(oMusicGroupAndAlbums.strGroupDirectory);
            }
            catch (Exception eException) {
               rtbMessagesToUser.AppendText("*** Error deleting Group directory " + oMusicGroupAndAlbums.strGroupDirectory + Environment.NewLine, Color.Black, fFontBold, cbLogOperationsToFile.Checked, strLogFilename);
            }
            finally { }
         }
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