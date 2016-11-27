using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundAudioShared.Exceptions
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
