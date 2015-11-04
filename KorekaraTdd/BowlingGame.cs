using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorekaraTdd
{
    class BowlingGame
    {
        private Frame spareFrame;
        private List<Frame> strikes = new List<Frame> { };
        private IList<Frame> frames = new List<Frame> { new Frame() };

        public int FrameScore(int frameNo)
        {
            return frames[frameNo - 1].Score;
        }

        public void RecordShot(int pins)
        {
            frames.Last().RecordShot(pins);
            CalcSpareBonus(pins);
            CalcStrikeBonus(pins);
            if (frames.Last().IsFinished())
            {
                frames.Add(new Frame());
            }
        }

        public int Score()
        {
            int total = 0;
            foreach(var frame in frames)
            {
                total += frame.Score;
            }
            return total;
        }

        private void AddStrikeBonus(int pins)
        {
            foreach(var strike in strikes)
            {
                if (strike.IsNeedBonus())
                {
                    strike.AddBonus(pins);
                }
            }
        }

        private void CalcSpareBonus(int pins)
        {
            if (spareFrame != null && spareFrame.IsNeedBonus())
            {
                spareFrame.AddBonus(pins);
            }

            if (frames.Last().IsSpare())
            {
               spareFrame = frames.Last();
            }
        }

        private void CalcStrikeBonus(int pins)
        {
            AddStrikeBonus(pins);
            if (frames.Last().IsStrike())
            {
                RecognizeStrikeBonus();
            }
        }

        private void RecognizeStrikeBonus()
        {
            strikes.Add(frames.Last());
        }
    }
}
