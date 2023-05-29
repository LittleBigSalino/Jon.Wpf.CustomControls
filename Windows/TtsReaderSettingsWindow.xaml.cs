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
using System.Windows.Shapes;

namespace Jon.Wpf.CustomControls.Windows
{
    /// <summary>
    /// Interaction logic for TtsReaderSettingsWindow.xaml
    /// </summary>
    public partial class TtsReaderSettingsWindow : Window
    {
        public SpeechSynthesizer _speechSynth { get; set; }

        public TtsReaderSettingsWindow(SpeechSynthesizer speechSynth)
        {
            InitializeComponent();

            _speechSynth = speechSynth;
            var voices = speechSynth.GetInstalledVoices();
            // Assuming you have a method to get system voices
            List<VoiceInfo> Voices = new List<VoiceInfo>();
            foreach(var voice in voices)
            {
                Voices.Add(voice.VoiceInfo);
            }
            VoiceComboBox.ItemsSource = Voices;
            VoiceComboBox.SelectedItem = speechSynth.Voice;
            VoiceComboBox.DisplayMemberPath = "Name";
            SpeedSlider.Value = speechSynth.Rate;
            VolumeSlider.Value = speechSynth.Volume;
            DataContext = _speechSynth;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _speechSynth.SelectVoice((VoiceComboBox.SelectedItem as VoiceInfo).Name);
            _speechSynth.Rate = (int)SpeedSlider.Value;
            _speechSynth.Volume = (int)VolumeSlider.Value;

            // Save the settings and close the window
            // You might want to implement actual saving logic depending on where you want to persist these settings
            DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void PlayTestButton_Click(object sender, RoutedEventArgs e)
        {
            // Use the text-to-speech functionality with the current settings to speak the text in the TextBox
            var text = TestTextBox.Text;
            SpeechSynthesizer testSynth = new SpeechSynthesizer();
            testSynth.SelectVoice((VoiceComboBox.SelectedItem as VoiceInfo).Name);
            testSynth.Rate = (int)SpeedSlider.Value;
            testSynth.Volume = (int)VolumeSlider.Value;
            testSynth.Speak(text);     
            
        }
    }


}
