using System;
using Xunit;
using ChronalCalibration;

namespace ChronalCalibrationTests
{
    public class FrequencyAdjusterTests
    {
        [Fact]
        public void ShouldCalculateOffsetsAgainstZero()
        {
            var offsets = new string[]
            {
                "+1",
                "+2",
                "-1",
                "+3"
            };

            var frequencyAdjuster = new FrequencyAdjuster();
            var result = frequencyAdjuster.CalculatedFrequency(offsets);
            Assert.Equal(5, result);
        }

        [Fact]
        public void ProcessPuzzleInput()
        {
            var offsets = System.IO.File.ReadAllLines(@"C:\projects\AdventOfCode2018\dotnet\day1\puzzleinput.txt");
            var frequencyAdjuster = new FrequencyAdjuster();
            var result = frequencyAdjuster.CalculatedFrequency(offsets);
            Console.WriteLine(result);
        }
    }
}
