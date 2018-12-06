using Xunit;

namespace CheckSumCalculatorTests
{
    public class CheckSumCalculatorTests
    {
        private readonly string[] _boxIds = new string[]
        {
            "abcdef",
            "bababc",
            "abbcde",
            "abcccd",
            "aabcdd",
            "abcdee",
            "ababab"
        };

        private readonly string[] _boxIdsMatched = new string[]
        {
            "abcde",
            "fghij",
            "klmno",
            "pqrst",
            "fguij",
            "axcye",
            "wvxyz"
        };

        [Fact]
        public void ShouldCalculateCorrectChecmsum()
        {
            var checkSumCalculator = new CheckSumCalculator.CheckSumCalculator();
            var checksum = checkSumCalculator.Checksum(_boxIds);
            Assert.Equal(12, checksum);
        }

        [Theory]
        [InlineData("abcdef", 0, 0)]
        [InlineData("bababc", 1, 1)]
        [InlineData("abbcde", 1, 0)]
        [InlineData("abcccd", 0, 1)]
        [InlineData("aabcdd", 1, 0)]
        public void ShouldCalculateChecksum(string boxId, int twoCount, int threeCount)
        {
            var checkSumCalculator = new CheckSumCalculator.CheckSumCalculator();
            var result = checkSumCalculator.EvaluateBoxId(boxId);
            Assert.Equal(twoCount, result.twoCount);
            Assert.Equal(threeCount, result.threeCount);
        }

        [Fact]
        public void ProcessPuzzleInput()
        {
            var boxIds = System.IO.File.ReadAllLines(@"C:\projects\AdventOfCode2018\dotnet\day2\puzzleinput.txt");
            var checkSumCalculator = new CheckSumCalculator.CheckSumCalculator();
            var result = checkSumCalculator.Checksum(boxIds);
            Assert.Equal(7105, result);
        }

        [Fact]
        public void TestBoxesWithFabric()
        {
            var checkSumCalculator = new CheckSumCalculator.CheckSumCalculator();
            var result = checkSumCalculator.BoxesWithPrototypeFabric(_boxIdsMatched);
            Assert.Equal("fgij", result);
        }

        [Fact]
        public void RealBoxesWithFabric()
        {
            var boxIds = System.IO.File.ReadAllLines(@"C:\projects\AdventOfCode2018\dotnet\day2\puzzleinput.txt");
            var checkSumCalculator = new CheckSumCalculator.CheckSumCalculator();
            var result = checkSumCalculator.BoxesWithPrototypeFabric(boxIds);
            Assert.Equal("omlvgdokxfncvqyersasjziup", result);
        }
    }
}
