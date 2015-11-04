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

        private int shotCount = 0;

        public Frame()
        {
            Score = 0;
        }

        public Boolean IsFinished()
        {
            return Score >= 10 || shotCount > 1;
        }

        public Boolean IsSpare()
        {
            return Score >= 10 && shotCount > 1;
        }

        public Boolean IsStrike()
        {
            return Score >= 10 && shotCount == 1;
        }

        public void RecordShot(int pins)
        {
            Score += pins;
            shotCount++;
        }
    }
}
