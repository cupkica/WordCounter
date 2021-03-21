using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCounterApplication.Interfaces;

namespace WordCounterApplication.Readers
{
    /// <summary>
    /// FileReader represents implementation of IReader for text file reading. 
    /// </summary>
    class FileReader : IReader
    {
        public string Read()
        {
            string allText = string.Empty;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    allText = File.ReadAllText(openFileDialog.FileName);
                }
            }

            return allText;
        }
    }
}
