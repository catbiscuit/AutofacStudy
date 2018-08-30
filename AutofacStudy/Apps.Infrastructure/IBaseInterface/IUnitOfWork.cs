using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Infrastructure.BaseObject;

namespace Apps.Infrastructure.IBaseInterface
{
    public interface IUnitOfWork<T>
        where T : ObjectContext
    {
        int Commit();

        T DataContext { get; }

        LogEventHandler LogEvent
        {
            get;
            set;
        }
    }
}
