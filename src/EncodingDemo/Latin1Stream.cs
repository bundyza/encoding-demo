using System.IO;
using System.Text;

namespace EncodingDemo
{
  /// <summary>
  /// Specialized StreamReader for working with ISO-8859-1 data
  /// </summary>
  internal sealed class Latin1StreamReader : StreamReader
  {
    private const string DefaultEncodingName = "ISO-8859-1";

    public Latin1StreamReader(Stream stream)
      : base(stream, Encoding.GetEncoding(DefaultEncodingName)) { }

    public Latin1StreamReader(string path)
      : base(path, Encoding.GetEncoding(DefaultEncodingName)) { }

    public Latin1StreamReader(Stream stream, int bufferSize)
      : base(stream, Encoding.GetEncoding(DefaultEncodingName), false, bufferSize) { }

    public Latin1StreamReader(string path, int bufferSize)
      : base(path, Encoding.GetEncoding(DefaultEncodingName), false, bufferSize) { }
  }

  /// <summary>
  /// Specialized StreamWriter for working with ISO-8859-1 data
  /// </summary>
  internal sealed class Latin1StreamWriter : StreamWriter
  {
    private const string DefaultEncodingName = "ISO-8859-1";

    public Latin1StreamWriter(Stream stream)
      : base(stream, Encoding.GetEncoding(DefaultEncodingName)) { }

    public Latin1StreamWriter(string path, bool append)
      : base(path, append, Encoding.GetEncoding(DefaultEncodingName)) { }

    public Latin1StreamWriter(Stream stream, int bufferSize)
      : base(stream, Encoding.GetEncoding(DefaultEncodingName), bufferSize) { }

    public Latin1StreamWriter(string path, bool append, int bufferSize)
      : base(path, append, Encoding.GetEncoding(DefaultEncodingName), bufferSize) { }
  }
}
