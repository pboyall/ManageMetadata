﻿using System;
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
            mm.validateKeyMessages();
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
            mm.sourcePath = "G:\\Code\\ra_uk_2016_veeva";
            mm.FolderPath = "G:\\ManageMetadataSource\\Publishing Forms";
            mm.mappingfiles = "G:\\ManageMetadataSource\\Original Publishing Forms";
        }

        private void btnValClickstreams_Click(object sender, EventArgs e)
        {

        }

        private void btnMakeSourceFolders_Click(object sender, EventArgs e)
        {

        }

        private void btnRenameZips_Click(object sender, EventArgs e)
        {
            mm.RenameZips();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
    }
}
