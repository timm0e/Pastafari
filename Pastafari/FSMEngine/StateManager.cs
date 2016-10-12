using System;
using System.Collections.Generic;
using System.Linq;

namespace Pastafari.FSMEngine
{
    public class StateManager
    {
        private List<State> states;

        public StateManager()
        {
            states = new List<State>();
        }

        public int addState(State s)
        {
            states.Add(s);
            return states.Count - 1;
        }

        public void removeState(State s)
        {
            states.Remove(s);
        }

        public void processString(String s)
        {
            State startState = null;

            foreach (State state in states)
            {
                if (state.start)
                {
                    if (startState != null)
                    {
                        throw new MultipleStartStatesException();
                    }
                    
                    startState = state;
                }
            }

            State curState = startState;

            List<Char> charsList = new List<char>(s.ToCharArray());

            while (charsList.Count>0)
            {
                curState = curState.processChar(charsList[0]);
                if (curState == null)
                {
                    throw new NoPathException();
                }
            }

            if (!curState.final)
            {
                throw new StateIsNotFinalException();
            }

        }

    }

    public class StateIsNotFinalException : Exception
    {
    }

    public class NoPathException : Exception
    {
    }

    public class MultipleStartStatesException : Exception
    {
    }
}