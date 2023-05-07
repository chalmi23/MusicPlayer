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
            button1 = new Button();
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(246, 43);
            button1.TabIndex = 1;
            button1.Text = "add new songs";
            button1.UseVisualStyleBackColor = false;
            button1.Click += AddNewSongsButtonClick;
            // 
            // musicList
            // 
            musicList.Columns.AddRange(new ColumnHeader[] { Cover, Id, Title, Artist, Album, Duration });
            musicList.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            musicList.FullRowSelect = true;
            musicList.HideSelection = true;
            musicList.Location = new Point(264, 12);
            musicList.MultiSelect = false;
            musicList.Name = "musicList";
            musicList.Size = new Size(950, 546);
            musicList.TabIndex = 0;
            musicList.UseCompatibleStateImageBehavior = false;
            musicList.ColumnWidthChanging += ColumnWidthChanging;
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
            pictureBoxStopMusic.Location = new Point(588, 590);
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
            pictureBoxPlayMusic.Location = new Point(588, 589);
            pictureBoxPlayMusic.Name = "pictureBoxPlayMusic";
            pictureBoxPlayMusic.Size = new Size(49, 49);
            pictureBoxPlayMusic.TabIndex = 4;
            pictureBoxPlayMusic.TabStop = false;
            pictureBoxPlayMusic.Click += playPausePictureBox_Click;
            // 
            // pictureBoxNextTrack
            // 
            pictureBoxNextTrack.Image = (Image)resources.GetObject("pictureBoxNextTrack.Image");
            pictureBoxNextTrack.Location = new Point(643, 601);
            pictureBoxNextTrack.Name = "pictureBoxNextTrack";
            pictureBoxNextTrack.Size = new Size(26, 26);
            pictureBoxNextTrack.TabIndex = 5;
            pictureBoxNextTrack.TabStop = false;
            pictureBoxNextTrack.Click += nextSong_Click;
            // 
            // pictureBoxPreviousTrack
            // 
            pictureBoxPreviousTrack.Image = (Image)resources.GetObject("pictureBoxPreviousTrack.Image");
            pictureBoxPreviousTrack.Location = new Point(556, 601);
            pictureBoxPreviousTrack.Name = "pictureBoxPreviousTrack";
            pictureBoxPreviousTrack.Size = new Size(26, 26);
            pictureBoxPreviousTrack.TabIndex = 6;
            pictureBoxPreviousTrack.TabStop = false;
            pictureBoxPreviousTrack.Click += previousSong_Click;
            // 
            // trackBar
            // 
            trackBar.LargeChange = 0;
            trackBar.Location = new Point(361, 644);
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(507, 45);
            trackBar.TabIndex = 7;
            trackBar.TickStyle = TickStyle.None;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 706);
            splitter1.TabIndex = 8;
            splitter1.TabStop = false;
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(1179, 583);
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
            pictureBoxSpeaker.Location = new Point(1143, 620);
            pictureBoxSpeaker.Name = "pictureBoxSpeaker";
            pictureBoxSpeaker.Size = new Size(30, 31);
            pictureBoxSpeaker.TabIndex = 10;
            pictureBoxSpeaker.TabStop = false;
            pictureBoxSpeaker.Click += setVolumeBySpeaker;
            // 
            // pictureBoxSpeakerNoSound
            // 
            pictureBoxSpeakerNoSound.Image = (Image)resources.GetObject("pictureBoxSpeakerNoSound.Image");
            pictureBoxSpeakerNoSound.Location = new Point(1143, 620);
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
            labelTimeCounter.BackColor = SystemColors.ButtonHighlight;
            labelTimeCounter.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTimeCounter.ForeColor = SystemColors.ActiveCaptionText;
            labelTimeCounter.Location = new Point(329, 644);
            labelTimeCounter.Name = "labelTimeCounter";
            labelTimeCounter.Size = new Size(40, 19);
            labelTimeCounter.TabIndex = 12;
            labelTimeCounter.Text = "00:00";
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.BackColor = SystemColors.ButtonHighlight;
            labelDuration.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDuration.ForeColor = SystemColors.ActiveCaptionText;
            labelDuration.Location = new Point(865, 644);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(40, 19);
            labelDuration.TabIndex = 13;
            labelDuration.Text = "00:00";
            // 
            // pictureBoxForwards
            // 
            pictureBoxForwards.BackgroundImage = (Image)resources.GetObject("pictureBoxForwards.BackgroundImage");
            pictureBoxForwards.Location = new Point(689, 594);
            pictureBoxForwards.Name = "pictureBoxForwards";
            pictureBoxForwards.Size = new Size(39, 41);
            pictureBoxForwards.TabIndex = 14;
            pictureBoxForwards.TabStop = false;
            pictureBoxForwards.Click += fastForwardSong;
            // 
            // pictureBoxBackwards
            // 
            pictureBoxBackwards.BackgroundImage = (Image)resources.GetObject("pictureBoxBackwards.BackgroundImage");
            pictureBoxBackwards.Location = new Point(500, 595);
            pictureBoxBackwards.Name = "pictureBoxBackwards";
            pictureBoxBackwards.Size = new Size(39, 41);
            pictureBoxBackwards.TabIndex = 15;
            pictureBoxBackwards.TabStop = false;
            pictureBoxBackwards.Click += rewindSong;
            // 
            // pictureBoxRepeat
            // 
            pictureBoxRepeat.Image = (Image)resources.GetObject("pictureBoxRepeat.Image");
            pictureBoxRepeat.Location = new Point(750, 596);
            pictureBoxRepeat.Name = "pictureBoxRepeat";
            pictureBoxRepeat.Size = new Size(42, 36);
            pictureBoxRepeat.TabIndex = 16;
            pictureBoxRepeat.TabStop = false;
            pictureBoxRepeat.Click += changeStatus;
            // 
            // pictureBoxRepeatOne
            // 
            pictureBoxRepeatOne.Image = (Image)resources.GetObject("pictureBoxRepeatOne.Image");
            pictureBoxRepeatOne.Location = new Point(750, 596);
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
            pictureBoxRepeatAll.Location = new Point(750, 596);
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
            labelTitle.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = SystemColors.ActiveCaptionText;
            labelTitle.Location = new Point(83, 628);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(187, 23);
            labelTitle.TabIndex = 19;
            labelTitle.Text = "title";
            // 
            // labelArtist
            // 
            labelArtist.AutoEllipsis = true;
            labelArtist.Font = new Font("Bahnschrift", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelArtist.ForeColor = SystemColors.ControlDarkDark;
            labelArtist.Location = new Point(83, 651);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(110, 23);
            labelArtist.TabIndex = 20;
            labelArtist.Text = "artist";
            // 
            // pictureBoxCover
            // 
            pictureBoxCover.Image = (Image)resources.GetObject("pictureBoxCover.Image");
            pictureBoxCover.Location = new Point(12, 620);
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
            pictureBoxRandom.Location = new Point(435, 598);
            pictureBoxRandom.Name = "pictureBoxRandom";
            pictureBoxRandom.Size = new Size(41, 37);
            pictureBoxRandom.TabIndex = 22;
            pictureBoxRandom.TabStop = false;
            pictureBoxRandom.Click += changeRandomPlay;
            // 
            // pictureBoxRandomGreen
            // 
            pictureBoxRandomGreen.Image = (Image)resources.GetObject("pictureBoxRandomGreen.Image");
            pictureBoxRandomGreen.Location = new Point(435, 598);
            pictureBoxRandomGreen.Name = "pictureBoxRandomGreen";
            pictureBoxRandomGreen.Size = new Size(41, 37);
            pictureBoxRandomGreen.TabIndex = 23;
            pictureBoxRandomGreen.TabStop = false;
            pictureBoxRandomGreen.Visible = false;
            pictureBoxRandomGreen.Click += changeRandomPlay;
            // 
            // panelSettings
            // 
            panelSettings.Location = new Point(264, 0);
            panelSettings.Name = "panelSettings";
            panelSettings.Size = new Size(960, 706);
            panelSettings.TabIndex = 24;
            panelSettings.Visible = false;
            panelSettings.Paint += panelSettingsPaint;
            // 
            // buttonSettings
            // 
            buttonSettings.BackColor = SystemColors.ButtonFace;
            buttonSettings.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSettings.ForeColor = SystemColors.ActiveCaptionText;
            buttonSettings.Location = new Point(12, 61);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(246, 43);
            buttonSettings.TabIndex = 25;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += openSettings;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1226, 706);
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
            Controls.Add(button1);
            Controls.Add(musicList);
            ForeColor = SystemColors.ControlLight;
            Name = "Form1";
            Text = "Form1";
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
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
    }
}