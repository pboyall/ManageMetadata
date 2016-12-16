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
            SortedDictionary<string, string> KeyMessages = mm.getPresentationsAndKeyMessages();     //KeyMessage, PresID
            
            this.trvPresentations.BeginUpdate();
            this.trvPresentations.Nodes.Clear();
            //this.trvPresentations.Nodes.Add(mm.getProjectName());
            //Add Presentation Names

            List<String> PresentationList = new List<String>();
            PresentationList = KeyMessages.Values.Distinct().ToList();
            PresentationList.Sort();

            foreach (var v in PresentationList)
            {
                this.trvPresentations.Nodes.Add(v.ToString(), v.ToString());
            }
            //For each presentation add the key messages
            foreach( TreeNode node in trvPresentations.Nodes)
            {
                //Get Key messages for this presentation
                var x = mm.getSortedKeyMessages(node.Text.ToString());
                //var k = from item in KeyMessages where item.Value.ToString() == node.Text.ToString() select item.Key.ToString();
                //foreach (var j in x)
                //{node.Nodes.Add(j.ToString());}
                foreach (var j in x) {
                    node.Nodes.Add(j.Value.ToString());
                }
            }
            this.trvPresentations.EndUpdate();

            this.trvSharedKeyMessages.BeginUpdate();
            this.trvSharedKeyMessages.Nodes.Clear();
            SortedDictionary<string, string> SharedKeyMessages = mm.getSharedKeyMessages();
            foreach (var v in SharedKeyMessages.ToList())
            {
                TreeNode thisNode = this.trvSharedKeyMessages.Nodes.Add(v.Value.ToString());
                thisNode.Nodes.Add(v.Key.ToString());
            }

            this.trvSharedKeyMessages.EndUpdate();

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
            mm.sourcePath = "G:\\Code\\axial_spa";
            mm.FolderPath = "G:\\ManageMetadataSource\\Publishing Forms";
            mm.mappingfiles = "G:\\ManageMetadataSource\\Original Publishing Forms";
            mm.clickstreamfile = "G:\\ManageMetadataSource\\Clickstreams\\ClickstreamReport.xlsx";
            mm.presrepfile = "G:\\ManageMetadataSource\\Clickstreams\\PresentationReport.xlsx";
        }

        private void btnValClickstreams_Click(object sender, EventArgs e)
        {
            mm.initialise();
            mm.validateClickstreams();
        }

        private void btnMakeSourceFolders_Click(object sender, EventArgs e)
        {
            //Based on the publishing form, create all the source folders
            mm.initialise();
            mm.CreateFolders();

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
            mm.initialise();
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

        private void btnExtractFromPDF_Click(object sender, EventArgs e)
        {

        }
    }
}
