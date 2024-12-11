public class Test
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Test1(string value, int blinks, long number)
    {
        Assert.Equal(number, Lib.Function(value, blinks));
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { sample, 25, 55312 },
            new object[] { input, 25, 231278 },
            new object[] { input, 75, 274229228071551 },
        };    

static string sample = 
@"125 17";

static string input = 
@"1750884 193 866395 7 1158 31 35216 0";

}
