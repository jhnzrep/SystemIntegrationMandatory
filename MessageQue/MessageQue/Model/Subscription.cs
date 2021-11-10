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

        }

        public Subscription(string name, Dictionary<string, List<string>> subs)
        {
            Subs = subs;
        }
    }
}
