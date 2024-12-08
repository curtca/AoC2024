﻿public class Test
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
            new object[] { sample, 34 },
            new object[] { input, 1266 },
        };    

static string sample = 
@"............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............";

static string input = 
@"...............3................d.................
.........................s..7......i.....e........
................C.......................e.........
...............Z.......m....................e.....
....................gC.....q......................
...............Q....s..........................A..
................................s........A........
...........n.....3.C..F......w..m...d.............
..E...............3.....m......d.i................
............f.3.......C....d........A.............
.........Z...........................n..A.........
....Q......p..............g.i.....................
.r......n...Q....p............S.7...........O.....
..........r......K....p.....M..........7....G.....
....................Fs...................G........
..z.........D..........G.g........................
rR.............F................M...............G.
.........I..c.nr...............M................O.
...I..............................................
...................f......I.......................
z.I...............f..K..........0................7
k...................K......u.........O............
.........Q...z.................ga......0.......o..
....E.5..F..................u..b.P......a.1.......
..........k9..................K.........H......1..
.E.........h..........................0......a...H
..........9...h..e........i......M....1...........
.c.............z.......................j.........T
c..D......................Pb.................2....
....................w.y......W......j.........T.2.
......ph...N..................y.......W.t.2.......
............9.................................o..1
.................Vq.......u....Pb.................
.......6R.........................................
........5............w...a.W.............H.j......
......Z.......Y..........V............H..2........
..........D.................v..y.........t...T..o.
.......5...................t......................
........8k...l...............v.........S....T...4.
......6....U......PR........b.B....y..............
..........6.V...U........................L........
.......8.........N....4.Vq.v..t......oJ.....L.....
N...........R.................w.JY................
............N.....................................
.....5Y.....................................j.....
.98........Y.....l.............B...........S...L..
.8...............U...............4................
..................W.........U4....................
...E........l..........B......................L..u
.....D............l....J..q.....................S.";


}
