using WordCounterApplication.Enums;

namespace WordCounterApplication.Interfaces
{
    interface IReaderFactory
    {
        IReader CreateReader(ReaderType reader);
    }
}
