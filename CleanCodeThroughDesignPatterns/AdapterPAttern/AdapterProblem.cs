using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.AdapterPAttern
{
    public class OldBarCodeReader
    {
        public string ReadBarCode(byte[] imae, string barCodeType)
        {
            return "1234567890";
        }
    }

    public class NewBarCodeReader
    {
        public string ScanImage(byte[] image)
        {
            return "1234567890";
        }
    }
}
