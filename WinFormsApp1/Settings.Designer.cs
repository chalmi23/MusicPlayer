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
            button2 = new Button();
            labelDark = new Label();
            pictureBoxLightMode = new PictureBox();
            pictureBoxDarkMode = new PictureBox();
            labelLight = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLightMode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDarkMode).BeginInit();
            SuspendLayout();
            // 
            // listViewDirectories
            // 
            listViewDirectories.BorderStyle = BorderStyle.None;
            listViewDirectories.Columns.AddRange(new ColumnHeader[] { empty, Id, Directory, Path });
            listViewDirectories.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            listViewDirectories.FullRowSelect = true;
            listViewDirectories.HeaderStyle = ColumnHeaderStyle.None;
            listViewDirectories.Location = new Point(392, 28);
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
            labelDirectoryList.Font = new Font("Bahnschrift Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelDirectoryList.ForeColor = SystemColors.ControlText;
            labelDirectoryList.Location = new Point(392, 0);
            labelDirectoryList.Name = "labelDirectoryList";
            labelDirectoryList.Size = new Size(104, 25);
            labelDirectoryList.TabIndex = 1;
            labelDirectoryList.Text = "Directory list";
            // 
            // buttonAddFolder
            // 
            buttonAddFolder.BackColor = SystemColors.ButtonFace;
            buttonAddFolder.FlatStyle = FlatStyle.System;
            buttonAddFolder.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddFolder.ForeColor = SystemColors.ControlText;
            buttonAddFolder.Location = new Point(392, 313);
            buttonAddFolder.Name = "buttonAddFolder";
            buttonAddFolder.Size = new Size(209, 42);
            buttonAddFolder.TabIndex = 2;
            buttonAddFolder.Text = "Add new directory";
            buttonAddFolder.UseVisualStyleBackColor = false;
            buttonAddFolder.Click += addFolder;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(721, 313);
            button2.Name = "button2";
            button2.Size = new Size(209, 42);
            button2.TabIndex = 3;
            button2.Text = "Delete selected directory";
            button2.UseVisualStyleBackColor = false;
            button2.Click += deleteFolder;
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
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(labelLight);
            Controls.Add(pictureBoxDarkMode);
            Controls.Add(pictureBoxLightMode);
            Controls.Add(labelDark);
            Controls.Add(button2);
            Controls.Add(buttonAddFolder);
            Controls.Add(labelDirectoryList);
            Controls.Add(listViewDirectories);
            Name = "Settings";
            Size = new Size(960, 706);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLightMode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDarkMode).EndInit();
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
        private Button button2;
        public Button buttonAddFolder;
        private Label labelDark;
        private PictureBox pictureBoxLightMode;
        private PictureBox pictureBoxDarkMode;
        private Label labelLight;
    }
}
