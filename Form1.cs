using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMetadata
{
    public partial class Form1 : Form
    {
        clsManageMetadata mm;

        public Form1()
        {
            InitializeComponent();
            mm = new clsManageMetadata();
        }

        private void btnMakeMetaFromPubClick(object sender, EventArgs e)
        {
            mm.listFileNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Duplicated code
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                mm.folderPath = folderBrowserDialog1.SelectedPath;
                lblFolder.Text = mm.folderPath;
            }
        }

        private void btnValidateKeyMessageNames_Click(object sender, EventArgs e)
        {
            //Iterate Source Folder Path
            mm.ListFolderNames();
            //Iterate Key Message Names in Spreadsheets
            mm.ExtractKeyMessages();
            //Compare the spreadsheet names with the source names
            mm.CompareKeyMessages();

        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            //Duplicated code
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                mm.sourcePath= folderBrowserDialog1.SelectedPath;
                lblSource.Text = mm.sourcePath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mm.sourcePath = "H:\\RATests\\code";
            mm.folderPath = "H:\\RATests\\PubForms";
        }

        private void btnValClickstreams_Click(object sender, EventArgs e)
        {

        }
    }
}
