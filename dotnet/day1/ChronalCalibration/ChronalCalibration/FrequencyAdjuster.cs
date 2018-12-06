using System.Linq;

namespace ChronalCalibration
{
    public class FrequencyAdjuster
    {
        public int CalculatedFrequency(string[] offsets)
        {
            return offsets.Aggregate(0, (current, offset) => current + int.Parse(offset));
        }
    }
}
