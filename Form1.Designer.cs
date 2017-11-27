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
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.btnMakeSourceFolders = new System.Windows.Forms.Button();
            this.btnRenameZips = new System.Windows.Forms.Button();
            this.btnMapping = new System.Windows.Forms.Button();
            this.lblMapping = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClickstream = new System.Windows.Forms.Label();
            this.btnClickstreamFile = new System.Windows.Forms.Button();
            this.Clickstream = new System.Windows.Forms.Label();
            this.btnValidatePresentations = new System.Windows.Forms.Button();
            this.lblPresentations = new System.Windows.Forms.Label();
            this.btnPresentationReport = new System.Windows.Forms.Button();
            this.lblPresReports = new System.Windows.Forms.Label();
            this.trvSharedKeyMessages = new System.Windows.Forms.TreeView();
            this.lblSharedKeys = new System.Windows.Forms.Label();
            this.btnSpA = new System.Windows.Forms.Button();
            this.btnPSA = new System.Windows.Forms.Button();
            this.btnUVE = new System.Windows.Forms.Button();
            this.txtMetadata = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtPrevMetadata = new System.Windows.Forms.TextBox();
            this.txtPresentation = new System.Windows.Forms.TextBox();
            this.txtClickstream = new System.Windows.Forms.TextBox();
            this.btnUVSpa = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDUO = new System.Windows.Forms.Button();
            this.btnAC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMakeMetaFromPub
            // 
            this.btnMakeMetaFromPub.Location = new System.Drawing.Point(15, 255);
            this.btnMakeMetaFromPub.Name = "btnMakeMetaFromPub";
            this.btnMakeMetaFromPub.Size = new System.Drawing.Size(174, 23);
            this.btnMakeMetaFromPub.TabIndex = 0;
            this.btnMakeMetaFromPub.Text = "MakeMetaFromPub";
            this.btnMakeMetaFromPub.UseVisualStyleBackColor = true;
            this.btnMakeMetaFromPub.Click += new System.EventHandler(this.btnMakeMetaFromPubClick);
            // 
            // btnValidateKeyMessageNames
            // 
            this.btnValidateKeyMessageNames.Location = new System.Drawing.Point(15, 284);
            this.btnValidateKeyMessageNames.Name = "btnValidateKeyMessageNames";
            this.btnValidateKeyMessageNames.Size = new System.Drawing.Size(174, 23);
            this.btnValidateKeyMessageNames.TabIndex = 1;
            this.btnValidateKeyMessageNames.Text = "ValidateKeyMessageNames";
            this.btnValidateKeyMessageNames.UseVisualStyleBackColor = true;
            this.btnValidateKeyMessageNames.Click += new System.EventHandler(this.btnValidateKeyMessageNames_Click);
            // 
            // btnExtractFromPDF
            // 
            this.btnExtractFromPDF.Location = new System.Drawing.Point(15, 226);
            this.btnExtractFromPDF.Name = "btnExtractFromPDF";
            this.btnExtractFromPDF.Size = new System.Drawing.Size(174, 23);
            this.btnExtractFromPDF.TabIndex = 2;
            this.btnExtractFromPDF.Text = "ExtractFromPDF";
            this.btnExtractFromPDF.UseVisualStyleBackColor = true;
            this.btnExtractFromPDF.Click += new System.EventHandler(this.btnExtractFromPDF_Click);
            // 
            // btnValClickstreams
            // 
            this.btnValClickstreams.Location = new System.Drawing.Point(15, 313);
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
            this.lblFolder.Location = new System.Drawing.Point(22, 8);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(83, 13);
            this.lblFolder.TabIndex = 4;
            this.lblFolder.Text = "Metadata Forms";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(111, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // trvPresentations
            // 
            this.trvPresentations.Location = new System.Drawing.Point(935, 3);
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
            this.trvPresentations.Size = new System.Drawing.Size(716, 849);
            this.trvPresentations.TabIndex = 6;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(111, 30);
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
            this.lblSource.Location = new System.Drawing.Point(22, 35);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(41, 13);
            this.lblSource.TabIndex = 8;
            this.lblSource.Text = "Source";
            // 
            // btnMakeSourceFolders
            // 
            this.btnMakeSourceFolders.Location = new System.Drawing.Point(195, 255);
            this.btnMakeSourceFolders.Name = "btnMakeSourceFolders";
            this.btnMakeSourceFolders.Size = new System.Drawing.Size(174, 23);
            this.btnMakeSourceFolders.TabIndex = 11;
            this.btnMakeSourceFolders.Text = "MakeSourceFolders";
            this.btnMakeSourceFolders.UseVisualStyleBackColor = true;
            this.btnMakeSourceFolders.Click += new System.EventHandler(this.btnMakeSourceFolders_Click);
            // 
            // btnRenameZips
            // 
            this.btnRenameZips.Location = new System.Drawing.Point(195, 284);
            this.btnRenameZips.Name = "btnRenameZips";
            this.btnRenameZips.Size = new System.Drawing.Size(174, 23);
            this.btnRenameZips.TabIndex = 12;
            this.btnRenameZips.Text = "RenameZips";
            this.btnRenameZips.UseVisualStyleBackColor = true;
            this.btnRenameZips.Click += new System.EventHandler(this.btnRenameZips_Click);
            // 
            // btnMapping
            // 
            this.btnMapping.Location = new System.Drawing.Point(111, 56);
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
            this.lblMapping.Location = new System.Drawing.Point(22, 61);
            this.lblMapping.Name = "lblMapping";
            this.lblMapping.Size = new System.Drawing.Size(75, 13);
            this.lblMapping.TabIndex = 13;
            this.lblMapping.Text = "Previous Meta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Source Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Metadata Forms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Previous Metadata";
            // 
            // lblClickstream
            // 
            this.lblClickstream.AutoSize = true;
            this.lblClickstream.Location = new System.Drawing.Point(192, 90);
            this.lblClickstream.Name = "lblClickstream";
            this.lblClickstream.Size = new System.Drawing.Size(96, 13);
            this.lblClickstream.TabIndex = 18;
            this.lblClickstream.Text = "Clickstream Report";
            // 
            // btnClickstreamFile
            // 
            this.btnClickstreamFile.Location = new System.Drawing.Point(111, 85);
            this.btnClickstreamFile.Name = "btnClickstreamFile";
            this.btnClickstreamFile.Size = new System.Drawing.Size(75, 23);
            this.btnClickstreamFile.TabIndex = 17;
            this.btnClickstreamFile.Text = "browse";
            this.btnClickstreamFile.UseVisualStyleBackColor = true;
            this.btnClickstreamFile.Click += new System.EventHandler(this.btnClickstreamFile_Click);
            // 
            // Clickstream
            // 
            this.Clickstream.AutoSize = true;
            this.Clickstream.Location = new System.Drawing.Point(22, 90);
            this.Clickstream.Name = "Clickstream";
            this.Clickstream.Size = new System.Drawing.Size(61, 13);
            this.Clickstream.TabIndex = 16;
            this.Clickstream.Text = "Clickstream";
            // 
            // btnValidatePresentations
            // 
            this.btnValidatePresentations.Location = new System.Drawing.Point(195, 226);
            this.btnValidatePresentations.Name = "btnValidatePresentations";
            this.btnValidatePresentations.Size = new System.Drawing.Size(174, 23);
            this.btnValidatePresentations.TabIndex = 19;
            this.btnValidatePresentations.Text = "ValidatePresentationNames";
            this.btnValidatePresentations.UseVisualStyleBackColor = true;
            this.btnValidatePresentations.Click += new System.EventHandler(this.btnValidatePresentations_Click);
            // 
            // lblPresentations
            // 
            this.lblPresentations.AutoSize = true;
            this.lblPresentations.Location = new System.Drawing.Point(192, 118);
            this.lblPresentations.Name = "lblPresentations";
            this.lblPresentations.Size = new System.Drawing.Size(101, 13);
            this.lblPresentations.TabIndex = 22;
            this.lblPresentations.Text = "Presentation Report";
            // 
            // btnPresentationReport
            // 
            this.btnPresentationReport.Location = new System.Drawing.Point(111, 113);
            this.btnPresentationReport.Name = "btnPresentationReport";
            this.btnPresentationReport.Size = new System.Drawing.Size(75, 23);
            this.btnPresentationReport.TabIndex = 21;
            this.btnPresentationReport.Text = "browse";
            this.btnPresentationReport.UseVisualStyleBackColor = true;
            this.btnPresentationReport.Click += new System.EventHandler(this.btnPresentationReport_Click);
            // 
            // lblPresReports
            // 
            this.lblPresReports.AutoSize = true;
            this.lblPresReports.Location = new System.Drawing.Point(22, 118);
            this.lblPresReports.Name = "lblPresReports";
            this.lblPresReports.Size = new System.Drawing.Size(63, 13);
            this.lblPresReports.TabIndex = 20;
            this.lblPresReports.Text = "Pres Report";
            // 
            // trvSharedKeyMessages
            // 
            this.trvSharedKeyMessages.Location = new System.Drawing.Point(25, 425);
            this.trvSharedKeyMessages.Name = "trvSharedKeyMessages";
            this.trvSharedKeyMessages.Size = new System.Drawing.Size(520, 432);
            this.trvSharedKeyMessages.TabIndex = 23;
            // 
            // lblSharedKeys
            // 
            this.lblSharedKeys.AutoSize = true;
            this.lblSharedKeys.Location = new System.Drawing.Point(25, 406);
            this.lblSharedKeys.Name = "lblSharedKeys";
            this.lblSharedKeys.Size = new System.Drawing.Size(239, 13);
            this.lblSharedKeys.TabIndex = 24;
            this.lblSharedKeys.Text = "Shared Key Messages Found in Publishing Forms";
            // 
            // btnSpA
            // 
            this.btnSpA.Location = new System.Drawing.Point(15, 160);
            this.btnSpA.Name = "btnSpA";
            this.btnSpA.Size = new System.Drawing.Size(75, 23);
            this.btnSpA.TabIndex = 25;
            this.btnSpA.Text = "SpA";
            this.btnSpA.UseVisualStyleBackColor = true;
            this.btnSpA.Click += new System.EventHandler(this.btnSpA_Click);
            // 
            // btnPSA
            // 
            this.btnPSA.Location = new System.Drawing.Point(96, 160);
            this.btnPSA.Name = "btnPSA";
            this.btnPSA.Size = new System.Drawing.Size(75, 23);
            this.btnPSA.TabIndex = 26;
            this.btnPSA.Text = "PSA";
            this.btnPSA.UseVisualStyleBackColor = true;
            this.btnPSA.Click += new System.EventHandler(this.btnPSA_Click);
            // 
            // btnUVE
            // 
            this.btnUVE.Location = new System.Drawing.Point(177, 160);
            this.btnUVE.Name = "btnUVE";
            this.btnUVE.Size = new System.Drawing.Size(75, 23);
            this.btnUVE.TabIndex = 27;
            this.btnUVE.Text = "Uveitis";
            this.btnUVE.UseVisualStyleBackColor = true;
            this.btnUVE.Click += new System.EventHandler(this.btnUVE_Click);
            // 
            // txtMetadata
            // 
            this.txtMetadata.Location = new System.Drawing.Point(293, 6);
            this.txtMetadata.Name = "txtMetadata";
            this.txtMetadata.Size = new System.Drawing.Size(636, 20);
            this.txtMetadata.TabIndex = 28;
            this.txtMetadata.TextChanged += new System.EventHandler(this.txtMetadata_TextChanged);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(293, 32);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(636, 20);
            this.txtSource.TabIndex = 29;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // txtPrevMetadata
            // 
            this.txtPrevMetadata.Location = new System.Drawing.Point(293, 56);
            this.txtPrevMetadata.Name = "txtPrevMetadata";
            this.txtPrevMetadata.Size = new System.Drawing.Size(636, 20);
            this.txtPrevMetadata.TabIndex = 30;
            this.txtPrevMetadata.TextChanged += new System.EventHandler(this.txtPrevMetadata_TextChanged);
            // 
            // txtPresentation
            // 
            this.txtPresentation.Location = new System.Drawing.Point(294, 114);
            this.txtPresentation.Name = "txtPresentation";
            this.txtPresentation.Size = new System.Drawing.Size(636, 20);
            this.txtPresentation.TabIndex = 32;
            this.txtPresentation.TextChanged += new System.EventHandler(this.txtPresentation_TextChanged);
            // 
            // txtClickstream
            // 
            this.txtClickstream.Location = new System.Drawing.Point(294, 90);
            this.txtClickstream.Name = "txtClickstream";
            this.txtClickstream.Size = new System.Drawing.Size(636, 20);
            this.txtClickstream.TabIndex = 31;
            this.txtClickstream.TextChanged += new System.EventHandler(this.txtClickstream_TextChanged);
            // 
            // btnUVSpa
            // 
            this.btnUVSpa.Location = new System.Drawing.Point(258, 160);
            this.btnUVSpa.Name = "btnUVSpa";
            this.btnUVSpa.Size = new System.Drawing.Size(75, 23);
            this.btnUVSpa.TabIndex = 33;
            this.btnUVSpa.Text = "UVE in Spa";
            this.btnUVSpa.UseVisualStyleBackColor = true;
            this.btnUVSpa.Click += new System.EventHandler(this.btnUVSpa_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(339, 160);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 37;
            this.button5.Text = "RA";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnDUO
            // 
            this.btnDUO.Location = new System.Drawing.Point(420, 160);
            this.btnDUO.Name = "btnDUO";
            this.btnDUO.Size = new System.Drawing.Size(75, 23);
            this.btnDUO.TabIndex = 38;
            this.btnDUO.Text = "DUO";
            this.btnDUO.UseVisualStyleBackColor = true;
            this.btnDUO.Click += new System.EventHandler(this.btnDUO_Click);
            // 
            // btnAC
            // 
            this.btnAC.Location = new System.Drawing.Point(501, 160);
            this.btnAC.Name = "btnAC";
            this.btnAC.Size = new System.Drawing.Size(75, 23);
            this.btnAC.TabIndex = 39;
            this.btnAC.Text = "AC";
            this.btnAC.UseVisualStyleBackColor = true;
            this.btnAC.Click += new System.EventHandler(this.btnAC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1835, 869);
            this.Controls.Add(this.btnAC);
            this.Controls.Add(this.btnDUO);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnUVSpa);
            this.Controls.Add(this.txtPresentation);
            this.Controls.Add(this.txtClickstream);
            this.Controls.Add(this.txtPrevMetadata);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.txtMetadata);
            this.Controls.Add(this.btnUVE);
            this.Controls.Add(this.btnPSA);
            this.Controls.Add(this.btnSpA);
            this.Controls.Add(this.lblSharedKeys);
            this.Controls.Add(this.trvSharedKeyMessages);
            this.Controls.Add(this.lblPresentations);
            this.Controls.Add(this.btnPresentationReport);
            this.Controls.Add(this.lblPresReports);
            this.Controls.Add(this.btnValidatePresentations);
            this.Controls.Add(this.lblClickstream);
            this.Controls.Add(this.btnClickstreamFile);
            this.Controls.Add(this.Clickstream);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Button btnMakeSourceFolders;
        private System.Windows.Forms.Button btnRenameZips;
        private System.Windows.Forms.Button btnMapping;
        private System.Windows.Forms.Label lblMapping;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblClickstream;
        private System.Windows.Forms.Button btnClickstreamFile;
        private System.Windows.Forms.Label Clickstream;
        private System.Windows.Forms.Button btnValidatePresentations;
        private System.Windows.Forms.Label lblPresentations;
        private System.Windows.Forms.Button btnPresentationReport;
        private System.Windows.Forms.Label lblPresReports;
        private System.Windows.Forms.TreeView trvSharedKeyMessages;
        private System.Windows.Forms.Label lblSharedKeys;
        private System.Windows.Forms.Button btnSpA;
        private System.Windows.Forms.Button btnPSA;
        private System.Windows.Forms.Button btnUVE;
        private System.Windows.Forms.TextBox txtMetadata;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtPrevMetadata;
        private System.Windows.Forms.TextBox txtPresentation;
        private System.Windows.Forms.TextBox txtClickstream;
        private System.Windows.Forms.Button btnUVSpa;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnDUO;
        private System.Windows.Forms.Button btnAC;
    }
}

