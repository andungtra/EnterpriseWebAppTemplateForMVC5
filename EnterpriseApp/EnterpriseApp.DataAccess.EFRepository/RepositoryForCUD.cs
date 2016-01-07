using EnterpriseApp.Domain.Shared.Repository;
using EnterpriseApp.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.DataAccess.EFRepository
{
    public class RepositoryForCUD<T> : IRepositoryForCUD<T> where T : class
    {
        private readonly IDbContextForCUD _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RepositoryForCUD(IDbContextForCUD context)
        {
            this._context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object[] id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public OperationResult Insert(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.Errors.Add(ex.Message);

            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public OperationResult Insert(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                foreach (T entity in entityList)
                {
                    this.Entities.Add(entity);
                }

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public async Task<OperationResult> InsertAsync(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }

            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public async Task<OperationResult> InsertAsync(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                foreach (T entity in entityList)
                {
                    this.Entities.Add(entity);
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }

            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public OperationResult Update(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    string entityName = validationErrors.Entry.Entity.GetType().Name;
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Obje: {0} {1}Özellik: {2} => Hata: {3}"
                            , entityName
                            , System.Environment.NewLine
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public OperationResult Update(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public async Task<OperationResult> UpdateAsync(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public async Task<OperationResult> UpdateAsync(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public OperationResult Delete(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);

                int effectedRows = this._context.SaveChanges();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        public OperationResult Delete(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            if (entityList == null)
            {
                throw new ArgumentNullException("entityList");
            }

            foreach (T entity in entityList)
            {
                this.Entities.Remove(entity);
            }

            int effectedRows = this._context.SaveChanges();

            if (effectedRows >= entityList.Count())
            {
                result.Succeeded = true;
            }
            else
            {
                result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public async Task<OperationResult> DeleteAsync(T entity)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= 1)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "{0} Özellik: {1} => Hata: {2}"
                            , entity.GetType().Name
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityList"></param>
        public async Task<OperationResult> DeleteAsync(IList<T> entityList)
        {
            OperationResult result = new OperationResult(false);

            try
            {
                if (entityList == null)
                {
                    throw new ArgumentNullException("entityList");
                }

                foreach (T entity in entityList)
                {
                    this.Entities.Remove(entity);
                }

                int effectedRows = await this._context.SaveChangesAsync();

                if (effectedRows >= entityList.Count)
                {
                    result.Succeeded = true;
                }
                else
                {
                    result.Errors.Add("Beklenenden farklı sayıda kayıt etkilendi: " + effectedRows);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                result.Succeeded = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.Errors.Add(string.Format(
                            "Özellik: {0} => Hata: {1}"
                            , validationError.PropertyName
                            , validationError.ErrorMessage)
                            );
                    }
                }
            }
            return result;
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (this._entities == null)
                {
                    this._entities = _context.Set<T>();
                }

                return this._entities;
            }
        }

    }

}
