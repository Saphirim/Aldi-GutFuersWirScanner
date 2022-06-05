using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AldiGutFuersWirQuickVoter
{
    public class WindowsAcousticFeedbackProvider
    {
#pragma warning disable CA1416 // Validate platform compatibility
        const string ResourcesDirecory = "Resources/";
        const string ScanConfirmFile = "Beep.wav";
        const string CodeRedeemedFile = "Yeah.wav";
        private readonly SoundPlayer _scanConfirmPlayer;
        private readonly SoundPlayer _codeRedeemedPlayer;


        public WindowsAcousticFeedbackProvider()
        {

            _scanConfirmPlayer = new SoundPlayer(Path.Combine(ResourcesDirecory, ScanConfirmFile));
            _scanConfirmPlayer.Load();

            _codeRedeemedPlayer = new SoundPlayer(Path.Combine(ResourcesDirecory, CodeRedeemedFile));
            _codeRedeemedPlayer.Load();
        }

        public void PlayScanConfirmedSound()
        {
            _scanConfirmPlayer.Play();
        }

        public void PlayCodeRedeemedSound()
        {
            _codeRedeemedPlayer.Play();
        }

#pragma warning restore CA1416 // Validate platform compatibility
    }
}
