using System.Windows.Forms;

namespace DailyBingWallpaper 
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void licenseButton_Click(object sender, System.EventArgs e)
        {
            LicenseDialog dialog = new LicenseDialog();
            dialog.Show();
        }
    }
}
