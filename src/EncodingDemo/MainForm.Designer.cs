namespace EncodingDemo
{
  partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.GroupBox plainTxtGrp;
      this.swappedDataEncodingBtn = new System.Windows.Forms.Button();
      this.expectedDataEncodingBtn = new System.Windows.Forms.Button();
      this.utf8DataLbl = new System.Windows.Forms.Label();
      this.latin1DataLbl = new System.Windows.Forms.Label();
      this.xmlTxtGrp = new System.Windows.Forms.GroupBox();
      this.swappedXmlEncodingBtn = new System.Windows.Forms.Button();
      this.expectedXmlEncodingBtn = new System.Windows.Forms.Button();
      this.utf8XmlLbl = new System.Windows.Forms.Label();
      this.latin1XmlLbl = new System.Windows.Forms.Label();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.domOpt = new System.Windows.Forms.RadioButton();
      this.xpathOpt = new System.Windows.Forms.RadioButton();
      this.xdocOpt = new System.Windows.Forms.RadioButton();
      plainTxtGrp = new System.Windows.Forms.GroupBox();
      plainTxtGrp.SuspendLayout();
      this.xmlTxtGrp.SuspendLayout();
      this.SuspendLayout();
      // 
      // plainTxtGrp
      // 
      plainTxtGrp.Controls.Add(this.swappedDataEncodingBtn);
      plainTxtGrp.Controls.Add(this.expectedDataEncodingBtn);
      plainTxtGrp.Controls.Add(this.utf8DataLbl);
      plainTxtGrp.Controls.Add(this.latin1DataLbl);
      plainTxtGrp.Location = new System.Drawing.Point(13, 13);
      plainTxtGrp.Name = "plainTxtGrp";
      plainTxtGrp.Size = new System.Drawing.Size(454, 91);
      plainTxtGrp.TabIndex = 0;
      plainTxtGrp.TabStop = false;
      plainTxtGrp.Text = "Simple Text Data";
      // 
      // swappedDataEncodingBtn
      // 
      this.swappedDataEncodingBtn.Location = new System.Drawing.Point(323, 58);
      this.swappedDataEncodingBtn.Name = "swappedDataEncodingBtn";
      this.swappedDataEncodingBtn.Size = new System.Drawing.Size(122, 23);
      this.swappedDataEncodingBtn.TabIndex = 3;
      this.swappedDataEncodingBtn.Text = "Swapped Encoding";
      this.toolTip.SetToolTip(this.swappedDataEncodingBtn, "Read the data files with the encoding swapped.");
      this.swappedDataEncodingBtn.UseVisualStyleBackColor = true;
      this.swappedDataEncodingBtn.Click += new System.EventHandler(this.swappedDataEncodingBtn_Click);
      // 
      // expectedDataEncodingBtn
      // 
      this.expectedDataEncodingBtn.Location = new System.Drawing.Point(195, 58);
      this.expectedDataEncodingBtn.Name = "expectedDataEncodingBtn";
      this.expectedDataEncodingBtn.Size = new System.Drawing.Size(122, 23);
      this.expectedDataEncodingBtn.TabIndex = 2;
      this.expectedDataEncodingBtn.Text = "Expected Encoding";
      this.toolTip.SetToolTip(this.expectedDataEncodingBtn, "Read the data files using the same encoding which they were created with.\r\n");
      this.expectedDataEncodingBtn.UseVisualStyleBackColor = true;
      this.expectedDataEncodingBtn.Click += new System.EventHandler(this.expectedDataEncodingBtn_Click);
      // 
      // utf8DataLbl
      // 
      this.utf8DataLbl.AutoSize = true;
      this.utf8DataLbl.Location = new System.Drawing.Point(7, 37);
      this.utf8DataLbl.Name = "utf8DataLbl";
      this.utf8DataLbl.Size = new System.Drawing.Size(40, 13);
      this.utf8DataLbl.TabIndex = 1;
      this.utf8DataLbl.Text = "UTF-8:";
      // 
      // latin1DataLbl
      // 
      this.latin1DataLbl.AutoSize = true;
      this.latin1DataLbl.Location = new System.Drawing.Point(7, 20);
      this.latin1DataLbl.Name = "latin1DataLbl";
      this.latin1DataLbl.Size = new System.Drawing.Size(107, 13);
      this.latin1DataLbl.TabIndex = 0;
      this.latin1DataLbl.Text = "Latin-1 / ISO-8859-1:";
      // 
      // xmlTxtGrp
      // 
      this.xmlTxtGrp.Controls.Add(this.xdocOpt);
      this.xmlTxtGrp.Controls.Add(this.xpathOpt);
      this.xmlTxtGrp.Controls.Add(this.domOpt);
      this.xmlTxtGrp.Controls.Add(this.swappedXmlEncodingBtn);
      this.xmlTxtGrp.Controls.Add(this.expectedXmlEncodingBtn);
      this.xmlTxtGrp.Controls.Add(this.utf8XmlLbl);
      this.xmlTxtGrp.Controls.Add(this.latin1XmlLbl);
      this.xmlTxtGrp.Location = new System.Drawing.Point(13, 110);
      this.xmlTxtGrp.Name = "xmlTxtGrp";
      this.xmlTxtGrp.Size = new System.Drawing.Size(454, 138);
      this.xmlTxtGrp.TabIndex = 1;
      this.xmlTxtGrp.TabStop = false;
      this.xmlTxtGrp.Text = "Xml Text Data";
      // 
      // swappedXmlEncodingBtn
      // 
      this.swappedXmlEncodingBtn.Location = new System.Drawing.Point(323, 109);
      this.swappedXmlEncodingBtn.Name = "swappedXmlEncodingBtn";
      this.swappedXmlEncodingBtn.Size = new System.Drawing.Size(122, 23);
      this.swappedXmlEncodingBtn.TabIndex = 5;
      this.swappedXmlEncodingBtn.Text = "Swapped Encoding";
      this.toolTip.SetToolTip(this.swappedXmlEncodingBtn, "Read the XML files with the encoding swapped.");
      this.swappedXmlEncodingBtn.UseVisualStyleBackColor = true;
      this.swappedXmlEncodingBtn.Click += new System.EventHandler(this.swappedXmlEncodingBtn_Click);
      // 
      // expectedXmlEncodingBtn
      // 
      this.expectedXmlEncodingBtn.Location = new System.Drawing.Point(195, 109);
      this.expectedXmlEncodingBtn.Name = "expectedXmlEncodingBtn";
      this.expectedXmlEncodingBtn.Size = new System.Drawing.Size(122, 23);
      this.expectedXmlEncodingBtn.TabIndex = 4;
      this.expectedXmlEncodingBtn.Text = "Expected Encoding";
      this.toolTip.SetToolTip(this.expectedXmlEncodingBtn, "Read the XML files using the same encoding which they were created with.\r\n");
      this.expectedXmlEncodingBtn.UseVisualStyleBackColor = true;
      this.expectedXmlEncodingBtn.Click += new System.EventHandler(this.expectedXmlEncodingBtn_Click);
      // 
      // utf8XmlLbl
      // 
      this.utf8XmlLbl.AutoSize = true;
      this.utf8XmlLbl.Location = new System.Drawing.Point(7, 33);
      this.utf8XmlLbl.Name = "utf8XmlLbl";
      this.utf8XmlLbl.Size = new System.Drawing.Size(40, 13);
      this.utf8XmlLbl.TabIndex = 3;
      this.utf8XmlLbl.Text = "UTF-8:";
      // 
      // latin1XmlLbl
      // 
      this.latin1XmlLbl.AutoSize = true;
      this.latin1XmlLbl.Location = new System.Drawing.Point(7, 16);
      this.latin1XmlLbl.Name = "latin1XmlLbl";
      this.latin1XmlLbl.Size = new System.Drawing.Size(107, 13);
      this.latin1XmlLbl.TabIndex = 2;
      this.latin1XmlLbl.Text = "Latin-1 / ISO-8859-1:";
      // 
      // domOpt
      // 
      this.domOpt.AutoSize = true;
      this.domOpt.Checked = true;
      this.domOpt.Location = new System.Drawing.Point(10, 68);
      this.domOpt.Name = "domOpt";
      this.domOpt.Size = new System.Drawing.Size(91, 17);
      this.domOpt.TabIndex = 7;
      this.domOpt.TabStop = true;
      this.domOpt.Text = "XmlDocument";
      this.domOpt.UseVisualStyleBackColor = true;
      // 
      // xpathOpt
      // 
      this.xpathOpt.AutoSize = true;
      this.xpathOpt.Location = new System.Drawing.Point(10, 91);
      this.xpathOpt.Name = "xpathOpt";
      this.xpathOpt.Size = new System.Drawing.Size(103, 17);
      this.xpathOpt.TabIndex = 8;
      this.xpathOpt.TabStop = true;
      this.xpathOpt.Text = "XPathDocument";
      this.xpathOpt.UseVisualStyleBackColor = true;
      // 
      // xdocOpt
      // 
      this.xdocOpt.AutoSize = true;
      this.xdocOpt.Location = new System.Drawing.Point(10, 114);
      this.xdocOpt.Name = "xdocOpt";
      this.xdocOpt.Size = new System.Drawing.Size(81, 17);
      this.xdocOpt.TabIndex = 9;
      this.xdocOpt.TabStop = true;
      this.xdocOpt.Text = "XDocument";
      this.xdocOpt.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(480, 269);
      this.Controls.Add(this.xmlTxtGrp);
      this.Controls.Add(plainTxtGrp);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Encoding Demo";
      this.Load += new System.EventHandler(this.MainForm_Load);
      plainTxtGrp.ResumeLayout(false);
      plainTxtGrp.PerformLayout();
      this.xmlTxtGrp.ResumeLayout(false);
      this.xmlTxtGrp.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label latin1DataLbl;
    private System.Windows.Forms.Label utf8DataLbl;
    private System.Windows.Forms.Button expectedDataEncodingBtn;
    private System.Windows.Forms.Button swappedDataEncodingBtn;
    private System.Windows.Forms.GroupBox xmlTxtGrp;
    private System.Windows.Forms.Label utf8XmlLbl;
    private System.Windows.Forms.Label latin1XmlLbl;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Button swappedXmlEncodingBtn;
    private System.Windows.Forms.Button expectedXmlEncodingBtn;
    private System.Windows.Forms.RadioButton xdocOpt;
    private System.Windows.Forms.RadioButton xpathOpt;
    private System.Windows.Forms.RadioButton domOpt;

  }
}

