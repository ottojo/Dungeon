using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DungeonJonas
{
    static class GegenstandUtil
    {
        private static Random random = new Random();
        public static List<AGegenstand> fromFile(string filename)
        {
            List<AGegenstand> list = new List<AGegenstand>();
            string lines = File.ReadAllText(filename);
            string pattern = @"(\w*),(\d*),(\d*),(\d*),(\d*),(\d*),(\d*),(\d*),";
            MatchCollection matches = Regex.Matches(lines, pattern);
            foreach (Match match in matches)
            {
                AGegenstand gegenstand = new GenericGegenstand(match.Groups[1].Value,
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value),
                    int.Parse(match.Groups[4].Value),
                    int.Parse(match.Groups[5].Value),
                    int.Parse(match.Groups[6].Value),
                    int.Parse(match.Groups[7].Value),
                    int.Parse(match.Groups[8].Value));
                list.Add(gegenstand);
            }
            return list;
        }

        public static AGegenstand randomGegenstand()
        {
            if(random.Next(0,2) == 0)
            {
                return new Langschwert();
            }
            else
            {
                return new Helm();
            }
        }
    }
}
