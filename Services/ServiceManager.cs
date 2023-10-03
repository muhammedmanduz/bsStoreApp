﻿using Repositories.EfCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServiceManager(RepositoryManager repositoryManager)
        {
            _bookService=new Lazy<IBookService>(()=>new BookManager(repositoryManager));
        }
        public IBookService bookService => throw new NotImplementedException();

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
