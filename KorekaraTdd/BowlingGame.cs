using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorekaraTdd
{
    class BowlingGame
    {
        public int Score { get; private set; }

        private bool spare = false;
        private int lastPins = 0;
        private int shotNo = 1;
        private int strikeBonusCount = 0;
        private int doubleBonusCount = 0;
        private Frame frame = new Frame();

        public BowlingGame()
        {
            Score = 0;
        }

        public int FrameScore(int frameNo)
        {
            return frame.Score;
        }

        public void RecordShot(int pins)
        {
            frame.RecordShot(pins);
            Score += pins;
            CalcSpareBonus(pins);
            CalcStrikeBonus(pins);
            lastPins = pins;
            ProceedNextShot();

        }

        private void AddStrikeBonus(int pins)
        {
            if (strikeBonusCount > 0)
            {
                Score += pins;
                strikeBonusCount--;
            }
        }

        private void AddDoubleBonus(int pins)
        {
            if (doubleBonusCount > 0)
            {
                Score += pins;
                doubleBonusCount--;
            }
        }

        private void CalcSpareBonus(int pins)
        {
            if (spare)
            {
                Score += pins;
                spare = false;
            }

            spare = IsSpare(pins);
        }

        private void CalcStrikeBonus(int pins)
        {
            AddStrikeBonus(pins);
            AddDoubleBonus(pins);

            if (IsStrike(pins))
            {
                RecognizeStrikeBonus();
            }
        }

        private Boolean IsSpare(int pins)
        {
            return shotNo == 2 && lastPins + pins == 10;
        }

        private Boolean IsStrike(int pins)
        {
            return pins == 10;
        }

        private void RecognizeStrikeBonus()
        {
            if (strikeBonusCount == 0)
            {
                strikeBonusCount = 2;
            }
            else
            {
                doubleBonusCount = 2;
            }
        }

        private void ProceedNextShot()
        {
            if (shotNo == 1 && strikeBonusCount < 2 && doubleBonusCount < 2)
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
