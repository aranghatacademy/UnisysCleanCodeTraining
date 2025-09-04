using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplsToCleanCode
{
    /*public interface IMediaService
    {
        void PlayAudio(string fileName);
        void PlayVideo(string fileName);
        void PlayVR(string fileName);


        void StopAudio();
        void StopVideo();
        void StopVR();
    }

    public class MusicPlayer : IMediaService
    {
        public void PlayAudio(string fileName)
        {
            throw new NotImplementedException();
        }

        public void PlayVideo(string fileName)
        {
            throw new NotImplementedException();
        }

        public void PlayVR(string fileName)
        {
            throw new NotImplementedException();
        }

        public void StopAudio()
        {
            throw new NotImplementedException();
        }

        public void StopVideo()
        {
            throw new NotImplementedException();
        }

        public void StopVR()
        {
            throw new NotImplementedException();
        }
    }*/

    public interface IAudioPlayer
    {
        void PlayAudio(string fileName);
        void StopAudio();
    }

    public interface IVideoPlayer 
    {
        void PlayVideo(string fileName);
        void StopVideo();
    }

    public interface IVRPlayer
    {
        void PlayVR();
        void StopVR();
    }

    public class MusicPlayer : IAudioPlayer
    {
        public void PlayAudio(string fileName)
        {
            Console.Write("Playing audio file");
        }

        public void StopAudio()
        {
            Console.Write("Stoppng Audio File");
        }
    }

    public class Phone : IAudioPlayer, IVideoPlayer
    {
        public void PlayAudio(string fileName)
        {
            throw new NotImplementedException();
        }

        public void PlayVideo(string fileName)
        {
            throw new NotImplementedException();
        }

        public void StopAudio()
        {
            throw new NotImplementedException();
        }

        public void StopVideo()
        {
            throw new NotImplementedException();
        }
    }

}
