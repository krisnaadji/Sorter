using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter
{
    public class ReadWriteFile
    {
        public List<string> ReadFileToList(string fileName)
        {
            // Read txt file and store to List<string>
            List<string> read = File.ReadAllLines(fileName).ToList();
            return read;
        }

        public void WriteListToFile(string resultName, List<string> strList)
        {
            // Write txt file from List<string> type data
            using (StreamWriter writer = new StreamWriter(resultName))
            {
                strList.ForEach(writer.WriteLine);
            }
        }
    }

    public class PrintList
    {
        public void Print(List<string> strList)
        {
            strList.ForEach(Console.WriteLine);
        }
    }

    public class ReverseWords
    {
        // Swap last name to first name
        public string ReverseWordInString(string[] s)
        {
            string lastToGiven = s[s.Length-1];
            for (int i = 0; i < s.Length-1; i++)
            {
                lastToGiven += " " + s[i];
            }
            Console.WriteLine(lastToGiven);
            return lastToGiven;
        }
    }

    public class PairLists : ReverseWords
    {
        private static int _minLength = 2;
        private static int _maxLength = 4;

        public List<KeyValuePair<string, string>> MakePair(List<string> origName)
        {
            List<KeyValuePair<string, string>> pair = new List<KeyValuePair<string, string>>();
            foreach (string value in origName)
            {
                string[] s = value.Split(' ');
                if (s.Length < _minLength || s.Length > _maxLength) continue;

                pair.Add(new KeyValuePair<string, string>(ReverseWordInString(s), value));
            }
            return pair;
        }
    }

    public class Sorter
    {
        private string _resultFileName;
        private List<string> _originalNameList, _sortedNameList;

        ReadWriteFile readWriteFile = new ReadWriteFile();
        PairLists pairs = new PairLists();
        PrintList p = new PrintList();

        public Sorter(string fileName)
        {
            _originalNameList = readWriteFile.ReadFileToList(fileName);
            _resultFileName = "sorted-names-list.txt";
        }

        public void SetResultFileName(string newName)
        {
            _resultFileName = newName;
        }

        public void SortName()
        {
            List<KeyValuePair<string, string>> pairName = pairs.MakePair(_originalNameList);
            _sortedNameList = pairName.OrderBy(x => x.Key).Select(y => y.Value).ToList();
            p.Print(_sortedNameList);
            readWriteFile.WriteListToFile(_resultFileName, _sortedNameList);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Sorter nm = new Sorter(args[0]);
            nm.SortName();
        }
    }
}
