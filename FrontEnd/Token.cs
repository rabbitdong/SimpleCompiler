using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCompiler.FrontEnd
{
    /// <summary>
    /// The framework class that represents a token returned by the scanner.
    /// </summary>
    public class Token
    {
        protected ITokenType type;
        /// <summary>
        /// Token text
        /// </summary>
        protected string text;

        /// <summary>
        /// Token value
        /// </summary>
        protected object value;

        public Source source { get; set; }

        public Token(Source source)
        {
            this.source = source;
        }
    }

    /// <summary>
    /// The generic end-of-file token.
    /// </summary>
    public class EofToken : Token
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">The source from where to fetch the characters.</param>
        public EofToken(Source source)
            : base(source)
        {
        }
    }
}
