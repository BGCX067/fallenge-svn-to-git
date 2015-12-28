using System;
using System.Collections.Generic;
using System.Text;

namespace FallenGE.File_System
{
    /// <summary>
    /// Represents a file on disk.
    /// </summary>
    public class File
    {
        #region Members
        private IntPtr handle;
        private string file;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new file using the given handle.
        /// </summary>
        /// <param name="handle">The handle to the file.</param>
        public File(IntPtr handle, string path)
        {
            this.handle = handle;
            this.file = path;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the handle to the file.
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                return handle;
            }
        }

        /// <summary>
        /// Get the file path.
        /// </summary>
        public string Path
        {
            get
            {
                return file;
            }
        }
        #endregion
    }
}
