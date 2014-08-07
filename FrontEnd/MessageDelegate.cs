using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCompiler.FrontEnd
{
    public delegate void MessageDelegate(object Sender, EventArgs args);

    public enum MessageType
    {
        SOURCE_LINE, 
        SYNTAX_ERROR,
        PARSER_SUMMARY, 
        INTERPRETER_SUMMARY, 
        COMPILER_SUMMARY,
        MISCELLANEOUS, 
        TOKEN,
        ASSIGN, 
        FETCH, 
        BREAKPOINT, 
        RUNTIME_ERROR,
        CALL, 
        RETURN
    }

    public interface IMessageSender
    {
        void SendMessage(Message msg);
    }

    public class Message
    {
        public MessageType MessageType { get; set; }

        public object Body { get; set; }

        public Message() { }

        public Message(MessageType type, object body)
        {
            MessageType = type;
            Body = body;
        }
    }
}
