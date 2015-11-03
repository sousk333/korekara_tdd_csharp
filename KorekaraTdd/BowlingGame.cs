using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorekaraTdd
{
    public class BowlingGame
    {
        public int Score { get; private set; }

        private bool spare = false;
        private int lastPins = 0;
        private int shotNo = 1;

        public BowlingGame()
        {
            Score = 0;
        }

        public void RecordShot(int pins)
        {
            Score += pins;

            if (spare)
            {
                Score += pins;
                spare = false;
            }

            if (shotNo == 2 && lastPins + pins == 10)
            {
                spare = true;
            }

            lastPins = pins;

            if (shotNo == 1)
            {
                shotNo++;
            } else
            {
                shotNo = 1;
            }
        }
    }
}
