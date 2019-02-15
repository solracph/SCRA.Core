using SCRA.Data.Common.Services;
using SCRA.Data.Clinical.Repositories;


namespace SCRA.Data.Clinical.Services
{
    public class ClinicalDbService : BaseDbService
    {
        private ApplicationRepository _applicationRepository;
        private ContractRepository _contractRepository;
        private MeasureRepository _measureRepository;
        private PbpRepository _pbpRepository;
        private RuleRepository _ruleRepository;
        private SegmentRepository _segmentRepository;
        private TinRepository _tinRepository;
        private UserRepository _userRepository;

        private UserApplicationRepository _userApplicationRepository;
        private ContractPbpRepository _contractPbpRepository;
        private RulePbpRepository _rulePbpRepository;

        public ClinicalDbService()
            : base()
        {
        }

        public ApplicationRepository ApplicationRepository
            => _applicationRepository ?? (_applicationRepository = new ApplicationRepository(DbContext));

        public ContractRepository ContractRepository
            => _contractRepository ?? (_contractRepository = new ContractRepository(DbContext));

        public MeasureRepository MeasureRepository
            => _measureRepository ?? (_measureRepository = new MeasureRepository(DbContext));

        public PbpRepository PbpRepository
            => _pbpRepository ?? (_pbpRepository = new PbpRepository(DbContext));

        public RuleRepository RuleRepository
            => _ruleRepository ?? (_ruleRepository = new RuleRepository(DbContext));

        public SegmentRepository SegmentRepository
            => _segmentRepository ?? (_segmentRepository = new SegmentRepository(DbContext));
        public TinRepository TinRepository
            => _tinRepository ?? (_tinRepository = new TinRepository(DbContext));

        public UserRepository UserRepository
           => _userRepository ?? (_userRepository = new UserRepository(DbContext));

        public UserApplicationRepository UserApplicationRepository
           => _userApplicationRepository ?? (_userApplicationRepository = new UserApplicationRepository(DbContext));

        public ContractPbpRepository ContractPbpRepository
              => _contractPbpRepository ?? (_contractPbpRepository = new ContractPbpRepository(DbContext));

        public RulePbpRepository RulePbpRepository
             => _rulePbpRepository ?? (_rulePbpRepository = new RulePbpRepository(DbContext));
    }
}
