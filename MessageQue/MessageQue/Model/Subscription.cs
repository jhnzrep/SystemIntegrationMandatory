using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageQue.Model
{
    public class Subscription
    {
        public Dictionary<string, List<string>> Subs { get; set; }

        public Subscription()
        {
            Subs = new Dictionary<string, List<string>>();
        }

        public Subscription(Dictionary<string, List<string>> subs)
        {
            Subs = subs;
        }
    }
}
