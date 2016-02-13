using EnterpriseApp.Domain.SampleDomain.Service.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseApp.Domain.SampleDomain.Entity;
using EnterpriseApp.Domain.Shared.ValueObject;

namespace EnterpriseApp.Application.Service.SampleDomain.Delete
{
    public class ServiceDeleteAuthor : IServiceDeleteAuthor
    {
        public OperationResult Delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
