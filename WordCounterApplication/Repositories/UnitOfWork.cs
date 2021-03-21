using WordCounterApplication.DataAccess;
using WordCounterApplication.Interfaces.Repositories;

namespace WordCounterApplication.Repositories
{
    /// <summary>
    /// UnitOfWork is implementation of IUnitOfWork that reads Word entites over Repository.
    /// </summary>
    class UnitOfWork : IUnitOfWork
    {
        WordDatabaseEntities wordDatabaseEntities = new WordDatabaseEntities();

        private Repository<Word> word;

        public Repository<Word> Words
        {
            get
            {
                if (word == null)
                {
                    word = new Repository<Word>(wordDatabaseEntities);
                }
                return word;
            }
        }
           
    }
}
