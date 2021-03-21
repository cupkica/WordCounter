using WordCounterApplication.Enums;
using WordCounterApplication.Interfaces;

namespace WordCounterApplication.Factories
{
    /// <summary>
    /// ReaderFactory is interface for factories that creates text readers.
    /// </summary>
    abstract class ReaderFactory : IReaderFactory
    {
        public abstract IReader CreateReader(ReaderType reader);
    }
}
