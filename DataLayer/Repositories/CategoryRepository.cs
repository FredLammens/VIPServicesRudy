using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private VIPServicesRudyContext context;
        public CategoryRepository(VIPServicesRudyContext context)
        {
            this.context = context;
        }
    }
}
