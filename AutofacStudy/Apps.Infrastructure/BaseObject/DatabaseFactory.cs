using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Infrastructure.IBaseInterface;

namespace Apps.Infrastructure.BaseObject
{
    public class DatabaseFactory<T> : Disposable, IDatabaseFactory<T>
        where T : class
    {
        private T dataContext;
        public T Get()
        {
            try
            {
                if (dataContext == null)
                {
                    Type t = typeof(T);
                    System.Reflection.ConstructorInfo ci = t.GetConstructor(System.Type.EmptyTypes);
                    T to = (T)ci.Invoke(new object[0]);
                    dataContext = to;
                }
                return dataContext;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                ((IDisposable)dataContext).Dispose();
            }
        }
    }
}
