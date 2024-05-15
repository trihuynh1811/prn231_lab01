using SE171368.ProductManagement.Repo.GenericRepository;
using SE171368.ProductManagement.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE171368.ProductManagement.Repo.UnitOfwork
{
    public class UnitOfwork : IDisposable, IUnitOfwork
    {

        private IGenericRepository<Product> productRepo;
        private IGenericRepository<Category> categoryRepo;
        private readonly ApplicationDBContext context;
        private bool dispose = false;

        public UnitOfwork(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Product> ProductRepo
        {
            get
            {
                if (productRepo == null)
                {
                    productRepo = new GenericRepository<Product>(context);
                }
                return productRepo;

            }
            set => throw new NotImplementedException();
        }
        public IGenericRepository<Category> CategoryRepo
        {
            get
            {
                if (categoryRepo == null)
                {
                    categoryRepo = new GenericRepository<Category>(context);
                }
                return categoryRepo;

            }
            set => throw new NotImplementedException();
        }
        protected virtual void Dispose(bool dispose)
        {
            if (!dispose)
            {
                if (dispose)
                {
                    context.Dispose();

                }
                dispose = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

}
