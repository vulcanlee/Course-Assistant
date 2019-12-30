using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public class QuestionBroadcast
    {
        public List<Action<string>> AllNewQuestionEvent { get; set; } = new List<Action<string>>();
        public List<Action<int>> ConcurrentConnectionEvent { get; set; } = new List<Action<int>>();
        public Task Subscribe(Action<string> action)
        {
            AllNewQuestionEvent.Add(action);
            return Task.FromResult(0);
        }
        public Task Unsubscribe(Action<string> action)
        {
            var foo = AllNewQuestionEvent.FirstOrDefault(x => x == action);
            if (foo != null)
            {
                AllNewQuestionEvent.Remove(foo);
            }
            return Task.FromResult(0);
        }
        public Task Publish(string message)
        {
            foreach (var item in AllNewQuestionEvent)
            {
                try
                {
                    item?.Invoke(message);
                }
                catch  { }
            }
            return Task.FromResult(0);
        }
        public Task<int> GetAllSubscriber()
        {
            int all = AllNewQuestionEvent.Count();
            return Task.FromResult(all);
        }
        public Task SubscribeConcurrentConnection(Action<int> action)
        {
            ConcurrentConnectionEvent.Add(action);
            return Task.FromResult(0);
        }
        public Task UnsubscribeConcurrentConnection(Action<int> action)
        {
            var foo = ConcurrentConnectionEvent.FirstOrDefault(x => x == action);
            if (foo != null)
            {
                ConcurrentConnectionEvent.Remove(foo);
            }
            return Task.FromResult(0);
        }
        public Task PublishConcurrentConnection()
        {
            int concurrentConnection = AllNewQuestionEvent.Count();
            foreach (var item in ConcurrentConnectionEvent)
            {
                try
                {
                    item?.Invoke(concurrentConnection);
                }
                catch { }
            }
            return Task.FromResult(0);
        }
    }
}
