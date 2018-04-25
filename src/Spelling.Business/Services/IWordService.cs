//-----------------------------------------------------------------------
// <copyright file="IWordService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Services
{
    using System.Threading.Tasks;
    using Beto.Core.Data;
    using Spelling.Domain;

    /// <summary>
    /// Word Service
    /// </summary>
    public interface IWordService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the words</returns>
        IPagedList<Word> GetAll(
            GroupType? groupType = null,
            OrderByWord orderBy = OrderByWord.Spanish,
            int page = 0,
            int pageSize = int.MaxValue);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>the words</returns>
        Task<IPagedList<Word>> GetAllAsync(
            GroupType? groupType = null,
            OrderByWord orderBy = OrderByWord.Spanish,
            int page = 0,
            int pageSize = int.MaxValue);
    }
}