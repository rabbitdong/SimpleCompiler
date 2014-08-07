using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCompiler.FrontEnd
{
    public abstract class Scanner
    {
        private Source source;
        private Token currentToken;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">the source to be used with this scanner</param>
        public Scanner(Source source)
        {
            this.source = source;
        }

        /// <summary>
        /// Return the current token.
        /// </summary>
        public Token CurrentToken
        {
            get { return currentToken; }
        }

        /// <summary>
        /// Get the next token from the source.
        /// </summary>
        public Token NextToken
        {
            get
            {
                currentToken = ExtractToken();
                return currentToken;
            }
        }

        /// <summary>
        /// Do the actual work of extracting and returning the next token from the source.
        /// Implement by scanner subclasses.
        /// </summary>
        protected abstract Token ExtractToken();
    }
}
