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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(622, 600);
            button1.Name = "button1";
            button1.Size = new Size(108, 48);
            button1.TabIndex = 1;
            button1.Text = "add new song";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // musicList
            // 
            musicList.Location = new Point(267, 12);
            musicList.Name = "musicList";
            musicList.Size = new Size(947, 546);
            musicList.TabIndex = 0;
            musicList.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1226, 706);
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
    }
}