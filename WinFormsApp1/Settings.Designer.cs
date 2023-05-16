﻿namespace WinFormsApp1
{
    partial class Settings
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            listViewDirectories = new ListView();
            empty = new ColumnHeader();
            Id = new ColumnHeader();
            Directory = new ColumnHeader();
            Path = new ColumnHeader();
            labelDirectoryList = new Label();
            buttonAddFolder = new Button();
            buttonDeleteFolder = new Button();
            labelDark = new Label();
            pictureBoxLightMode = new PictureBox();
            pictureBoxDarkMode = new PictureBox();
            labelLight = new Label();
            trackBar1 = new TrackBar();
            checkBox1 = new CheckBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLightMode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDarkMode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // listViewDirectories
            // 
            listViewDirectories.BorderStyle = BorderStyle.None;
            listViewDirectories.Columns.AddRange(new ColumnHeader[] { empty, Id, Directory, Path });
            listViewDirectories.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listViewDirectories.FullRowSelect = true;
            listViewDirectories.HeaderStyle = ColumnHeaderStyle.None;
            listViewDirectories.Location = new Point(458, 57);
            listViewDirectories.MultiSelect = false;
            listViewDirectories.Name = "listViewDirectories";
            listViewDirectories.Size = new Size(538, 279);
            listViewDirectories.TabIndex = 0;
            listViewDirectories.UseCompatibleStateImageBehavior = false;
            // 
            // empty
            // 
            empty.Width = 0;
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 100;
            // 
            // Directory
            // 
            Directory.Text = "Directory";
            Directory.Width = 175;
            // 
            // Path
            // 
            Path.Text = "Path";
            Path.Width = 250;
            // 
            // labelDirectoryList
            // 
            labelDirectoryList.AutoSize = true;
            labelDirectoryList.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            labelDirectoryList.ForeColor = SystemColors.ControlText;
            labelDirectoryList.Location = new Point(458, 13);
            labelDirectoryList.Name = "labelDirectoryList";
            labelDirectoryList.Size = new Size(117, 29);
            labelDirectoryList.TabIndex = 1;
            labelDirectoryList.Text = "Directory list";
            // 
            // buttonAddFolder
            // 
            buttonAddFolder.BackColor = SystemColors.ButtonHighlight;
            buttonAddFolder.FlatAppearance.BorderSize = 0;
            buttonAddFolder.FlatStyle = FlatStyle.Flat;
            buttonAddFolder.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddFolder.ForeColor = SystemColors.ControlText;
            buttonAddFolder.Location = new Point(594, 9);
            buttonAddFolder.Name = "buttonAddFolder";
            buttonAddFolder.Size = new Size(198, 42);
            buttonAddFolder.TabIndex = 2;
            buttonAddFolder.Text = "Add new directory";
            buttonAddFolder.TextAlign = ContentAlignment.MiddleLeft;
            buttonAddFolder.UseVisualStyleBackColor = false;
            buttonAddFolder.Click += addFolder;
            // 
            // buttonDeleteFolder
            // 
            buttonDeleteFolder.BackColor = SystemColors.ButtonHighlight;
            buttonDeleteFolder.FlatAppearance.BorderSize = 0;
            buttonDeleteFolder.FlatStyle = FlatStyle.Flat;
            buttonDeleteFolder.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDeleteFolder.ForeColor = Color.Red;
            buttonDeleteFolder.Location = new Point(798, 9);
            buttonDeleteFolder.Name = "buttonDeleteFolder";
            buttonDeleteFolder.Size = new Size(198, 42);
            buttonDeleteFolder.TabIndex = 3;
            buttonDeleteFolder.Text = "Delete selected directory";
            buttonDeleteFolder.TextAlign = ContentAlignment.MiddleLeft;
            buttonDeleteFolder.UseVisualStyleBackColor = false;
            buttonDeleteFolder.Click += deleteFolder;
            // 
            // labelDark
            // 
            labelDark.AutoSize = true;
            labelDark.BackColor = Color.Transparent;
            labelDark.Font = new Font("Bahnschrift Condensed", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelDark.ForeColor = SystemColors.ControlText;
            labelDark.Location = new Point(48, 30);
            labelDark.Name = "labelDark";
            labelDark.Size = new Size(131, 39);
            labelDark.TabIndex = 4;
            labelDark.Text = "Dark mode";
            labelDark.Click += changeMode;
            // 
            // pictureBoxLightMode
            // 
            pictureBoxLightMode.Image = (Image)resources.GetObject("pictureBoxLightMode.Image");
            pictureBoxLightMode.Location = new Point(185, 28);
            pictureBoxLightMode.Name = "pictureBoxLightMode";
            pictureBoxLightMode.Size = new Size(42, 41);
            pictureBoxLightMode.TabIndex = 5;
            pictureBoxLightMode.TabStop = false;
            pictureBoxLightMode.Visible = false;
            pictureBoxLightMode.Click += changeMode;
            // 
            // pictureBoxDarkMode
            // 
            pictureBoxDarkMode.Image = (Image)resources.GetObject("pictureBoxDarkMode.Image");
            pictureBoxDarkMode.Location = new Point(185, 28);
            pictureBoxDarkMode.Name = "pictureBoxDarkMode";
            pictureBoxDarkMode.Size = new Size(42, 41);
            pictureBoxDarkMode.TabIndex = 6;
            pictureBoxDarkMode.TabStop = false;
            pictureBoxDarkMode.Click += changeMode;
            // 
            // labelLight
            // 
            labelLight.AutoSize = true;
            labelLight.BackColor = Color.Transparent;
            labelLight.Font = new Font("Bahnschrift Condensed", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelLight.ForeColor = SystemColors.ButtonHighlight;
            labelLight.Location = new Point(48, 30);
            labelLight.Name = "labelLight";
            labelLight.Size = new Size(133, 39);
            labelLight.TabIndex = 7;
            labelLight.Text = "Light mode";
            labelLight.Visible = false;
            labelLight.Click += changeMode;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(48, 171);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(141, 45);
            trackBar1.TabIndex = 8;
            trackBar1.TickStyle = TickStyle.None;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Bahnschrift Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.ForeColor = SystemColors.ControlText;
            checkBox1.Location = new Point(48, 132);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(173, 33);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "smooth transition";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(185, 168);
            label1.Name = "label1";
            label1.Size = new Size(29, 23);
            label1.TabIndex = 10;
            label1.Text = "0 s";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(trackBar1);
            Controls.Add(labelLight);
            Controls.Add(pictureBoxDarkMode);
            Controls.Add(pictureBoxLightMode);
            Controls.Add(labelDark);
            Controls.Add(buttonDeleteFolder);
            Controls.Add(buttonAddFolder);
            Controls.Add(labelDirectoryList);
            Controls.Add(listViewDirectories);
            Name = "Settings";
            Size = new Size(1003, 653);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLightMode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDarkMode).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewDirectories;
        private Label labelDirectoryList;
        private ColumnHeader empty;
        private ColumnHeader Id;
        private ColumnHeader Directory;
        private ColumnHeader Path;
        private Button buttonDeleteFolder;
        public Button buttonAddFolder;
        private Label labelDark;
        private PictureBox pictureBoxLightMode;
        private PictureBox pictureBoxDarkMode;
        private Label labelLight;
        private TrackBar trackBar1;
        private CheckBox checkBox1;
        private Label label1;
    }
}
