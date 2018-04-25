//-----------------------------------------------------------------------
// <copyright file="WordService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Beto.Core.Data;
    using Spelling.Domain;

    /// <summary>
    /// Word Service
    /// </summary>
    /// <seealso cref="Spelling.Business.Services.IWordService" />
    public class WordService : IWordService
    {
        /// <summary>
        /// The word repository
        /// </summary>
        private readonly IRepository<Word> wordRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordService"/> class.
        /// </summary>
        /// <param name="wordRepository">The word repository.</param>
        public WordService(IRepository<Word> wordRepository)
        {
            this.wordRepository = wordRepository;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the words
        /// </returns>
        public IPagedList<Word> GetAll(
            GroupType? groupType = null,
            OrderByWord orderBy = OrderByWord.Spanish,
            int page = 0,
            int pageSize = int.MaxValue)
        {
            return new PagedList<Word>(this.GetAllQuery(groupType, orderBy), page, pageSize);
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the words
        /// </returns>
        public async Task<IPagedList<Word>> GetAllAsync(
            GroupType? groupType = null,
            OrderByWord orderBy = OrderByWord.Spanish,
            int page = 0,
            int pageSize = int.MaxValue)
        {
            return await new PagedList<Word>().Async(this.GetAllQuery(groupType, orderBy), page, pageSize);
        }

        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <param name="groupType">Type of the group.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>the query of words</returns>
        public IQueryable<Word> GetAllQuery(
            GroupType? groupType = null,
            OrderByWord orderBy = OrderByWord.Spanish)
        {
            var query = this.wordRepository.TableNoTracking;

            if (groupType.HasValue)
            {
                query = query.Where(c => c.GroupId == Convert.ToInt16(groupType));
            }

            switch (orderBy)
            {
                case OrderByWord.Random:
                    query = query.OrderBy(c => Guid.NewGuid());
                    break;

                case OrderByWord.Spanish:
                    query = query.OrderBy(c => c.Spanish);
                    break;

                case OrderByWord.English:
                    query = query.OrderBy(c => c.English);
                    break;

                default:
                    query = query.OrderBy(c => c.Id);
                    break;
            }

            return query;
        }
    }
}