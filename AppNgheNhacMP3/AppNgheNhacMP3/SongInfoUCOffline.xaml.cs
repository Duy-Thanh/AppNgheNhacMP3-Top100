using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppNgheNhacMP3
{
    /// <summary>
    /// Interaction logic for SongInfoUCOffline.xaml
    /// </summary>
    public partial class SongInfoUCOffline : UserControl, INotifyPropertyChanged
    {
        private Song songInfo;

        DispatcherTimer timer;

        public SongInfoUCOffline()
        {
            InitializeComponent();
            this.DataContext = SongInfo;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            SongInfo.Postition += SpeedRatio;
            sdDuration.Value = SongInfo.Postition;
        }

        public Song SongInfo
        {
            get { return songInfo; }
            set
            {
                songInfo = value;
                DownloadSong(SongInfo);
                OnPropertyChanged("SongInfo");
                this.DataContext = SongInfo;
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Lyrics\\" + "Lyrics.html", SongInfo.Lyric);
                webLyric.Refresh();
                SpeedRatio = 1;
            }
        }

        private double speedRatio;

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }
            set
            {
                isPlaying = value;
                if (isPlaying)
                {
                    mediaPlayer.Play();
                    timer.Start();
                    btnPlay.Content = "Pause";
                }
                else
                {
                    mediaPlayer.Pause();
                    timer.Stop();
                    btnPlay.Content = "Play";
                }
            }
        }

        public double SpeedRatio
        {
            get
            {
                return speedRatio;
            }
            set
            {
                speedRatio = value;
            }
        }

        public bool IsPlay
        {
            get
            {
                return isPlay;
            }
            set
            {
                isPlay = value;
                if (isPlay)
                {
                    btnStop.IsEnabled = true;
                }
                else
                {
                    mediaPlayer.Stop();
                    timer.Stop();
                    //btnStop.IsEnabled = false;
                }
            }
        }

        private bool isPlaying;
        private bool isPlay;

        private event EventHandler backToMain;
        public event EventHandler BackToMain
        {
            add { backToMain += value; }
            remove { backToMain -= value; }
        }

        //void PlaySound()
        //{
        //    mediaPlayer.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Song\\" + songInfo.SongName + ".mp3");
        //}

        //void GetLinkImage()
        //{

        //}

        void DownloadSong(Song songInfo)
        {
            string songName = songInfo.SavePath;
            if (!File.Exists(songName))
            {
                WebClient wb = new WebClient();
                wb.DownloadFile(SongInfo.DownloadURL, AppDomain.CurrentDomain.BaseDirectory + "Song\\" + songInfo.SongName + ".mp3");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (backToMain != null)
            {
                backToMain(this, new EventArgs());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }
        private void mediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            IsPlaying = true;
            SongInfo.Duration = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            txbDuration.Text = new TimeSpan(0, (int)(SongInfo.Duration / 60), (int)(SongInfo.Duration % 60)).ToString(@"mm\:ss");
            sdDuration.Maximum = SongInfo.Duration;
            SongInfo.Postition = 0;
            //timer.Start();
        }
        bool isDraging = false;
        private void sdDuration_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isDraging)
            {
                SongInfo.Postition = sdDuration.Value;
                mediaPlayer.Position = new TimeSpan(0, 0, (int)SongInfo.Postition);
            }
            txbPostition.Text = new TimeSpan(0, (int)(SongInfo.Postition / 60), (int)(SongInfo.Postition % 60)).ToString(@"mm\:ss");
        }

        private void sdDuration_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDraging = true;
        }

        private void sdDuration_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDraging = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsPlaying = !IsPlaying;
        }

        private event EventHandler previousBtnClicked;
        public event EventHandler PreviousBtnClicked
        {
            add { previousBtnClicked += value; }
            remove { previousBtnClicked -= value; }

        }

        private event EventHandler nextClicked;
        public event EventHandler NextClicked
        {
            add { nextClicked += value; }
            remove { nextClicked -= value; }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (previousBtnClicked != null)
            {
                previousBtnClicked(this, new EventArgs());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (nextClicked != null)
            {
                nextClicked(this, new EventArgs());
            }

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton toggle = sender as ToggleButton;

            if (toggle.IsChecked == true)
            {
                SpeedRatio = 2;
            }
            else if (toggle.IsChecked == false)
            {
                SpeedRatio = 1;
            }
            mediaPlayer.SpeedRatio = SpeedRatio;
            toggle.Content = string.Format("{0}.0", SpeedRatio);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IsPlay = !IsPlay;
        }
    }
}
