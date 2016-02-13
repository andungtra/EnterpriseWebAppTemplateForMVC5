using EnterpriseApp.Presentation.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq;
using System.Linq.Expressions;

namespace EnterpriseApp.Presentation.Web.Areas.SampleDomain.ViewModel.Book
{
    public class ViewModelIndex : BaseViewModelList<ViewModelIndex_Book>
    {

    }

    public class ViewModelIndex_Book
    {

        #region Properties

        public int Id { get; set; }

        public string Title { get; set; }

        #endregion

        #region Navigational Properties

        public ViewModelIndex_Author Author { get; set; }

        #endregion

    }

    public class ViewModelIndex_Author
    {

        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        #endregion

    }

    public class ViewModelIndexSearch
    {


        public void AddCriteria<T_Value, T_Dest>(Expression<Func<T_Value, T_Dest>> property, string op, T_Dest value)
        {



        }



    }


}