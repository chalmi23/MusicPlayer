namespace WinFormsApp1
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
            listViewDirectories = new ListView();
            empty = new ColumnHeader();
            Id = new ColumnHeader();
            Directory = new ColumnHeader();
            Path = new ColumnHeader();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listViewDirectories
            // 
            listViewDirectories.Columns.AddRange(new ColumnHeader[] { empty, Id, Directory, Path });
            listViewDirectories.Font = new Font("Bahnschrift Condensed", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listViewDirectories.FullRowSelect = true;
            listViewDirectories.Location = new Point(419, 28);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift Condensed", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(419, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 1;
            label1.Text = "Directory list";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(419, 313);
            button1.Name = "button1";
            button1.Size = new Size(209, 42);
            button1.TabIndex = 2;
            button1.Text = "Add new directory";
            button1.UseVisualStyleBackColor = false;
            button1.Click += addFolder;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(748, 313);
            button2.Name = "button2";
            button2.Size = new Size(209, 42);
            button2.TabIndex = 3;
            button2.Text = "Delete selected directory";
            button2.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(listViewDirectories);
            Name = "Settings";
            Size = new Size(960, 706);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listViewDirectories;
        private Label label1;
        private Button button1;
        private ColumnHeader empty;
        private ColumnHeader Id;
        private ColumnHeader Directory;
        private ColumnHeader Path;
        private Button button2;
    }
}
