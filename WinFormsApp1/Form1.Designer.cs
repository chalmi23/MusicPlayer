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
            button1 = new Button();
            musicList = new ListView();
            empty = new ColumnHeader();
            Id = new ColumnHeader();
            Cover = new ColumnHeader();
            Title = new ColumnHeader();
            Artist = new ColumnHeader();
            Album = new ColumnHeader();
            Duration = new ColumnHeader();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(148, 34);
            button1.TabIndex = 1;
            button1.Text = "add new song\r\n";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddNewSongs;
            // 
            // musicList
            // 
            musicList.Columns.AddRange(new ColumnHeader[] { empty, Id, Cover, Title, Artist, Album, Duration });
            musicList.Location = new Point(264, 12);
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
            Title.Width = 300;
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
            // button2
            // 
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(66, 375);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "play";
            button2.UseVisualStyleBackColor = true;
            button2.Click += playMusic;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1226, 706);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(musicList);
            ForeColor = SystemColors.ControlLight;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
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
        private Button button2;
    }
}