using System.Collections.Generic;
using System.IO;

namespace Bank
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lines = new List<string>();
            using (var sr = new StreamReader("../../InputText.txt"))
            {
                while (!sr.EndOfStream) lines.Add(sr.ReadLine());
            }

            var results = new List<string>();
            for (var i = 0; i < lines.Count; i += 4)
            {
                var resultLine = string.Empty;
                if (lines[i].Length != 27)
                {
                    results.Add("Wrong number!");
                    continue;
                }

                for (var j = 0; j < lines[i].Length; j += 3)
                {
                    var fragments = GetFragments(lines[i].Substring(j, 3)) +
                                    GetFragments(lines[i + 1].Substring(j, 3)) +
                                    GetFragments(lines[i + 2].Substring(j, 3));


                    switch (fragments)
                    {
                        case 2:
                            resultLine += 1;
                            break;
                        case 3:
                            resultLine += 7;
                            break;
                        case 4:
                            resultLine += 4;
                            break;
                        case 5:
                        {
                            if (lines[i + 1][j + 2] != '|')
                                resultLine += 5;
                            else if (lines[i + 2][j + 2] != '|')
                                resultLine += 2;
                            else resultLine += 3;
                        }
                            break;
                        case 6:
                        {
                            if (lines[i + 1][j + 2] != '|')
                                resultLine += 6;
                            else if (lines[i + 2][j] != '|')
                                resultLine += 9;
                            else resultLine += 0;
                        }
                            break;
                        case 7:
                            resultLine += 8;
                            break;
                        default:
                            {
                                results.Add("Wrong number!");
                                continue;
                            }
                    }
                }

                results.Add(resultLine);
            }

            using (var sw = new StreamWriter("../../OutputText.txt"))
            {
                for (var i = 0; i < results.Count; i++)
                    sw.WriteLine(results[i]);
            }
        }

        public static int GetFragments(string line)
        {
            var res = 0;
            for (var i = 0; i < line.Length; i++)
                if (line[i] == '_' || line[i] == '|')
                    res++;
            return res;
        }
    }
}