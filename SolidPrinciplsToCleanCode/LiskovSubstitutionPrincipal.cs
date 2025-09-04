using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplsToCleanCode
{
    public abstract class ImageReader
    {
        public virtual string ReadImage(string fileName)
        {
            return "";
        }
    }

    public class BarCodeReader : ImageReader {
        public override string ReadImage(string fileName)
        {
            return "BarCode Image Read";
        }
    }

    public class QRCodeReader : ImageReader
    {
        public override string ReadImage(string fileName)
        {
            return "QRCode Image Read";
        }
    }
}
