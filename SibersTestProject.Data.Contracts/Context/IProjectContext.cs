using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.Contracts.Context
{
    public interface IProjectContext : IDisposable
    {
        DbContext DbContext { get; }
    }
}
