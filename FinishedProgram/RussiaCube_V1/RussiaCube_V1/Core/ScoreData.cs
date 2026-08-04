using System;
using System.Collections.Generic;
using System.Text;

namespace RussiaCube_V1.Core
{
    internal static class ScoreData
    {
        private static int _score = 0;
        public static int Score { get { return _score; } }

        public static void AddScore(int score)
        {
            _score += score;
        }
        
    }
}
