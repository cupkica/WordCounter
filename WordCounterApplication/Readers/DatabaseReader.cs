using System.Text;
using System.Windows;
using WordCounterApplication.DataAccess;
using WordCounterApplication.Interfaces;
using WordCounterApplication.Interfaces.Repositories;
using WordCounterApplication.Repositories;

namespace WordCounterApplication.Readers
{
    /// <summary>
    /// DatabaseReader represents implementation of IReader for reading text from database. 
    /// </summary>
    class DatabaseReader : IReader
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public string Read()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (Word word in unitOfWork.Words.GetAll())
                {
                    stringBuilder.Append(word.Name + '\t');
                    stringBuilder.Append(word.Description);
                    stringBuilder.AppendLine();
                }

                return stringBuilder.ToString();
            }
            catch
            {
                MessageBox.Show("Failed to connect on database. \nPlease check configuration.", "Error");
                return string.Empty;
            }
          
        }
    }
}
