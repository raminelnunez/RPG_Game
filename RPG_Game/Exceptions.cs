using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class NegativeIntException : Exception
    {
        public NegativeIntException() : base("Should Not Input Negative Int")
        {

        }

    }

    internal class NotIntException : Exception
    {
        public NotIntException() : base("Input Is Not Int")
        {

        }
    }

    internal class exception3 : Exception
    {
    }

    internal class exception4 : Exception
    {
    }

    internal class exception5 : Exception
    {
    }
}
