using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleCompiler.FrontEnd
{
    /// <summary>
    /// Present a source line.
    /// </summary>
    public struct SourceLine
    {
        /// <summary>
        /// source line.
        /// </summary>
        public string Line;

        /// <summary>
        /// source line number.
        /// </summary>
        public int LineNum { get; set; }

        /// <summary>
        /// source line position.
        /// </summary>
        public int LinePos { get; set; }

        /// <summary>
        /// Is at the end of line?
        /// </summary>
        public bool IsEndOfLine
        {
            get { return LinePos >= Line.Length; }
        }
    }

    /// <summary>
    /// The framework class that represents the source program
    /// </summary>
    public class Source : IEnumerable<char>
    {
        /// <summary>
        /// The reader for reading the source file.
        /// </summary>
        private TextReader reader;

        /// <summary>
        /// End-of-line character.
        /// </summary>
        public static readonly char EOL = '\n';

        /// <summary>
        /// End-of-file character.
        /// </summary>
        public static readonly char EOF = (char)0;

        /// <summary>
        /// Current source line.
        /// </summary>
        private SourceLine line;

        /// <summary>
        /// Is the first time read the source.
        /// </summary>
        private bool isFirstTime;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader">The reader for reading the source.</param>
        public Source(TextReader reader)
        {
            this.reader = reader;
            this.isFirstTime = true;
        }

        /// <summary>
        /// Return the source char at the current position.
        /// </summary>
        /// <returns></returns>
        public char CurrentChar
        {
            get
            {
                //the first time, need read the line.
                if (isFirstTime)
                {
                    line.Line = reader.ReadLine();
                    return NextChar;
                }
                else if (line.Line == null) // at the end  of file.
                {
                    return EOF;
                }
                else if (line.IsEndOfLine)  // at the end of line.
                {
                    return EOL;
                }

                return CurrentChar;
            }
        }

        /// <summary>
        /// Return the source character following the current character without consuming the current character.
        /// </summary>
        public char PeekChar()
        {
            if (line.Line == null)
                return EOF;

            return line.LinePos < line.Line.Length ? line.Line[line.LinePos] : EOL;
        }

        /// <summary>
        /// Consume the current source character and get the next character.
        /// </summary>
        public char NextChar
        {
            get
            {
                //If at the end of current line.
                if (line.IsEndOfLine)
                    line.Line = reader.ReadLine();

                line.LinePos++;
                return CurrentChar;
            }
        }

        /// <summary>
        /// Read the next source line.
        /// </summary>
        public void ReadLine()
        {
            line.Line = reader.ReadLine();  // At the end of line, it will get the null.
            line.LinePos = -1;
            if (line.Line != null)
                line.LineNum++;
        }

        /// <summary>
        /// Get the next char enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<char> GetEnumerator()
        {
            yield return NextChar;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
