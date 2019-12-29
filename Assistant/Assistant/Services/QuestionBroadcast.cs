using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public class QuestionBroadcast
    {
        public List<Action<string>> AllNewQuestionEvent { get; set; } = new List<Action<string>>();
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
    }
}
