using DomainLayer.Contracts;
using DomanLayer.Models;
using System.Linq.Expressions;


namespace ServiceLayer.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    {
        protected BaseSpecifications(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        #region Includes
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<TEntity, object>> IncludeException)
        {
            IncludeExpressions.Add(IncludeException);
        }
        #endregion

        #region Ordering

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        #endregion
        #region Pagination

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginated { get; set; }

        protected void ApplyPagination(int pageSize, int pageIndex)
        {

            IsPaginated = true;
            Take = pageSize;
            Skip = pageSize * (pageIndex - 1);

        }

        #endregion

    }
}
