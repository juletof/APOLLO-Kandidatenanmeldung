﻿namespace ApolloDb
{
    public class SuccessMessage : Message
    {
        public SuccessMessage(string text) : base(MessageType.IsSuccess, text) { }
    }

    public class ErrorMessage : Message
    {
        public ErrorMessage(string text) : base(MessageType.IsError, text) { }
    }

    public class Message
    {
        public readonly string Text;
        public readonly MessageType Type;

        public string CssClass
        {
            get
            {
                if (Type == MessageType.IsError)
                    return "alert alert-error";

                return "alert alert-success";
            }
        }

        public string Style;

        public Message() { }

        public Message(MessageType messageType, string message)
        {
            Text = message;
            Type = messageType;
        }
    }
}