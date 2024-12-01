namespace lib;

public class Test
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Test1(string value, long number)
    {
        Assert.Equal(number, Lib.Function(value));
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { sample, 0 },
            new object[] { input, 0 },
        };    

static string sample = 
@"";

static string input = 
@"";


}
