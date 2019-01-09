using System;
using System.IO;
using System.Text;
using System.Xml;

namespace EncodingDemo
{
  internal static class EncodingHelpers
  {
    private const string EncodingName = "ISO-8859-1";

    private static void CopyStream(Stream input, Stream output)
    {
      #region validate argument(s)

      if (input == null)
        throw new ArgumentNullException("input");

      if (output == null)
        throw new ArgumentNullException("output");

      #endregion

      const int bufferSize = 4096;
      byte[] buffer = new byte[bufferSize];

      input.Seek(0, SeekOrigin.Begin);

      while (true)
      {
        int read = input.Read(buffer, 0, buffer.Length);

        if (read <= 0)
          return;

        output.Write(buffer, 0, read);
      }
    }
    
    /// <summary>
    /// This method demonstrates how to save an Xml document to a file with a specific encoding.
    /// </summary>
    /// <param name="document"></param>
    /// <param name="path"></param>
    /// <remarks>
    /// When using the XmlWriter with the encoding provided, should the XmlDocument contain an XmlDeclaration with a different encoding value,
    /// the settings provided to the writer override the encoding specified on the XmlDeclaration.
    /// 
    /// Example: 
    /// 
    /// XmlDocument instance contains <?xml version="1.0" encoding="UTF-8"?>, output file will be written with
    /// < ?xml version="1.0" encoding="iso-8859-1"?> as the declaration.
    /// </remarks>
    public static void SaveLatin1(this XmlDocument document, string path)
    {
      SaveXmlImpl(document, path, Encoding.GetEncoding(EncodingName));
    }

    public static void SaveUtf8(this XmlDocument document, string path)
    {
      SaveXmlImpl(document, path, null);
    }

    private static void SaveXmlImpl(XmlDocument document, string path, Encoding encoding)
    {
      #region validate argument(s)

      if (document == null)
        throw new ArgumentNullException("document");

      if (string.IsNullOrEmpty(path))
        throw new ArgumentException("Unexpected null or empty string.", "path");

      #endregion

      const int Buffer = 1024;

      var settings = new XmlWriterSettings()
      {
        CloseOutput = true,
        Indent = true,
        OmitXmlDeclaration = false
      };

      // Default is UTF-8      
      if (encoding != null)
        settings.Encoding = encoding;

      using (XmlWriter writer = XmlWriter.Create(File.Create(path, Buffer, FileOptions.None), settings))
      {
        document.Save(writer);
        writer.Flush();
        writer.Close();
      }
    }

    public static string ReadTextStream(Stream data, Type readerType)
    {
      #region validate argument(s)

      if (data == null)
        throw new ArgumentNullException("data");

      if (readerType == null)
        throw new ArgumentNullException("readerType");

      if (!typeof(StreamReader).IsAssignableFrom(readerType))
        throw new Exception("Incompatible types.");

      #endregion

      string result = null; 

      using (StreamReader reader = Activator.CreateInstance(readerType, data) as StreamReader)
        result = reader.ReadToEnd();

      return result;
    }
  }
}
