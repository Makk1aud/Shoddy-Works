using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IClientRepository Client { get; }
        IClientOrderRepository ClientOrder { get; }
        IMentorRepository Mentor { get; }
        IOfferRepository OfferRepository { get; }
        void Save();
    }
}
