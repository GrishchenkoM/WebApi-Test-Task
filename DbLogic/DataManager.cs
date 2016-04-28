using DbLogic.Repositories.Interfaces;

namespace DbLogic
{
    public class DataManager
    {
        public DataManager(
            IComputerNameRepository computerNameRepository, 
            IManufacturerRepository manufacturerRepository,
            IUserNameRepository userNameRepository)
        {
            _computerNameRepository = computerNameRepository;
            _manufacturerRepository = manufacturerRepository;
            _userNameRepository = userNameRepository;
        }

        public IComputerNameRepository ComputerNameRepositories { get { return _computerNameRepository; } }
        public IManufacturerRepository ManufacturerRepositories { get { return _manufacturerRepository; } }
        public IUserNameRepository UserNameRepositories { get { return _userNameRepository; } }

        private readonly IComputerNameRepository _computerNameRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IUserNameRepository _userNameRepository;
    }
}
