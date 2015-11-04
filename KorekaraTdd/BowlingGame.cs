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
        private int strikeBonusCount = 0;
        private int doubleBonusCount = 0;
        private IList<Frame> frames = new List<Frame> { new Frame() };

        public BowlingGame()
        {
            Score = 0;
        }

        public int FrameScore(int frameNo)
        {
            return frames[frameNo - 1].Score;
        }

        public void RecordShot(int pins)
        {
            frames.Last().RecordShot(pins);
            Score += pins;
            CalcSpareBonus(pins);
            CalcStrikeBonus(pins);
            if (frames.Last().IsFinished())
            {
                frames.Add(new Frame());
            }
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

            spare = frames.Last().IsSpare();
        }

        private void CalcStrikeBonus(int pins)
        {
            AddStrikeBonus(pins);
            AddDoubleBonus(pins);

            if (frames.Last().IsStrike())
            {
                RecognizeStrikeBonus();
            }
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
    }
}
