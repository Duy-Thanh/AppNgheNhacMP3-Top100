using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using xNet;

namespace AppNgheNhacMP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //[Synchronization]
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool isCheckVN;
        private bool isCheckEU;
        private bool isCheckKO;
        private bool isCheckNhacTrinh;
        private bool isCheeckNhacTienChien;
        private bool isCheckNhacRap;
        private bool isCheckNhacTaiVe;
        private bool isCheckNhacTrongMay;
        private List<Song> listVN;
        private List<Song> listEU;
        private List<Song> listKO;
        private List<Song> listNhacTrinh;
        private List<Song> listNhacTienChien;
        private List<Song> listNhacRap;
        private List<Song> listNhacTaiVe;
        private List<Song> listNhacTrongMay;
        private Song currentSong;
        
        public bool IsCheckVN { get => isCheckVN; set { isCheckVN = value; lsbTopSongs.ItemsSource = ListVN; IsCheckNhacTaiVe = false; IsCheckNhacTrongMay = false; isCheckEU = false; isCheckKO = false; isCheckNhacTrinh = false; isCheeckNhacTienChien = false; isCheckNhacRap = false; OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO"); OnPropertyChanged("IsCheckOfflineSong"); OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); } }
        public bool IsCheckEU { get => isCheckEU; set { isCheckEU = value; lsbTopSongs.ItemsSource = ListEU; isCheckVN = false; IsCheckNhacTaiVe = false; IsCheckNhacTrongMay = false; isCheckKO = false; isCheckNhacTrinh = false; isCheeckNhacTienChien = false; isCheckNhacRap = false; OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO"); OnPropertyChanged("IsCheckOfflineSong"); OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); } }
        public bool IsCheckKO { get => isCheckKO; set { isCheckKO = value; lsbTopSongs.ItemsSource = ListKO; isCheckEU = false; IsCheckNhacTaiVe = false; IsCheckNhacTrongMay = false; isCheckVN = false; isCheckNhacTrinh = false; isCheeckNhacTienChien = false; isCheckNhacRap = false; OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO"); OnPropertyChanged("IsCheckOfflineSong"); OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); } }
        public bool IsCheckNhacTrinh { get => isCheckNhacTrinh; set { isCheckNhacTrinh = value; lsbTopSongs.ItemsSource = ListNhacTrinh; isCheckVN = false; IsCheckNhacTaiVe = false; IsCheckNhacTrongMay = false; isCheckKO = false; isCheckEU = false; isCheeckNhacTienChien = false; isCheckNhacRap = false; isCheckNhacTrinh = true; OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO"); OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); } }
        public bool IsCheeckNhacTienChien { get => isCheeckNhacTienChien; set { isCheeckNhacTienChien = value; lsbTopSongs.ItemsSource = ListNhacTienChien; isCheckVN = false; IsCheckNhacTaiVe = false; IsCheckNhacTrongMay = false; isCheckKO = false; isCheckEU = false; isCheckNhacTrinh = false; isCheckNhacRap = false; isCheeckNhacTienChien = true; OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO"); OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); } }
        public bool IsCheckNhacRap { get => isCheckNhacRap; set { isCheckNhacRap = value; lsbTopSongs.ItemsSource = ListNhacRap; IsCheckNhacTaiVe = false; IsCheckNhacTrongMay = false; isCheckVN = false; isCheckKO = false; isCheckEU = false; isCheckNhacTrinh = false; isCheeckNhacTienChien = false; isCheckNhacRap = true; OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO"); OnPropertyChanged("IsCheckOfflineSong"); OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); } }
        public bool _isCheckNhacTaiVe;
        public bool IsCheckNhacTaiVe { get => isCheckNhacTaiVe; set { isCheckNhacTaiVe = value; lsbTopSongs.ItemsSource = ListNhacTaiVe; /*IsCheckNhacTrongMay = false;*/ } }//isCheckVN = false; isCheckKO = false; isCheckEU = false; isCheckNhacTrinh = false; isCheeckNhacTienChien = false; isCheckNhacRap = false;  OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO"); OnPropertyChanged("IsCheckOfflineSong"); OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); } }
        public bool _isCheckNhacTrongMay;
        public bool IsCheckNhacTrongMay { get => isCheckNhacTrongMay; set { isCheckNhacTrongMay = value; lsbTopSongs.ItemsSource = ListNhacTrongMay; /*IsCheckNhacTaiVe = false;*/  } }// isCheckVN = false; isCheckKO = false; isCheckEU = false; isCheckNhacTrinh = false; isCheeckNhacTienChien = false; isCheckNhacRap = false; IsCheckNhacTrongMay = false; OnPropertyChanged("IsCheckVN"); OnPropertyChanged("IsCheckEU"); OnPropertyChanged("IsCheckKO");  OnPropertyChanged("IsCheckNhacTrinh"); OnPropertyChanged("IsCheeckNhacTienChien"); OnPropertyChanged("IsCheckNhacRap"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay"); OnPropertyChanged("IsCheckNhacTaiVe"); OnPropertyChanged("IsCheckNhacTrongMay");} }
        public List<Song> ListVN { get => listVN; set => listVN = value; }
        public List<Song> ListEU { get => listEU; set => listEU = value; }
        public List<Song> ListKO { get => listKO; set => listKO = value; }
        public List<Song> ListNhacTrinh { get => listNhacTrinh; set => listNhacTrinh = value; }
        public List<Song> ListNhacTienChien { get => listNhacTienChien; set => listNhacTienChien = value; }
        public List<Song> ListNhacRap { get => listNhacRap; set => listNhacRap = value; }
        public List<Song> ListNhacTaiVe { get => listNhacTaiVe; set => listNhacTaiVe = value; }
        public List<Song> ListNhacTrongMay { get => listNhacTrongMay; set => listNhacTrongMay = value; }
        public Song CurrentSong { get => currentSong; set => currentSong = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }

        public MainWindow()
        {
            Assembly.ReflectionOnlyLoadFrom(AppDomain.CurrentDomain.BaseDirectory + "AppNgheNhacMP3Top100NhacVietNam.exe");
            InitializeComponent();
            this.Title = "AppNgheNhacMP3 - Phiên bản: " + Application.ResourceAssembly.ImageRuntimeVersion;
            lsbTopSongs.IsEnabled = false;
            MainControl.IsEnabled = false;
            text.Text = "Đang tải";
            ucSongInfo.BackToMain += UcSongInfo_BackToMain;

            this.Show();

            this.DataContext = this;

            Thread thread = new Thread(() =>
            {
                ListVN = new List<Song>();
                ListEU = new List<Song>();
                ListKO = new List<Song>();
                ListNhacTrinh = new List<Song>();
                ListNhacTienChien = new List<Song>();
                ListNhacRap = new List<Song>();
                ListNhacTaiVe = new List<Song>();
                ListNhacTrongMay = new List<Song>();
                CrawlBXH();
            });
            thread.Start();
        }

        void getSongDownloaded()
        {
            var listSongDownloaded = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "Song\\", "*.mp3");
            string songDownloaded = listSongDownloaded[0].ToString();
            GetListSongDownloads(ListNhacTaiVe, songDownloaded);
        }

        void getSongiPod()
        {
            var listSongiPod = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "*.mp3");
            string songiPod = listSongiPod[0].ToString();
            GetListSongOffline(ListNhacTrongMay, songiPod);
        }

        private void GetListSongDownloads(List<Song> listSongsDownloaded, string directory)
        {
            var listBXH = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "Song\\", "*.mp3");
            for (int i = 0; i < listBXH.Length; i++)
            {
                string songPath = listBXH[i].ToString();
                string songName = listBXH[i].ToString().Replace(AppDomain.CurrentDomain.BaseDirectory + "Song\\", "");
                string templyrics = "<html> <body> <div> <br> Chưa có lyric </br> </div> <body> </html>";
                string singerName = "Không rõ";

                listSongsDownloaded.Add(new Song() { SongName = songName, Lyric = templyrics, DownloadURL = songPath, SingerName = singerName, STT = i + 1, SavePath = songPath });
            }
        }

        void GetListSongOffline(List<Song> listSongsiPod, string directory)
        {
            var listMusic = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "*.mp3");
            for (int i = 0; i < listMusic.Length; i++)
            {
                string songPath = listMusic[i].ToString();
                string songName = listMusic[i].ToString().Replace(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\", "");
                string templyrics = "<html> <body> <div> <br> Chưa có lyric </br> </div> <body> </html>";
                string singerName = "Không rõ";

                listSongsiPod.Add(new Song() { SongName = songName, Lyric = templyrics, DownloadURL = songPath, SingerName = singerName, STT = i + 1, SavePath = songPath });
            }
        }

        void CrawlBXH()
        {
            HttpRequest http = new HttpRequest();
            string htmlBXH = http.Get(@"https://www.nhaccuatui.com/top100/top-100-nhac-tre.m3liaiy6vVsF.html").ToString();
            string bxhPattern = @"<div class=""box_resource_slide"">(.*?)</ul>";
            var listBXH = Regex.Matches(htmlBXH, bxhPattern, RegexOptions.Singleline);

            HttpRequest http2 = new HttpRequest();
            string htmlBXHEU = http2.Get(@"https://www.nhaccuatui.com/top100/top-100-tru-tinh.RKuTtHiGC8US.html").ToString();
            string bxhPatternEU = @"<div class=""box_resource_slide"">(.*?)</ul>";
            var listBXHEU = Regex.Matches(htmlBXHEU, bxhPatternEU, RegexOptions.Singleline);

            HttpRequest http3 = new HttpRequest();
            string htmlBXHKO = http3.Get(@"https://www.nhaccuatui.com/top100/top-100-remix-viet.aY3KIEnpCywU.html").ToString();
            string bxhPatternKO = @"<div class=""box_resource_slide"">(.*?)</ul>";
            var listBXHKO = Regex.Matches(htmlBXHKO, bxhPatternKO, RegexOptions.Singleline);

            HttpRequest http4 = new HttpRequest();
            string htmlBXH4 = http4.Get(@"https://www.nhaccuatui.com/top100/top-100-nhac-trinh.v0AGjIhhCegh.html").ToString();
            string bxhPattern4 = @"<div class=""box_resource_slide"">(.*?)</ul>";
            var listBXH4 = Regex.Matches(htmlBXH4, bxhPattern4, RegexOptions.Singleline);

            HttpRequest http5 = new HttpRequest();
            string htmlBXH5 = http5.Get(@"https://www.nhaccuatui.com/top100/top-100-tien-chien.TDSMAL1lI8F6.html").ToString();
            string bxhPattern5 = @"<div class=""box_resource_slide"">(.*?)</ul>";
            var listBXH5 = Regex.Matches(htmlBXH5, bxhPattern5, RegexOptions.Singleline);

            HttpRequest http6 = new HttpRequest();
            string htmlBXH6 = http6.Get(@"https://www.nhaccuatui.com/top100/top-100-rap-viet.iY1AnIsXedqE.html").ToString();
            string bxhPattern6 = @"<div class=""box_resource_slide"">(.*?)</ul>";
            var listBXH6 = Regex.Matches(htmlBXH6, bxhPattern6, RegexOptions.Singleline);

            string bxhVN = listBXH[0].ToString();
            AddSongToListSong(ListVN, bxhVN);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            string bxhEU = listBXHEU[0].ToString();
            AddSongToListSong(ListEU, bxhEU);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            string bxhKO = listBXHKO[0].ToString();
            AddSongToListSong(ListKO, bxhKO);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            string bxhKO1 = listBXH4[0].ToString();
            AddSongToListSong(ListNhacTrinh, bxhKO1);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            string bxhKO2 = listBXH5[0].ToString();
            AddSongToListSong(ListNhacTienChien, bxhKO2);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            string bxhKO3 = listBXH6[0].ToString();
            AddSongToListSong(ListNhacRap, bxhKO3);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            gridLoading.Visibility = Visibility.Hidden;
            gridLoading.IsEnabled = false;
            lsbTopSongs.IsEnabled = true;
            MainControl.IsEnabled = true;
            IsCheckNhacTaiVe = true;
            lsbTopSongs.Items.Refresh();

        } 
        private static readonly object balanceLock = new object();
        private void AddSongToListSong(List<Song> listSong, string html)
        {
            var listSongHTML = Regex.Matches(html, "<li>(.*?)</li>", RegexOptions.Singleline);
            for (int i = 0; i <= listSongHTML.Count; i++)
            {
                try
                {
                    var songandsinger = Regex.Matches(listSongHTML[i].ToString(), @"<a\s\S*\stitle=""(.*?)""", RegexOptions.Singleline);

                    string songString = songandsinger[0].ToString();
                    int indexSong = songString.IndexOf("title=\"");
                    string songName = songString.Substring(indexSong, songString.Length - indexSong - 1).Replace("title=\"", "");

                    string singerString = songandsinger[0].ToString();
                    int indexSinger = singerString.IndexOf("title=\"");
                    string singerName = singerString.Substring(indexSinger, singerString.Length - indexSong - 1).Replace("title=\"", "");

                    int indexURL = songString.IndexOf("href=\"");
                    string URL = songString.Substring(indexURL, indexSong - indexURL - 2).Replace("href=\"", "");

                    HttpRequest http = new HttpRequest();
                    string htmlSong = http.Get(URL).ToString();

                    string templyrics = "<html lang=\"vi\"> <body> <div> <p> Chưa có lyric </p> </div> <body> </html>";

                    var lyrics = Regex.Matches(htmlSong, @"<p id=""divLyric""(.*?)</p>", RegexOptions.Singleline);
                    if (lyrics.Count > 0)
                    {
                        templyrics = lyrics[0].ToString();
                        string tempToCut = templyrics.Substring(0, templyrics.IndexOf(">"));
                        templyrics = templyrics.Replace(tempToCut, "");
                    }
                    string downloadURL = Regex.Match(htmlSong, @"player.peConfig.xmlURL\s\S*\s\S*(.*?)", RegexOptions.Singleline).Value.Replace("player.peConfig.xmlURL = \"", "").Replace("\";", "");
                    HttpRequest downloadHttp = new HttpRequest();
                    string downloadXml = downloadHttp.Get(downloadURL).ToString();
                    var photosURLVar = Regex.Matches(downloadXml, @"<avatar>(.*?)</avatar>", RegexOptions.Singleline);
                    string photosURL = photosURLVar[i].ToString().Replace("<avatar>", "").Replace("</avatar>", "").Replace("\n", "").Replace("<![CDATA[", "").Replace("]]>", "").Replace("        ", "").Replace("\"", "");
                    var XmlCutVar = Regex.Matches(downloadXml, @"<location>(.*?)</location>", RegexOptions.Singleline);
                    string XmlCut = XmlCutVar[i].ToString().Replace("<location>", "").Replace("</location>", "").Replace("\n", "").Replace("<![CDATA[", "").Replace("]]>", "").Replace("        ", "").Replace("\"", "");
                    string savePath = AppDomain.CurrentDomain.BaseDirectory + "Song\\" + songName + ".mp3";
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Lyrics\\" + "Lyrics.html", templyrics);

                    listSong.Add(new Song() { SingerName = singerName, SongName = songName, SongURL = URL, STT = i + 1, Lyric = templyrics, DownloadURL = XmlCut, PhotoURL = photosURL, SavePath = savePath });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!\nUnable to complete connection action to the server! Exception was thrown, please provide information about this exception to customer service when they request information about bug reports and exceptions that were thrown during the use of the software this We deeply apologize for the inconvenience. Wish you sympathize.\nException throw:\n" + ex, "Critical Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }
            ThrownException();
        }

        private void ThrownException()
        {
            getSongDownloaded();
            getSongiPod();
            this.Dispatcher.Invoke(() =>
            {
                MainControl.IsEnabled = true;
                text.Text = "";
                text.IsEnabled = false;
                mediaPlayerControl.IsEnabled = true;
                NhacTaiVe.IsEnabled = true;
                NhaciPod.IsEnabled = true;
                NhacTre.IsEnabled = false;
                NhacTruTinh.IsEnabled = false;
                NhacRemix.IsEnabled = false;
                NhacTrinh.IsEnabled = false;
                NhacRap.IsEnabled = false;
                NhacTienChien.IsEnabled = false;
                IsCheckNhacTaiVe = true;
                lsbTopSongs.IsEnabled = true;
            });
        }

        //void ChooseBXH(bool showButton)
        //{
        //    IsCheckVN = true;
        //    IsCheckEU = false;
        //    IsCheckKO = false;
        //}

        private void UcSongInfo_BackToMain(object sender, EventArgs e)
        {
            gridTop10.Visibility = Visibility.Visible;
            ucSongInfo.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Song song = (sender as Button).DataContext as Song;

            //MessageBox.Show(song.Lyric);

            //var a = 5;
            gridTop10.Visibility = Visibility.Hidden;
            ucSongInfo.Visibility = Visibility.Visible;
            ucSongInfo.SongInfo = song;
        }

        void ChangeToNextWSong(List<Song> listSong, int postition, int addCount)
        {
            int index = listSong.IndexOf(CurrentSong);
            if (index == postition)
            {
                return;
            }
            else
            {
                CurrentSong = listSong[index + addCount];
                ucSongInfo.SongInfo = CurrentSong;
            }
        }

        private void ucSongInfo_PreviousClicked(object sender, EventArgs e)
        {
            if (IsCheckVN)
            {
                ChangeToNextWSong(ListVN, 0, -1);
            }
            else if (IsCheckEU)
            {
                ChangeToNextWSong(ListEU, 0, -1);
            }
            else if (IsCheckEU)
            {
                ChangeToNextWSong(ListKO, 0, -1);
            }
            else if (IsCheckNhacTrinh)
            {
                ChangeToNextWSong(ListNhacTrinh, 0, -1);
            }
            else if (IsCheeckNhacTienChien)
            {
                ChangeToNextWSong(ListNhacTienChien, 0, -1);
            }
            else if (IsCheckNhacRap)
            {
                ChangeToNextWSong(ListNhacRap, 0, -1);
            }
            else if (IsCheckNhacTaiVe)
            {
                ChangeToNextWSong(ListNhacTaiVe, 0, -1);
            }
            else if (IsCheckNhacTrongMay)
            {
                ChangeToNextWSong(ListNhacTrongMay, 0, -1);
            }
        }

        private void ucSongInfo_NextClicked(object sender, EventArgs e)
        {
            if (IsCheckVN)
            {
                ChangeToNextWSong(ListVN, 9, 1);
            }
            else if (IsCheckEU)
            {
                ChangeToNextWSong(ListEU, 9, 1);
            }
            else if (IsCheckEU)
            {
                ChangeToNextWSong(ListKO, 9, 1);
            }
            else if (IsCheckNhacTrinh)
            {
                ChangeToNextWSong(ListNhacTrinh, 0, -1);
            }
            else if (IsCheeckNhacTienChien)
            {
                ChangeToNextWSong(ListNhacTienChien, 0, -1);
            }
            else if (IsCheckNhacRap)
            {
                ChangeToNextWSong(ListNhacRap, 0, -1);
            }
            else if (IsCheckNhacTaiVe)
            {
                ChangeToNextWSong(ListNhacTaiVe, 0, -1);
            }
            else if (IsCheckNhacTrongMay)
            {
                ChangeToNextWSong(ListNhacTrongMay, 0, -1);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gridTop10.Visibility = Visibility.Hidden;
            ucSongInfo.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
