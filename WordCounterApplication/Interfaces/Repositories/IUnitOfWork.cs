using WordCounterApplication.DataAccess;
using WordCounterApplication.Repositories;

namespace WordCounterApplication.Interfaces.Repositories
{
    /// <summary>
    /// IUnitOfWork is interface for entity transaction over repository.
    /// </summary>
    interface IUnitOfWork
    {
        Repository<Word> Words { get; }
    }
}
