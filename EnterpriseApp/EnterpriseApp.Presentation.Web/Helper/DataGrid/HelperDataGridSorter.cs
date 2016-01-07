using EnterpriseApp.Domain.Shared.Helper.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EnterpriseApp.Presentation.Web.Helper.DataGrid
{
    public class HelperDataGridSorter : IHelperDataGridSorter
    {

        public HelperDataGridSorter()
        {
            this._SorterExpressions = new List<IDictionary<GridSorterDirection, Expression>>();
        }

        public IList<IDictionary<GridSorterDirection, Expression>> SorterExpressions
        {
            get
            {
                return this._SorterExpressions;
            }
        }

        private IList<IDictionary<GridSorterDirection, Expression>> _SorterExpressions;

        public IHelperDataGridSorter AddSorter<T, F>(Expression<Func<T, F>> sortingExpression, GridSorterDirection direction)
        {
            IDictionary<GridSorterDirection, Expression> newSorterExpression = new Dictionary<GridSorterDirection, Expression>();
            newSorterExpression.Add(direction, sortingExpression);
            this._SorterExpressions.Add(newSorterExpression);

            return this as IHelperDataGridSorter;
        }

        public IQueryable<T> ApplySorters<T>(IQueryable<T> queryableList)
        {
            if (this._SorterExpressions != null)
            {

                int counter = 0;
                foreach (Dictionary<GridSorterDirection, Expression> sorterExpression in this.SorterExpressions)
                {
                    KeyValuePair<GridSorterDirection, Expression> sorter = sorterExpression.FirstOrDefault();

                    if (sorter.Value != null)
                    {
                        counter++;

                        string methodName = "ThenBy";
                        string direction = "";

                        if (sorter.Key == GridSorterDirection.DESC)
                        {
                            direction = "Descending";
                        }

                        if (counter == 1)
                        {
                            methodName = "OrderBy";
                        }

                        methodName = methodName + direction;

                        MethodCallExpression sorterMethodCall = this._GenericEvaluateOrderBy(sorter.Value, methodName, queryableList.Expression);

                        queryableList = queryableList.Provider.CreateQuery<T>(sorterMethodCall);
                    }

                }
            }
            return queryableList;
        }

        private MethodCallExpression _GenericEvaluateOrderBy(Expression sortingExpression, string methodName, Expression queryableListExpression)
        {
            MethodCallExpression result = null;

            var typeArguments = sortingExpression.Type.GetGenericArguments();

            result = Expression.Call(
                typeof(Queryable),
                methodName,
                typeArguments,
                queryableListExpression,
                sortingExpression);

            return result;

        }

    }

}