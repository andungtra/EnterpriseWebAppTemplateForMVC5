using EnterpriseApp.Domain.SampleDomain.Service.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseApp.Domain.SampleDomain.Entity;
using EnterpriseApp.Domain.Shared.ValueObject;

namespace EnterpriseApp.Application.Service.SampleDomain.Create
{
    public class ServiceCreateAuthor : IServiceCreateAuthor
    {
        public Author CreateNew()
        {
            throw new NotImplementedException();
        }

        public OperationResult Insert(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
