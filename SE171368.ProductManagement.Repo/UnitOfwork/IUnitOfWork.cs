using SE171368.ProductManagement.Repo.GenericRepository;
using SE171368.ProductManagement.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171368.ProductManagement.Repo.UnitOfwork
{
    public interface IUnitOfwork : IDisposable
    {
        IGenericRepository<Product> ProductRepo { get; set; }
        IGenericRepository<Category> CategoryRepo { get; set; }

        void Save();
    }

}
