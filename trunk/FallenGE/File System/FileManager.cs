using System;
using System.Collections.Generic;
using System.Text;

using Tao.PhysFs;

using FallenGE.Utility;

namespace FallenGE.File_System
{
    /// <summary>
    /// Specifies the mode to access the file.
    /// </summary>
    public enum AccessMode
    {
        /// <summary>
        /// Read mode file access.
        /// </summary>
        READ,
        /// <summary>
        /// Write mode file access.
        /// </summary>
        WRITE,
        /// <summary>
        /// Append to the file.
        /// </summary>
        APPEND
    }

    /// <summary>
    /// Specifies a file manager which uses PhysFS.
    /// </summary>
    public static class FileManager
    {
        #region Properties
        /// <summary>
        /// Get the search paths added to the file manager.
        /// </summary>
        public static string[] SearchPaths
        {
            get
            {
                return Fs.PHYSFS_getSearchPath();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Init file manager with the given search paths.
        /// </summary>
        /// <param name="searchPaths">The search paths to add.</param>
        public static void Init(string[] searchPaths)
        {
            Fs.PHYSFS_init("init");

            foreach (string path in searchPaths)
                Fs.PHYSFS_addToSearchPath(path, 1);
        }

        /// <summary>
        /// Adds a search path.
        /// </summary>
        /// <param name="path">The path to be added.</param>
        public static void AddArchive(string path)
        {
            Fs.PHYSFS_addToSearchPath(path, 1);
        }

        /// <summary>
        /// Destorys the file manager and any resources it may be using.
        /// </summary>
        public static void Destroy()
        {
            Fs.PHYSFS_deinit();
        }

        /// <summary>
        /// Checks to see if a file exists with in any of the added search paths.
        /// </summary>
        /// <param name="file">The name of the file to check for.</param>
        /// <returns>True if the file can be accessed.</returns>
        public static bool FileExists(string file)
        {
            return Convert.ToBoolean(Fs.PHYSFS_exists(file));
        }

        /// <summary>
        /// Opens a file that exists in the added search paths.
        /// </summary>
        /// <param name="file">The name of the file.</param>
        /// <param name="mode">The mode with which to access the file.</param>
        /// <returns>An instance of the open file, null if no file found.</returns>
        public static File OpenFile(string file, AccessMode mode)
        {
            switch (mode)
            {
                case AccessMode.READ:
                    return new File(Fs.PHYSFS_openRead(file), file);

                case AccessMode.WRITE:
                    return new File(Fs.PHYSFS_openWrite(file), file);

                case AccessMode.APPEND:
                    return new File(Fs.PHYSFS_openAppend(file), file);
            }

            return null;
        }

        /// <summary>
        /// Closes an open file.
        /// </summary>
        /// <param name="file">The file to be closed.</param>
        public static void CloseFile(File file)
        {
            Fs.PHYSFS_close(file.Handle);
        }

        /// <summary>
        /// Reads memory of size into buffer.
        /// </summary>
        /// <param name="file">The file to read from.</param>
        /// <param name="buffer">The buffer to write to.</param>
        /// <param name="size">Size in bytes.</param>
        /// <param name="count">The number to be read.</param>
        public static void Read(File file, FallenGE.Utility.Buffer buffer, uint size, uint count)
        {
            IntPtr data;
            Fs.PHYSFS_read(file.Handle, out data, size, count);
            buffer.Data = data;
        }

        /// <summary>
        /// Reads a file as a text file.
        /// </summary>
        /// <param name="file">The file to read.</param>
        /// <returns>The file as a text file.</returns>
        public static string ReadText(File file)
        {
            string text = "";
            byte[] array;
            Fs.PHYSFS_read(file.Handle, out array, 1, (uint)(FileSize(file)));
            for (int i = 0; i < array.Length; i++)
                text += ((char)array[i]);

            return text;
        }

        /// <summary>
        /// Calculates the size of a file.
        /// </summary>
        /// <param name="file">The file to be checked.</param>
        /// <returns>The size of the file in bytes.</returns>
        public static long FileSize(File file)
        {
            return Fs.PHYSFS_fileLength(file.Handle);
        }
        #endregion
    }
}
