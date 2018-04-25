//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Services
{
    using System.Threading.Tasks;
    using Beto.Core.Data;
    using Spelling.Domain;

    /// <summary>
    /// Interface of user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the list of users</returns>
        IPagedList<User> GetAll(string keyword = null, int page = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets all users asynchronous.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the users</returns>
        Task<IPagedList<User>> GetAllAsync(string keyword = null, int page = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>the user</returns>
        User GetByEmail(string email);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the user</returns>
        User GetById(int id);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the user</returns>
        Task<User> GetByIdAsync(int id);

        /// <summary>
        /// Validates the authentication.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>the user if is valid</returns>
        Task<User> ValidateAuthentication(string email, string password);
    }
}