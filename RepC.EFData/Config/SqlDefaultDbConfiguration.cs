using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace RepC.EFData.Config
{
    class SqlDefaultDbConfiguration : DbConfiguration
    {
        public SqlDefaultDbConfiguration()
        {
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());
            this.SetProviderServices("System.Data.SqlClient",System.Data.Entity.SqlServer.SqlProviderServices.Instance);


            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}
