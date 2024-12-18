public class Test
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Test1(string value, string output)
    {
        Assert.Equal(output, Lib.Function(value));
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { sample, "4,6,3,5,6,3,5,2,1,0" },
            new object[] { input, "6,7,5,2,1,3,5,1,7" },
        };    

static string sample = 
@"Register A: 729
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0";

static string input = 
@"Register A: 21539243
Register B: 0
Register C: 0

Program: 2,4,1,3,7,5,1,5,0,3,4,1,5,5,3,0";


}
