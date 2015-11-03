using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorekaraTdd
{
    class Frame
    {
        public int Score { get; private set; }

        public Frame()
        {
            Score = 0;
        }

        public void RecordShot(int pins)
        {
            Score += pins;
        }
    }
}
