using AutoMapper;
using SCRA.Data.Clinical.Entities;
using SCRA.Framework.Models.Clinical;
using System.Linq;

namespace SCRA.Framework.Clinical.Service
{
    public class ClinicalFactory
    {
        private Mapper _mappingToApplication;
        private Mapper _mappingToSegment;
        private Mapper _mappingToPbp;
        private Mapper _mappingToContract;
        private Mapper _mappingToTin;
        private Mapper _mappingToMesure;
        private Mapper _mappingToRule;
        private Mapper _mappingToRuleEntity;
        private Mapper _mappingToUser;
        private Mapper _mappingToUserEntity;

        public Mapper MappingToApplication
            => _mappingToApplication ?? (_mappingToApplication = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ApplicationEntity, Application>())));

        public Mapper MappingToSegment
            => _mappingToSegment ?? (_mappingToSegment = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SegmentEntity, Segment>())));

        public Mapper MappingToContract
          => _mappingToContract ?? (_mappingToContract = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ContractEntity, Contract>())));

        public Mapper MappingToPbp
            => _mappingToPbp ?? (_mappingToPbp = new Mapper(new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<PbpEntity, Pbp>();
                })
            ));

        public Mapper MappingToTin
          => _mappingToTin ?? (_mappingToTin = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TinEntity, Tin>())));

        public Mapper MappingToMesures
          => _mappingToMesure ?? (_mappingToMesure = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MeasureEntity, Measure>())));

        public Mapper MappingToRule
            => _mappingToRule ?? (_mappingToRule = new Mapper(new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<RuleEntity, Rule>()
                        .ForMember(
                            dest => dest.Segments,
                            opt => opt.MapFrom(
                                src => src.RuleSegment.Select(c => c.Segment)))
                        .ForMember(
                            dest => dest.Contracts,
                            opt => opt.MapFrom(
                                src => src.RuleContract.Select(c => c.Contract)))
                        .ForMember(
                            dest => dest.Pbp,
                            opt => opt.MapFrom(
                                src => src.RulePbp))
                        .ForMember(
                            dest => dest.Tin,
                            opt => opt.MapFrom(
                                src => src.RuleTin.Select(c => c.Tin)))
                        .ForMember(
                            dest => dest.Measures,
                            opt => opt.MapFrom(
                                src => src.RuleMeasure.Select(c => c.Measure)))
                        .ForMember(
                            dest => dest.Applications,
                            opt => opt.MapFrom(
                                src => src.RuleApplication.Select(c => c.Application)));
                    cfg.CreateMap<RulePbpEntity, Pbp>()
                        .ForMember(
                            dest => dest.PbpId,
                            opt => opt.MapFrom(
                                src => src.PbpId))
                        .ForMember(
                            dest => dest.Description,
                            opt => opt.MapFrom(
                                src => src.Pbp.Description))
                        .ForMember(
                            dest => dest.ContractId,
                            opt => opt.MapFrom(
                                src => src.ContractId))
                        .ForMember(
                            dest => dest.ContractDescription,
                            opt => opt.MapFrom(
                                src => src.Contract.Description));
                })
            ));

        public Mapper MappingToRuleEntity
            => _mappingToRuleEntity ?? (_mappingToRuleEntity = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rule, RuleEntity>()
                .ForMember(
                    dest => dest.RuleApplication,
                    opt => opt.MapFrom(
                        src => src.Applications))
                .ForMember(
                    dest => dest.RuleSegment,
                    opt => opt.MapFrom(
                        src => src.Segments))
                .ForMember(
                    dest => dest.RuleContract,
                    opt => opt.MapFrom(
                        src => src.Contracts))
                .ForMember(
                    dest => dest.RulePbp,
                    opt => opt.MapFrom(
                        src => src.Pbp))
                .ForMember(
                    dest => dest.RuleTin,
                    opt => opt.MapFrom(
                        src => src.Tin))
                .ForMember(
                    dest => dest.RuleMeasure,
                    opt => opt.MapFrom(
                        src => src.Measures)); 

                cfg.CreateMap<Application, RuleApplicationEntity>()
                    .ForMember(
                        dest => dest.Application,
                        opt => opt.MapFrom(
                            src => src));
                cfg.CreateMap<Application, ApplicationEntity>()
                    .ForMember(
                        dest => dest.RuleApplication,
                        opt => opt.Ignore());

                cfg.CreateMap<Segment, RuleSegmentEntity>()
                    .ForMember(
                        dest => dest.Segment,
                        opt => opt.MapFrom(
                            src => src));
                cfg.CreateMap<Segment, SegmentEntity>()
                    .ForMember(
                        dest => dest.RuleSegment,
                        opt => opt.Ignore());

                cfg.CreateMap<Contract, RuleContractEntity>()
                    .ForMember(
                        dest => dest.Contract,
                        opt => opt.MapFrom(
                            src => src));
                cfg.CreateMap<Contract, ContractEntity>()
                    .ForMember(
                        dest => dest.RuleContract,
                        opt => opt.Ignore());

                cfg.CreateMap<Pbp, RulePbpEntity>()
                    .ForMember(
                        dest => dest.Pbp,
                        opt => opt.MapFrom(
                            src => src));
                cfg.CreateMap<Pbp, PbpEntity>()
                     .ForMember(
                        dest => dest.ContractPbp,
                        opt => opt.Ignore())
                    .ForMember(
                        dest => dest.RulePbp,
                        opt => opt.Ignore());

                cfg.CreateMap<Tin, RuleTinEntity>()
                    .ForMember(
                        dest => dest.Tin,
                        opt => opt.MapFrom(
                            src => src));
                cfg.CreateMap<Tin, TinEntity>()
                    .ForMember(
                        dest => dest.RuleTin,
                        opt => opt.Ignore());

                cfg.CreateMap<Measure, RuleMeasureEntity>()
                    .ForMember(
                        dest => dest.Measure,
                        opt => opt.MapFrom(
                            src => src));
                cfg.CreateMap<Measure, MeasureEntity>()
                   .ForMember(
                        dest => dest.RuleMeasure,
                        opt => opt.Ignore());

            }
        )));

        public Mapper MappingToUser
         => _mappingToUser ?? (_mappingToUser = new Mapper(new MapperConfiguration(
            cfg => {
                cfg.CreateMap<UserEntity, User>()
                    .ForMember(
                        dest => dest.Applications,
                        opt => opt.MapFrom(
                            src => src.UserApplication.Select(c => c.Application)))
                    .ForMember(
                        dest => dest.Rules,
                        opt => opt.MapFrom(
                            src => src.UserRule.Select(c => c.Rule)));

                cfg.CreateMap<RuleEntity, Rule>()
                    .ForMember(
                        dest => dest.Applications,
                        opt => opt.MapFrom(
                            src => src.RuleApplication.Select(c => c.Application)))
                    .ForMember(
                        dest => dest.Segments,
                        opt => opt.MapFrom(
                            src => src.RuleSegment.Select(c => c.Segment)))
                    .ForMember(
                        dest => dest.Contracts,
                        opt => opt.MapFrom(
                            src => src.RuleContract.Select(c => c.Contract)))
                    .ForMember(
                        dest => dest.Pbp,
                        opt => opt.MapFrom(
                            src => src.RulePbp))
                    .ForMember(
                        dest => dest.Tin,
                        opt => opt.MapFrom(
                            src => src.RuleTin.Select(c => c.Tin)))
                    .ForMember(
                        dest => dest.Measures,
                        opt => opt.MapFrom(
                            src => src.RuleMeasure.Select(c => c.Measure)));


                cfg.CreateMap<RulePbpEntity, Pbp>()
                    .ForMember(
                        dest => dest.PbpId,
                        opt => opt.MapFrom(
                            src => src.PbpId))
                    .ForMember(
                        dest => dest.Description,
                        opt => opt.MapFrom(
                            src => src.Pbp.Description))
                    .ForMember(
                        dest => dest.ContractId,
                        opt => opt.MapFrom(
                            src => src.ContractId))
                    .ForMember(
                        dest => dest.ContractDescription,
                        opt => opt.MapFrom(
                            src => src.Contract.Description));
            })
        ));

        public Mapper MappingToUserEntityr
           => _mappingToUserEntity ?? (_mappingToUserEntity = new Mapper(new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<User, UserEntity>();
               cfg.CreateMap<Rule, RuleEntity>();
               cfg.CreateMap<Application, ApplicationEntity>();
           }
       )));

        public Mapper MappingToUserEntityPlain
              => _mappingToUserEntity ?? (_mappingToUserEntity = new Mapper(new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<User, UserEntity>()
                    .ForMember(
                        dest => dest.UserApplication,
                        opt => opt.MapFrom(
                            src => src.Applications))
                    .ForMember(
                        dest => dest.UserRule,
                        opt => opt.MapFrom(
                            src => src.Rules));

                  cfg.CreateMap<Application, UserApplicationEntity>()
                   .ForMember(
                       dest => dest.Application,
                       opt => opt.MapFrom(
                           src => src));

                  cfg.CreateMap<Application, ApplicationEntity>()
                    .ForMember(
                        dest => dest.RuleApplication,
                        opt => opt.Ignore())
                    .ForMember(
                        dest => dest.UserApplication,
                        opt => opt.Ignore());


                  cfg.CreateMap<Rule, UserRuleEntity>()
                   .ForMember(
                       dest => dest.Rule,
                       opt => opt.MapFrom(
                           src => src));

                  cfg.CreateMap<Rule, RuleEntity>()
                   .ForMember(
                       dest => dest.RuleSegment,
                       opt => opt.Ignore())
                   .ForMember(
                       dest => dest.RuleApplication,
                       opt => opt.Ignore())
                    .ForMember(
                       dest => dest.RuleContract,
                       opt => opt.Ignore())
                    .ForMember(
                       dest => dest.RulePbp,
                       opt => opt.Ignore())
                    .ForMember(
                       dest => dest.RuleTin,
                       opt => opt.Ignore())
                    .ForMember(
                       dest => dest.RuleMeasure,
                       opt => opt.Ignore());
              }
          )));
    }

  
}
