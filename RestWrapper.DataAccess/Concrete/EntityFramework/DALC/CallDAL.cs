using RestWrapper.Core.Repository.EntityFramework;
using RestWrapper.DataAccess.Abstract;
using RestWrapper.DataAccess.Concrete.EntityFramework.Contexts;
using RestWrapper.Entities.Concrete;

namespace RestWrapper.DataAccess.Concrete.EntityFramework.DALC
{
    public class CallDAL : EFEntityRepositoryBase<ApplicationDbContext, CallDAO>, ICallDAL
    {
        public CallDAL(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
