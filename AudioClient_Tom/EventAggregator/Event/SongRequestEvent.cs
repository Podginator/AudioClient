using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventAggregator.Event
{
    /// <summary>
    /// The Request the event, 
    /// </summary>
    public class SongRequestEvent
    {
        /// <summary>
        /// The Request Type
        /// </summary>
        public enum REQUEST_TYPE
        {
            Next = 0, 
            Previous = 1, 
            Random = 2 
        }

        /// <summary>
        /// The Type Accessor.
        /// </summary>
        public REQUEST_TYPE Type { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="type"> The Type of the Request </param>
        public SongRequestEvent(REQUEST_TYPE type)
        {
            Type = type;
        }

    }
}
