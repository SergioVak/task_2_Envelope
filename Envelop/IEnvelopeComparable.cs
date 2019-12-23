using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelope
{
    public interface IEnvelopeComparable : IEnvelope
    {
        bool IsContains(IEnvelope second);
    }
}
