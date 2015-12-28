using System;
using System.Collections.Generic;
using System.Text;

using Tao.Sdl;

using FallenGE.Utility;
using FallenGE.File_System;

namespace FallenGE.Audio
{
    /// <summary>
    /// Represents an audio manager.
    /// </summary>
    public class AudioPlayer
    {
        
        #region Constructors
        /// <summary>
        /// Create a new audio manager.
        /// </summary>
        public AudioPlayer()
        {
            Sdl.SDL_Init(Sdl.SDL_INIT_AUDIO);
            SdlMixer.Mix_OpenAudio(SdlMixer.MIX_DEFAULT_FREQUENCY, (short)SdlMixer.MIX_DEFAULT_FORMAT, SdlMixer.MIX_DEFAULT_CHANNELS, 1024);
            SdlMixer.Mix_AllocateChannels(16);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Destroy the audio manager and free used resoueces.
        /// </summary>
        public void Destroy()
        {
            SdlMixer.Mix_CloseAudio();
            Sdl.SDL_Quit();
        }

        /// <summary>
        /// Load a sound from search paths added to file manager.
        /// </summary>
        /// <param name="filePath">The name of the sound file.</param>
        /// <returns></returns>
        public Sound LoadSound(String filePath)
        {
            FallenGE.File_System.File file = FallenGE.File_System.FileManager.OpenFile(filePath, FallenGE.File_System.AccessMode.READ);
            Sound sound = new Sound(file);
            FallenGE.File_System.FileManager.CloseFile(file);
            return sound;
        }

        /// <summary>
        /// Unload a sound and free resources.
        /// </summary>
        /// <param name="sound">The sound to unload.</param>
        public void UnloadSound(Sound sound)
        {
            sound.Unload();
        }

        /// <summary>
        /// Plays a sound.
        /// </summary>
        /// <param name="sound">The sound to play.</param>
        /// <param name="channel">The channel to play the sound on.</param>
        /// <param name="loops">Number of loops.</param>
        public void PlaySound(Sound sound, int channel, int loops)
        {
            sound.Play(channel, loops);
        }

        /// <summary>
        /// Pause a channel.
        /// </summary>
        /// <param name="channel">Channel to pause.</param>
        public void PauseChannel(int channel)
        {
            SdlMixer.Mix_Pause(channel);
        }

        /// <summary>
        /// Resume a pused channel.
        /// </summary>
        /// <param name="channel">Channel to resume.</param>
        public void ResumeChannel(int channel)
        {
            SdlMixer.Mix_Resume(channel);
        }

        /// <summary>
        /// Test to see if a channel is playing.
        /// </summary>
        /// <param name="channel">Channel to test.</param>
        /// <returns></returns>
        public bool ChannelPlaying(int channel)
        {
            return (SdlMixer.Mix_Playing(channel) != 0);
        }

        /// <summary>
        /// Set the volume of a channel.
        /// </summary>
        /// <param name="channel">Channel to set.</param>
        /// <param name="volume">Volume ranging from 0.0f to 1.0f.</param>
        public void SetChannelVolume(int channel, float volume)
        {
            SdlMixer.Mix_Volume(channel, (int)(128.0f * volume));
        }
        #endregion
    }
}
