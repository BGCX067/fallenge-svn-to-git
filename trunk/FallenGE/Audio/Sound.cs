using System;
using System.Collections.Generic;
using System.Text;

using Tao.Sdl;

using FallenGE.Utility;
using FallenGE.File_System;

namespace FallenGE.Audio
{
    /// <summary>
    /// Represents a sound file.
    /// </summary>
    [Serializable]
    public class Sound
    {
        #region Members
        private IntPtr chunk;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new sound.
        /// </summary>
        /// <param name="file">The file that contains sound data.</param>
        public Sound(File file)
        {
            FallenGE.Utility.Buffer buffer = new FallenGE.Utility.Buffer();

            uint size = Convert.ToUInt32(FallenGE.File_System.FileManager.FileSize(file));

            FallenGE.File_System.FileManager.Read(file, buffer, size, 1);

            chunk = SdlMixer.Mix_LoadWAV_RW(Sdl.SDL_RWFromMem(buffer.Data, (int)size), 1);

            buffer.Destroy();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Play the sound.
        /// </summary>
        /// <param name="channel">Channel to play sound on.</param>
        /// <param name="loops">Number of times to loop.</param>
        public void Play(int channel, int loops)
        {
            SdlMixer.Mix_PlayChannel(channel, chunk, loops);
        }

        /// <summary>
        /// Unload the sound and free the resources used.
        /// </summary>
        public void Unload()
        {
            SdlMixer.Mix_FreeChunk(chunk);
        }
        #endregion
    }
}
