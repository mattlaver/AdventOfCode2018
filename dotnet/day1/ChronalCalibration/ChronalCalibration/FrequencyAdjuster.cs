using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChronalCalibration
{
    public class FrequencyAdjuster
    {
        private IList foundFrequencies = new List<int>();

        public int CalculatedFrequency(string[] offsets)
        {
            return offsets.Aggregate(0, (current, offset) => current + int.Parse(offset));
        }

        public int? FindFirstDuplicate(string[] offsets)
        {
            foundFrequencies.Clear();
            
            int? frequencyFoundTwice = null;
            var seed = 0;
     
            while (frequencyFoundTwice == null)
            {
                seed = offsets.Aggregate(seed, (current, offset) =>
                {
                    var frequency = current + int.Parse(offset);
                    if (foundFrequencies.Contains(frequency))
                    {
                        frequencyFoundTwice = frequency;
                    }
                                       
                    foundFrequencies.Add(frequency);
                    return frequency;
                });

            }

            return frequencyFoundTwice;
        }
    }
}
