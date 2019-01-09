using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace EncodingDemo
{
  public partial class MainForm : Form
  {
    private const string BasicText = "Ending character should be an accented E: \"É\"";
    private const string XmlText_1 = "<Data>Ending character should be an accented E: \"É\"</Data>";
    
    private const string Latin1Text = "Latin1.txt";
    private const string Latin1Xml = "Latin1.xml";
    private const string Utf8Text = "UTF-8.txt";
    private const string Utf8Xml = "UTF-8.xml";

    private const string Latin1TextLabel = "Latin-1 / ISO-8859-1:";
    private const string Utf8TextLabel = "UTF-8:";

    public MainForm()
    {
      InitializeComponent();
    }

    private void SetupSourceFiles()
    {
      // UTF-8 - No BOM
      File.WriteAllText(Utf8Text, BasicText);
      File.WriteAllText(Latin1Text, BasicText, Encoding.GetEncoding("ISO-8859-1"));

      XmlDocument document = new XmlDocument();
      document.LoadXml(XmlText_1);
      document.SaveLatin1(Latin1Xml);
      document.Save(Utf8Xml);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      SetupSourceFiles();
    }

    private static string GetXmlData(IXPathNavigable navigable)
    {
      if (navigable == null)
        throw new ArgumentNullException("navigable");

      var navigator = navigable.CreateNavigator();
      navigator = navigator.SelectSingleNode("/Data");
      return navigator.Value;
    }

    private static string GetXmlData(XDocument document)
    {
      if (document == null)
        throw new ArgumentNullException("document");

      return document.Root.Value;
    }

    /// <summary>
    /// Loads the data correctly into a string variable.
    /// </summary>
    /// <remarks>
    /// You need to read the data using the same encoding that is was written with
    /// </remarks>
    private void LoadDataExpected()
    {
      string latin1Data = EncodingHelpers.ReadTextStream(File.Open(Latin1Text, FileMode.Open), typeof(Latin1StreamReader));
      string utf8Data = EncodingHelpers.ReadTextStream(File.Open(Utf8Text, FileMode.Open), typeof(StreamReader));

      this.latin1DataLbl.Text = string.Format("{0} {1}", Latin1TextLabel, latin1Data);
      this.utf8DataLbl.Text = string.Format("{0} {1}", Utf8TextLabel, utf8Data);
    }
    
    /// <summary>
    /// Loads the data incorrectly into a string variable.
    /// </summary>
    /// <remarks>
    /// Swapping the write and then read encoding results in data translation errors.
    ///
    /// Latin1Text was written with the ISO-8859-1 encoding, however is being read with UTF-8 encoding
    /// Utf8Text was written with the Utf-8 encoding, however is being read with the ISO-8859-1 encoding
    /// </remarks>
    private void LoadDataSwapped()
    {
      string latin1Data = EncodingHelpers.ReadTextStream(File.Open(Latin1Text, FileMode.Open), typeof(StreamReader));
      string utf8Data = EncodingHelpers.ReadTextStream(File.Open(Utf8Text, FileMode.Open), typeof(Latin1StreamReader));

      this.latin1DataLbl.Text = string.Format("{0} {1}", Latin1TextLabel, latin1Data);
      this.utf8DataLbl.Text = string.Format("{0} {1}", Utf8TextLabel, utf8Data);
    }

    private void LoadXDocumentExpected()
    {
      XDocument latin1XDoc = XDocument.Load(Latin1Xml);
      XDocument utf8XDoc = XDocument.Load(Utf8Xml);

      // Alternative using the SteamReader(s)
      // latin1XDoc = XDocument.Load(new Latin1StreamReader(File.Open(Latin1Xml, FileMode.Open)));
      // utf8XDoc = XDocument.Load(new StreamReader(File.Open(Utf8Xml, FileMode.Open)));

      this.latin1XmlLbl.Text = string.Format("{0} {1}", Latin1TextLabel, GetXmlData(latin1XDoc));
      this.utf8XmlLbl.Text = string.Format("{0} {1}", Utf8TextLabel, GetXmlData(utf8XDoc));
    }

    private void LoadXPathDocExpected()
    {
      XPathDocument latin1Doc = new XPathDocument(Latin1Xml);
      XPathDocument utf8Doc = new XPathDocument(Utf8Xml);

      // Alternative using the SteamReader(s)
      // latin1Doc = new XPathDocument(new Latin1StreamReader(File.Open(Latin1Xml, FileMode.Open)));
      // utf8Doc = new XPathDocument(new StreamReader(File.Open(Utf8Xml, FileMode.Open)));

      this.latin1XmlLbl.Text = string.Format("{0} {1}", Latin1TextLabel, GetXmlData(latin1Doc));
      this.utf8XmlLbl.Text = string.Format("{0} {1}", Utf8TextLabel, GetXmlData(utf8Doc));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Try the different variations of the loading for the XmlDocument instance
    /// </remarks>
    private void LoadXmlDocExpected()
    {
      XmlDocument latin1Doc = new XmlDocument();
      XmlDocument utf8Doc = new XmlDocument();

      // using Load(string filename) : encoding is detected if the Xml declaration contains an encoding attribute
      latin1Doc.Load(Latin1Xml);
      utf8Doc.Load(Utf8Xml);

      // using Load(TextReader txtReader) - encoding is determined by encoding specified on the text reader
      // latin1Doc.Load(new Latin1StreamReader(File.Open(Latin1Xml, FileMode.Open)));
      // utf8Doc.Load(new StreamReader(File.Open(Utf8Xml, FileMode.Open)));

      // using Load(Stream inStream) : encoding appears to be detected based on Xml declaration encoding attribute
      // latin1Doc.Load(File.Open(Latin1Xml, FileMode.Open));
      // utf8Doc.Load(File.Open(Utf8Xml, FileMode.Open));

      this.latin1XmlLbl.Text = string.Format("{0} {1}", Latin1TextLabel, GetXmlData(latin1Doc));
      this.utf8XmlLbl.Text = string.Format("{0} {1}", Utf8TextLabel, GetXmlData(utf8Doc));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Loaded using a string read from file with the incorrect encoding. Loading it into XDocument does not resolve the issue as it is already too late.
    /// </remarks>
    private void LoadXDocumentSwapped()
    {
      string latin1Data = EncodingHelpers.ReadTextStream(File.Open(Latin1Xml, FileMode.Open), typeof(StreamReader));
      string utf8Data = EncodingHelpers.ReadTextStream(File.Open(Utf8Xml, FileMode.Open), typeof(Latin1StreamReader));

      XDocument latin1XDoc = XDocument.Parse(latin1Data);
      XDocument utf8XDoc = XDocument.Parse(utf8Data);

      this.latin1XmlLbl.Text = string.Format("{0} {1}", Latin1TextLabel, GetXmlData(latin1XDoc));
      this.utf8XmlLbl.Text = string.Format("{0} {1}", Utf8TextLabel, GetXmlData(utf8XDoc));
    }

    /// <summary>
    /// Loads an XPathDocument from a string which was read with the incorrect encoding.
    /// </summary>
    /// <remarks>
    /// Loaded using a string read from file with the incorrect encoding. Loading it into XPathDocument does not resolve the issue as it is already too late.
    /// </remarks>
    private void LoadXPathDocSwapped()
    {
      var latin1Doc = new XPathDocument(new StreamReader(File.Open(Latin1Xml, FileMode.Open)));
      var utf8Doc = new XPathDocument(new Latin1StreamReader(File.Open(Utf8Xml, FileMode.Open)));

      this.latin1XmlLbl.Text = string.Format("{0} {1}", Latin1TextLabel, GetXmlData(latin1Doc));
      this.utf8XmlLbl.Text = string.Format("{0} {1}", Utf8TextLabel, GetXmlData(utf8Doc));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Loaded using a string read from file with the incorrect encoding. Loading it into XmlDocument does not resolve the issue as it is already too late.
    /// Try the different variations of the loading for the XmlDocument instance.
    /// </remarks>
    private void LoadXmlDocSwapped()
    {
      XmlDocument latin1Doc = new XmlDocument();
      XmlDocument utf8Doc = new XmlDocument();

      // -----------------------------------------------------
      // Common scenario - Xml data is loaded with incorrect encoding into a string variable (perhaps passed as a parameter)
      // String is then used to Load XmlDocument instance
      // -----------------------------------------------------
      string latin1Data = EncodingHelpers.ReadTextStream(File.Open(Latin1Xml, FileMode.Open), typeof(StreamReader));
      string utf8Data = EncodingHelpers.ReadTextStream(File.Open(Utf8Xml, FileMode.Open), typeof(Latin1StreamReader));
      latin1Doc.LoadXml(latin1Data);
      utf8Doc.LoadXml(utf8Data);

      // using Load(TextReader txtReader) - encoding is determined by encoding specified on the text reader
      // latin1Doc.Load(new StreamReader(File.Open(Latin1Xml, FileMode.Open)));
      // utf8Doc.Load(new Latin1StreamReader(File.Open(Utf8Xml, FileMode.Open)));

      this.latin1XmlLbl.Text = string.Format("{0} {1}", Latin1TextLabel, GetXmlData(latin1Doc));
      this.utf8XmlLbl.Text = string.Format("{0} {1}", Utf8TextLabel, GetXmlData(utf8Doc));
    }

    private void expectedDataEncodingBtn_Click(object sender, EventArgs e)
    {
      LoadDataExpected();
    }

    private void swappedDataEncodingBtn_Click(object sender, EventArgs e)
    {
      LoadDataSwapped();
    }

    private void expectedXmlEncodingBtn_Click(object sender, EventArgs e)
    {
      if (domOpt.Checked)
        LoadXmlDocExpected();
      
      if (xpathOpt.Checked)
        LoadXPathDocExpected();

      if (xdocOpt.Checked)
        LoadXDocumentExpected();
    }

    private void swappedXmlEncodingBtn_Click(object sender, EventArgs e)
    {
      if (domOpt.Checked)
        LoadXmlDocSwapped();
      
      if (xpathOpt.Checked)
        LoadXPathDocSwapped();

      if (xdocOpt.Checked)
        LoadXDocumentSwapped();
    }
  }
}
