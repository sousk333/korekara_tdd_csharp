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
        private int strikeBonusCount = 0;
        private int doubleBonusCount = 0;

        public BowlingGame()
        {
            Score = 0;
        }

        public void RecordShot(int pins)
        {
            Score += pins;
            CalcSpareBonus(pins);
            CalcStrikeBonus(pins);
            lastPins = pins;
            ProceedNextShot();

        }

        private void CalcSpareBonus(int pins)
        {
            if (spare)
            {
                Score += pins;
                spare = false;
            }

            if (shotNo == 2 && lastPins + pins == 10)
            {
                spare = true;
            }
        }

        private void CalcStrikeBonus(int pins)
        {
            if (strikeBonusCount > 0)
            {
                Score += pins;
                strikeBonusCount--;
            }

            if (doubleBonusCount > 0)
            {
                Score += pins;
                doubleBonusCount--;
            }

            if (pins == 10)
            {
                if (strikeBonusCount == 0)
                {
                    strikeBonusCount = 2;
                } else
                {
                    doubleBonusCount = 2;
                }
            }
        }

        private void ProceedNextShot()
        {
            if (shotNo == 1)
            {
                shotNo++;
            }
            else
            {
                shotNo = 1;
            }
        }
    }
}
