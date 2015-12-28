using System;
using System.Collections.Generic;
using System.Text;

using Tao.OpenGl;

using FallenGE.File_System;

namespace FallenGE.Graphics
{
    /// <summary>
    /// Specifies the type of shader being loaded.
    /// </summary>
    [Serializable]
    public enum ShaderType
    {
        /// <summary>
        /// Vertex shader program.
        /// </summary>
        VERTEX,
        /// <summary>
        /// Fragment shader program.
        /// </summary>
        FRAGMENT
    }

    public class Shader
    {
        #region Members
        private int id, programCount;
        private ShaderType type;
        private List<string> shaderSource;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a shader from a file.
        /// </summary>
        /// <param name="file">The file(s) containing shader source.</param>
        /// <param name="type">The type of shader.</param>
        /// <param name="compile">True to compile upon creation.</param>
        public Shader(File[] file, ShaderType type, bool compile)
        {
            int i = 0;
            string[] programText = new string[file.Length];

            programCount = file.Length;
            shaderSource = new List<string>();

            foreach (File f in file)
            {
                programText[i] = FileManager.ReadText(f);
                shaderSource.Add(programText[i]);
                i++;
            }
        
            this.type = type;

            switch (type)
            {
                case ShaderType.FRAGMENT:
                    this.id = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);
                    Gl.glShaderSource(id, programCount, programText, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;

                case ShaderType.VERTEX:
                    this.id = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
                    Gl.glShaderSource(id, programCount, programText, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;
            }
        }

        /// <summary>
        /// Create a shader from a string source.
        /// </summary>
        /// <param name="source">The string containing shader source(s).</param>
        /// <param name="type">The type of shader.</param>
        /// <param name="compile">True to compile upon creation.</param>
        public Shader(string[] source, ShaderType type, bool compile)
        {
            int i = 0;

            programCount = source.Length;
            shaderSource = new List<string>();

            foreach (string s in source)
                shaderSource.Add(s);

            this.type = type;

            switch (type)
            {
                case ShaderType.FRAGMENT:
                    this.id = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);
                    Gl.glShaderSource(id, programCount, source, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;

                case ShaderType.VERTEX:
                    this.id = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
                    Gl.glShaderSource(id, programCount, source, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add source code to the shader via a string array.
        /// </summary>
        /// <param name="source">The source(s) to add.</param>
        /// <param name="compile">True to compile after adding.</param>
        public void AddSource(string[] source, bool compile)
        {
            programCount += source.Length;

            foreach (string s in source)
                shaderSource.Add(s);

            switch (type)
            {
                case ShaderType.FRAGMENT:
                    this.id = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);
                    Gl.glShaderSource(id, source.Length, source, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;

                case ShaderType.VERTEX:
                    this.id = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
                    Gl.glShaderSource(id, source.Length, source, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;
            }
        }

        /// <summary>
        /// Add source code to the shader via a file array.
        /// </summary>
        /// <param name="file">The source(s) to add.</param>
        /// <param name="compile">True to compile after adding.</param>
        public void AddSource(File[] file, bool compile)
        {
            string[] source = new string[file.Length];

            programCount += file.Length;

            int i = 0;
            foreach (File f in file)
            {
                source[i] = FileManager.ReadText(f);
                shaderSource.Add(source[i]);
                i++;
            }

            switch (type)
            {
                case ShaderType.FRAGMENT:
                    this.id = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);
                    Gl.glShaderSource(id, source.Length, source, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;

                case ShaderType.VERTEX:
                    this.id = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
                    Gl.glShaderSource(id, source.Length, source, null);
                    if (compile)
                        Gl.glCompileShader(id);
                    break;
            }
        }

        /// <summary>
        /// Compile the shader.
        /// </summary>
        public void Compile()
        {
            Gl.glCompileShader(id);
        }

        /// <summary>
        /// Unload the shader an free used resource.
        /// </summary>
        public void Unload()
        {
            Gl.glDeleteShader(id);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the shaders internal ID.
        /// </summary>
        public int ID
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Get the number of shader sources.
        /// </summary>
        public int ProgramCount
        {
            get
            {
                return programCount;
            }
        }

        /// <summary>
        /// Get the type of the shader.
        /// </summary>
        public ShaderType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Get the source code to shader(s).
        /// </summary>
        public string[] Source
        {
            get
            {
                return shaderSource.ToArray();
            }
        }
        #endregion
    }
}
