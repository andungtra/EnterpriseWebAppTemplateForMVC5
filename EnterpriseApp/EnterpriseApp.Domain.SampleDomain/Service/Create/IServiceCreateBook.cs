using EnterpriseApp.Domain.SampleDomain.Entity;
using EnterpriseApp.Domain.Shared.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.SampleDomain.Service.Create
{
    public interface IServiceCreateBook : IServiceCreate<int, Book>
    {
    }
}
