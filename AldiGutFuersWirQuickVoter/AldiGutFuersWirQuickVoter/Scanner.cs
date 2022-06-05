using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace AldiGutFuersWirQuickVoter
{
    public class Scanner : IDisposable
    {
        private readonly VideoCapture _capture;
        private readonly Window _window;
        private bool disposedValue;

        public Scanner()
        {
            _capture = new VideoCapture(0);
            _window = new Window("ScannerView");

            _capture.Set(VideoCaptureProperties.FrameHeight, 720);
            _capture.Set(VideoCaptureProperties.FrameWidth, 1280);
        }

        public void ReadFromCam(out Bitmap? image)
        {
            var frame = new Mat();

            _capture.Read(frame);
            if (frame.Empty())
            {
                image = null;
                return;
            }

            _window.ShowImage(frame);
            image = BitmapConverter.ToBitmap(frame);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _capture.Dispose();
                    _window.Close();
                    _window.Dispose();
                }

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Scanner()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
