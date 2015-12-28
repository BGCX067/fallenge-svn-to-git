using System;
using System.Collections.Generic;
using System.Text;

using Tao.OpenGl;

namespace FallenGE.Graphics
{
    [Serializable]
    public class ShaderProgram
    {
        #region Members
        private const int MAX_LOG_LENGTH = 5000;

        private int id;
        private List<Shader> shaderList;

        private StringBuilder linkLog;
        private StringBuilder validLog;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a shader program from an array of shaders.
        /// </summary>
        /// /// <param name="shaders">The array containing compiled shaders.</param>
        public ShaderProgram(Shader[] shaders)
        {
            id = Gl.glCreateProgram();

            shaderList = new List<Shader>();

            foreach (Shader shader in shaders)
            {
                Gl.glAttachShader(id, shader.ID);
                shaderList.Add(shader);
            }

            Gl.glLinkProgram(id);

            linkLog = new StringBuilder(MAX_LOG_LENGTH);
            Gl.glGetProgramInfoLog(id, MAX_LOG_LENGTH, null, linkLog);

            Gl.glValidateProgram(id);

            validLog = new StringBuilder(MAX_LOG_LENGTH);
            //Gl.glgetprogram(id, MAX_LOG_LENGTH, null, linkLog);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the internal shader program ID.
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Get the link log.
        /// </summary>
        public string LinkLog
        {
            get
            {
                return linkLog.ToString();
            }
        }

        /// <summary>
        /// Get the validation log.
        /// </summary>
        public string ValidLog
        {
            get
            {
                return validLog.ToString();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Bind the shader program ready for use.
        /// </summary>
        public void Bind()
        {
            Gl.glUseProgram(id);
        }

        /// <summary>
        /// Unbind the program and go back to fixed function.
        /// </summary>
        public void Unbind()
        {
            Gl.glUseProgram(0);
        }

        /// <summary>
        /// Unload the shader a detach shaders (doesn't unload shaders).
        /// </summary>
        public void Unload()
        {
            foreach (Shader shader in shaderList)
                Gl.glDetachShader(id, shader.ID);
            Gl.glDeleteProgram(id);
        }
        #endregion
    }
}
