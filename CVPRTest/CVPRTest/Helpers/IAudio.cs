using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVPRTest.Helpers
{
    public interface IAudio
    {
        void Play(string url);
        void Stop(bool val);
    }
}
