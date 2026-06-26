namespace FacadeDesignPattern
{
    public class Stereoketen
    {
        private Versterker versterker = new Versterker();
        private Equalizer equalizer = new Equalizer();
        private Radio radio = new Radio();
        private CDSpeler cdSpeler = new CDSpeler();
        private IGeluidsbron huidigeGeluidsbron;
        private bool gestart;

        public void Start()
        {
            versterker.Start();
            equalizer.Start();
            huidigeGeluidsbron?.Start();
            gestart = true;
        }
        public void Stop()
        {
            versterker.Stop();
            equalizer.Stop();
            huidigeGeluidsbron?.Stop();
            gestart = false;
        }
        public void StartRadio()
        {
            if (gestart)
            {
                huidigeGeluidsbron?.Stop();
                radio.Start();
                huidigeGeluidsbron = radio;
            }
        }
        public void StartCDSpeler()
        {
            if (gestart)
            {
                huidigeGeluidsbron?.Stop();
                cdSpeler.Start();
                huidigeGeluidsbron = cdSpeler;
            }
        }
    }
}
