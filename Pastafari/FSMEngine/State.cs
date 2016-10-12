using System;
using System.Collections.Generic;

namespace Pastafari.FSMEngine
{
    public class State
    {
        public bool final { get; set; }
        public bool start { get; set; }

        private List<Path> paths;

        public State()
        {
            paths = new List<Path>();
        }

        public void addPath(Path path)
        {
            paths.Add(path);
        }

        public void removePath(Path path)
        {
            paths.Remove(path);
        }

        public State processChar(Char c)
        {
            State ret = null;
            foreach (Path path in paths)
            {
                if (path.Trigger == c)
                {
                    if (ret != null)
                    {
                        throw new MultiplePathsException(c);
                    }
                    ret = path.To;
                }
            }
            return ret;
        }
    }
    public class MultiplePathsException : Exception
    {
        private char Errchar { get; set; }

        public MultiplePathsException(Char c)
        {
            this.Errchar = c;
        }
    }
}

