using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WordCounterService
{
    [ServiceContract]
    public interface IWordCounterService
    {
        /// <summary>
        /// WCF service for counting word in string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [OperationContract]
        long CountWords(string text);
    }
}
