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
            empty = new ColumnHeader();
            Id = new ColumnHeader();
            Cover = new ColumnHeader();
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
            ((System.ComponentModel.ISupportInitialize)pictureBoxStopMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNextTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreviousTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpeaker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpeakerNoSound).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(204, 43);
            button1.TabIndex = 1;
            button1.Text = "add new songs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddNewSongs;
            // 
            // musicList
            // 
            musicList.Columns.AddRange(new ColumnHeader[] { empty, Id, Cover, Title, Artist, Album, Duration });
            musicList.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            musicList.HideSelection = true;
            musicList.Location = new Point(264, 12);
            musicList.MultiSelect = false;
            musicList.Name = "musicList";
            musicList.Size = new Size(950, 546);
            musicList.TabIndex = 0;
            musicList.UseCompatibleStateImageBehavior = false;
            musicList.ColumnWidthChanging += ColumnWidthChanging;
            musicList.Click += playMusic;
            // 
            // empty
            // 
            empty.Width = 0;
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 65;
            // 
            // Cover
            // 
            Cover.Text = "Cover";
            Cover.Width = 100;
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 280;
            // 
            // Artist
            // 
            Artist.Text = "Artist";
            Artist.Width = 150;
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
            pictureBoxStopMusic.Location = new Point(665, 578);
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
            pictureBoxPlayMusic.Location = new Point(665, 577);
            pictureBoxPlayMusic.Name = "pictureBoxPlayMusic";
            pictureBoxPlayMusic.Size = new Size(49, 49);
            pictureBoxPlayMusic.TabIndex = 4;
            pictureBoxPlayMusic.TabStop = false;
            pictureBoxPlayMusic.Click += playPausePictureBox_Click;
            // 
            // pictureBoxNextTrack
            // 
            pictureBoxNextTrack.Image = (Image)resources.GetObject("pictureBoxNextTrack.Image");
            pictureBoxNextTrack.Location = new Point(749, 589);
            pictureBoxNextTrack.Name = "pictureBoxNextTrack";
            pictureBoxNextTrack.Size = new Size(26, 26);
            pictureBoxNextTrack.TabIndex = 5;
            pictureBoxNextTrack.TabStop = false;
            pictureBoxNextTrack.Click += nextSong_Click;
            // 
            // pictureBoxPreviousTrack
            // 
            pictureBoxPreviousTrack.Image = (Image)resources.GetObject("pictureBoxPreviousTrack.Image");
            pictureBoxPreviousTrack.Location = new Point(601, 589);
            pictureBoxPreviousTrack.Name = "pictureBoxPreviousTrack";
            pictureBoxPreviousTrack.Size = new Size(26, 26);
            pictureBoxPreviousTrack.TabIndex = 6;
            pictureBoxPreviousTrack.TabStop = false;
            pictureBoxPreviousTrack.Click += previousSong_Click;
            // 
            // trackBar
            // 
            trackBar.LargeChange = 0;
            trackBar.Location = new Point(441, 632);
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
            trackBarVolume.Location = new Point(1169, 577);
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
            pictureBoxSpeaker.Location = new Point(1133, 614);
            pictureBoxSpeaker.Name = "pictureBoxSpeaker";
            pictureBoxSpeaker.Size = new Size(30, 31);
            pictureBoxSpeaker.TabIndex = 10;
            pictureBoxSpeaker.TabStop = false;
            pictureBoxSpeaker.Click += setVolumeBySpeaker;
            // 
            // pictureBoxSpeakerNoSound
            // 
            pictureBoxSpeakerNoSound.Image = (Image)resources.GetObject("pictureBoxSpeakerNoSound.Image");
            pictureBoxSpeakerNoSound.Location = new Point(1133, 614);
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
            labelTimeCounter.Location = new Point(409, 632);
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
            labelDuration.Location = new Point(945, 632);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(40, 19);
            labelDuration.TabIndex = 13;
            labelDuration.Text = "00:00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1226, 706);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private ListView musicList;
        private ColumnHeader empty;
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
    }
}