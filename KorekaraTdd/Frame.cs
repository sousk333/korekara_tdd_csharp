using System;

namespace KorekaraTdd
{
    class Frame
    {
        private int score = 0;
        private int bonusCount = 0;

        public int Score {
            get
            {
                return score + Bonus;
            }
            private set
            {
                score = value;
            }
        }

        public int Bonus { get; private set; }

        private int shotCount = 0;

        public Frame()
        {
            Score = 0;
            Bonus = 0;
        }

        public void AddBonus(int bonus)
        {
            Bonus += bonus;
            bonusCount++;
        }

        public bool IsFinished()
        {
            return Score >= 10 || shotCount > 1;
        }

        public bool IsSpare()
        {
            return Score >= 10 && shotCount > 1;
        }

        public bool IsStrike()
        {
            return Score >= 10 && shotCount == 1;
        }

        public bool IsNeedBonus()
        {
            if (IsSpare())
            {
                return bonusCount < 1;
            }

            if (IsStrike())
            {
                return bonusCount < 2;
            }

            return false;
        }

        public void RecordShot(int pins)
        {
            CheckPinsCount(pins);
            Score += pins;
            shotCount++;
        }

        private void CheckPinsCount(int pins)
        {
            if ((pins < 0 || 10 < pins) && Score + pins <= 10)
            {
                throw new ArgumentException();
            }
        }
    }
}
