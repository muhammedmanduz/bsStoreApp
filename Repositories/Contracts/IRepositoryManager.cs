using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{//unit of work design pattern ie bir çok repositorya manager üzerinden erişim sağlayabılırız
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        void Save();
    }
}
