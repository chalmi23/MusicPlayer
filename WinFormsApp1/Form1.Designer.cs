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
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStopMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNextTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreviousTrack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
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
            pictureBoxStopMusic.Location = new Point(672, 577);
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
            pictureBoxPlayMusic.Location = new Point(672, 576);
            pictureBoxPlayMusic.Name = "pictureBoxPlayMusic";
            pictureBoxPlayMusic.Size = new Size(49, 49);
            pictureBoxPlayMusic.TabIndex = 4;
            pictureBoxPlayMusic.TabStop = false;
            pictureBoxPlayMusic.Click += playPausePictureBox_Click;
            // 
            // pictureBoxNextTrack
            // 
            pictureBoxNextTrack.Image = (Image)resources.GetObject("pictureBoxNextTrack.Image");
            pictureBoxNextTrack.Location = new Point(756, 588);
            pictureBoxNextTrack.Name = "pictureBoxNextTrack";
            pictureBoxNextTrack.Size = new Size(26, 26);
            pictureBoxNextTrack.TabIndex = 5;
            pictureBoxNextTrack.TabStop = false;
            pictureBoxNextTrack.Click += nextSong_Click;
            // 
            // pictureBoxPreviousTrack
            // 
            pictureBoxPreviousTrack.Image = (Image)resources.GetObject("pictureBoxPreviousTrack.Image");
            pictureBoxPreviousTrack.Location = new Point(608, 588);
            pictureBoxPreviousTrack.Name = "pictureBoxPreviousTrack";
            pictureBoxPreviousTrack.Size = new Size(26, 26);
            pictureBoxPreviousTrack.TabIndex = 6;
            pictureBoxPreviousTrack.TabStop = false;
            pictureBoxPreviousTrack.Click += previousSong_Click;
            // 
            // trackBar
            // 
            trackBar.Location = new Point(441, 649);
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(507, 45);
            trackBar.TabIndex = 7;
            trackBar.TickStyle = TickStyle.None;
            // 
            // button2
            // 
            button2.Location = new Point(50, 266);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1226, 706);
            Controls.Add(button2);
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
        private Button button2;
    }
}