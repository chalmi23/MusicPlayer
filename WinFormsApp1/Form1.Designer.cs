namespace WinFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonAddSongs = new Button();
            musicList = new ListView();
            Cover = new ColumnHeader();
            Id = new ColumnHeader();
            Title = new ColumnHeader();
            Artist = new ColumnHeader();
            Album = new ColumnHeader();
            Duration = new ColumnHeader();
            pictureBoxStopMusic = new PictureBox();
            pictureBoxPlayMusic = new PictureBox();
            pictureBoxNextTrack = new PictureBox();
            pictureBoxPreviousTrack = new PictureBox();
            trackBar = new TrackBar();
            splitter1 = new Splitter();
            trackBarVolume = new TrackBar();
            pictureBoxSpeaker = new PictureBox();
            pictureBoxSpeakerNoSound = new PictureBox();
            labelTimeCounter = new Label();
            labelDuration = new Label();
            pictureBoxForwards = new PictureBox();
            pictureBoxBackwards = new PictureBox();
            pictureBoxRepeat = new PictureBox();
            pictureBoxRepeatOne = new PictureBox();
            pictureBoxRepeatAll = new PictureBox();
            labelTitle = new Label();
            labelArtist = new Label();
            pictureBoxCover = new PictureBox();
            pictureBoxRandom = new PictureBox();
            pictureBoxRandomGreen = new PictureBox();
            panelSettings = new Panel();
            buttonSettings = new Button();
            buttonAddPlaylist = new Button();
            listViewPlaylist = new ListView();
            Image = new ColumnHeader();
            Number = new ColumnHeader();
            PlayListName = new ColumnHeader();
            defaultCover = new PictureBox();
            pictureBoxMinimizeApp = new PictureBox();
            pictureBoxCloseApp = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStopMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNextTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreviousTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpeaker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpeakerNoSound).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForwards).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackwards).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRepeat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRepeatOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRepeatAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRandom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRandomGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)defaultCover).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizeApp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCloseApp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonAddSongs
            // 
            buttonAddSongs.BackColor = SystemColors.ButtonHighlight;
            buttonAddSongs.FlatAppearance.BorderSize = 0;
            buttonAddSongs.FlatStyle = FlatStyle.Flat;
            buttonAddSongs.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddSongs.ForeColor = SystemColors.ActiveCaptionText;
            buttonAddSongs.Location = new Point(12, 251);
            buttonAddSongs.Name = "buttonAddSongs";
            buttonAddSongs.Size = new Size(246, 43);
            buttonAddSongs.TabIndex = 1;
            buttonAddSongs.Text = "Add new songs";
            buttonAddSongs.TextAlign = ContentAlignment.MiddleLeft;
            buttonAddSongs.UseVisualStyleBackColor = false;
            buttonAddSongs.Click += AddNewSongsButtonClick;
            // 
            // musicList
            // 
            musicList.BackColor = SystemColors.ButtonHighlight;
            musicList.BorderStyle = BorderStyle.None;
            musicList.Columns.AddRange(new ColumnHeader[] { Cover, Id, Title, Artist, Album, Duration });
            musicList.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            musicList.ForeColor = Color.White;
            musicList.FullRowSelect = true;
            musicList.HeaderStyle = ColumnHeaderStyle.None;
            musicList.HideSelection = true;
            musicList.Location = new Point(264, 56);
            musicList.MultiSelect = false;
            musicList.Name = "musicList";
            musicList.Size = new Size(950, 546);
            musicList.TabIndex = 0;
            musicList.UseCompatibleStateImageBehavior = false;
            musicList.ColumnWidthChanging += ColumnWidthChangingMusicList;
            musicList.Click += playSelectedTrack;
            // 
            // Cover
            // 
            Cover.Text = "Cover";
            Cover.Width = 75;
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 65;
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 280;
            // 
            // Artist
            // 
            Artist.Text = "Artist";
            Artist.Width = 175;
            // 
            // Album
            // 
            Album.Text = "Album";
            Album.Width = 250;
            // 
            // Duration
            // 
            Duration.Text = "Duration";
            Duration.Width = 81;
            // 
            // pictureBoxStopMusic
            // 
            pictureBoxStopMusic.Image = (Image)resources.GetObject("pictureBoxStopMusic.Image");
            pictureBoxStopMusic.Location = new Point(588, 634);
            pictureBoxStopMusic.Name = "pictureBoxStopMusic";
            pictureBoxStopMusic.Size = new Size(49, 49);
            pictureBoxStopMusic.TabIndex = 3;
            pictureBoxStopMusic.TabStop = false;
            pictureBoxStopMusic.Visible = false;
            pictureBoxStopMusic.Click += playPausePictureBox_Click;
            // 
            // pictureBoxPlayMusic
            // 
            pictureBoxPlayMusic.Image = (Image)resources.GetObject("pictureBoxPlayMusic.Image");
            pictureBoxPlayMusic.Location = new Point(588, 634);
            pictureBoxPlayMusic.Name = "pictureBoxPlayMusic";
            pictureBoxPlayMusic.Size = new Size(49, 49);
            pictureBoxPlayMusic.TabIndex = 4;
            pictureBoxPlayMusic.TabStop = false;
            pictureBoxPlayMusic.Click += playPausePictureBox_Click;
            // 
            // pictureBoxNextTrack
            // 
            pictureBoxNextTrack.Image = (Image)resources.GetObject("pictureBoxNextTrack.Image");
            pictureBoxNextTrack.Location = new Point(643, 645);
            pictureBoxNextTrack.Name = "pictureBoxNextTrack";
            pictureBoxNextTrack.Size = new Size(26, 26);
            pictureBoxNextTrack.TabIndex = 5;
            pictureBoxNextTrack.TabStop = false;
            pictureBoxNextTrack.Click += nextSong_Click;
            // 
            // pictureBoxPreviousTrack
            // 
            pictureBoxPreviousTrack.Image = (Image)resources.GetObject("pictureBoxPreviousTrack.Image");
            pictureBoxPreviousTrack.Location = new Point(556, 645);
            pictureBoxPreviousTrack.Name = "pictureBoxPreviousTrack";
            pictureBoxPreviousTrack.Size = new Size(26, 26);
            pictureBoxPreviousTrack.TabIndex = 6;
            pictureBoxPreviousTrack.TabStop = false;
            pictureBoxPreviousTrack.Click += previousSong_Click;
            // 
            // trackBar
            // 
            trackBar.LargeChange = 0;
            trackBar.Location = new Point(361, 688);
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(507, 45);
            trackBar.TabIndex = 7;
            trackBar.TickStyle = TickStyle.None;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 740);
            splitter1.TabIndex = 8;
            splitter1.TabStop = false;
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(1179, 627);
            trackBarVolume.Maximum = 100;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Orientation = Orientation.Vertical;
            trackBarVolume.Size = new Size(45, 104);
            trackBarVolume.TabIndex = 9;
            trackBarVolume.TickStyle = TickStyle.None;
            trackBarVolume.Value = 100;
            trackBarVolume.Scroll += setVolume;
            // 
            // pictureBoxSpeaker
            // 
            pictureBoxSpeaker.Image = (Image)resources.GetObject("pictureBoxSpeaker.Image");
            pictureBoxSpeaker.Location = new Point(1143, 664);
            pictureBoxSpeaker.Name = "pictureBoxSpeaker";
            pictureBoxSpeaker.Size = new Size(30, 31);
            pictureBoxSpeaker.TabIndex = 10;
            pictureBoxSpeaker.TabStop = false;
            pictureBoxSpeaker.Click += setVolumeBySpeaker;
            // 
            // pictureBoxSpeakerNoSound
            // 
            pictureBoxSpeakerNoSound.Image = (Image)resources.GetObject("pictureBoxSpeakerNoSound.Image");
            pictureBoxSpeakerNoSound.Location = new Point(1143, 664);
            pictureBoxSpeakerNoSound.Name = "pictureBoxSpeakerNoSound";
            pictureBoxSpeakerNoSound.Size = new Size(30, 31);
            pictureBoxSpeakerNoSound.TabIndex = 11;
            pictureBoxSpeakerNoSound.TabStop = false;
            pictureBoxSpeakerNoSound.Visible = false;
            pictureBoxSpeakerNoSound.Click += setVolumeBySpeaker;
            // 
            // labelTimeCounter
            // 
            labelTimeCounter.AutoSize = true;
            labelTimeCounter.BackColor = Color.Transparent;
            labelTimeCounter.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTimeCounter.ForeColor = SystemColors.ActiveCaptionText;
            labelTimeCounter.Location = new Point(329, 688);
            labelTimeCounter.Name = "labelTimeCounter";
            labelTimeCounter.Size = new Size(40, 19);
            labelTimeCounter.TabIndex = 12;
            labelTimeCounter.Text = "00:00";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.BackColor = Color.Transparent;
            labelDuration.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDuration.ForeColor = SystemColors.ActiveCaptionText;
            labelDuration.Location = new Point(865, 688);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(40, 19);
            labelDuration.TabIndex = 13;
            labelDuration.Text = "00:00";
            // 
            // pictureBoxForwards
            // 
            pictureBoxForwards.BackgroundImage = (Image)resources.GetObject("pictureBoxForwards.BackgroundImage");
            pictureBoxForwards.Image = (Image)resources.GetObject("pictureBoxForwards.Image");
            pictureBoxForwards.Location = new Point(689, 638);
            pictureBoxForwards.Name = "pictureBoxForwards";
            pictureBoxForwards.Size = new Size(39, 41);
            pictureBoxForwards.TabIndex = 14;
            pictureBoxForwards.TabStop = false;
            pictureBoxForwards.Click += fastForwardSong;
            // 
            // pictureBoxBackwards
            // 
            pictureBoxBackwards.BackgroundImage = (Image)resources.GetObject("pictureBoxBackwards.BackgroundImage");
            pictureBoxBackwards.Image = (Image)resources.GetObject("pictureBoxBackwards.Image");
            pictureBoxBackwards.Location = new Point(500, 639);
            pictureBoxBackwards.Name = "pictureBoxBackwards";
            pictureBoxBackwards.Size = new Size(39, 41);
            pictureBoxBackwards.TabIndex = 15;
            pictureBoxBackwards.TabStop = false;
            pictureBoxBackwards.Click += rewindSong;
            // 
            // pictureBoxRepeat
            // 
            pictureBoxRepeat.Image = (Image)resources.GetObject("pictureBoxRepeat.Image");
            pictureBoxRepeat.Location = new Point(750, 640);
            pictureBoxRepeat.Name = "pictureBoxRepeat";
            pictureBoxRepeat.Size = new Size(42, 36);
            pictureBoxRepeat.TabIndex = 16;
            pictureBoxRepeat.TabStop = false;
            pictureBoxRepeat.Click += changeStatus;
            // 
            // pictureBoxRepeatOne
            // 
            pictureBoxRepeatOne.Image = (Image)resources.GetObject("pictureBoxRepeatOne.Image");
            pictureBoxRepeatOne.Location = new Point(750, 640);
            pictureBoxRepeatOne.Name = "pictureBoxRepeatOne";
            pictureBoxRepeatOne.Size = new Size(42, 36);
            pictureBoxRepeatOne.TabIndex = 17;
            pictureBoxRepeatOne.TabStop = false;
            pictureBoxRepeatOne.Visible = false;
            pictureBoxRepeatOne.Click += changeStatus;
            // 
            // pictureBoxRepeatAll
            // 
            pictureBoxRepeatAll.Image = (Image)resources.GetObject("pictureBoxRepeatAll.Image");
            pictureBoxRepeatAll.Location = new Point(750, 640);
            pictureBoxRepeatAll.Name = "pictureBoxRepeatAll";
            pictureBoxRepeatAll.Size = new Size(42, 36);
            pictureBoxRepeatAll.TabIndex = 18;
            pictureBoxRepeatAll.TabStop = false;
            pictureBoxRepeatAll.Visible = false;
            pictureBoxRepeatAll.Click += changeStatus;
            // 
            // labelTitle
            // 
            labelTitle.AutoEllipsis = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = SystemColors.ActiveCaptionText;
            labelTitle.Location = new Point(83, 672);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(187, 23);
            labelTitle.TabIndex = 19;
            labelTitle.Text = "title";
            // 
            // labelArtist
            // 
            labelArtist.AutoEllipsis = true;
            labelArtist.BackColor = Color.Transparent;
            labelArtist.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelArtist.ForeColor = SystemColors.ControlDarkDark;
            labelArtist.Location = new Point(83, 695);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(110, 23);
            labelArtist.TabIndex = 20;
            labelArtist.Text = "artist";
            // 
            // pictureBoxCover
            // 
            pictureBoxCover.Image = (Image)resources.GetObject("pictureBoxCover.Image");
            pictureBoxCover.Location = new Point(12, 664);
            pictureBoxCover.MaximumSize = new Size(66, 58);
            pictureBoxCover.MinimumSize = new Size(66, 58);
            pictureBoxCover.Name = "pictureBoxCover";
            pictureBoxCover.Size = new Size(66, 58);
            pictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCover.TabIndex = 21;
            pictureBoxCover.TabStop = false;
            // 
            // pictureBoxRandom
            // 
            pictureBoxRandom.Image = (Image)resources.GetObject("pictureBoxRandom.Image");
            pictureBoxRandom.Location = new Point(435, 642);
            pictureBoxRandom.Name = "pictureBoxRandom";
            pictureBoxRandom.Size = new Size(41, 37);
            pictureBoxRandom.TabIndex = 22;
            pictureBoxRandom.TabStop = false;
            pictureBoxRandom.Click += changeRandomPlay;
            // 
            // pictureBoxRandomGreen
            // 
            pictureBoxRandomGreen.Image = (Image)resources.GetObject("pictureBoxRandomGreen.Image");
            pictureBoxRandomGreen.Location = new Point(435, 642);
            pictureBoxRandomGreen.Name = "pictureBoxRandomGreen";
            pictureBoxRandomGreen.Size = new Size(41, 37);
            pictureBoxRandomGreen.TabIndex = 23;
            pictureBoxRandomGreen.TabStop = false;
            pictureBoxRandomGreen.Visible = false;
            pictureBoxRandomGreen.Click += changeRandomPlay;
            // 
            // panelSettings
            // 
            panelSettings.Location = new Point(264, 53);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(960, 706);
            panelSettings.TabIndex = 24;
            panelSettings.Visible = false;
            panelSettings.Paint += panelSettingsPaint;
            // 
            // buttonSettings
            // 
            buttonSettings.BackColor = SystemColors.ButtonHighlight;
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSettings.ForeColor = SystemColors.ActiveCaptionText;
            buttonSettings.Location = new Point(9, 56);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(249, 44);
            buttonSettings.TabIndex = 25;
            buttonSettings.Text = "Settings";
            buttonSettings.TextAlign = ContentAlignment.MiddleLeft;
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += openSettings;
            // 
            // buttonAddPlaylist
            // 
            buttonAddPlaylist.BackColor = SystemColors.ButtonHighlight;
            buttonAddPlaylist.FlatAppearance.BorderSize = 0;
            buttonAddPlaylist.FlatStyle = FlatStyle.Flat;
            buttonAddPlaylist.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddPlaylist.ForeColor = SystemColors.ActiveCaptionText;
            buttonAddPlaylist.Location = new Point(12, 300);
            buttonAddPlaylist.Name = "buttonAddPlaylist";
            buttonAddPlaylist.Size = new Size(246, 43);
            buttonAddPlaylist.TabIndex = 26;
            buttonAddPlaylist.Text = "Add new playlist";
            buttonAddPlaylist.TextAlign = ContentAlignment.MiddleLeft;
            buttonAddPlaylist.UseVisualStyleBackColor = false;
            buttonAddPlaylist.Click += AddNewPlaylist;
            // 
            // listViewPlaylist
            // 
            listViewPlaylist.BorderStyle = BorderStyle.None;
            listViewPlaylist.Columns.AddRange(new ColumnHeader[] { Image, Number, PlayListName });
            listViewPlaylist.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listViewPlaylist.FullRowSelect = true;
            listViewPlaylist.HeaderStyle = ColumnHeaderStyle.None;
            listViewPlaylist.Location = new Point(12, 349);
            listViewPlaylist.MultiSelect = false;
            listViewPlaylist.Name = "listViewPlaylist";
            listViewPlaylist.Size = new Size(246, 309);
            listViewPlaylist.TabIndex = 27;
            listViewPlaylist.UseCompatibleStateImageBehavior = false;
            listViewPlaylist.ColumnWidthChanging += ColumnWidthChangingPlaylist;
            listViewPlaylist.SelectedIndexChanged += listViewPlaylist_SelectedIndexChanged;
            // 
            // Image
            // 
            Image.Text = "Image";
            Image.Width = 0;
            // 
            // Number
            // 
            Number.Text = "No.";
            Number.Width = 40;
            // 
            // PlayListName
            // 
            PlayListName.Text = "Playlist name";
            PlayListName.Width = 190;
            // 
            // defaultCover
            // 
            defaultCover.Image = (Image)resources.GetObject("defaultCover.Image");
            defaultCover.Location = new Point(13, 664);
            defaultCover.Name = "defaultCover";
            defaultCover.Size = new Size(65, 58);
            defaultCover.SizeMode = PictureBoxSizeMode.Zoom;
            defaultCover.TabIndex = 28;
            defaultCover.TabStop = false;
            defaultCover.Visible = false;
            // 
            // pictureBoxMinimizeApp
            // 
            pictureBoxMinimizeApp.Image = (Image)resources.GetObject("pictureBoxMinimizeApp.Image");
            pictureBoxMinimizeApp.Location = new Point(1124, 5);
            pictureBoxMinimizeApp.Name = "pictureBoxMinimizeApp";
            pictureBoxMinimizeApp.Size = new Size(42, 42);
            pictureBoxMinimizeApp.TabIndex = 0;
            pictureBoxMinimizeApp.TabStop = false;
            pictureBoxMinimizeApp.Click += MinimizeWindow;
            // 
            // pictureBoxCloseApp
            // 
            pictureBoxCloseApp.Image = (Image)resources.GetObject("pictureBoxCloseApp.Image");
            pictureBoxCloseApp.Location = new Point(1172, 5);
            pictureBoxCloseApp.Name = "pictureBoxCloseApp";
            pictureBoxCloseApp.Size = new Size(42, 42);
            pictureBoxCloseApp.TabIndex = 29;
            pictureBoxCloseApp.TabStop = false;
            pictureBoxCloseApp.Click += CloseApplication;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Bahnschrift Condensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(60, 9);
            label1.Name = "label1";
            label1.Size = new Size(129, 33);
            label1.TabIndex = 0;
            label1.Text = "Music Player";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 44);
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1226, 740);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(pictureBoxCloseApp);
            Controls.Add(pictureBoxMinimizeApp);
            Controls.Add(listViewPlaylist);
            Controls.Add(buttonAddPlaylist);
            Controls.Add(panelSettings);
            Controls.Add(buttonSettings);
            Controls.Add(pictureBoxRandomGreen);
            Controls.Add(pictureBoxRandom);
            Controls.Add(pictureBoxCover);
            Controls.Add(labelArtist);
            Controls.Add(labelTitle);
            Controls.Add(pictureBoxRepeatAll);
            Controls.Add(pictureBoxRepeatOne);
            Controls.Add(pictureBoxRepeat);
            Controls.Add(pictureBoxBackwards);
            Controls.Add(pictureBoxForwards);
            Controls.Add(labelDuration);
            Controls.Add(labelTimeCounter);
            Controls.Add(pictureBoxSpeakerNoSound);
            Controls.Add(pictureBoxSpeaker);
            Controls.Add(trackBarVolume);
            Controls.Add(splitter1);
            Controls.Add(trackBar);
            Controls.Add(pictureBoxPreviousTrack);
            Controls.Add(pictureBoxNextTrack);
            Controls.Add(pictureBoxPlayMusic);
            Controls.Add(pictureBoxStopMusic);
            Controls.Add(buttonAddSongs);
            Controls.Add(musicList);
            Controls.Add(defaultCover);
            ForeColor = SystemColors.ControlLight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Music Player";
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBoxStopMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNextTrack).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreviousTrack).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpeaker).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpeakerNoSound).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxForwards).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBackwards).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRepeat).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRepeatOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRepeatAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRandom).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRandomGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)defaultCover).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimizeApp).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCloseApp).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonAddSongs;
        private ListView musicList;
        private ColumnHeader Id;
        private ColumnHeader Cover;
        private ColumnHeader Title;
        private ColumnHeader Artist;
        private ColumnHeader Album;
        private ColumnHeader Duration;
        private PictureBox pictureBoxStopMusic;
        private PictureBox pictureBoxPlayMusic;
        private PictureBox pictureBoxNextTrack;
        private PictureBox pictureBoxPreviousTrack;
        private TrackBar trackBar;
        private Splitter splitter1;
        private TrackBar trackBarVolume;
        private PictureBox pictureBoxSpeaker;
        private PictureBox pictureBoxSpeakerNoSound;
        private Label labelTimeCounter;
        private Label labelDuration;
        private PictureBox pictureBoxForwards;
        private PictureBox pictureBoxBackwards;
        private PictureBox pictureBoxRepeat;
        private PictureBox pictureBoxRepeatOne;
        private PictureBox pictureBoxRepeatAll;
        private Label labelTitle;
        private Label labelArtist;
        private PictureBox pictureBoxCover;
        private PictureBox pictureBoxRandom;
        private PictureBox pictureBoxRandomGreen;
        private Panel panelSettings;
        private Button buttonSettings;
        private Button buttonAddPlaylist;
        private ListView listViewPlaylist;
        private ColumnHeader Image;
        private ColumnHeader Number;
        private ColumnHeader PlayListName;
        private PictureBox defaultCover;
        private PictureBox pictureBoxMinimizeApp;
        private PictureBox pictureBoxCloseApp;
        private Label label1;
        private PictureBox pictureBox1;
    }
}