using AutoMapper;
using EnterpriseApp.Domain.SampleDomain.Entity;
using EnterpriseApp.Domain.SampleDomain.Service.Create;
using EnterpriseApp.Domain.SampleDomain.Service.Delete;
using EnterpriseApp.Domain.SampleDomain.Service.Read;
using EnterpriseApp.Domain.SampleDomain.Service.Update;
using EnterpriseApp.Domain.Shared.Helper.DataGrid;
using EnterpriseApp.Presentation.Web.Areas.SampleDomain.ViewModel.Book;
using EnterpriseApp.Presentation.Web.Helper.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseApp.Presentation.Web.Areas.SampleDomain.Controllers
{
    public class BookController : Controller
    {

        private readonly IServiceCreateBook _bookCreateService;
        private readonly IServiceReadBook _bookReadService;
        private readonly IServiceUpdateBook _bookUpdateService;
        private readonly IServiceDeleteBook _bookDeleteService;


        public BookController(
            IServiceCreateBook bookCreateService
            , IServiceReadBook bookReadService
            , IServiceUpdateBook bookUpdateService
            , IServiceDeleteBook bookDeleteService
        )
        {
            this._bookCreateService = bookCreateService;
            this._bookReadService = bookReadService;
            this._bookUpdateService = bookUpdateService;
            this._bookDeleteService = bookDeleteService;
        }


        // GET: SampleDomain/Book
        [AllowAnonymous]
        public ActionResult Index(int? BookIndexPageNo)
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/Index.cshtml";

            ViewModelIndex viewModel = null;

            try
            {
                // ViewModel Definition
                Mapper.Reset();

                Mapper.CreateMap<Book, ViewModelIndex_Book>();
                Mapper.CreateMap<Author, ViewModelIndex_Author>();

                Mapper.AssertConfigurationIsValid();

                // Get Query With Projection
                IQueryable<ViewModelIndex_Book> bookListWithProjectionQuery = this._bookReadService
                    .GetListWithProjectionQuery<ViewModelIndex_Book>();

                // Execute Query
                IEnumerable<ViewModelIndex_Book> bookList = this._bookReadService
                    .GetList(bookListWithProjectionQuery);

                // Create And Populate ViewModel
                viewModel = new ViewModelIndex();
                viewModel.Data = bookList;

            }
            catch (Exception e)
            {

                throw;
            }

            return View(viewName, viewModel);
        }

        // GET: SampleDomain/Book/View/5
        [AllowAnonymous]
        public ActionResult View(int id)
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/View.cshtml";

            ViewModelView viewModel = null;

            try
            {

                // ViewModel Definition
                Mapper.Reset();

                Mapper.CreateMap<Book, ViewModelIndex_Book>();
                Mapper.CreateMap<Author, ViewModelIndex_Author>();

                Mapper.AssertConfigurationIsValid();

                viewModel.Entity = this._bookReadService
                    .GetByIdWithProjection<ViewModelView_Book>(id);

                if(viewModel.Entity == null)
                {
                    return HttpNotFound("Book not found");
                }

            }
            catch (Exception)
            {

                throw;
            }
            return View(viewName, viewModel);
        }

        // GET: SampleDomain/Book/Create
        public ActionResult Create()
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/Create.cshtml";

            return View(viewName);
        }

        // POST: SampleDomain/Book/Create
        [HttpPost]
        public ActionResult Create(ViewModelEdit viewModel)
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/Create.cshtml";

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            return View(viewName);
        }

        // GET: SampleDomain/Book/Edit/5
        public ActionResult Edit(int id)
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/Edit.cshtml";

            return View(viewName);
        }

        // POST: SampleDomain/Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/Edit.cshtml";

            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            return View(viewName);
        }

        // GET: SampleDomain/Book/Delete/5
        public ActionResult Delete(int id)
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/Delete.cshtml";

            return View(viewName);
        }

        // POST: SampleDomain/Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            string viewName = "~/Areas/SampleDomain/Views/Book/Delete.cshtml";

            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View(viewName);
        }
    }
}
