
namespace AIUB.FingerPrintSync.Framework.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class zkEntities2 : DbContext
    {
        public zkEntities2(string nameOrEntityConnectionString)
            : base(nameOrEntityConnectionString)
        {
        }

    }
}
