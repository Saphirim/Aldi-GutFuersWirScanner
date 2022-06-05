using System.Drawing;

namespace AldiGutFuersWirQuickVoter
{
    public class Program
    {
        private static BarCodeReader _barCodeReader;
        private static Scanner _scanner;
        private static AldiVoter _voter;
        private static WindowsAcousticFeedbackProvider _acousticFeedback;
        private const string ScansDirectory = "Scans";




        static Program()
        {
            _barCodeReader = new BarCodeReader();
            _scanner = new Scanner();
            _voter = new AldiVoter();
            _acousticFeedback = new WindowsAcousticFeedbackProvider();

        }

        static async Task Main(string[] args)
        {


            Directory.CreateDirectory(ScansDirectory);

            while (true)
            {
                Console.Write("Present QR-Code....");

                Bitmap? scannedImage;
                _scanner.ReadFromCam(out scannedImage);

                if (scannedImage != null)
                {
                    //scannedImage.Save($"{ScansDirectory}/ScannedImage_{DateTime.Now.ToString("HHmmss")}.bmp");

                    var decodedQrText = _barCodeReader.DecodeFromBitmap(scannedImage);

                    if (!string.IsNullOrEmpty(decodedQrText))
                    {
                        ClearCurrentConsoleLine();
                        var code = _voter.ExtractCode(decodedQrText);
                        _acousticFeedback.PlayScanConfirmedSound();
                        Console.Write($"Code {code} detected ...");

                        var success = await _voter.TryVoting(code);
                        if (success)
                        {
                            ClearCurrentConsoleLine();
                            _acousticFeedback.PlayCodeRedeemedSound();
                            Console.WriteLine($"Code {code} successfully redeemed!!!");
                            await Task.Delay(TimeSpan.FromSeconds(1));
                        }
                        else
                        {
                            Console.Write("Please Try again...");
                        }
                    }
                    else
                    {
                        ClearCurrentConsoleLine();
                    }
                }

                scannedImage?.Dispose();
            }

        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}