using Jon.Wpf.CustomControls.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls
{
    public class TtsReader : Control
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(TtsReader), new PropertyMetadata(default(string)));

        

        private SpeechSynthesizer synth;

        public static readonly DependencyProperty PlayStopCommandProperty = DependencyProperty.Register(
       "PlayStopCommand", typeof(ICommand), typeof(TtsReader), new PropertyMetadata(null));

        public static readonly DependencyProperty OpenSettingsCommandProperty = DependencyProperty.Register(
            "OpenSettingsCommand", typeof(ICommand), typeof(TtsReader), new PropertyMetadata(null));

        public ICommand PlayStopCommand
        {
            get => (ICommand)GetValue(PlayStopCommandProperty);
            set => SetValue(PlayStopCommandProperty, value);
        }

        public ICommand OpenSettingsCommand
        {
            get => (ICommand)GetValue(OpenSettingsCommandProperty);
            set => SetValue(OpenSettingsCommandProperty, value);
        }

        public TtsReader()
        {
            synth = new SpeechSynthesizer();
            PlayStopCommand = new RelayCommand(_ => PlayTextToSpeech());
            OpenSettingsCommand = new RelayCommand(_ => OpenSettingsWindow());
        }

        static TtsReader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TtsReader), new FrameworkPropertyMetadata(typeof(TtsReader)));
        }        

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        // This method will be called when the play/stop button is clicked
        public void PlayTextToSpeech()
        {
            try
            {
                if (synth.State == SynthesizerState.Speaking)
                {

                    synth.Pause();
                }
                else
                {
                    synth.SpeakAsync(Text);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // This method will be called when the settings button is clicked
        private void OpenSettingsWindow()
        {
            var settingsWindow = new TtsReaderSettingsWindow(synth);
            var dialogResult = settingsWindow.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value)
            {
                synth = settingsWindow._speechSynth;
            }
        }

      


        // TODO: Implement the logic for changing the voice based on the system voices
        public void ChangeVoice(string voice)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement the logic for changing the speed
        public void ChangeSpeed(int speed)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement the logic for changing the cadence
        public void ChangeCadence(int cadence)
        {
            throw new NotImplementedException();
        }
    }
}
