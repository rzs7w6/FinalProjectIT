using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProjectIT4410
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double lastTime = 0;
        Double currentTime = 0;
        bool recording = false;
        String sheetMusic;
        private Thread activity1Thread = null;

        private void Update()
        {
            while (true)
            {
                UpdateTime();
                Thread.Sleep(500);
            }
        }

        void UpdateTime()
        {
            Action action = () => currentTime += 5; ;
            Dispatcher.BeginInvoke(action);
        }

        void UpdateNote(char c)
        {
            Action action = () =>
            {
                textBox.Text += (currentTime - lastTime).ToString() + " " + c + " ";
                lastTime = currentTime;
            };
            Dispatcher.BeginInvoke(action);
        }
        

        private void record_Click(object sender, RoutedEventArgs e)
        {
            if (!recording)
            {
                textBox.Text = "";
                recording = true;
                if (activity1Thread == null)
                {
                    activity1Thread = new Thread(Update);
                    activity1Thread.Start();
                }
                record.Content = "Recording...";
            }
            else if (recording)
            {
                recording = false;
                activity1Thread.Abort();
                activity1Thread = null;
                record.Content = "Record";
                SaveAs();
            }
        }

        private void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            string fileName;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                Save(fileName, textBox.Text);
            }
            else
            {
                return;
            }
        }

        public void Save(String fileName, String text)
        {
            StreamWriter outputFile;
            outputFile = File.CreateText(fileName);
            outputFile.Write(text);
            outputFile.Close();
        }


        private void DoOpen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            string fileName;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                sheetMusic += Open(fileName);
                Console.WriteLine(sheetMusic);
            }
        }

        public String Open(String fileName)
        {
            StreamReader inputFile;
            inputFile = File.OpenText(fileName);

            String loadString;
            loadString = inputFile.ReadToEnd();
            inputFile.Close();
            return loadString;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void playSound(Uri path)
        {
            new Thread(() => {
                var c = new System.Windows.Media.MediaPlayer();
                c.Open(path);
                c.Play();
                Thread.Sleep(2000);
                c.Stop();
            }).Start();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            sheetMusic = "";
            DoOpen();
            double time;
            foreach (string word in sheetMusic.Split(' '))
            {
                switch (word)
                {
                    case "c":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.C1.mp3"));
                        break;

                    case "d":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.D1.mp3"));
                        break;

                    case "e":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.E1.mp3"));
                        break;

                    case "f":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.F1.mp3"));
                        break;

                    case "g":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.G1.mp3"));
                        break;

                    case "a":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.A1.mp3"));
                        break;

                    case "b":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.B1.mp3"));
                        break;

                    case "C":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.C2.mp3"));
                        break;

                    case "D":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.D2.mp3"));
                        break;

                    case "E":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.E2.mp3"));
                        break;

                    case "F":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.F2.mp3"));
                        break;

                    case "G":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.G2.mp3"));
                        break;

                    case "A":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.A2.mp3"));
                        break;

                    case "B":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.B2.mp3"));
                        break;

                    case "z":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.C3.mp3"));
                        break;

                    case "x":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.D3.mp3"));
                        break;

                    case "v":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.E3.mp3"));
                        break;

                    case "n":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.F3.mp3"));
                        break;

                    case "m":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.G3.mp3"));
                        break;

                    case ",":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.A3.mp3"));
                        break;

                    case ".":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.B3.mp3"));
                        break;

                    case "t":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Db1.mp3"));
                        break;

                    case "T":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Eb1.mp3"));
                        break;

                    case "y":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Gb1.mp3"));
                        break;

                    case "Y":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Ab1.mp3"));
                        break;

                    case "u":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Bb1.mp3"));
                        break;

                    case "U":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Db2.mp3"));
                        break;

                    case "i":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Eb2.mp3"));
                        break;

                    case "I":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Gb2.mp3"));
                        break;

                    case "o":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Ab2.mp3"));
                        break;

                    case "O":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Bb2.mp3"));
                        break;

                    case "p":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Db3.mp3"));
                        break;

                    case "P":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Eb3.mp3"));
                        break;

                    case "[":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Gb3.mp3"));
                        break;

                    case "]":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Ab3.mp3"));
                        break;

                    case "\\":
                        playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Bb3.mp3"));
                        break;

                    default:
                        Double.TryParse(word, out time);
                        Thread.Sleep((int) time * 100);
                        break;
                }
            }

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if(recording)
            {
                UpdateNote('c');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.C1.mp3"));
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('d');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.D1.mp3"));
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('e');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.E1.mp3"));
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('f');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.F1.mp3"));
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('g');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.G1.mp3"));
        }

        private void button_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('a');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.A1.mp3"));
        }

        private void button_Copy5_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('b');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.B1.mp3"));
        }

        private void button_Copy6_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('C');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.C2.mp3"));
        }

        private void button_Copy7_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('D');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.D2.mp3"));
        }

        private void button_Copy8_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('E');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.E2.mp3"));
        }

        private void button_Copy9_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('F');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.F2.mp3"));
        }

        private void button_Copy10_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('G');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.G2.mp3"));
        }

        private void button_Copy11_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('A');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.A2.mp3"));
        }

        private void button_Copy12_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('B');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.B2.mp3"));
        }

        private void button_Copy13_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('z');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.C3.mp3"));
        }

        private void button_Copy14_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('x');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.D3.mp3"));
        }

        private void button_Copy15_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('v');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.E3.mp3"));
        }

        private void button_Copy16_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('n');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.F3.mp3"));
        }

        private void button_Copy17_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('m');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.G3.mp3"));
        }

        private void button_Copy18_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote(',');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.A3.mp3"));
        }

        private void button_Copy19_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('.');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.B3.mp3"));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('t');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Db1.mp3"));
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('T');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Eb1.mp3"));
        }

        private void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('y');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Gb1.mp3"));
        }

        private void button1_Copy2_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('Y');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Ab1.mp3"));
        }

        private void button1_Copy3_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('u');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Bb1.mp3"));
        }

        private void button1_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('U');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Db2.mp3"));
        }

        private void button1_Copy5_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('i');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Eb2.mp3"));
        }

        private void button1_Copy6_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('I');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Gb2.mp3"));
        }

        private void button1_Copy7_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('o');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Ab2.mp3"));
        }

        private void button1_Copy8_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('O');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Bb2.mp3"));
        }

        private void button1_Copy9_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('p');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Db3.mp3"));
        }

        private void button1_Copy10_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('P');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Eb3.mp3"));
        }

        private void button1_Copy11_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('[');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Gb3.mp3"));
        }

        private void button1_Copy12_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote(']');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Ab3.mp3"));
        }

        private void button1_Copy13_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
            {
                UpdateNote('\\');
            }
            playSound(new System.Uri(Environment.CurrentDirectory + "/NotesMp3/Piano.pp.Bb3.mp3"));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (activity1Thread != null)
            {
                activity1Thread.Abort();
            }
        }

    }
}
