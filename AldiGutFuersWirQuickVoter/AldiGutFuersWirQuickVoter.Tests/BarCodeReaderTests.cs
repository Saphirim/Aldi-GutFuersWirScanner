using AldiGutFuersWirQuickVoter;
using System.Drawing;

namespace AldiGutFuersWirQuickVoter.Tests
{
    public class BarCodeReaderTests
    {
        [Fact]
        public void TestStringReadingFromBitmap()
        {
            BarCodeReader reader = new BarCodeReader();
            FileInfo testImageFile = new FileInfo("Resources/BarCodeTest.bmp");
            Bitmap testImage = new Bitmap(testImageFile.FullName);


            string result = reader.DecodeFromBitmap(testImage);
            Assert.Equal("https://aldi-gutfuerswir.de/?c=g43qdqnqz", result);


        }
    }
}