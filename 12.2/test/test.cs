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
            new object[] { sample1, 80 },
            new object[] { sample5, 436 },
            new object[] { sample3, 236 },
            new object[] { sample4, 368 },
            new object[] { sample2, 1206 },
            new object[] { input, 808796 },
        };    

static string sample1 = 
@"AAAA
BBCD
BBCC
EEEC";

static string sample5 = 
@"OOOOO
OXOXO
OOOOO
OXOXO
OOOOO";

static string sample3 = 
@"EEEEE
EXXXX
EEEEE
EXXXX
EEEEE";

static string sample4 = 
@"AAAAAA
AAABBA
AAABBA
ABBAAA
ABBAAA
AAAAAA";

static string sample2 = 
@"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE";

static string input = 
@"CCCCCCCCCBBBMMGGGGGGGGGGGGGYWWWWWWWWWWWWOOOOOOOOOOOOOOOOHLLHHHHHHHHHHTHUUUULBBBBBBBBBBBBPPPPPPPPPPPKKWWWWCCCWWWWWWWWWWWWWWWWWWWWEEEEYNNNYYLL
CCCCCCCCCBBBBBBGGGGGGGGGGGGGWWWWWWWWWWWWOOOOOOOOOOOOOOOOHHHHHHHHHHHHHHHHUUULBBBBBBBBBBBPPPPPPPPPPPPPPPWWWCCCWWWWWWWWWWWWWWWWWWWBEEEYYYNYYLLL
CCCCCCCBBBBBBBBGGGGGGGGGGGGWWWWWWWWWWWWWOAOOOOOOOOOOOOOOHHHHHHHHHHHHHHHHUUULLLLLBBBBBBBBPSPPPPPPPPPPPMMWWCCCCCCCWWWWWWWWWWWBWWWBBBBYYYYYYYLL
CCCCCCCCBBBBBBBGGGGGGGGAAGWWWWWWWWWWWWWWWWOOOOOOOOOOOIOOHHHHHHHHHHHHHHHHUUULLLLLLLBBBJBJSSPPPPPPPPPPMMMMMCCCCCCCWWWWWWWWWBBBBBWBBBBYYYYYYYYY
CCCCCCCCCBBBBBBGGGGGGGGGAAWPPWWWWWWWWWWWWWOOOOOOOOOIIIOHHHHHHHHHHHHHHHHUULLLLLLLLBBBBJJJSSPPPPPGGGGPEEMCCCCCCCCCCCCCCCBBWWBBBBBBBBBBYYYYYYYY
CCCCCCCCCBBBBBBBGGGGGGGGAAASSWWWWWWWWWWWWWOOOUOOOIIIIIIIYHHHHHHHHHHHHHHHHHNLLLLLLLBBBBJJJJVPPPPGGGGPEEMCCCCCCCCCCCCCCCBBBBBBBBBBBBBYYYYYYYYY
CCCNNNCCBBBBBBBBGEGGGGGAAAAASWWWWWWWWWWWWWXOOOOIIIIIIIYYYHHHHHHHHHHHHHHHGGLLLLLLLLLBBJJJJJJPPPPGGGGPMEMCCCCCCCCCCCCCCCBBBBBBBBBBBBBYYYYYYYYY
CCNNNNNBBBBBBBBBBEBSGGGGGGSSSWWWWWWWWUWXXXXXXOOIVVVIIIIIYHHHYYHHHYYYYHHHGLLLLLLLLLLLLJJJJJPPPPPGGGGPMMMMMMMCCCCCCCCCCBBBBBBBBBBBBYYYYYYYYYYM
NNNNNNNVVVBBBBBBBBBSGGSSSSSSSSWWWWWWWUWWXXXXXXOVVVIIIIIIYYYYYYYYHYYYYYHHGGLLLLLLLLLLLJJJJJJJPPPGGGGPMMMMMMMCCCCCCCCCCBBBBBBBBBBBBBBYYYYYYMMM
NNNNNNNVVVBBBBBBBBBSGGSSSSSSSDDWWWWWWWWXXXXXXXOOIIIIISIIYYYYYYYYYYYYDYYGGGLLLLLLLLLLLJJJJJJJPGGGGGGPPPMMMMMCCCCCCCCCCBBBBBBBBBBBBBBYYYYYYMMM
NNNNFNNNNBNBBBBBBBSSSSSSSSSSSSSSWDWWUUNXXXXXXXXXIIIIISSSSYYYYYYYYYYYYYYGGGLLLLLLLLJJJJJJJJJJGGGGGGGPDMMMMMMCCCCCXWWWWWBBBBBBBBBBBBBYYYYYMMMM
NNNNNNNNBBBBBBBBBBSSSSSSSSSSSSSSSDDDNUNNNXXXXXXXIIXIISSSYYYYYYYYYYYYYYYGGGGGLLLLLLLJJJJJJJJJGGGGGGGPDDMDMMMXXXXXXXXXWWWWWWBBBBBBBBBYYYYMMMMM
NNNNNNNBBBBBBBBBBBSSSSSSSSSSSSSSSSNNNNNNNNXXXXXXXXXXXXSSSQQNYYYYYYYYYYGGGGGGLLLLLLLLJJJJJJJDGGGGGGGDDDDDMMDXXXXXXWWWWWWWWBBBBBBBBBHYYYMMMMMM
NNNNNNAAXXXBBBBXXBBBSSSSSSSSSSSSSENNNNNNNNNNXXXXXXXQXXQQQQQNYYYYYYYYYYYGGGGGGLLLLLLLJJJJJJJDGGGGGGGDDDDDDDDXXXXXWWWWWWWWWWWBBBBBBHHYYYMMMMMM
NNNNNNNNXXXXXXXXBBBSSSYSSSSSSSSSSNNNNNNNNNNZXXXXXXEQQQQQQQQYYYYYYYYYYYYGGGGGLLLLLLLGJJJJJJJJGGGGGGGDDDDDDXXXXXXXXWWWWWWWWWWBBBBBBHHHYYMMMMMM
NNNXXNNNXXXXXXXXXXXYYYYYSSSSSSSSIIINNNNNNNNXXCXXXXEQQQQQQQQQYYYYYYYYYYYGGGGGGGGLGLGGJJJJJJJDGGGGGGGDGDDDGGXXXXXXCWWWWWWWWWWWWABOOHHHYMMMMMMM
SNNSXNNNRXXXXXXXXXXXYYYYYSSSSSSIIIINNNNNNNNXXCCXEEEQQQQQQQQYYYYYYYYYYYYGGGGGGGGGGGGJJJJJJJJUGGGGGGGGGGGGGGGGGGXCCCWCCWWWWWAAAAAOOHHHHMMMMMMM
SSSSXSNNRXXXXXXXYYYYYEYNYSSSMHSIIIIINNNNNNNNCCCCTTEQYYQQQQQQYYYYYUYYYYYGGGGGGGGGGGJJJJJJJJJJGGGGGGGGGGGGGGGGGGXGCCCCCWWWWWAAAAAHOHHHHMMMMMMM
SSSSSSNNSJJJXXXYYYYYYYYYMSMMMMGMIMIINNNNNNNCCCCCTTEYYYQYQQQQQQMYUUYUYYGGGGGGGGIIIJJJJJJJJJJUGGGGGGGGGGGGGGGGGGDGCCCCWWWWWWAAAAAHHHHNMMMMMMMM
SSSSSSSSSSSJXXXYYYYYYYYYMSMMMMMMMMIIINNNNNNCCCCCTTEYYYYYYQQQQBBBUUYYYYYOOOOGGGIIIPJJJJJJJJUUGGGGGGUGGGGGGGGGGGGGCCCCCCAAAAAAAAAHHHHNMMMMMMMM
SSSSSSSSSSSJJJJYYYYYYYYYYMMMMMMMMMIIIINNNCCCCCCTTTTCYYYYQQQBBBBBBUUYYYYOGOOOOGIIIIIIIJJJJUUUGGGGGGGGGGGGGGGGGGGGCCCHHHAAAAAAAAAHHHHNNMMMMMMM
SSSSSSSSSSSSSJJJYYYYYYYMMMMMMMMMMMIIIINNNCSCCTTTTTYYYYYYPPQBBBBBBUUUYGYGGOGGGGIIIIIIIJJIIUUUGGGGGGGGGGGGGGGGGGCGGCCCCCAAAAAAAAAHHHNNAAAMMQMM
SSSSSSSSSSSJJJJJYYYYYYYYMMMMMMMMMIIISISSSSSCCTTTTTYYYYYYPPPPBBBBUUUUUGGGGGGGGGIIIIIIIIJIIUUUGGGGGGGGGGGGGGGGGGCCGCCCCCAAAAAAAAAKKKAKAHAMMQMY
SSSSSSSSSSSSJJDJJJYYYYYMMMMMMMMMMOOSSSSSSSSSCTETTTTYYYPYPPPPPPBBBBUGUGGGGGGGYYIIIIIIIIIIIUUUGGGGGGGGGMMMGGGGGGCCCCCCCAAAAAAAAAAKKKKKHHAAMQMY
SSSSSSSSSSSSJJDJJJYYOOMMMMMMMMMOQOFFFFSSSSSCCCCOOYYYYYPSPPPPBPBBBBGGGGGGGYGGYYIIIIIIIIIIUUUUUUUUUUUUUUMMGGGGGCCCCCCCBAAAAAAAAAAAAKKKHHHHHHYY
SWSSSSSSSSSSJJDJDDYYMOOMMMMMOMOOOOOOSSSSSSSSCCYYYYYYYYPPPPPBBBBBBBIIIIGGGYYYYYYIIIIIIIIIIIIUUUUUUUUUUMMMMMMGKCCKKCCCCAAAAAAAAAAAAKKKHHHHHHYY
SSSSSSSSSSSSJDDDDDDYMMMMMMMMOOOOMOOOOOSSSSSNCCZZZZYYYYPPPPPBBBBBBBBBBBWYGAAAAAAAIIIIIIIIIIUUUUUUUUUUUMMMMMKKKKCKKCCCBAAAAAAAAAAAAKKHHHHHHYYY
SSSSSSSJSSSSJDDDDDDMMMMMMMMMMGGOOLOCSSSSSSSSCCZZZZZYYYEEPPPBBBBBBBBBBBBYWAAAAAAAIIIIIIIIIIUUUUUUUUUUUMMMMKKKKKKKCCBBBAAAAAAAAAAAAKHHHHHHPHHY
SSSSSSSSSYYSDDDDDDDDDDMMMMMMMMMMLLSCCSSSSSSZZZZZZZZZYSPPPPPPBBBBBBBBBBBYYAAAAAAAIIIIIIIIIIUUUUUUUUUUUUUKKKKKKKKKKCCBBAAAAAAAAAAAAHHHHHHHHHHY
YYSYSSYYYYYDJDDDDDDDDDMMMMMMMMLLLLSSSSSSSSSZZZZZZZZVSSPPPMPBBBBBBBBBBBBYYAAAAAAAIIIIIIIIIIUUUUUUUUUUUKKKKKKKKKKKKBBBBAAAAAAAAAAAAHHHHHHHHHHH
YYYYSSYYYYYDDDDDDDDDDMMMMMMMMLLLLLSSSSSSSSSSZZZZZVVVSSPPPPBBBBBBBBBBBBYYYAAAAAAABIIIIJJIIIUUUUUURVKKKKKKKKKKKKKKKBBBBAAAAAAAAAAAAHHHHHHHHHHF
YYYYYYYYYYYDDDDDDDDDMMLMMMMLLLGGLLLLSSSSSSSSZZZZZVVVVSVBPBBBBBBBBAAAAAAAAAAAAAAABIIIIJJJIRRRRRRRRRRRKKKKKKKKKKEKKBBBBAAAAAAAAAAAAHHHHHHHHHHF
YYSSSYYYYYYDDDDDDDDDDMLLLLLLLLGGGGLLSSLLSSSZZZZZZVVVVVVBBBBBBAAAAAAAAAAAAAAAAAAABBIIRRRRRRRRRLRRRRRRKKKKKKKKKKKKWWWBBAAAAAAAAAAAAHHHHHHHHFFF
SSSSSSYAAYYYYDDDDDDDDDDLLLLLGGGGGGGLLLLLLSSZZZZZZVVVVVBBBBBBBAAAAAAAAAAAAAABBYYBBRIIRRRRRRRRRRRRRRRKKKKKKKKKKKKKWWWWWAAAABBBBBBBCHHHHHHAAFFF
SSSSSAAAAYAYYYYDDDDDDDDDDZZZGGGGGGGGGGLLLSSZZZZZZVVVFVBBBBBBBAAAAAAAAAAAAAABBBBBBRRRRRRRRRRRRRRRRRRKKKKKKKKKKKKKWWWWAAAAABAABIBHHHHHHHHAAAFF
SSSSSAAAAAAAYYYYDDDDDDDDZZZZGGGGGGGGGGGLLSZZZZZZVVVVVBBBBBBBBAAAAAAAAAAAAAABBBBBBBNRRRRRRRRRRRVRRRRRKKKKKKKKKKKWWWWWAAAAAAABBIIIHHHHHAAAAAAA
SSSAAAAAAAAAAAAZDDDDDDDDZZZZGGGGGGGGGGGLLZZZZZZZZVVVVVBBBBBBBAAAAAAAAAAAAAABBBBBBBBRRRRRRRRRRRVRRRRRRKKRKKKRKKWWWWWWWAAAAAAAIIIIHHHHHMAAAAAA
SSSAAAAAAAAAAADZKKKDDDDZZZZZGGGGGGGGGGGGLZYKKZKUVVVVVVBBBBBBBAAAAAAAAAAAAAABBBBBBRRRRRRRRRRRRVVVRRRRRRRRRRRRRWWWWWWWAAAAAAAAAIIIIISSAAAAAAAA
SSSAAAAAAAAAAKKKKKKKDDZZZZZZZGGGGGGGGGGGGGKKKKKUUVVOODOOBBBBBBBBBJJJJJJBBBBBBBBBBBRRRRRRRRRRRVVVRRRRRRRRRRRRWWWWWWWAAAAAAAAAAIIIISSSSAAAAAAA
SSSAAAAAAAAAAKKKKKKKZZZZZZZZZVGGGGGGGGGGXKKKKKKUVVOOOOOOBBBBBBBJJJJJJJJJJBBBBBBBBBCCRRRRRRRRRVVRRRRRRRRRRRRRWWWWWWWAAAAAAAAAAIIIIIIAAAAAAAAA
SSSAAAAAHHHHHHHHHHHHHHHHHHZZZVGGGGGGGGGKKKKKKKKUVVOOOOOOCBBBBBBBJJJJJJJJJBBBBBBBBCCRRRRRRRRIRRRRRRRRRRRRRRWWWWWWWWWAAAAAAAAAAIIIIIIAAAAAAAAA
SSSSAAAAHHHHHHHHHHHHHHHHHHZZZZQQGQQGGGQKKKKKKKKVVVOOOOOOCCBBBBBBJJJJJJJJJJJJJJBCCCCRRRCCCCCIIIRRRRRRRRRRRRWWWWWWWWAAAAAAAAVVIIIIIIIOAAAAAAAA
SSSSSSAAHHHHHHHHHHHHHHHHHHZZZZZQQQQQQQQQQKKKKKKKOOOOOOOOCCBBBBBJJJJJJJJJJJJJJJBCCCCCCCCCCCIIKKKRRRYRRRRWWWWWWKWWWKKAAAAAAAAIIIIIIIIIHAAAAAAA
SSSSSSSAABBBBKKKHHHHHHHHHHZZZZZQQQQQQQQQQQKKKKKKOOOOOOOOCCCBBBBJJJJJJJJJJJJJJCBCCCCCCCCCCCCCKKKKKRKRRRRWWWWWWKKKKKKWAAAAAAAIIIIIIIIIHAAAAAAA
SSSSSSSSABBBBBZZHHHHHHHHHHZCCEECCCCQQQQQQQKKKKKKOOOOOOOOOCBBBBBJJJJJJJJJJJJSCCCCCCCCCCCCCCCCKKKKKKKKKKKKWWWGGKKKKKKWWWAATTIIIIIIIYHHHHAAAAAA
SSSSSSSSSSSBBBBHHHHHHHHHHHZZCCCCCCCQQCQQQQNKKNOOOOOOOOOOOBBBBBBBBJJJJJJJJJJSSCCCCCCCCCCCCCCCCKKKKKKKKKKMMMGGYYKKKKKWWWWATTIIIINIIYYHYYAAAAAA
SSSSSSSSSSSSBBBHHHHHHHHHHHKKKCCCCCCCCCQQQNNKKNNOOOOOOOOFFBBBBBBBBJJJJJJJJJJJCCCCCCCCCCCCCKCCKKKKKKKKMMMMMMMGGKKKKKKWWWWTTTTITIIIKYYYYYAAAAJA
SSSSSSSSSSSSSSBHHHHHHHHHHHHHKCCCCCCCCCNNNNNNNNNNOOOOOOOFFFFBUBHHHHHJJJJAJQQJQCCCDCCCJCKKCKKKKKKKKKKMMMMMMMGGGKKKKKKTTTTTTTTTTTTIKYYYYYAYAAAU
SSSSSSSSSFFFFBBHHHHHHHHHHHHHHCCCCCCCYCYNNNNNNNNNNNNOOOORRRRRRTZHZZZJJJJJJQQQQCBCCCCCCCKKKKKKKKKKKKKKMMMMKMGGGKKKKKKTTTTTTTTTTTTTTTYYYYYYYAAU
SSSSSSSSFFFFFBBHHHHHHHHHHHHHHCCCCCYCYYYYYNNNNNNNNNNOONARRRRRZZZZZZZJJJJQQQQQQQCCCCCCCDKKKKKKKMMKKKKKKMMMKMGGGKKKKKKTTTTTTTTTTTTTXTYYYYYYYYYY
SMSSSSSSJFFFFFBHHHHHHHHHHHHHHHCCCCYYYYYYYYYNNNNNNNNNNNRRRZZZZZZZZZZZZJJQQQQQQQQQCCCCDDKBKKBKMMMKKKKKKMMKKKJGGGGGKKKTTTTTTTTTTTTTTTTTTYYYYYYY
YJJSSSSJJFGFFFBHHHHHHHHHHHHHHHCCCYYYYYYYYYNNJNNNNNNNNNVRRRRZZZZZZZZZZQQQQQQQQQQQCCCCCGBBBBBBBMAMKKKKKKKKKCGGGGGKKKKTTTTTTTTTTTTTTTTYYYYYYYYW
YGJJSSSJJJFFJJJHHHHHHHHHHHDLHHHCYYYYYYYYYYYYNNNNNNNNNVVVVRRRZZZZZZZZZQQQQQQQQQQQQQCCCGBBBBGBBMMMKKKKKKKKKCCGGGGKKKKKTTTTTTTTTTTTTTTTYYYYYYYY
YGJSSJJJJJJJJJJHHHHHHHHHHHLLLLLLYYYYYYYYYYYYNNNNNNNNNNVVVRRRRRZZZZZZZQQQQQRQQQQQQQQCGGGGGBGMMMMMMMKKCKKCCCCCZGGKKKKKTTTTTTTTTTTXTTTTYMMYYYYY
GGJJJJJJJJJJJJJJJHHHHHHHLLLLLLLLLYYYYYYYYYYYYNNNNNNNNNVVVRRRRRZZZZZZRQQRRQRRQKKQQQQCQGGGGGGMMMMMMKKCCCKCCCCCCGKKKKKKTTTXXXXXTTTXTTMTMMMMMYYY
GGGGJJJJJJJJJJJJJHHHFHHLLLLLLLLLLYYYYYYYYYYYYNNNNNNNNNNVRRRRRZZZZZZZRRRRRRRRRKKKQQQQQQGGGGGGMMMCMCCCCCCCCCCCCCKKKKKKTTTXXXXXXXXXXXMMMMMMAYYY
GGGGGJJJJJJJJJJJJHHHHHHLLLLLLLLLLYYYYYYWYYWYYYNNNNNNNNSSSRRRRAAZZZZRRRRRRRRRRKEKKQQQQGGGGGGOOOMCCCCCCCCCCCCCCNNNNNNNNNNNNNNNNNNMMMMMMMMMMYYA
GGGGGJJGTTTTJJJJJLLLLLLLLLLLLLLLLLLYWYWWWWWYYNNNNNNNNNSSSSRKAAAZZZRRRRRRRRRKKKKKKQQQQQGFGGGOOOICCCCCCCCCCCCCCNNNNNNNNNNNNNNNNNNXMMMMMMMMMMYA
GGGPPGJGTTTTJTJJJLLLLLLLLLLLLLLLLLYYWWWWWWWWYYYNSNNNNSSSSABAAAAZZRRRRRRRRRRKKKKKNNNNQQFFFFGOOOCCCCCCCCCCCCCCCNNNNNNNNNNNNNNNNNNMMMMMMMMMMMAA
GGGGGGGGTTTTTTTLLLLHLLLLLLLLLLDLLLLWWWWWWWWWYYYSSNNSSSSSSAAAAAAAAARRRRRRRRRRKKKKKNNNNQQFFOOOOOOCCCCCCCCCCCCJGNNNNNNNNNNNNNNNNNNMMMMMMMMMMMAN
GGGGGGGGGTTTTTTTTTTHLSLLLLLLLLDLLLXXWWWWWWWWYYYSNNNSSSSSSAAAAAAALLRRRRRRRRRRRKKRNNNNQQRFFOOOOOOCCCCCCCCCCCCJJNNNNNNNNNNNNNNNNNNMMMMMMMMMNDNN
GGGGGWGGGTTTTTTTFFSSSSSSLLLLLLLLLBWWWWWWWWWWYYYSSSSSSSSSSAAAAAAAAARRRRRRRRRRRRRRNNSSRRRRRRROOOOOOCCCCCCCCJJJJNNNNNNNNNNNNNNNNNNXXXMMMNNNNNNN
GGGGWWWGGTTTTTTFFSSSSSSSLLLLLLLLKBWWWWWWWWWWYYYYSSSSSSSSBJJAAAAAAARRRRRRRRRRRRNNNNNNOORRRRRROOOOOCCCCCCCJJJJJNNNNNNNNNNQQQQXXXXXXXXXXNNLNNNN
GGGWWWWTTTTTTTTTTOSSSSSSBLSSHLLLKKJWWWWWWWWWWYYRRSRSRSBBBJJJAAAAAAARRRRRRRRRRRNNNNNNOOOORRRRRRROOOOOOJJJVJJJJJJJNNNQQQQQQQQQXXXXXXXXXNNNNNNQ
GGGWWWTTTTTTTTKSSSSSSSSSSSSSHLLLKKKWMWWWWWWWWWYRRRRRRBBBBBAAAAEEEAARRRRRRRRRRNNNOOOOOOORRRRRRROOOOOGJJJJJJJJJJJJNNNQQQQQQQQQXXXXXXXNNNNNNNNN
WWWWWWTTTTTTTTTJSSSSSSSSSSSSSKKKKKKWMWWWWWWWWWYRRRRRBBBBBBAAAAEEEEEEERRRRRRRRRRROOOOORRRRRRRRRROOOGGJHJJJJJJJJJJNNNQQQQQQQQQXXXXXXXNXNNNNNNN
WWWWWTTTTTTTTTTTSSSSSSSSSSHKKKKKKKUKMWWWWWWWWKKKKRRBBBBBEEEEEEEEEEEEETRRDDRRRRROOOOOORRRRRRRRRROOGGGGJJJJJJJJJJJJJQQQQQQQQQQQQQQXXXXXNNNNNNN
WWWWWWWTTTTTTTTSSSSSSSSSSSKKKKKKKKKKKWWWWWWWKKKKKRRBBBBBBBBEEEEEEEEETTRRDDRRRRRROOOLOORRRRRRROOOGGGGGJJJJJJJJJJJJCQQQQQQQQQQQQQXXXXNNNNNNNNN
WWWIWWWTTTTTTTSSSSSSSSSSSSKKKKKKKKKYYWWWWWWWWKKKKLRBEBEEEEEEEEEEEEETFTTTDDDTTTRBLLLLLLRRRRRRROOHGGGGGGJJJJJJJJJJJJWQQQQQQQQQQQQQXXXNNNRNNNNN
WWIIIWWWTTLTTTSSSSSSSSSSKKKKKKKKKPPYYWWWWWWWWKKKKLLEEEEEEEEVVVVVEEETTTTDDTTTTTTLLLLLLLLRRRRRRHHHGGGGMJJJJJJJJJJJQQQQQQQQQQQQQQQQQQNNNRRNNNNN
WWIIWWWTTKGTTTSSSSSSSSSKKKKKKKKKPPPPMMMMWWWKKKKLLLLEEEEEEVVVVVVEEEETTTTTTTTTTTTLLLLLLLLRRRIRHHHHGGGGGJJJJJJJJJJQQQQQQQQQQQQQQQQQQQQRRRDDDNNN
IIIIIWWWWGGGVVSSSSSSSSSSKKKKKKKKPPPPMMMMWWKKKKKKLLLLELEEEVVVVVVEEEEEETTTTTTTXLLLLLLLLLLLLLLHHHHHGGGGGGJJJJJJJJQQQQQLLLQQQQQQQQQQQQQQRRDDMMDD
IIIIIIWWGGGGGVVVSSSSSSSSKKKKKKKFEPPMMMMMMMKKKKKLLLLLLLEVVVVVVVVEEEEETTTTTTTTLLLLLLLLLLLLLLLHHHHHHHGGGGJJJJJJJJNQQQQQLLQQLLQQQQQQQQQQDDDDDDDD
IIIIIIGGGGGGGGGVSSSSSSSSSSKKKKKFFPPMMMMMMMKKKSSLLLLLLVVVVVVVVVEEEETETTTTTTTTTLLLLLLLLLLLLLLHHHHHHHGGGGGAJJJJJDQQQQQLLLQLLLLQQQQQQQQQDDDDDDDD
IIIIIGGGGGGGGZZZGSSSSSSSSSKKKFFFFHPMMMMMMMKSSSSLLLLLLVVTVVVVVVEEEETTTTTTTTTLLLFFFFFFFFFFLLHHHHHHHHGEEGDDDJDDDDQQQQQLLLQQLQQQQQQQQQQQDDDDDDDD
IIIIIGGGGGGGGZZZTTSSSSSSSSKKKKFFFFPMMMMMMMKKSSSLLLLLLLVVVVVVVEEEEEETTTTTTTTLLLFFFFFFFFFFHHHHHHHHHHGEDDDDDDDDDDQQIQQQQLLLLQQQQQQQQDQQDDDDDDDD
IIIIIICGGGGGGZZZTTNSSSKKKKKKKFFFFFFMMMMMMMKSSSSSLZLLLLVVVVVVVEEEEEETTTTTTTTLLLFFFFFFFFFFHHHHHIIIHHEEDDDDDDDDDDDTDDQLLLLLTTQQQQQQDDDQDDDDDDDD
IIIIIIGGGGGGGZZZNNNNKKKKKKKKKKFFFFFMMMMMMMKSSSSSFZLLLLLVVVVPVLLEETTTTTTTTTTQLLFFFFFFFFFFHHHIIIHHHHEEDDDDDDDDDDDDDDLLLLLTTTTTQQQQQDDDDDDDDDDD
ZZIIIIUGWGGGGZZZNNNNNKKKKKKKKKFFFFBKKKKKKKKSKSSSFZLLLLLLVZVPPLLLETTTTTTTTTTTOOLLLLLLLILIHIIITTTHHHEEDDDDDDDDDDDDDLLLLLLLTTTTTTDQDDDDDDDDDDDX
ZZIIIUUGWWZZZZZZNNNNNKKKKKKFFFFFFFFKKKKKKKKKKKKZZZZLLLLLVVLLLLLLEETTTTTTTTTOOONNNNNLIIIIIIIIIIIHHEEEEEDDDKKDDDDDDDLLLIIIIIIIIIIQDDDDDDDDDDDD
ZIIIIUZGGGZZZZZZNNNNKKLKLFFFFFFFFFFKKKKKKKKKKKKKZZZLLLLLLLLLLLLLEETTTSTTTTSSFNNNNNNNIIIIIIIIIIIHEEEEEEEDDKKDDDDDDLLLLIIIIIIIIIIDDDDDHHHHHHNN
ZIIIZZZZZNZZZZZZNNNNNNLLLLFFFFFFFFFKKKKKKKKKKKKKZZLLLLLLLLLLLLLEEEEETSSTTSSLFNNNNNNNIIIIIIIIIIIHHEEEEEEKKKKDDDDDDLLLLIIIIIIIIIIDDDDDHHHHHHNN
ZZIZZZZZZNZZZZZZNNNNNNLLLLFFFFFFFFFKKKKKKKKKKHKKGGSLLSLLLLLLLLLLEEESSSSSSSLLFFNNNNNNNPIIIIIIIIIIIEEEEEEEKKLLDLLLDLLLLIIIIIIIIIIDDDDDHHHHHHHN
ZZZZZZZZNNZZZZZZNNNNNLLLLLLFDFFFFQQKKKKUKKKKKKKKSGSLLSLSSSSLLLLEEEESSSSSLSLLFFFNNNNKQQQIIIIIIIIJIEEEEELLLLLLLLLLLLLKKIIIIIIIIIIDDDDDHHHHHHHH
ZZZZZZZZZZZZZZZNNNNNNNLLLLLQQQQQQQGKAKKEKKKKEEESSGSSSSSSSSSTLLLJJJESSSSLLLLLLQQQQNNNQQQIIIIIIIIIIEEEEELLLLLLLLLLKKKKKIIIIIIIIIIDDDHHHHHHHHHH
ZZZZCZZZNNZZZZZNNNNNNNLLLLLQQQQQQQQKAAKEEEEEEEESSSSSSSSSSGZTTTLJJJJSSSSSLLLLLQQQQQNNQQQIIIIIIIIIEEEEEELYLLLLLLLLKKKKIIIIIIIIIIIDHHHHHHHHHHHH
CCCCCCZZNNZZZZZNNNNNUNNLLLLQOQQQQQQQQAKEEEEEEEEESSSSSSSSEZZTTTJJJJJFSJNNLLLLLQQQQQQQQQQIIIIIIIEEEEEEEELYYLLFFLLLLPPKIIIIIIIIIIIHHHHHHHHHHHHH
CCCCCCZZNNNNNNNNNNNNLLLLLLLOOOOQQQQQQQKEEEEEEEEESSSSSSSSEZZTTTJJJJJJJJLLLLLLLQQQQQQQQQQIIIIIIIEEEEEEEEYYYLYLLLLLLLLKIIIIIIIIKKHHHHHHHHHHHHHH
LCCCZZZZZZNNNNNNNNNNNLJRRLLLOOOOOQQQQTTEETEEEEEEESSSSSSEEEZZTTJJJJJJJJJJLLLQQQQQQQQQQQQQIIIHIEEEEEEEEEEEYYYYLLLLLKMKIIIIIIIIKKHHHHHHHHHHHHHH
LCLLLZLZLNNNNNNNNNRNNRRROOLOOOOOOQQQQTEEETTTTTEEEESSSEEEEZZTTTTJJJJJJJJJLLLLQQQQQQQQQQQQIIIHHHEEEEEEEYYYYYYYYLLZLKKKIIIIIIIISSHHHHHHHHHHHHHH
LLLLLLLZLNNNNNNNRRRFRRRROOLOOOOQQQQQQTTTTTTTTTEEEEEEEEEEEZZTTTZZJJJJJJJJLLQQQQQQQQQQQQQQQQIHHHHEEYYYYYYYYYJJJJJJJKKKIIIIIIIISSSSHHHHHHHHHHHH
LLLLLLLLLNLLLLLLRRFFRRRROOLOOOOQQQQDQRTTTTTTTTEEEEEEEZZZZZZTZZZJJJJJJJJLLLQQQQQQQQQQQQQQQQHHHHHNNYYNNNNNNNCJJJJJFKKKIIIIIIIISSSGHHHHHHHHHHHH
LLLLLLLLNNLLLLLRRFFFFFRRROOOOOOYFQQQQTTTTTTTTEEEEEEEZZZZZZZZZZZZZJJJJJLLKLQQQQQQQMQQQQQQQNHHHHNNNYYYNNNNNNCJJJJJFKKKIIIIIIIISSSGGHHHHHHHHHHM
LLLLLLLLLLLLLLLFFFFFFFFFFFOOOOOYYAAAATTTTTTTTTEEEEZZOZZZZZZZZZZUZJJJJLLLQQQQQQQQMMQQQNNNNNNNNNNNNYNNNNNNNNCCOCCCFFKKIIIIIIIISSSSSSSSSPXXHMHH
LLLLLLLLLLLLLLLFFFFFFFOFOOOOOOYYYYYAAATTQTTTQTTQEEZZZZZZZZZZZZZZZJJJJJICCCCCCQQQOMQQQDDNNNNNNNNNNNNNNANNNNCCCCCCFFFFKKKKKKSSSSSSSSSSSPGGHHXX
LLLLLLLLLLLLLLLFFFFFFFOOOOOOOOOYYYYAAATTQQTTQQQQEEEEEZZZZZZZZZZZZJJJJJJCCCCCCYQQOMDDDDDNNNNNNNNNNNNNNNNNNCCCCCCFFFFFKKKKKKSSSSSSSSRSPPGGXXXX
SSSLLLLLLLLLLLLFFFFFFFFYOOYYYYYYYYYYAATTQQQQQQQQEEEEEZZZZZZZZZZZZJJJJJCCCCCCCCCCODDBDDDDDNNNNNNNNNNNNNNNNCCCCCCCFFFFFFKKKKKSSSSSSSPPPPGGGNNX
SSLLLLLLLLLLXXLFXFFFXXXYYYYYYYYYYYYAAAQQQQQQQOQQQEEEEZZZZZZZZZZZYJJYGGCCCCCCCCCCOODDVDDDDINNNNNNNNNNNNNNCCCCZQFFFFFSSFFFFKSSSSSSSSAPPPPGPNNN
LLLLLLLLLLLLXXLXXXXXXXXYYYYYYYYYYYYYYQQQQQQQQQQQQQEEEEZZZZZZZZBYYYYYGGCCCCCCCCCDDDDDDDDDDNNNNNNNNNNNNNNNNCCCZQFFFFFSSFFFFKSSSSSSSSSPPPPPPNNN
LLLLLLLLLLLLLXXXXXXXXXXYYYYYYYYYYYYQQQQQQQQQQQQPQQEEEEEFZZLZZZBYYYYYYGCCCCCCCCDDDDDDDDDDDNDNNNNNNNNNNNNNNNCCZQFFFFFSSFFFFSSSSSSSSSSSPPNNPPNN
QQQYLYYYYLLLJXXXXJXXXXYYYYYYYYYYYYYYQQQQQQQQQQQPPPPPPFFFFFLZZZZYYYYYYYCCCCCCCCCAADADDDDDDDDDNNNNNLNNJJJJCCCCZQQFFFSSSFFFSSSSSSSSSSLLPNNNNNNN
QQYYYYYWWLLLJJJJJJJXXXYYYXXXXXXXXXYYQQQQQQQQQQQPPPPNFFFFFFLLZZZYYYYYYYCCCCCCCCZAAAADDDDDDDDDDNNNLLLLJJJJJCCCQQQFQSSSSFKFSSSSSSSSSSSPPPNNNNNN
QQQQYYYYWLLLJJJJJJJJJJSNBXXXNXXXUYYYYIIJJJQQBBBPPPPPFFFFFFFZZDYYYYYYYYZCCZCCZZZAAAADDDDLLLDDDDNLLLLJJJJJJQQQQQQQQSSSSKKKKSSSSSSSHSSHHHNDDNNN
QQQQYYYYWLLLJJJJJJJJJZNNNNNNNJXXUUUYYYJJJJQQQBPPPPPFFFFFFFFKKYYYYYYKYYZZZZTTTTZZAAAAALLLKLLDLDLLLLJJJJJJJQQQQQQQQSSSSKKKKSSSSSSSHHHHHDDDDNNN
QQQYYYYYYYJJJJJJJJZZZZNNNNNNNNUUUUUUYJJJJJJJJBBPPPFFFFFFFFFKKKKKYYYKKZZZZZZZZZZZZAAAAALLLLLLLLLLLLLLLJJJQQQQQQQQQSSSSSKKKKKSSSSSSHHHHDDDDNNN
YYYYYYYYYYYJJJJJJJJZZNNNNNNNNUUJJJJJJJJJJJJJJJJBFFFFFFFFFFFFKKKKKKKKKZZZZZZZZZZZAAAAAAAGLLLLLLLLLLLJJJJJJQQQQQQQQSSSSSSKKKKKSSSSTTTTTTTDNNNN
SYYYYYYYYYYJJJJJJJJZNNNNNNNNNUUUJJJJJJJJJJJJJBBBBBFFFFFGFFFKKKKKKKKKKZZZZZZZZZAAAGGGAGGGLLLLLLLLLLLLJJJQQTQQQQQQQQQSSSKKKKKKKESTTTTTTNNDNNNN
SCYYYYYYYYYJJJJJJUZZZNNNNNNNNNUUUUJJJJJJJJJJJJBBBBFFFFGGFKKKKKKKKKKZZZZZZZZZZZAAAGYGAGGGGLLLLLLLLLLJJJJQQQQQQQQQQQQSSSSSKKKTTTTTTTTTTNNNNNNN
SCCYYYYYYJYJJJJJJUUUZNNNNNNNNUUJUUJJJJJJJJJJJLBBBBBGGGGGGKKKKKKKKKKZZZZZZZZZZZAAAGGGAGGGGLLLLLLLLLLLLLJQQQQQQQQQQQQSSSSSKKKTTTTTTTTTTTNNNNNN
CCCYYYYYJJJJJJJJUUUNZNNNNNNNNNUJJJJJJJJJJJLJJLLLBBBGGGGGGKKKKKKKKKKZZZZZZZZZZAABAGGGGGGGGGGLLLLLLLLLLLQQQQQQQQQQQQQQSSSSKKTTTTTTTTTTTTNNNMNN
CCCYYYYJJJJJJJUUUUUNNNNNNNNJJJJJJJJJJJJJJJLLLLLLLLBBGGGGGKGKKKKKKKKZZZZZZZZZZZABBBBGGGGGGGGLLLLLLLLLLLQQQQQQQQQQQQQQSSSSKKTTTTTTTTTTTTTMMMNN
CCCCCYYCJJJJJUUUUUUUNUUNNNNJJJJJJJJJJJJJJLLLLLLLLLLLGGGGGGGKKKKKKKKZZZZZZZZZZZBBBBGGGGGGGGGGGOOLLLLGGGGQQQQQQQQQQQQQSSSKKTTTTTTTTTMMTTTMMMMM
CCCCZZCCJJJJJUUUUUUUUUUUUUUJJJJJJJJJJJJJZZLLLLLLLLLLFGGGGGGGGGKKKKKZZZZZZZZZZZBBBGGGGGGGGGGGGGLLLGGGGEEEQQQQQQQQQQSQSSSSSTTTTTTTTMMMTTMMMMMM
CCCCZZZCCCJJUUUUUUUUUUUUUUUJJJJUUJJJJDDJJZZLLLLLLLZZGGGGGGGGGGKKKKKZZZZZZZZZZZBBBBGGGGGGGGGGGGLLGGGGETEEEEQQQQSSSSSSSSSXTTTTTTTMTMMMTTTMMMMM
CCCCCCCCCCJUUUUUUUUUUUUUUUUUJJJUUUDDDDDJJZZFFLLLFLZZZGGGGGGGGGGKKKKZZZZZZZZZBBBBBBGGGGGGGGGGGGLLLGGEEEEEEEQQJQSSSSUSSSSMMTMMMTTMMMMMTTTMMMMM
CCCCCCCCCCCUUUUUUUUUUUUUUUUUUJJUUUDDDDDZZZZFFLLLLLLZGGGGGGGGGGGKKKKZZKKKKZZZZBBBBBJBGGGCGGGGGGGLLGGGEEEEEEQQQSSUUUUSSSMMMMMMMMMMMMMMTTMMMMMM
CCCCCCCCCCCUUUUUUUUUUUUUUUUUUUUUUDDDDDDDZZFFFFLPWWLEGGGGGGGGGGKKKKKKKKKLZZZZZZBBBBJBGCCCCGGGGGGGLGGGEBBEEEEQSSUUUUUSUSSMMMMMMMMMMMMMMMMMMMMM
CCCCCCCCCCCCUUUUUUUUUUUUUUUUUUUUUUDDDDDZZFFFFPLPWWWEGGGGGGESSSSSSSSSSSLLLLZZBBBBBBBBGGGCCCGGGGGGGGGGGGEEEEEESSUUUUUUUMMMMMNNNNNNNMMMMMMMMMMM
CCCCCCCCCCCCUUUUUUUUUUUUUUUUUUUUUUDZDDDDZZZZZPPPWWPEEEEEEEESSSSSSSSSSSLLLLLZBBBBBBBBGGCCCXGGGGNNKNGGGAAEEEEEEBBUUUUUMMUMNNNNNNNNNNMMMMMMMMMM
CCCCCCCCCLLUUUUUUUUUUUUUUUUUUUUUUUUZZZZZZZZPPPPPPPPPEEEEEEESSSSSSSSSSSLLLLLLBBBBBIBBGGCCXXGGNNNNNNGGAAAEAAAENBBUUBUUUUUMMNUNNNNNNMMNMMMBMBBS
CCYYCCCCCLLLUUUUUUUUUUUUUUUUUUUUUUUZZZZZZZZPPPPPEPPPPEEEEEESSSSSSSSSSSLLLLLBBBBBBBBIIGCCXCCWWWNNZNVGAAAAAAABBBBCBBBUUUUUUNUNNKNNNNNNNMMBBBBB
YCYYYYYCCLLLUUULUUUUUUUUUUUUUUUUUUUUZZZZZZZPPPPPPPPPPEEEEEKKKSSSSSSSSSLLLLLLBBBBBBIIIIICCCCWWNNNNVVVFAFAAAABBBBBBBBBBBBUUUUUNNNNNNNNNMBBBBBB
YYYYYYYCLLLLLLLLLUWUUUUUUUUUUUUUUUUUZZZZZZZZPPPPPPPPPEEEEEKKKSSSSSSSSSLLLLLLBBBBBIIIIIIUCFCWWNNNVVVVFFFFAAAABBBBBBBBBBUUUUUUNNNNNNNNABBBBBBB
YYYYYYCCLLLLLLLCLCCRUUUUUUUUUUXXUUUUZZZZZZPPPPPPPPPPPEEEKKKKKSSSSSSSSSLLLLLLLBBBBBYIIIIIIFFNNNNNVVVFFFFFFFFABBBBBBBBBBBUUUUUNUUNNNNNANNNBBBN
YYYYYYYYYYPPLLCCCCCCCCUUUUUUUUXXNDNZZZZZZZPPPPPPPPPRREEEEEERASSSSSSSSSLLLLLLLBYBBYYYYYYYIFFNNNNNNVVFFFFFFFFABBBBBBBBBBBBUUUUUUUNNNNNNNNNNNNN
QYYYYYYYYYPLLLLCCCCCCCCCTTUUUUNNNNNZZZZZZZZPPPPPPPPRNNEEEEEESAAAABBBLLLLLLLLLLYBYYYYYYYYFFKKKKKKKKZFFFFFFFFFBBBBBBBBBBBBUUUUUUUUNNNNNNNNNNNN
YYYYYYYYPPPPPLLCCCCCCCCCCCAAUUNNNNNZZNNNZPPPPPPPPPPRRREREMESSQAAALLLLLLLLLALAYYYYYYYYYYYFFKKKKKKKKZZFFFFFFFRRRRBBBBBBBBUUUUUUUUUNNNNNNNNNNNN
EEYYYYYYPPPPPPPCCCCCCCCCCAAAUUNNNNNZZNNNZPPPPPPPPRRRRRRRORRSSQQAAALALLLLLLAAAAYYYYYYYYYNNNKKKKKKKKZZFFFFFFFFRRRBBBBBBBUUUUUUUUUUNNNNNNNNNNNN
EEYMMPPPPPPPPPPCCCCCCCCCCCCNNNNNNNNNNNNXPPPPPPPPPRRRRRRRRRRRQQQAAAAAALLLLLAAAAYYYYYYYYNNNNKKKKKKKKZZFFFFFFFFRRBBBBBBBBUUUUUUUUUUNNNNNNNNNNNN
EEYYPPPPPPPPPPGCCCCCCCCCCCDNNNNNNNNNNNNNPPPPPPPPRRRRRRRRRRRYQQQQQQQQALLLAAAAAAAYYYYYNNNNNNKKKKKKKKFFFFFFFFFFFRRRBBBBBRRRUUUUUUUUNNNNNNNNNNNN
EEENNPPPPPPPPGGCMCCCCCCNNNNNNNNNNNNNNNNNPPPPPPPPRVRVRRRRRRYYYFQQQQQEQQQVAAAAAAAYYYYYYNNNNNKKKKKKKKKKKKFFFFFFFFFBBBCCBRRRRRUUUUUUNNNNNNNNNNNN
EEEPPPPPPPPPPPPCMCCCCCCNNNNNNNNNNNNNNNNNKPPPPPPPPVRVRRRRRYYYYFQQQQQQQQQQQAAAAAAYYYYYYNNNNNKKKKKKKKKKKKFFFFFFFFFFFFFCRRORRRRUUUUUNANNNNNNNNNN
EEEPPPPPPPPPPPMMMMCCCICMMNNNNNNNNNNNZNNNTTPTTPPPVVVVRRRRRYYYYQQQQQQQQQQQQQAAAAAYYYYYNNNNNNNNNKKKKKKKKKFFFFFFTCCCCCCCRRRRRRRUUIUNINNNNNNNNNNN
EEELPPPWWPPPMMMMMMCCCCCCMMMNNNNNNNNNZNNZTTTTTPPTVVVVVRRRYYYYQQQQQQQQQQQQAAAAAAYYYNNNNNNNNNNNNKKKKKKKKKCCCTTTTTCTTRRRRRRRRRTIIIINNNNNNNNNNNNN
UUEEEPPWMPPPPMMMMMCCCCCMMMMNNNNNNNZZZNNZTTTTTYTTVVPPVVRRRYYYYQQQQQQQQQQASAAYYAYNNNNNNNNNNNNNNNYCKKKKKKCSSTTTTTCTTTTRRRRRRTTTIITTNNNNNNNNNNNN
UUUUMMMMMPPPMMMMMMCMMMMMMMMNNNNNNNZZZZZZCTTTTTTTPPPPVVVRRRRYYQQQQQQQQQQAAAYYYYYYNNNNNNNNNNNNCYYCCCCCCCCCCTTTTTTTTTTERRRRRRRTTITTNNNNNNNNNNNN
UUUMMMMMPPMMMMMMMMMMMUUMMNNNNNNNNNZZZZZCTTTTTTTQPPPPVPPPYYYYYYQQQQQQQQQQEAAYYYYYYNNNNNNNNNNCCCCCCCCCCCCCTTTTTTTTTTTRRRRRRRRTTTTTNTNNNNNNNNNN
UUMMMMMMMMMMMMMUMMMMMMUUMMMNNNNNNNZZZZOTTFTTTTTQPPPPPPPPBYYYYQQQQQQQQQQQQYYYYYYYYYNNNNNNNANCCJCCCCCCCCCCTSTTTTTTTTTTTTRRRTTTTTTTNTNTTNNNNNNN
UMMMMMMMMMMMMMMUUUUUMUUUMMMNBNNNNZZZZZZZFFFFTTTTPPPPFPPPBYYYQQQQQQQQQQQQCQYYYYYYYYYNNNNNNCCCCCCCCCCCCCCCCCTTTTTTTTTTTTRRTTTTTTTTTTTTTNNNNNNN
UUMMMMMMMMMMMMMUUUUUUUUUUMMMBNNNZZZZZZZZFFFFUUTPPPPPPPPBBYYYQWQQQQQQQQQQQQQYYYYYYYYNNNNNNCCCCCCCCCCCCCCCCCTTTTTTTTTTTTTTTTTTTTTTTTTNNNNNNNNN";


}
