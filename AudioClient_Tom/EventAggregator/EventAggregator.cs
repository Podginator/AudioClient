using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioClient_Tom.EventAggregator
{
    /// <summary>
    /// An Event Aggregator singleton class.
    /// Push events to this and distribute them to subscribers. 
    /// </summary>
    class EventAggregator
    {
        // Self Instance
        private static EventAggregator me;

        // Dictionary of Class Extending Event
        private readonly ConcurrentDictionary<Type, List<object>> mTypeAction = new ConcurrentDictionary<Type, List<object>>();

        /// <summary>
        /// Return the instance of this class
        /// </summary>
        /// <returns> The singleton instance of this class </returns>
        public static EventAggregator Instace
        {
            get
            {
                if (me == null)
                {
                    me = new EventAggregator();
                }

                return me;
            }
        }


        /// <summary>
        /// Raise and distribute an event
        /// </summary>
        /// <typeparam name="Event">Type of action we wish to distribute </typeparam>
        /// <param name="ev">The Event we wish to distribute </param>
        public void RaiseEvent<Event>(Event ev)
        {
            //Avoid operating on the UI thread and blocking on long things by placing onto a thread pool
            List<object> actions = GetOrCreateListeners(typeof(Event));             
            foreach (object act in actions)
            {
                //Check whether this is an action.
                if (act is Action<Event>)
                {
                    Action<Event> action = (Action<Event>)act;
                    Tuple<Action<Event>, Event> actionTup =
                        new Tuple<Action<Event>, Event>(action, ev);
                    ThreadPool.QueueUserWorkItem(InvokeActionCallback<Event>, actionTup);
                }
            }
        }

        /// <summary>
        /// Callback method for the Threadpool
        /// </summary>
        /// <typeparam name="Event">The parameter Type for the action</typeparam>
        /// <param name="ev">The Event paramter</param>
        private void InvokeActionCallback<Event>(object ev)
        {
            //Cast the state object back down to an Action Tuple.
            Tuple<Action<Event>, Event> actionTup = (Tuple<Action<Event>, Event>)ev;
            //Then invoke the Action<Event> and the Event parameter on a seperate thread.
            actionTup.Item1.Invoke(actionTup.Item2);


        }

        /// <summary>
        /// Register a listener. 
        /// </summary>
        /// <typeparam name="Event"></typeparam>
        /// <param name="action"></param>
        public void RegisterListener<Event>(Action<Event> action)
        {
            List<object> listeners = GetOrCreateListeners(typeof(Event));

            listeners.Add(action);
        }


        private List<object> GetOrCreateListeners(Type type)
        {
            List<object> res = mTypeAction.GetOrAdd(type, new List<object>());

            return res;
        }
    }
}
