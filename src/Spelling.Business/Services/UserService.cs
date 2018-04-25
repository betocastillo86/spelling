//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Beto.Core.Data;
    using Beto.Core.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Spelling.Domain;

    /// <summary>
    /// User Service
    /// </summary>
    /// <seealso cref="Spelling.Business.Services.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the list of users
        /// </returns>
        public IPagedList<User> GetAll(string keyword = null, int page = 0, int pageSize = int.MaxValue)
        {
            var query = this.GetAllQuery(keyword, page, pageSize);
            return new PagedList<User>(query, page, pageSize);
        }

        /// <summary>
        /// Gets all users asynchronous.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the users
        /// </returns>
        public async Task<IPagedList<User>> GetAllAsync(string keyword = null, int page = 0, int pageSize = int.MaxValue)
        {
            var query = this.GetAllQuery(keyword, page, pageSize);
            return await new PagedList<User>().Async(query, page, pageSize);
        }

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// the user
        /// </returns>
        public User GetByEmail(string email)
        {
            return this.userRepository.TableNoTracking
                .FirstOrDefault(c => c.Email.Equals(email));
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// the user
        /// </returns>
        public User GetById(int id)
        {
            return this.userRepository.TableNoTracking
                .FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// the user
        /// </returns>
        public async Task<User> GetByIdAsync(int id)
        {
            return await this.userRepository.TableNoTracking
               .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Validates the authentication.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// the user if is valid
        /// </returns>
        public async Task<User> ValidateAuthentication(string email, string password)
        {
            var user = await this.userRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Email.Equals(email));

            if (user != null)
            {
                var passwordSha = StringHelpers.ToSha1(password, user.Salt);
                return passwordSha.Equals(user.Password) ? user : null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the users</returns>
        private IQueryable<User> GetAllQuery(string keyword = null, int page = 0, int pageSize = int.MaxValue)
        {
            var query = this.userRepository.TableNoTracking;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.Email.Contains(keyword));
            }

            return query;
        }
    }
}