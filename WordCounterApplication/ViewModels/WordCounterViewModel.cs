using System.Windows.Input;
using WordCounterApplication.Enums;
using WordCounterApplication.Factories;
using WordCounterApplication.Interfaces;
using WordCounterApplication.ServiceProxies;

namespace WordCounterApplication.ViewModels
{
    /// <summary>
    /// WordCounterViewModel implements ViewModelBase and represent connection between bussines logic and UI. 
    /// </summary>
    class WordCounterViewModel : ViewModelBase
    {
        #region Fields
        private ReaderFactory readerFactory;
        private IReader reader;
        private string text;
        private long numberOfWords;
        #endregion

        #region Properties

        /// <summary>
        /// Represent texts provided from reader.
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        /// <summary>
        /// Text reader
        /// </summary>
        public IReader Reader
        {
            get
            {
                return reader;
            }
            set
            {
                reader = value;
                OnPropertyChanged(nameof(Reader));
            }
        }

        /// <summary>
        /// Number of words in textual file
        /// </summary>
        public long NumberOfWords
        {
            get
            {
                return numberOfWords;
            }
            set
            {
                numberOfWords = value;
                OnPropertyChanged(nameof(NumberOfWords));
            }
        }


        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public WordCounterViewModel()
        {
            readerFactory = new ConcreteReaderFactory();
        }

        #region Commands

        private ICommand fileReaderCommand;
        public ICommand FileReaderCommand
        {
            get
            {
                if (fileReaderCommand == null)
                {
                    fileReaderCommand = new RelayCommand(
                        p => CanExecuteFileReaderCommand(),
                        p => FileReaderCommandExecute());
                }
                return fileReaderCommand;
            }
        }

        private ICommand databaseReaderCommand;
        public ICommand DatabaseReaderCommand
        {
            get
            {
                if (databaseReaderCommand == null)
                {
                    databaseReaderCommand = new RelayCommand(
                        p => CanExecuteDatabaseReaderCommand(),
                        p => DatabaseReaderCommandExecute());
                }
                return databaseReaderCommand;
            }
        }

        private ICommand userInputReaderCommand;
        public ICommand UserInputReaderCommand
        {
            get
            {
                if (userInputReaderCommand == null)
                {
                    userInputReaderCommand = new RelayCommand(
                        p => CanExecuteUserInputReaderCommand(),
                        p => UserInputReaderCommandExecute());
                }
                return userInputReaderCommand;
            }
        }

        private ICommand calculateNumberOfWordsCommand;
        public ICommand CalculateNumberOfWordsCommand
        {
            get
            {
                if (calculateNumberOfWordsCommand == null)
                {
                    calculateNumberOfWordsCommand = new RelayCommand(
                        p => CanExecuteCalculateNumberOfWordsCommand(),
                        p => CalculateNumberOfWordsCommandExecute());
                }
                return calculateNumberOfWordsCommand;
            }
        }

        private ICommand clearTextCommand;
        public ICommand ClearTextCommand
        {
            get
            {
                if (clearTextCommand == null)
                {
                    clearTextCommand = new RelayCommand(
                        p => CanExecuteClearTextCommand(),
                        p => ClearTextCommandExecute());
                }
                return clearTextCommand;
            }
        }

        #endregion

        #region Methods

        private void UserInputReaderCommandExecute()
        {
            Reader = readerFactory.CreateReader(ReaderType.UserInputReader);
            Text = reader.Read();
            ClearValues();
        }

        private bool CanExecuteUserInputReaderCommand()
        {
            return true;
        }

        private void FileReaderCommandExecute()
        {
            Reader = readerFactory.CreateReader(ReaderType.FileReader);
            Text = reader.Read();
            ClearValues();
        }

        private bool CanExecuteFileReaderCommand()
        {
            return true;
        }

        private void DatabaseReaderCommandExecute()
        {
            Reader = readerFactory.CreateReader(ReaderType.DatabaseReader);
            Text = reader.Read();
            ClearValues();
        }

        private bool CanExecuteDatabaseReaderCommand()
        {
            return true;
        }

        private void CalculateNumberOfWordsCommandExecute()
        {
            IWordCounterServiceProxy wordCounterService = new WordCounterServiceProxy();
            NumberOfWords = wordCounterService.GetNumberOfWords(Text);
        }

        private bool CanExecuteCalculateNumberOfWordsCommand()
        {
            return !string.IsNullOrEmpty(Text);
        }

        private void ClearTextCommandExecute()
        {
            Text = null;
            NumberOfWords = 0;
        }

        private bool CanExecuteClearTextCommand()
        {
            return !string.IsNullOrEmpty(Text);
        }
        #endregion

        #region Private Methods

        private void ClearValues()
        {
            NumberOfWords = 0;
            Reader = null;
        }

        #endregion
    }
}
