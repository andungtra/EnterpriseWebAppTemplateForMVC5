using EnterpriseApp.Domain.Shared.Helper.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseApp.Presentation.Web.Helper.DataGrid
{
    public class HelperDataGridPaginator : IHelperDataGridPaginator
    {

        public HelperDataGridPaginator()
        {

        }

        public HelperDataGridPaginator(
            ControllerContext controllerContext
            , int pageSize
            , int? pageNo
        )
        {
            this.AreaName = "";
            if (controllerContext.RouteData.DataTokens.ContainsKey("area"))
            {
                this.AreaName = controllerContext.RouteData.DataTokens["area"].ToString();
            }

            this.ControllerName = controllerContext.RouteData.Values["controller"].ToString();
            this.ActionName = controllerContext.RouteData.Values["action"].ToString();

            this.ActiveClass = "active";
            this.DisabledClass = "disabled";

            this.PageSize = pageSize;
            this.CurrentPage = pageNo.HasValue ? pageNo.Value : 1;
        }

        public int? PageSize
        {
            get
            {
                return this._PageSize;
            }

            set
            {
                this._PageSize = value;
            }
        }

        public int? CurrentPage
        {
            get
            {
                return this._CurrentPage;
            }

            set
            {
                this._CurrentPage = value;
            }
        }

        public string LinkBase { get; set; }

        public string AreaName { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string GoToFirstPageLink { get; set; }

        public string GoToPreviousPageLink { get; set; }

        public string GoToNextPageLink { get; set; }

        public string GoToLastPageLink { get; set; }

        public string DisabledClass { get; set; }

        public string ActiveClass { get; set; }

        public string GoToFirstPageClass { get; set; }

        public string GoToPreviousPageClass { get; set; }

        public string GoToNextPageClass { get; set; }

        public string GoToLastPageClass { get; set; }

        public int StartingPageNo { get; set; }

        public int EndingPageNo { get; set; }

        public int? TotalPages
        {
            get
            {
                return this._TotalPages;
            }
        }

        public int? TotalElement
        {
            get
            {
                return this._TotalElement;
            }
        }

        public int? StartingElementNo
        {
            get
            {
                return this._StartingElementNo;
            }
        }

        public int? EndingElementNo
        {
            get
            {
                return this._EndingElementNo;
            }
        }

        public IQueryable<T> ApplyPaginator<T>(IQueryable<T> queryableList)
        {
            int skip = 0;
            int take = 10;

            if (this._CurrentPage != null)
            {
                skip = Convert.ToInt32(this._PageSize * (this._CurrentPage - 1));
            }
            if (this._PageSize != null)
            {
                take = Convert.ToInt32(this._PageSize);
            }

            this._TotalElement = queryableList.Count();

            this._StartingElementNo = (this._CurrentPage - 1) * this._PageSize + 1;
            this._EndingElementNo = this._StartingElementNo + this._PageSize - 1;
            this._EndingElementNo = (this._EndingElementNo > this._TotalElement) ? this._TotalElement : this._EndingElementNo;

            double bolum = Convert.ToDouble(this._TotalElement) / Convert.ToDouble(this._PageSize);
            bolum = Math.Ceiling(bolum);
            this._TotalPages = Convert.ToInt32(bolum);

            queryableList = queryableList
                .Skip(skip)
                .Take(take);

            this._populateHtmlFields();

            return queryableList;

        }

        private void _populateHtmlFields()
        {
            //UrlHelper.GenerateUrl(null, this.ActionName, this.ControllerName, new { culture = "tr", area = this.AreaName }, null, null, false);
            string currentCulture = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            this.LinkBase = "/" + this.ControllerName.ToLower()
                                + "/" + this.ActionName.ToLower();

            if (!String.IsNullOrEmpty(this.AreaName))
            {
                this.LinkBase = "/" + this.AreaName.ToLower()
                           + this.LinkBase;
            }

            if (currentCulture != "tr")
            {
                this.LinkBase = "/" + currentCulture
                            + this.LinkBase;
            }

            this.GoToFirstPageLink = this.LinkBase + "/1";

            if (this._CurrentPage.Value == 1)
            {
                this.GoToPreviousPageLink = this.LinkBase + "/1";
            }
            else
            {
                this.GoToPreviousPageLink = this.LinkBase + "/" + (this._CurrentPage.Value - 1);
            }

            if (this._CurrentPage.Value == this._TotalPages)
            {
                this.GoToNextPageLink = this.LinkBase + "/" + this._TotalPages;
            }
            else
            {
                this.GoToNextPageLink = this.LinkBase + "/" + (this._CurrentPage.Value + 1);
            }

            this.GoToLastPageLink = this.LinkBase + "/" + (this._TotalPages);

            this.GoToFirstPageClass = "";
            this.GoToPreviousPageClass = "";
            this.GoToNextPageClass = "";
            this.GoToLastPageClass = "";

            if (this._CurrentPage == 1)
            {
                this.GoToFirstPageClass = this.DisabledClass;
                this.GoToPreviousPageClass = this.DisabledClass;
            }

            if (this._CurrentPage == this._TotalPages)
            {
                this.GoToNextPageClass = this.DisabledClass;
                this.GoToLastPageClass = this.DisabledClass;
            }

            int halfPageSize = 5;

            this.StartingPageNo = 0;
            this.EndingPageNo = 0;

            if (this._TotalPages > this._PageSize)
            {

                if (this._CurrentPage <= halfPageSize)
                {
                    this.StartingPageNo = 1;
                    this.EndingPageNo = halfPageSize * 2;
                }
                else
                {
                    if (this._CurrentPage >= Convert.ToInt32(this._TotalPages - halfPageSize))
                    {
                        this.StartingPageNo = Convert.ToInt32(this._TotalPages - halfPageSize * 2 + 1);
                        this.EndingPageNo = Convert.ToInt32(this._TotalPages);
                    }
                    else
                    {
                        this.StartingPageNo = Convert.ToInt32(this._CurrentPage - halfPageSize + 1);
                        this.EndingPageNo = Convert.ToInt32(this._CurrentPage + halfPageSize);
                    }
                }
            }
            else
            {
                this.StartingPageNo = 1;
                this.EndingPageNo = Convert.ToInt32(this._TotalPages);
            }

        }

        private int? _PageSize { get; set; }

        private int? _CurrentPage { get; set; }

        private int? _TotalPages { get; set; }

        private int? _TotalElement { get; set; }

        private int? _StartingElementNo { get; set; }

        private int? _EndingElementNo { get; set; }

    }

}