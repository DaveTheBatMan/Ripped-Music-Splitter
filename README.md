# Ripped-Music-Splitter

When I rip music from CDs, I like to make multiple rips (of different files types {FLAC, 320kbps mp3, wav}) while I have the CD loaded, then put away the CD and use the ripped files on whatever device I choose. This results in a ripped file and directory structure where a single album directory contains all of the ripped songs from that album, which is to be expected), such as:

* MusicGroupName
* -> AlbumName
* ---> a.flac
* ---> a.mp3
* ---> a.wav
* ---> AlbumArt1.jpg

However, that's not what I want -- I want all of the file types (for each album) in separate directories, which this program does. Its use takes the above structure and creates (in a different location):

* MusicGroupName
* -> AlbumName [flac]
* ---> a.flac
* ---> AlbumArt1.jpg
* -> AlbumName [320kbps mp3]
* ---> a.mp3
* ---> AlbumArt1.jpg
* -> AlbumName [wav]
* ---> a.wav
* ---> AlbumArt1.jpg

Currently, there are several restrictions:
* The music files can only be *moved* from the Source, not *copied*.
* The Source and Target directories must be on the same drive.
* Files of type .flac, .mp3, and .wav are supported; at run-time, you can select any/all of those types so that you can process ALL of the files, or ONLY process mp3 files, for example.
* The Target's album names will be appended with {"[FLAC]", "[320kbps mp3]", "[wav]"}; since I deal with mp3 rips @ 320kbps, I wanted this noted in the directory name.
* When you choose all three file types and move all of the music files to a new location, that means that the only thing left in the album's source directory is the album art; if that's the case, then the album art is deleted and the album's directory is deleted.
* When all albums' directories for a Group have been deleted, the Group is deleted.
* There is a message box at the bottom of the panel that appears with messages, but only when there are messages worth noting.
* Settings are saved and reloaded across runs of the program (in "Ripped Music Splitter.exe.Config")
* A logfile can record all file activity ("Ripped Music Splitter [Log].txt").
