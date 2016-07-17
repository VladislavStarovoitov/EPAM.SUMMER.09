using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    public class WordFrequency
    {
        private string _path;

        public String FilePath
        {
            get
            {
                return _path;
            }
            set
            {
                if (value != String.Empty)
                    _path = value;
                else
                    throw new ArgumentException();
            }
        }

        public Dictionary<string, double> GetWordFrequency()
        {
            Dictionary<string, double> tempResult = new Dictionary<string, double>();
            Dictionary<string, double> result = new Dictionary<string, double>();
            if (File.Exists(FilePath))
            {
                using(var file = File.OpenRead(FilePath))
                {
                    using(var textFile = new StreamReader(file))
                    {
                        string fullText = textFile.ReadToEnd();
                        int wordCount = 0;
                        StringBuilder word = new StringBuilder();
                        foreach (char @char in fullText)
                        {
                            word.Clear();
                            if (char.IsLetter(@char))
                                word.Append(@char);
                            else
                            {
                                string strWord = word.ToString();
                                if (strWord != String.Empty)
                                {
                                    if (tempResult.ContainsKey(word.ToString()))
                                        tempResult[strWord]++;
                                    else
                                        tempResult.Add(strWord, 0);
                                    wordCount++;
                                }
                            }                                    
                        }
                        foreach (var pair in tempResult)
                        {
                            result.Add(pair.Key, pair.Value / wordCount);
                        }
                    }
                }
                return result;
            }
            throw new FileNotFoundException();
        }
    }
}
