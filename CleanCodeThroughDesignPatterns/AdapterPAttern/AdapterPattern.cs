using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeThroughDesignPatterns.AdapterPAttern
{
    public interface IBarCodeReader
    {
        string Read(byte[] image);
    }

    public class OldBarCodeReaderAdapter : OldBarCodeReader, IBarCodeReader
    {
        string _barCodeType = "128";
        public OldBarCodeReaderAdapter(string barCodeType = "128")
        {
            // Initialize with specific barcode type if needed
            _barCodeType = barCodeType;
        }

        public string Read(byte[] image)
        {
            return ReadBarCode(image, _barCodeType);
        }
    }
}
