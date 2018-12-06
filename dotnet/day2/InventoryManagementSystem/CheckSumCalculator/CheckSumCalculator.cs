using System;
using System.Linq;

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

        public string BoxesWithPrototypeFabric(string[] boxIds)
        {              
            foreach (var box1 in boxIds)
            {
                foreach (var box2 in boxIds)
                {
                    var position = 0;
                    var diffCount = 0;
                    var diffPosition = 0;

                    foreach (var character in box1)
                    {
                        if (box2[position] != character)
                        {
                            diffCount++;
                            diffPosition = position;
                        }

                        position++;
                    }

                    if (diffCount == 1)
                    {
                        return box2.Remove(diffPosition, 1);
                    }                    
                }
            }

            throw new Exception("Oh No, we can't find the box!");
        }
    }
}
