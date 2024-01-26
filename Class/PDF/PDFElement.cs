using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFComparer.Class.PDF
{
    class PDFElement
    {
        public enum langGuageType
        {
            korea=0,
            english=1
        }

        public static byte[] Signature = { (byte)37,(byte)80, (byte)68, (byte)70, (byte)45};

        public int Pages = 0;

        private byte[] PDFByte = null;
        public byte[] PdfEntireArr { get; set; }
        public byte[] Version { get; set; }
    }
}
