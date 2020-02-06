using System;
using System.IO;
using System.Windows.Forms;

namespace DailyBingWallpaper 
{
    public partial class LicenseDialog : Form
    {
        const string LicenseFileName = "LICENSE.txt";

        public LicenseDialog()
        {
            InitializeComponent();

            Activated += (sender, args) =>
            {
                licenseTextBox.Text = LoadLicenseText();
            };
        }

        private string LoadLicenseText()
        {
            var path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), LicenseFileName);

            return File.ReadAllText(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
