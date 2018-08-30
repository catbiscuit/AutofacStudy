using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Infrastructure.IBaseInterface;

namespace Apps.Infrastructure.BaseObject
{
    public delegate void LogEventHandler(string dbTypeName, List<ObjectStateEntry> changeEntries);
    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : ObjectContext
    {
        private readonly IDatabaseFactory<T> databaseFactory;
        private T dataContext;

        public LogEventHandler _LogEvent;

        public LogEventHandler LogEvent
        {
            get
            {
                return _LogEvent;
            }
            set
            {
                this._LogEvent = value;
            }
        }

        public UnitOfWork(IDatabaseFactory<T> databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        public T DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public int Commit()
        {
            //return DataContext.SaveChanges();
            try
            {
                List<ObjectStateEntry> changeEntries = new List<ObjectStateEntry>();

                ObjectStateEntry[] objAdded = (ObjectStateEntry[])DataContext
                    .ObjectStateManager
                    .GetObjectStateEntries(System.Data.EntityState.Added);
                changeEntries.AddRange(objAdded);
                ObjectStateEntry[] objDeleted = (ObjectStateEntry[])DataContext
                    .ObjectStateManager
                    .GetObjectStateEntries(System.Data.EntityState.Deleted);
                changeEntries.AddRange(objDeleted);
                ObjectStateEntry[] objModified = (ObjectStateEntry[])DataContext
                    .ObjectStateManager
                    .GetObjectStateEntries(System.Data.EntityState.Modified);
                changeEntries.AddRange(objModified);

                if (LogEvent != null)
                    LogEvent(DataContext.GetType().ToString(), changeEntries);

                int tmp = DataContext.SaveChanges();

                return tmp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
