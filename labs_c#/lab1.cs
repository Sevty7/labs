using System;
using System.Text;
using System.IO;
public class lab1
{
    public struct GeneticData
    {
        public string name;
        public string organism; 
        public string aminoAcids;  
    }

    public static List<GeneticData> data = new List<GeneticData>();
    public static void Main(string[] args)
    {
        readGeneticData("C:\\Users\\maxim\\VSProjects\\labs_c#\\labs_c#\\sequences.txt");
        readCommandsAndWrite("C:\\Users\\maxim\\VSProjects\\labs_c#\\labs_c#\\commands.txt", "C:\\Users\\maxim\\VSProjects\\labs_c#\\labs_c#\\genedata.txt");
    }

    public static void readGeneticData(string fileName)
    {
        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] fragments = line.Split('\t', 3);

                    GeneticData protein;
                    protein.name = fragments[0];
                    protein.organism = fragments[1];
                    protein.aminoAcids = fragments[2];

                    data.Add(protein);
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Ошибка FileNotFoundException: {e.Message} ");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message} ");
        }
    }

    public static void readCommandsAndWrite(string fileNameToRead, string fileNameToWrite)
    {
        try
        {
            using (StreamReader sr = new StreamReader(fileNameToRead))
            using (StreamWriter sw = new StreamWriter(fileNameToWrite))
            {
                int counter = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    counter++;
                    string[] fragments = line.Split('\t', 3);

                    if (fragments[0].Equals("search"))
                    {
                        sw.WriteLine($"{counter.ToString("D3")}\t{"search"}\t{decode(fragments[1])}");
                        string s = search(fragments[1]);

                        sw.WriteLine("organism\t\t\tprotein");
                        sw.WriteLine(search(fragments[1]));
                        sw.WriteLine("================================================");
                    }
                    else if (fragments[0].Equals("diff"))
                    {
                        sw.WriteLine($"{counter.ToString("D3")}\t{"diff"}\t{fragments[1]}\t{fragments[2]}");
                        sw.WriteLine("amino-acids difference:");
                        sw.WriteLine(diff(fragments[1], fragments[2]));
                        sw.WriteLine("================================================");
                    }
                    else if (fragments[0].Equals("mode"))
                    {
                        sw.WriteLine($"{counter.ToString("D3")}\t{"mode"}\t{fragments[1]}");
                        sw.WriteLine("amino-acid occurs:");
                        sw.WriteLine(mode(fragments[1]));
                        sw.WriteLine("================================================");
                    }
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Ошибка FileNotFoundException: {e.Message} ");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message} ");
        }
    }
    public static string encode(string s)
    {
        int counterOfLetters = 1;
        StringBuilder encodedString = new StringBuilder();

        for (int i = 1; i <= s.Length; i++)
            {
                if (i < s.Length && s[i] == s[i - 1])
                {
                    counterOfLetters++;
                }
                else
                {
                    if (counterOfLetters > 2)
                        encodedString.Append(counterOfLetters).Append(s[i - 1]);
                    else
                        encodedString.Append(new string(s[i - 1], counterOfLetters));

                    counterOfLetters = 1;
                } 
            }

        return encodedString.ToString();
    }
    public static string decode(string s)
        {
            int counterOfLetters = 1;
            StringBuilder decodedString = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    counterOfLetters = s[i] - '0';
                }
                else
                {
                    decodedString.Append(new string(s[i], counterOfLetters));
                    counterOfLetters = 1;
                }
            }

            return decodedString.ToString();
        }

    public static string search(string aminoAcids)
    {
        string decodedAminoAcids = decode(aminoAcids);
        List<string> results = new List<string>();

        foreach (GeneticData item in data)
        {
            if (item.aminoAcids.Contains(decodedAminoAcids)) results.Add($"{item.organism}\t{item.name}");
        }

        return results.Count > 0 ? string.Join("\n", results) : "NOT FOUND";
    }

    public static string diff(string nameOfProtein1, string nameOfProtein2)
    {
        string aminoAcids1 = getAminoAcids(nameOfProtein1);
        string aminoAcids2 = getAminoAcids(nameOfProtein2);

        aminoAcids1 = decode(aminoAcids1);
        aminoAcids2 = decode(aminoAcids2);

        int minLen = Math.Min(aminoAcids1.Length, aminoAcids2.Length);
        int diff = 0;

        for (int i = 0; i < minLen; i++)
        {
            if (aminoAcids1[i] != aminoAcids2[i])
                diff++;
        }

        diff += Math.Abs(aminoAcids1.Length - aminoAcids2.Length);

        return diff.ToString();
    }

    public static string mode(string nameOfProtein)
    {
        string aminoAcids = getAminoAcids(nameOfProtein);
        aminoAcids = decode(aminoAcids);
        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char ch in aminoAcids)
        {
            if (counts.ContainsKey(ch))
                counts[ch]++;
            else
                counts[ch] = 1;
        }

        int maxCount = 0;
        char result = ' ';

        foreach (var kv in counts)
        {
            if (kv.Value > maxCount || (kv.Value == maxCount && kv.Key < result))
            {
                maxCount = kv.Value;
                result = kv.Key;
            }
        }

        return $"{result}\t{maxCount}";
    }

    public static bool isValid(string s)
    {
        string validAminoAcids = "acdefghiklmnpqrstvwyACDEFGHIKLMNPQRSTVWY";
        s = decode(s);

        foreach (char c in s)
        {
            if (!validAminoAcids.Contains(c))
                return false;
        }

        return true;
    }

    public static string getAminoAcids(string nameOfProtein)
    {
        foreach (GeneticData item in data)
        {
            if (item.name.Equals(nameOfProtein))
            {
                return item.aminoAcids;
            }
        }

        return "MISSING";
    }


}