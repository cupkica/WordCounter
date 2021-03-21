using WordCounterApplication.Interfaces;
using WordCounterApplication.ServiceWordCounter;

namespace WordCounterApplication.ServiceProxies
{
    /// <summary>
    /// WordCounterServiceProxy is implementation of IWordCounterServiceProxy
    /// that collects number of word in text from ServiceWordCounterClient
    /// </summary>
    class WordCounterServiceProxy : IWordCounterServiceProxy
    {
        public long GetNumberOfWords(string text)
        {
            using (WordCounterServiceClient service = new WordCounterServiceClient())
            {
                return service.CountWords(text);
            }
        }
    }
}
