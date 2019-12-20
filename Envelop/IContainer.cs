using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelope
{
    public interface IContainer<T>
    {
        bool IsContains(T second);
    }
}
