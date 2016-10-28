namespace ManageMetadata
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("80.123.KeyMessage1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("HUM_ABV_LO_02", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("HUM_ABV_LO_03");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("HUM_ABV_LO", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.btnMakeMetaFromPub = new System.Windows.Forms.Button();
            this.btnValidateKeyMessageNames = new System.Windows.Forms.Button();
            this.btnExtractFromPDF = new System.Windows.Forms.Button();
            this.btnValClickstreams = new System.Windows.Forms.Button();
            this.btnValKeyMsgNames = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblFolder = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.trvPresentations = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.btnMakeSourceFolders = new System.Windows.Forms.Button();
            this.btnRenameZips = new System.Windows.Forms.Button();
            this.btnMapping = new System.Windows.Forms.Button();
            this.lblMapping = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMakeMetaFromPub
            // 
            this.btnMakeMetaFromPub.Location = new System.Drawing.Point(12, 150);
            this.btnMakeMetaFromPub.Name = "btnMakeMetaFromPub";
            this.btnMakeMetaFromPub.Size = new System.Drawing.Size(174, 23);
            this.btnMakeMetaFromPub.TabIndex = 0;
            this.btnMakeMetaFromPub.Text = "MakeMetaFromPub";
            this.btnMakeMetaFromPub.UseVisualStyleBackColor = true;
            this.btnMakeMetaFromPub.Click += new System.EventHandler(this.btnMakeMetaFromPubClick);
            // 
            // btnValidateKeyMessageNames
            // 
            this.btnValidateKeyMessageNames.Location = new System.Drawing.Point(12, 179);
            this.btnValidateKeyMessageNames.Name = "btnValidateKeyMessageNames";
            this.btnValidateKeyMessageNames.Size = new System.Drawing.Size(174, 23);
            this.btnValidateKeyMessageNames.TabIndex = 1;
            this.btnValidateKeyMessageNames.Text = "ValidateKeyMessageNames";
            this.btnValidateKeyMessageNames.UseVisualStyleBackColor = true;
            this.btnValidateKeyMessageNames.Click += new System.EventHandler(this.btnValidateKeyMessageNames_Click);
            // 
            // btnExtractFromPDF
            // 
            this.btnExtractFromPDF.Location = new System.Drawing.Point(12, 121);
            this.btnExtractFromPDF.Name = "btnExtractFromPDF";
            this.btnExtractFromPDF.Size = new System.Drawing.Size(174, 23);
            this.btnExtractFromPDF.TabIndex = 2;
            this.btnExtractFromPDF.Text = "ExtractFromPDF";
            this.btnExtractFromPDF.UseVisualStyleBackColor = true;
            // 
            // btnValClickstreams
            // 
            this.btnValClickstreams.Location = new System.Drawing.Point(12, 208);
            this.btnValClickstreams.Name = "btnValClickstreams";
            this.btnValClickstreams.Size = new System.Drawing.Size(174, 23);
            this.btnValClickstreams.TabIndex = 3;
            this.btnValClickstreams.Text = "ValidateClickstreams";
            this.btnValClickstreams.UseVisualStyleBackColor = true;
            this.btnValClickstreams.Click += new System.EventHandler(this.btnValClickstreams_Click);
            // 
            // btnValKeyMsgNames
            // 
            this.btnValKeyMsgNames.Location = new System.Drawing.Point(12, 86);
            this.btnValKeyMsgNames.Name = "btnValKeyMsgNames";
            this.btnValKeyMsgNames.Size = new System.Drawing.Size(174, 23);
            this.btnValKeyMsgNames.TabIndex = 1;
            this.btnValKeyMsgNames.Text = "ValidateKeyMessageNames";
            this.btnValKeyMsgNames.UseVisualStyleBackColor = true;
            this.btnValKeyMsgNames.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(180, 13);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(83, 13);
            this.lblFolder.TabIndex = 4;
            this.lblFolder.Text = "Metadata Forms";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(269, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // trvPresentations
            // 
            this.trvPresentations.Location = new System.Drawing.Point(395, 8);
            this.trvPresentations.Name = "trvPresentations";
            treeNode1.Name = "80.123.KeyMessage1";
            treeNode1.Text = "80.123.KeyMessage1";
            treeNode2.Name = "HUM_ABV_LO_02";
            treeNode2.Text = "HUM_ABV_LO_02";
            treeNode3.Name = "HUM_ABV_LO_03";
            treeNode3.Text = "HUM_ABV_LO_03";
            treeNode4.Name = "HUM_ABV_LO";
            treeNode4.Text = "HUM_ABV_LO";
            this.trvPresentations.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.trvPresentations.Size = new System.Drawing.Size(369, 223);
            this.trvPresentations.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Metadata Forms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Source Code";
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(269, 35);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 9;
            this.btnBrowseSource.Text = "browse";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(180, 40);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(41, 13);
            this.lblSource.TabIndex = 8;
            this.lblSource.Text = "Source";
            // 
            // btnMakeSourceFolders
            // 
            this.btnMakeSourceFolders.Location = new System.Drawing.Point(192, 121);
            this.btnMakeSourceFolders.Name = "btnMakeSourceFolders";
            this.btnMakeSourceFolders.Size = new System.Drawing.Size(174, 23);
            this.btnMakeSourceFolders.TabIndex = 11;
            this.btnMakeSourceFolders.Text = "MakeSourceFolders";
            this.btnMakeSourceFolders.UseVisualStyleBackColor = true;
            this.btnMakeSourceFolders.Click += new System.EventHandler(this.btnMakeSourceFolders_Click);
            // 
            // btnRenameZips
            // 
            this.btnRenameZips.Location = new System.Drawing.Point(192, 150);
            this.btnRenameZips.Name = "btnRenameZips";
            this.btnRenameZips.Size = new System.Drawing.Size(174, 23);
            this.btnRenameZips.TabIndex = 12;
            this.btnRenameZips.Text = "RenameZips";
            this.btnRenameZips.UseVisualStyleBackColor = true;
            this.btnRenameZips.Click += new System.EventHandler(this.btnRenameZips_Click);
            // 
            // btnMapping
            // 
            this.btnMapping.Location = new System.Drawing.Point(269, 61);
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(75, 23);
            this.btnMapping.TabIndex = 14;
            this.btnMapping.Text = "browse";
            this.btnMapping.UseVisualStyleBackColor = true;
            this.btnMapping.Click += new System.EventHandler(this.btnMapping_Click);
            // 
            // lblMapping
            // 
            this.lblMapping.AutoSize = true;
            this.lblMapping.Location = new System.Drawing.Point(180, 66);
            this.lblMapping.Name = "lblMapping";
            this.lblMapping.Size = new System.Drawing.Size(48, 13);
            this.lblMapping.TabIndex = 13;
            this.lblMapping.Text = "Mapping";
            this.lblMapping.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 261);
            this.Controls.Add(this.btnMapping);
            this.Controls.Add(this.lblMapping);
            this.Controls.Add(this.btnRenameZips);
            this.Controls.Add(this.btnMakeSourceFolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trvPresentations);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnValClickstreams);
            this.Controls.Add(this.btnExtractFromPDF);
            this.Controls.Add(this.btnValidateKeyMessageNames);
            this.Controls.Add(this.btnMakeMetaFromPub);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMakeMetaFromPub;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnValidateKeyMessageNames;
        private System.Windows.Forms.Button btnExtractFromPDF;
        private System.Windows.Forms.Button btnValClickstreams;
        private System.Windows.Forms.Button btnValKeyMsgNames;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TreeView trvPresentations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Button btnMakeSourceFolders;
        private System.Windows.Forms.Button btnRenameZips;
        private System.Windows.Forms.Button btnMapping;
        private System.Windows.Forms.Label lblMapping;
    }
}

