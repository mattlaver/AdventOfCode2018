using System;
using System.Linq;
using System.Threading;

namespace CheckSumCalculator
{
    public class CheckSumCalculator
    {
        public (int twoCount, int threeCount) EvaluateBoxId(string boxId)
        {
            var twoCount = boxId.GroupBy(c => c).Count(c => c.Count<char>() == 2) > 0 ? 1 : 0;
            var threeCount = boxId.GroupBy(c => c).Count(c => c.Count<char>() == 3) > 0 ? 1 : 0;

            return (twoCount, threeCount);
        }

        public int Checksum(string[] boxIds)
        {
            var twoCount = 0;
            var threeCount = 0;

            foreach (var boxId in boxIds)
            {
                var counts = EvaluateBoxId(boxId);
                twoCount += counts.twoCount;
                threeCount += counts.threeCount;
            }

            return twoCount * threeCount;
        }
    }
}
