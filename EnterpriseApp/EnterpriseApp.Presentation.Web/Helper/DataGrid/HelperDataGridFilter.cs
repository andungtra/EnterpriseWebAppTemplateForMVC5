using EnterpriseApp.Domain.Shared.Helper.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EnterpriseApp.Presentation.Web.Helper.DataGrid
{
    public class HelperDataGridFilter : IHelperDataGridFilter
    {

        public List<Expression> Filters { get; set; }

        public HelperDataGridFilter()
        {
            this.Filters = new List<Expression>();
        }

        public IHelperDataGridFilter AddFilter<TValue, TCompareAgainst>(string filterKey, IEnumerable<TCompareAgainst> wantedItems, Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes)
        {

            Expression<Func<TValue, bool>> filter = this._BuildOrExpressionTree<TValue, TCompareAgainst>(wantedItems, convertBetweenTypes);

            this.Filters.Add(filter);

            return this;

        }

        public IQueryable<T> ApplyFilters<T>(IQueryable<T> queryableList)
        {

            if (this.Filters != null)
            {
                foreach (Expression<Func<T, bool>> filter in this.Filters)
                {
                    queryableList = queryableList.Where(filter);
                }
            }

            return queryableList;
        }


        private Expression<Func<TValue, bool>> _BuildOrExpressionTree<TValue, TCompareAgainst>(
            IEnumerable<TCompareAgainst> wantedItems,
            Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes
        )
        {
            Expression<Func<TValue, bool>> result = null;

            ParameterExpression inputParam = convertBetweenTypes.Parameters[0];

            Expression binaryExpressionTree = this._BuildBinaryOrTree(wantedItems.GetEnumerator(), convertBetweenTypes.Body, null);

            result = Expression.Lambda<Func<TValue, bool>>(binaryExpressionTree, new[] { inputParam });

            return result;

        }

        private Expression _BuildBinaryOrTree<T>(
            IEnumerator<T> itemEnumerator,
            Expression expressionToCompareTo,
            Expression expression
        )
        {
            Expression result = null;

            if (itemEnumerator.MoveNext() == false)
            {
                return expression;
            }

            ConstantExpression constant = Expression.Constant(itemEnumerator.Current, typeof(T));
            BinaryExpression comparison = Expression.Equal(expressionToCompareTo, constant);

            BinaryExpression newExpression;

            if (expression == null)
            {
                newExpression = comparison;
            }
            else
            {
                newExpression = Expression.OrElse(expression, comparison);
            }

            result = this._BuildBinaryOrTree(itemEnumerator, expressionToCompareTo, newExpression);

            return result;
        }
    }

}