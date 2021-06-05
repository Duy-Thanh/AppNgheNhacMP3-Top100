using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AppNgheNhacMP3
{
    //[Synchronization]
    public class Song
    {
        private string songName;

        private string singerName;

        private string songURL;

        private int sTT;

        private string lyric;

        private string downloadURL;

        private string photoURL;

        private string savePath;

        private double duration;

        private double postition;

        //private string savePathOffline;

        public string SongName { get => songName; set => songName = value; }
        public string SingerName { get => singerName; set => singerName = value; }
        public string SongURL { get => songURL; set => songURL = value; }
        public int STT { get => sTT; set => sTT = value; }
        public string Lyric { get => lyric; set => lyric = value; }
        public string DownloadURL { get => downloadURL; set => downloadURL = value; }
        public string PhotoURL { get => photoURL; set => photoURL = value; }
        public string SavePath { get => savePath; set => savePath = value; }
        public double Duration { get => duration; set => duration = value; }
        public double Postition { get => postition; set => postition = value; }
    }
}
