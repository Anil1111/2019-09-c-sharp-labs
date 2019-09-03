using System;
using System.Collections.Generic;
using System.Text;

namespace lab_02_class
{
    class Dog
    {
        public string Name;
        public int Age;
        public int Height;

        public void Grow()
        {
            Age = Age + 1;
            Height = Height + 10;
        }
    }
}
