using Xunit;
using System.Collections.Generic;

namespace CodingExercise.HighestOrder.UnitTest
{
    public class HighestCommonDivisorTest
    {
        public static IEnumerable<object[]> ValidInterger()
        {
            yield return new object[] { new List<int>() { 20, 100 ,80 }, 20 };
            yield return new object[] { new List<int> () { 24, 54 } , 6 };
            yield return new object[] { new List<int>() { 0, 54 }, 0 };
            yield return new object[] { new List<int>() { 2 }, 2 };
        }
        [Theory , MemberData(nameof(ValidInterger))]
        public void Correct_Highorderfactor_When_Valid_Listofintergerprovider(List<int> ValidIntergerlist,int expectedoutput)
        {
            Assert.Equal(expectedoutput,HighestCommonDivisorService.GetHighestCommonDivisor(ValidIntergerlist));
        }
    }
}
