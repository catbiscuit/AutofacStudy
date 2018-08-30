using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Infrastructure.IBaseInterface
{
    public interface IDatabaseFactory<T>
        where T : class
    {
        T Get();
    }
}
