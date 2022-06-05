using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AldiGutFuersWirQuickVoter
{
    public class BarCodeReader
    {

        public string? DecodeFromBitmap(Bitmap image)
        {
            BarcodeResult result = BarcodeReader.QuicklyReadOneBarcode(image);

            return result?.Text;
        }

    }
}
