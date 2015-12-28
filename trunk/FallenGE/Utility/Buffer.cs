using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FallenGE.Utility
{
    /// <summary>
    /// Represents a buffer of memory.
    /// </summary>
    public class Buffer
    {
        #region Members
        private IntPtr buffer;
        private int size;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a buffer of zero size.
        /// </summary>
        public Buffer()
        {
            this.buffer = IntPtr.Zero;
            this.size = 0;
        }

        /// <summary>
        /// Create a bufferof given size.
        /// </summary>
        /// <param name="size">Size, in bytes, of the buffer.</param>
        public Buffer(int size)
        {
            this.buffer = Marshal.AllocHGlobal(size);
            this.size = size;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the data in the buffer.
        /// </summary>
        public IntPtr Data
        {
            get
            {
                return buffer;
            }
            set
            {
                this.buffer = value;
                this.size = Marshal.SizeOf(value);
            }
        }

        /// <summary>
        /// Get the size of the buffer.
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Frees memory used by buffer.
        /// </summary>
        public void Destroy()
        {
            Marshal.FreeHGlobal(this.buffer);
        }
        #endregion
        
    }
}
