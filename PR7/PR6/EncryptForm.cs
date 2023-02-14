namespace PR6
{
    public partial class EncryptForm : Form
    {
        RSA rsa;
        public EncryptForm()
        {
            InitializeComponent();

        }

        private void PathButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                PathTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(PathTextBox.Text, "*", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                MessageBox.Show($"Выбранный каталог не содержит файлов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in files)
                {
                    var savePath = FolderBrowserDialog.SelectedPath+item.Remove(0,PathTextBox.Text.Length);
                    if (File.Exists(item))
                    {
                        byte[] file = File.ReadAllBytes(item);
                        int[] key = KeyTextBox.Text.Split(",").Select(s => Int32.Parse(s)).ToArray();
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        File.WriteAllBytes(savePath, rsa.Encrypt(file, key[0], key[1]));
                    }
                    else
                    {
                        MessageBox.Show($"Файл {item} не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Файлы зашифрованы");
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(PathTextBox.Text, "*", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                MessageBox.Show($"Выбранный каталог не содержит файлов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in files)
                {
                    var savePath = FolderBrowserDialog.SelectedPath + item.Remove(0, PathTextBox.Text.Length);
                    if (File.Exists(item))
                    {
                        byte[] file = File.ReadAllBytes(item);
                        int[] key = KeyTextBox.Text.Split(",").Select(s => Int32.Parse(s)).ToArray();
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        File.WriteAllBytes(savePath, rsa.Decrypt(file));
                    }
                    else
                    {
                        MessageBox.Show($"Файл {item} не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Файлы расшифрованы");
            }
        }

        private void EncryptForm_Load(object sender, EventArgs e)
        {
            if (PR7.Properties.Settings.Default.D == 0 || PR7.Properties.Settings.Default.E == 0 || PR7.Properties.Settings.Default.N == 0)
            {
                rsa = new RSA();
                PR7.Properties.Settings.Default.E = rsa.E;
                PR7.Properties.Settings.Default.D = rsa.D;
                PR7.Properties.Settings.Default.N = rsa.N;
                PR7.Properties.Settings.Default.Save();
            }
            else
            {
                rsa = new RSA(PR7.Properties.Settings.Default.E, PR7.Properties.Settings.Default.D, PR7.Properties.Settings.Default.N);
            }
            KeyTextBox.Text = $"{rsa.E},{rsa.N}";
        }

        private void RenewKeyButton_Click(object sender, EventArgs e)
        {
            rsa = new RSA();
            PR7.Properties.Settings.Default.E = rsa.E;
            PR7.Properties.Settings.Default.D = rsa.D;
            PR7.Properties.Settings.Default.N = rsa.N;
            PR7.Properties.Settings.Default.Save();
            KeyTextBox.Text = $"{rsa.E},{rsa.N}";
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            KeyTextBox.Text = $"{rsa.E},{rsa.N}";
        }
    }
}