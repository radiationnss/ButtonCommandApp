using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Speech.Recognition;
using System.Windows.Forms;
namespace ButtonCommandApp
{
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] {"backspace","break","caps","delete","down","end","enter","escape","help","home","insert","left","number lock","page down","page up","print screen","right","scroll lock","tab","up","add","subtract","multiply","divide"});
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            recognitionEngine.LoadGrammarAsync(grammar);
            recognitionEngine.SetInputToDefaultAudioDevice();
            recognitionEngine.SpeechRecognized += recognitionEngine_SpeechRecognized;
        }
        private void ButtonStuff(object sender, RoutedEventArgs e)
        {
            if(btnStartRecording.IsEnabled == true)
            {
                btnStartRecording.IsEnabled = false;
                recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
                btnStopRecording.IsEnabled = true;
            }
            else if(btnStartRecording.IsEnabled == false)
            {
                recognitionEngine.RecognizeAsyncStop();
                btnStartRecording.IsEnabled = true;
                btnStopRecording.IsEnabled = false;
            }
        }
        void recognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch(e.Result.Text)
            {
                case "backspace":
                    SendKeys.SendWait("{BACKSPACE}");
                    break;
                case "break":
                    SendKeys.SendWait("{BREAK}");
                    break;
                case "caps lock":
                    SendKeys.SendWait("{CAPSLOCK}");
                    break;
                case "delete":
                    SendKeys.SendWait("{DELETE}");
                    break;
                case "down":
                    SendKeys.SendWait("{DOWN}");
                    break;
                case "end":
                    SendKeys.SendWait("{END}");
                    break;
                case "enter":
                    SendKeys.SendWait("{ENTER}");
                    break;
                case "escape":
                    SendKeys.SendWait("{ESC}");
                    break;
                case "help":
                    SendKeys.SendWait("{HELP}");
                    break;
                case "home":
                    SendKeys.SendWait("{HOME}");
                    break;
                case "insert":
                    SendKeys.SendWait("{INSERT}");
                    break;
                case "left":
                    SendKeys.SendWait("{LEFT}");
                    break;
                case "number lock":
                    SendKeys.SendWait("{NUMLOCK}");
                    break;
                case "page down":
                    SendKeys.SendWait("{PGDN}");
                    break;
                case "page up":
                    SendKeys.SendWait("{PGUP}");
                    break;
                case "print screen":
                    SendKeys.SendWait("{PRTSC}");
                    break;
                case "right":
                    SendKeys.SendWait("{RIGHT}");
                    break;
                case "scroll lock":
                    SendKeys.SendWait("{SCROLLLOCK}");
                    break;
                case "tab":
                    SendKeys.SendWait("{TAB}");
                    break;
                case "up":
                    SendKeys.SendWait("{UP}");
                    break;
                case "add":
                    SendKeys.SendWait("{ADD}");
                    break;
                case "subtract":
                    SendKeys.SendWait("{SUBTRACT}");
                    break;
                case "multiply":
                    SendKeys.SendWait("{MULTIPLY}");
                    break;
                case "divide":
                    SendKeys.SendWait("{DIVIDE}");
                    break;
            }
        }
    }
}