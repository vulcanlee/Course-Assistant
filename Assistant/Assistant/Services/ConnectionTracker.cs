using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assistant.Services
{
    class ConnectionTracker
    {
        private int activeConnections;

        public int ActiveConnections => activeConnections;

        public void Increment()
        {
            Interlocked.Increment(ref activeConnections);
        }

        public void Decrement()
        {
            Interlocked.Decrement(ref activeConnections);
        }
    }
}
