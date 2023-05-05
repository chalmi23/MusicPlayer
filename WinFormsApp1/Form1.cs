namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            musicList.View = View.Details; // W³¹czenie wyœwietlania nag³ówków

            musicList.Columns.Add("Tytu³", 150);
            musicList.Columns.Add("Wykonawca", 150);
            musicList.Columns.Add("Album", 150);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Utwórz obiekt okna dialogowego OpenFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Ustawienie w³aœciwoœci okna dialogowego
            openFileDialog1.Title = "Wybierz plik muzyczny";
            openFileDialog1.Filter = "Pliki muzyczne (*.mp3, *.wav, *.mp4)|*.mp3;*.wav;*.mp4";
            openFileDialog1.Multiselect = true;

            // Wyœwietlenie okna dialogowego i sprawdzenie, czy u¿ytkownik wybra³ plik
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