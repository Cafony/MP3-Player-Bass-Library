using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Un4seen.Bass;


namespace Bass_Dll_Player.cs
{
    public static class BassLike
    {
        //https://www.youtube.com/watch?v=jpOcIsNeueQ&t=476s VIDEO RUSSO
        public static int HZ = 44110;
        public static bool InitDefaultDevice;
        public static int Stream;
        public static int Volume = 100;

        private static bool InitBass(int hz)
        {
            if (!InitDefaultDevice) 
                InitDefaultDevice = Bass.BASS_Init(-1, hz, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            return InitDefaultDevice;            
        }

        
        public static void Play(string filename, int vol)
        {
            Stop();
            if (InitBass(HZ))
            {
                Stream = Bass.BASS_StreamCreateFile(filename, 0, 0, BASSFlag.BASS_DEFAULT);
                if (Stream != 0)
                {
                    Volume = vol;
                    Bass.BASS_ChannelSetAttribute(Stream, BASSAttribute.BASS_ATTRIB_VOL, Volume / 100);
                    Bass.BASS_ChannelPlay(Stream, false);
                }
            }
        }

        public static void Stop()
        {
            Bass.BASS_ChannelStop(Stream);
            Bass.BASS_StreamFree(Stream);
        }

        public static int GetTimeOfStream(int stream)  // Tempo do MP3
        {
            long TimeBytes = Bass.BASS_ChannelGetLength(stream);
            double Time = Bass.BASS_ChannelBytes2Seconds(stream, TimeBytes);
            return (int)Time;

        }

        public static int GetPosOfStream(int stream)
        {
            long pos = Bass.BASS_ChannelGetPosition(stream);
            int posSec = (int)Bass.BASS_ChannelBytes2Seconds(stream, pos);
            return (int)posSec;
        }


        public static void SetPosOfScroll(int stream, int pos)
        {
            Bass.BASS_ChannelSetPosition(stream, (double)pos);
        }

        public static void SetVolumeToStream(int stream, int vol)
        {
            Volume = vol;
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, Volume /100F);

        }

    }
}
