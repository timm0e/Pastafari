using System;
using System.Collections.Generic;

namespace Pastafari.FSMEngine
{
    public struct Path
    {
        public State To { get; private set; }

        public Char Trigger { get; private set; }

        public Path(State to, char trigger)
        {
            To = to;
            Trigger = trigger;
        }
    }
}