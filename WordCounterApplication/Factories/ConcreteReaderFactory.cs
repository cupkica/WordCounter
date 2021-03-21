using System;
using WordCounterApplication.Enums;
using WordCounterApplication.Interfaces;
using WordCounterApplication.Readers;

namespace WordCounterApplication.Factories
{
    /// <summary>
    /// ConcreteReaderFactory represents factory for text readers creation depending on choosen type. 
    /// </summary>
    class ConcreteReaderFactory : ReaderFactory
    {
        public override IReader CreateReader(ReaderType reader)
        {
            switch (reader)
            {
                case (Enums.ReaderType.FileReader):
                    return new FileReader();
                case (Enums.ReaderType.DatabaseReader):
                    return new DatabaseReader();
                case (Enums.ReaderType.UserInputReader):
                    return new UserInputReader();
                default:
                    throw new ArgumentException("Reader is not supported.");
            }
        }
    }
}
