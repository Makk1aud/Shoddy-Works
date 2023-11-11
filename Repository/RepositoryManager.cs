using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ShoddyWorksContext _context;
        private readonly Lazy<IClientRepository> _clientRepository;
        private readonly Lazy<IMentorRepository> _mentorRepository;
        private readonly Lazy<IClientOrderRepository> _clientOrderRepository;
        private readonly Lazy<IOfferRepository> _offerRepository;

        public RepositoryManager(ShoddyWorksContext context)
        {
            _context = context;
            _clientRepository = new Lazy<IClientRepository>(() => new ClientRepository(context));
            _mentorRepository = new Lazy<IMentorRepository>(() => new MentorRepository(context));
            _clientOrderRepository = new Lazy<IClientOrderRepository>(() => new ClientOrderRepository(context));
            _offerRepository = new Lazy<IOfferRepository>(() => new OfferRepository(context));
        }

        public IClientRepository Client => _clientRepository.Value;

        public IClientOrderRepository ClientOrder => _clientOrderRepository.Value;

        public IMentorRepository Mentor => _mentorRepository.Value;

        public IOfferRepository OfferRepository => _offerRepository.Value;

        public void Save() => _context.SaveChanges();
    }
}
