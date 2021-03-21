using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WordCounterService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WordCounterService : IWordCounterService
    {
        public long CountWords(string text)
        {
            string[] textArray = text.Split(' ', '\n', '\t', '\r', '=', '!', '"', '#', '%', '&', '\'', '(', ')',
                                        '\\', '*', '-', '.', '/', ':', ';', '?', '@', '[', '\\', ']', '_', '{', '}');

            long counter = 0;

            foreach (string txt in textArray)
            {
                foreach (char ch in txt)
                {
                    if (Char.IsLetterOrDigit(ch))
                    {
                        counter++;
                        break;
                    }
                }
            }

            return counter;
        }
    }
}
