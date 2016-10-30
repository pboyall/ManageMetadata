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
            mm.initialise();
            mm.createMetadata();
            
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
                mm.FolderPath = folderBrowserDialog1.SelectedPath;
                lblFolder.Text = mm.FolderPath;
            }
        }

        private void btnValidateKeyMessageNames_Click(object sender, EventArgs e)
        {
            mm.initialise();
            mm.validateKeyMessages();
            //Populate Treeview
            SortedDictionary<string, string> KeyMessages = mm.getPresentationsAndKeyMessages();
            this.trvPresentations.BeginUpdate();
            this.trvPresentations.Nodes.Clear();
            //this.trvPresentations.Nodes.Add(mm.getProjectName());
            
            foreach (var v in  KeyMessages.Values.Distinct())
            {
                this.trvPresentations.Nodes.Add(v.ToString(), v.ToString());
            }
            this.trvPresentations.EndUpdate();
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
            mm.sourcePath = "e:\\Code\\ra_uk_2016_veeva";
            mm.FolderPath = "e:\\ManageMetadataSource\\Publishing Forms";
            mm.mappingfiles = "e:\\ManageMetadataSource\\Original Publishing Forms";
            mm.clickstreamfile = "e:\\ManageMetadataSource\\Clickstreams\\ClickstreamReport.xlsx";
            mm.presrepfile = "e:\\ManageMetadataSource\\Clickstreams\\PresentationReport.xlsx";
        }

        private void btnValClickstreams_Click(object sender, EventArgs e)
        {
            mm.validateClickstreams();
        }

        private void btnMakeSourceFolders_Click(object sender, EventArgs e)
        {
            //Based on the publishing form, 
        }

        private void btnRenameZips_Click(object sender, EventArgs e)
        {
            mm.initialise();
            mm.RenameZips();
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            //Duplicated code
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                mm.mappingfiles = folderBrowserDialog1.SelectedPath;
                lblMapping.Text = mm.mappingfiles;
            }
        }

        private void btnClickstreamFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Clickstream File";
            theDialog.Filter = "XLSX files|*.xlsx";
            theDialog.InitialDirectory = mm.FolderPath;
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                this.lblClickstream.Text = theDialog.FileName.ToString();
                mm.clickstreamfile = this.lblClickstream.Text;
            }

        }

        private void btnValidatePresentations_Click(object sender, EventArgs e)
        {
            mm.validatePresentations();
        }

        private void btnPresentationReport_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Presentation Report File";
            theDialog.Filter = "XLSX files|*.xlsx";
            theDialog.InitialDirectory = mm.FolderPath;
            DialogResult result = theDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                this.lblPresentations.Text = theDialog.FileName.ToString();
                mm.presrepfile = this.lblPresentations.Text;
            }
        }
    }
}
