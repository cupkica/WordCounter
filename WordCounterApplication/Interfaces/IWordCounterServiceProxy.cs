namespace WordCounterApplication.Interfaces
{
    /// <summary>
    /// IWordCounterServiceProxy is interface proxies for communcation with WCF service.
    /// </summary>
    interface IWordCounterServiceProxy
    {
        long GetNumberOfWords(string text);
    }
}
