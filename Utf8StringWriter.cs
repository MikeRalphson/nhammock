using System;
using System.IO;
using System.Text;

namespace NHammock.Core
{
	/// <summary>
	/// Class derived from <see cref="StringWriter"/> that allways outputs
	/// UTF-8 encoded strings.
	/// </summary>
	public class Utf8StringWriter : StringWriter
	{
		static UTF8Encoding _encoding;

		/// <summary>
		/// Initialises a new instance of the <see cref="Utf8StringWriter"/> class.
		/// </summary>
		public Utf8StringWriter() : this(new StringBuilder()) {}

		/// <summary>
		/// Initialises a new instance of the <see cref="Utf8StringWriter"/> class.
		/// that writes to the specified <see cref="StringBuilder"/>.
		/// </summary>
		/// <param name="sb"></param>
		public Utf8StringWriter(StringBuilder sb) : base(sb) {}

		/// <summary>
		/// Gets the <see cref="Encoding"/> in which the output is written,
		/// which is always <see cref="UTF8Encoding"/>.
		/// </summary>
		public override Encoding Encoding
		{
			get
			{
				if(Utf8StringWriter._encoding == null)
					Utf8StringWriter._encoding = new UTF8Encoding();
				
				return Utf8StringWriter._encoding;
			}
		}

	}
}
