using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, StockContext>, IUserDal
    {
        public List<Role> GetClaims(User user)
        {
            using (var context = new StockContext())
            {
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                             on role.Id equals userRole.RoleId
                             where userRole.UserId == user.Id
                             select new Role { Id = role.Id, Definition = role.Definition, CreatedDate = role.CreatedDate, ModifiedDate = role.ModifiedDate, IsDeleted = role.IsDeleted };

                return result.ToList();
            }
        }
    }
}
