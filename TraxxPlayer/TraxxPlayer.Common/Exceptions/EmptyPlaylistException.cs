using System;

namespace TraxxPlayer.Common.Exceptions
{
    public class EmptyPlaylistException : Exception
    {
        public EmptyPlaylistException()
        {
        }

        public EmptyPlaylistException(string message)
            : base(message)
        {
        }

        public EmptyPlaylistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
