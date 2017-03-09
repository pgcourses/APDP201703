using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00Data
{
    public class AddressContext : DbContext
    {
        public DbSet<MyAddress> MyAddresses { get; set; }
    }

    /// <summary>
    /// Az EF megkeresi, hogy a DbContext mellett van-e AddressContext
    /// </summary>
    public class MyConfig : DbConfiguration
    {
        public MyConfig()
        {
            Console.WriteLine("MyConfig");
            SetExecutionStrategy("System.Data.SqlClient", () => new MyStrategy(5, TimeSpan.FromSeconds(30)));
        }
    }

    internal class MyStrategy : SqlAzureExecutionStrategy
    {
        public MyStrategy(int maxRetryCount, TimeSpan maxDelay) : base(maxRetryCount,  maxDelay)
        {
            Console.WriteLine("MyStrategy");
        }

        protected override TimeSpan? GetNextDelay(Exception lastException)
        {
            var retval = base.GetNextDelay(lastException);
            //Console.WriteLine("GetNextDelay (Exception: {0}, nextDelay: {1}", lastException.Message, retval.ToString());
            Console.WriteLine("GetNextDelay (nextDelay: {0})", retval.ToString());
            return retval;
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            var errorToRetry = new int[] {-1, 109, 233 };

            var isShouldRetry = false;
            var retval = base.ShouldRetryOn(exception);

            var sqlException = exception as SqlException;

            if (sqlException != null)
            {
                foreach (SqlError e in sqlException.Errors)
                {
                    Console.WriteLine("ShouldRetryOn (ErrorNumber:{0}, ShouldRetryOn: {1})", e.Number, retval);
                    if (errorToRetry.Contains(e.Number))
                    {
                        isShouldRetry = true;
                    }
                }

            }

            Console.WriteLine("ShouldRetryOn (Exception:{0}, ShouldRetryOn: {1}, isShouldRetry: {2})", exception.Message, retval, isShouldRetry);
            return isShouldRetry;
        }
    }
}
