using Microsoft.EntityFrameworkCore;
using CVIMS.Entity.Context;
using CVIMS.Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.API.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser FindUserNoTracking(string guid);
        ApplicationUser FindUserByEmail(string email);
        string FindUserNameById(string guid);
        Task<IEnumerable<ApplicationUser>> FindUsersBySearchAsync(string query);
    }

    public class UserRepository : IUserRepository
    {

        private readonly CVIMSContext _context;
        private readonly CVIMSContextRO _contextRo;

        public UserRepository(CVIMSContext ctx, CVIMSContextRO contextRo)
        {
            _context = ctx;
            _contextRo = contextRo;
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        public ApplicationUser FindUserNoTracking(string guid)
        {
            return _contextRo.ApplicationUser.AsNoTracking().FirstOrDefault(x => string.Equals(x.Id, guid));
        }

        public ApplicationUser FindUserByEmail(string email)
        {
            return _contextRo.ApplicationUser.FirstOrDefault(x => string.Equals(email, x.Email));
        }

        public string FindUserNameById(string guid)
        {
            var user = _context.ApplicationUser.AsNoTracking().FirstOrDefault(x => x.Id.ToString() == guid);
            return user?.FirstName + " " + user?.LastName;
        }

        public Task<IEnumerable<ApplicationUser>> FindUsersBySearchAsync(string query)
        {
            var results =
                _contextRo.ApplicationUser.Where(x => x.Email.Contains(query) || 
                                                x.FirstName.Contains(query) || 
                                                x.LastName.Contains(query))
                                    //.Include(x => x.AspNetUserClaims)
                                    .Take(10);

            return Task.FromResult(results.AsEnumerable<ApplicationUser>());
        }
    }
}