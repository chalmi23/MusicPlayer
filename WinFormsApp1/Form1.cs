namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details; // W��czenie wy�wietlania nag��wk�w

            musicList.Columns.Add("Tytu�", 150);
            musicList.Columns.Add("Wykonawca", 150);
            musicList.Columns.Add("Album", 150);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Utw�rz obiekt okna dialogowego OpenFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Ustawienie w�a�ciwo�ci okna dialogowego
            openFileDialog1.Title = "Wybierz plik muzyczny";
            openFileDialog1.Filter = "Pliki muzyczne (*.mp3, *.wav, *.mp4)|*.mp3;*.wav;*.mp4";
            openFileDialog1.Multiselect = true;

            // Wy�wietlenie okna dialogowego i sprawdzenie, czy u�ytkownik wybra� plik
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Dodanie wybranego pliku do kontrolki ListView
                foreach (string file in openFileDialog1.FileNames)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = System.IO.Path.GetFileNameWithoutExtension(file);
                    item.SubItems.Add(System.IO.Path.GetExtension(file));
                    item.SubItems.Add(file);
                    musicList.Items.Add(item);
                }
            }
        }


    }
}