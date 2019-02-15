using SCRA.Data.Clinical.Services;
using SCRA.Framework.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SCRA.Framework.Common.Errors;
using SCRA.Framework.Clinical.Service;
using SCRA.Framework.Models.Clinical;
using Microsoft.EntityFrameworkCore;
using SCRA.Data.Clinical.Entities;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System;

namespace SCRA.Framework.Clinical
{
    public class ClinicalService 
    {
        private readonly ClinicalFactory _clinicalFactory = new ClinicalFactory();

        public ClinicalDbService ClinicalDbService;
        public RuleConstraintException RuleConstraintException;

        public ClinicalService()
        {
            ClinicalDbService = new ClinicalDbService();
            RuleConstraintException = new RuleConstraintException();
        }

        #region  Get
        public async Task<Result> GetApplications()
        {
             IList<Application> applications = (await ClinicalDbService.ApplicationRepository.GetAllAsync())
                 .Select(item => _clinicalFactory.MappingToApplication.DefaultContext.Mapper.Map<Application>(item)).ToList();

            return Result.New(applications);
        }

        public async Task<Result> GetContracts()
        {
            IList<Contract> contracts = (await ClinicalDbService.ContractRepository.GetAllAsync())
                 .Select(item => _clinicalFactory.MappingToContract.DefaultContext.Mapper.Map<Contract>(item)).ToList();

            return Result.New(contracts);
        }

        public async Task<Result> GetMeasures()
        {
            IList<Measure> mesures = (await ClinicalDbService.MeasureRepository.GetAllAsync())
                .Select(item => _clinicalFactory.MappingToMesures.DefaultContext.Mapper.Map<Measure>(item)).ToList();

            return Result.New(mesures);
        }

        public async Task<Result> GetPbpList()
        {

            IList<Pbp> pbpList = (

                    await (
                        from Pbp in ClinicalDbService.PbpRepository.Queryable().Include(P => P.ContractPbp)
                        join ContractPbp in ClinicalDbService.ContractPbpRepository.Queryable()
                        on Pbp.PbpId equals ContractPbp.PbpId
                        select new { Pbp.PbpId, ContractPbp.ContractId, Pbp.Description, ContractDescription = ContractPbp.Contract.Description }
                    ).ToArrayAsync())
                .Select(item => _clinicalFactory.MappingToPbp.DefaultContext.Mapper.Map<Pbp>(item)).ToList();

            return Result.New(pbpList);
        }

        public async Task<Result> GetRules()
        {
            var test = ClinicalDbService.RulePbpRepository.Queryable().Include(rp => rp.Contract).ToList();

               IList<Rule> rules = (
                await _GetRuleIncludableQueryable().ToListAsync()
            ).Select(item => _clinicalFactory.MappingToRule.DefaultContext.Mapper.Map<Rule>(item)).ToList();

            return Result.New(rules);
        }

        public async Task<Result> GetSegments()
        {
            IList<Segment> segments = (await ClinicalDbService.SegmentRepository.GetAllAsync())
                .Select(item => _clinicalFactory.MappingToSegment.DefaultContext.Mapper.Map<Segment>(item)).ToList();

            return Result.New(segments);
        }

        public async Task<Result> GetTinList()
        {
            IList<Tin> tinList = (await ClinicalDbService.TinRepository.GetAllAsync())
                .Select(item => _clinicalFactory.MappingToTin.DefaultContext.Mapper.Map<Tin>(item)).ToList();

            return Result.New(tinList);
        }

        public async Task<Result> GetUsers()
        {
            
            IList<User> users = (
                await _GetUsers()
            ).Select(item => _clinicalFactory.MappingToUser.DefaultContext.Mapper.Map<User>(item)).ToList();

            return Result.New(users);
        }
        #endregion

        #region  Create
        public async Task<Result> CreateNewRule(Rule rule)
        {
            RuleEntity _ruleEntity = _clinicalFactory.MappingToRuleEntity.DefaultContext.Mapper.Map<RuleEntity>(rule);

            foreach (SegmentEntity Segment in _ruleEntity.RuleSegment.Select(r => r.Segment))
            {
                ClinicalDbService.SegmentRepository.AddAndAttach(Segment);
            }

            foreach (ContractEntity Contract in _ruleEntity.RuleContract.Select(r => r.Contract))
            {
                ClinicalDbService.ContractRepository.AddAndAttach(Contract);
            }

            IEnumerable<PbpEntity> PbpList = _ruleEntity.RulePbp.Select(r => r.Pbp).GroupBy(p => p.PbpId,(baseId, list) => new PbpEntity {
                PbpId = baseId
            });

            foreach (PbpEntity Pbp in PbpList)
            {
                ClinicalDbService.PbpRepository.AddAndAttach(Pbp);
            }

            foreach (TinEntity Tin in _ruleEntity.RuleTin.Select(r => r.Tin))
            {
                ClinicalDbService.TinRepository.AddAndAttach(Tin);
            }

            foreach (MeasureEntity Measures in _ruleEntity.RuleMeasure.Select(r => r.Measure))
            {
                ClinicalDbService.MeasureRepository.AddAndAttach(Measures);
            }

            foreach (ApplicationEntity Application in _ruleEntity.RuleApplication.Select(r => r.Application))
            {
                ClinicalDbService.ApplicationRepository.AddAndAttach(Application);
            }

            ClinicalDbService.RuleRepository.Add(_ruleEntity);

            await ClinicalDbService.SaveAsync();

            return Result.New(_ruleEntity);
        }
        #endregion

        #region  Delete
        public async Task<Result> DeleteRule(Rule rule)
        {
            try
            {
                RuleEntity _ruleEntity = _GetReleById(rule.RuleId); 

                foreach (SegmentEntity Segment in _ruleEntity.RuleSegment.Select(r => r.Segment))
                {
                    ClinicalDbService.SegmentRepository.AddAndAttach(Segment);
                }

                foreach (ContractEntity Contract in _ruleEntity.RuleContract.Select(r => r.Contract))
                {
                    ClinicalDbService.ContractRepository.AddAndAttach(Contract);
                }

                foreach (PbpEntity Pbp in _ruleEntity.RulePbp.Select(r => r.Pbp))
                {
                    ClinicalDbService.PbpRepository.AddAndAttach(Pbp);
                }

                foreach (TinEntity Tin in _ruleEntity.RuleTin.Select(r => r.Tin))
                {
                    ClinicalDbService.TinRepository.AddAndAttach(Tin);
                }

                foreach (MeasureEntity Measures in _ruleEntity.RuleMeasure.Select(r => r.Measure))
                {
                    ClinicalDbService.MeasureRepository.AddAndAttach(Measures);
                }

                foreach (ApplicationEntity Application in _ruleEntity.RuleApplication.Select(r => r.Application))
                {
                    ClinicalDbService.ApplicationRepository.AddAndAttach(Application);
                }


                ClinicalDbService.RuleRepository.Delete(_ruleEntity);

                await ClinicalDbService.SaveAsync();

                return Result.New(_ruleEntity);
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

                if (sqlException != null)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        Result result = Result.New(null);

                        return result.SetError("547", sqlException, "The rule could not be deleted, there are users associated with it.");
                    }
                }

                return Result.New(null);
            }

        }
        #endregion

        #region  Update
        public async Task<Result> UpdateUserRules(IList<User> users)
        {
            foreach (User user in users)
            {

                UserEntity newUserEntity = _clinicalFactory.MappingToUserEntityPlain.DefaultContext.Mapper.Map<UserEntity>(user);
                UserEntity originalUserEntity = _GetUserById(newUserEntity.UserId);

                IList<Rule> originalRules = (originalUserEntity.UserRule.Select(r => r.Rule))
                   .Select(item => _clinicalFactory.MappingToRule.DefaultContext.Mapper.Map<Rule>(item)).ToList();

                
                string ruleConstraintException
                    = RuleConstraintException.CheckRulesConstraintConsistency(user.Rules.ToList(), user.Rules.Where(r => !originalRules.Any(or => or.RuleId == r.RuleId)).ToList());
                
                if (ruleConstraintException == null)
                {
                    IEnumerable<int> originalRulesId = originalUserEntity.UserRule.Select(r => r.Rule).Select(r => r.RuleId);

                    IEnumerable<int> editedRulesId = new List<int>();
                    if (newUserEntity.UserRule != null) {
                        editedRulesId = newUserEntity.UserRule.Select(r => r.Rule).Select(r => r.RuleId);
                    }
                    

                    IList<RuleEntity> rulesToAdd = new List<RuleEntity>();
                    IEnumerable<int> rulesIdToAdd = editedRulesId.Except(originalRulesId);
                    foreach (int ruleId in rulesIdToAdd)
                    {
                        RuleEntity segment = ClinicalDbService.RuleRepository.GetById(ruleId);
                        if (!rulesToAdd.Contains(segment))
                            rulesToAdd.Add(segment);
                    }

                    rulesToAdd.ToList().ForEach(r => originalUserEntity.UserRule.Add(
                        new UserRuleEntity {
                            UserId = originalUserEntity.UserId,
                            Rule = r
                        }
                    ));

                    IList<RuleEntity> rulesToRemove = new List<RuleEntity>();
                    IEnumerable<int> rulesIdRemove = originalRulesId.Except(editedRulesId);

                    foreach (int ruleId in rulesIdRemove)
                    {
                        RuleEntity segment = originalUserEntity.UserRule.Select(r => r.Rule).FirstOrDefault(r => r.RuleId == ruleId);
                        if (!rulesToRemove.Contains(segment))
                            rulesToRemove.Add(segment);
                    }
                    rulesToRemove.ToList().ForEach(r => originalUserEntity.UserRule.Remove(
                        originalUserEntity.UserRule.Select(ur => ur).Where(ur => ur.RuleId == r.RuleId).First()
                    ));

                    ClinicalDbService.UserRepository.Update(originalUserEntity);

                    await ClinicalDbService.SaveAsync();
                }
                else
                {
                    Result result = Result.New(null);

                    return result.SetError(null, ruleConstraintException);
                }

            }

            return Result.New();
        }

        public async Task<Result> UpdateRule(Rule rule)
        {
            RuleEntity newruleEntity = _clinicalFactory.MappingToRuleEntity.DefaultContext.Mapper.Map<RuleEntity>(rule);
            RuleEntity originalRuleEntity = _GetReleById(rule.RuleId);

            originalRuleEntity.Description = newruleEntity.Description;

            #region Update Segments ------------------------------------------------------------------------------------

            IEnumerable<int> originalSegmentsId = originalRuleEntity.RuleSegment.Select(s => s.Segment).Select(s => s.SegmentId);
            IEnumerable<int> editedSegmentsId = newruleEntity.RuleSegment.Select(s => s.Segment).Select(s => s.SegmentId);

            IList<SegmentEntity> segmentToAdd = new List<SegmentEntity>();
            IEnumerable<int> segmentsIdToAdd = editedSegmentsId.Except(originalSegmentsId);
            foreach (int segmentId in segmentsIdToAdd)
            {
                SegmentEntity segment = ClinicalDbService.SegmentRepository.GetById(segmentId);
                if (!segmentToAdd.Contains(segment))
                    segmentToAdd.Add(segment);
            }


            segmentToAdd.ToList().ForEach(s => originalRuleEntity.RuleSegment.Add( new RuleSegmentEntity {
                RuleId = originalRuleEntity.RuleId,
                Segment = s
            }));


            IList<SegmentEntity> segmentToRemove = new List<SegmentEntity>();
            IEnumerable<int> segmentsIdRemove = originalSegmentsId.Except(editedSegmentsId);

            foreach (int segmentId in segmentsIdRemove)
            {
                SegmentEntity segment = originalRuleEntity.RuleSegment.Select(s => s.Segment).FirstOrDefault(s => s.SegmentId == segmentId);
                if (!segmentToRemove.Contains(segment))
                    segmentToRemove.Add(segment);
            }


            segmentToRemove.ToList().ForEach(s => originalRuleEntity.RuleSegment.Remove(
                originalRuleEntity.RuleSegment.Select(r => r).Where(r => r.SegmentId == s.SegmentId).First()
            ));
            #endregion

            #region Update Contracts -----------------------------------------------------------------------------------

            IEnumerable<int> originalContractsId = originalRuleEntity.RuleContract.Select(c => c.Contract).Select(c => c.ContractId);
            IEnumerable<int> editedContractsId = newruleEntity.RuleContract.Select(c => c.Contract).Select(c => c.ContractId);

            IList<ContractEntity> contractToAdd = new List<ContractEntity>();
            IEnumerable<int> contractsIdToAdd = editedContractsId.Except(originalContractsId);
            foreach (int contractId in contractsIdToAdd)
            {
                ContractEntity contract = ClinicalDbService.ContractRepository.GetById(contractId);
                if (!contractToAdd.Contains(contract))
                    contractToAdd.Add(contract);
            }

            contractToAdd.ToList().ForEach(c => originalRuleEntity.RuleContract.Add(new RuleContractEntity
            {
                RuleId = originalRuleEntity.RuleId,
                Contract = c
            }));

            IList<ContractEntity> contractToRemove = new List<ContractEntity>();
            IEnumerable<int> contractsIdRemove = originalContractsId.Except(editedContractsId);

            foreach (int contractId in contractsIdRemove)
            {
                ContractEntity contract = originalRuleEntity.RuleContract.Select(c => c.Contract).FirstOrDefault(s => s.ContractId == contractId);
                if (!contractToRemove.Contains(contract))
                    contractToRemove.Add(contract);
            }

            contractToRemove.ToList().ForEach(c => originalRuleEntity.RuleContract.Remove(
                 originalRuleEntity.RuleContract.Select(rc => rc).Where(rc => rc.ContractId == c.ContractId).First()
            ));
            #endregion

            #region Update Pbp -----------------------------------------------------------------------------------------
            
                IEnumerable<RulePbpEntity> originalPbp = originalRuleEntity.RulePbp.Select(p => p);
                IEnumerable<RulePbpEntity> editedPbp = newruleEntity.RulePbp.Select(p => p);

                IEnumerable<RulePbpEntity> pbpToAdd = editedPbp.Except(originalPbp, new IRulePbpEntityComparer()).ToList();

                foreach (var pbp in pbpToAdd)
                {
                    PbpEntity _pbp = ClinicalDbService.PbpRepository.Queryable().Include(p => p.ContractPbp).FirstOrDefault(p => p.PbpId == pbp.PbpId);
                }

                pbpToAdd.ToList().ForEach(rp => originalRuleEntity.RulePbp.Add(rp));

                IEnumerable<RulePbpEntity> pbpToRemove = originalPbp.Except(editedPbp, new IRulePbpEntityComparer()).ToList();

                pbpToRemove.ToList().ForEach(p => originalRuleEntity.RulePbp.Remove(
                    originalRuleEntity.RulePbp.Select(rp => rp).Where(rp => rp.PbpId == p.PbpId && p.ContractId == p.ContractId).First()
                ));
            #endregion

            #region Update TIN -----------------------------------------------------------------------------------------

            IEnumerable<int> originalTinId = originalRuleEntity.RuleTin.Select(t => t.Tin).Select(c => c.TinId);
            IEnumerable<int> editedTinId = newruleEntity.RuleTin.Select(t => t.Tin).Select(c => c.TinId);

            IList<TinEntity> tinToAdd = new List<TinEntity>();
            IEnumerable<int> tinsIdToAdd = editedTinId.Except(originalTinId);
            foreach (int tinId in tinsIdToAdd)
            {
                TinEntity tin = ClinicalDbService.TinRepository.GetById(tinId);
                if (!tinToAdd.Contains(tin))
                    tinToAdd.Add(tin);
            }

            tinToAdd.ToList().ForEach(t => originalRuleEntity.RuleTin.Add(
                new RuleTinEntity {
                    RuleId = originalRuleEntity.RuleId,
                    Tin = t
                }
            ));

            IList<TinEntity> tinToRemove = new List<TinEntity>();
            IEnumerable<int> tinsIdRemove = originalTinId.Except(editedTinId);

            foreach (int tinId in tinsIdRemove)
            {
                TinEntity tin = originalRuleEntity.RuleTin.Select(t => t.Tin).FirstOrDefault(s => s.TinId == tinId);
                if (!tinToRemove.Contains(tin))
                    tinToRemove.Add(tin);
            }

            tinToRemove.ToList().ForEach(t => originalRuleEntity.RuleTin.Remove(
                 originalRuleEntity.RuleTin.Select(rt => rt).Where(rt => rt.TinId == t.TinId).First()
            ));
            #endregion

            #region Update Measures ------------------------------------------------------------------------------------

            IEnumerable<int> originalMeasuresId = originalRuleEntity.RuleMeasure.Select(rm => rm.Measure).Select(c => c.MeasureId);
            IEnumerable<int> editedMeasuresId = newruleEntity.RuleMeasure.Select(rm => rm.Measure).Select(c => c.MeasureId);

            IList<MeasureEntity> measuresToAdd = new List<MeasureEntity>();
            IEnumerable<int> measuresIdToAdd = editedMeasuresId.Except(originalMeasuresId);
            foreach (int measureId in measuresIdToAdd)
            {
                MeasureEntity measure = ClinicalDbService.MeasureRepository.GetById(measureId);
                if (!measuresToAdd.Contains(measure))
                    measuresToAdd.Add(measure);
            }

            measuresToAdd.ToList().ForEach(m => originalRuleEntity.RuleMeasure.Add(
                new RuleMeasureEntity {
                    RuleId = originalRuleEntity.RuleId,
                    Measure = m
                }
            ));

            IList<MeasureEntity> measuresToRemove = new List<MeasureEntity>();
            IEnumerable<int> measuresIdRemove = originalMeasuresId.Except(editedMeasuresId);

            foreach (int measureId in measuresIdRemove)
            {
                MeasureEntity measure = originalRuleEntity.RuleMeasure.Select(rm => rm.Measure).FirstOrDefault(s => s.MeasureId == measureId);
                if (!measuresToRemove.Contains(measure))
                    measuresToRemove.Add(measure);
            }

            measuresToRemove.ToList().ForEach(m => originalRuleEntity.RuleMeasure.Remove(
                 originalRuleEntity.RuleMeasure.Select(rm => rm).Where(rm => rm.MeasureId == m.MeasureId).First()
            ));
            #endregion

            #region Update Applications --------------------------------------------------------------------------------

            IEnumerable<int> originalApplicationsId = originalRuleEntity.RuleApplication.Select(ra => ra.Application).Select(a => a.ApplicationId);
            IEnumerable<int> editedApplicationsId = newruleEntity.RuleApplication.Select(ra => ra.Application).Select(c => c.ApplicationId);

            IList<ApplicationEntity> applicationsToAdd = new List<ApplicationEntity>();
            IEnumerable<int> applicationsIdToAdd = editedApplicationsId.Except(originalApplicationsId);
            foreach (int applicationId in applicationsIdToAdd)
            {
                ApplicationEntity application = ClinicalDbService.ApplicationRepository.GetById(applicationId);
                if (!applicationsToAdd.Contains(application))
                    applicationsToAdd.Add(application);
            }

            applicationsToAdd.ToList().ForEach(a => originalRuleEntity.RuleApplication.Add(
                new RuleApplicationEntity {
                    RuleId = originalRuleEntity.RuleId,
                    Application = a
                }
            ));

            IList<ApplicationEntity> applicationsToRemove = new List<ApplicationEntity>();
            IEnumerable<int> applicationsIdRemove = originalApplicationsId.Except(editedApplicationsId);

            foreach (int applicationId in applicationsIdRemove)
            {
                ApplicationEntity application = originalRuleEntity.RuleApplication.Select(ra => ra.Application).FirstOrDefault(s => s.ApplicationId == applicationId);
                if (!applicationsToRemove.Contains(application))
                    applicationsToRemove.Add(application);
            }

            applicationsToRemove.ToList().ForEach(a => originalRuleEntity.RuleApplication.Remove(
                 originalRuleEntity.RuleApplication.Select(ra => ra).Where(ra => ra.ApplicationId == a.ApplicationId).First()
            ));
            #endregion
    
            ClinicalDbService.RuleRepository.Update(originalRuleEntity);

            await ClinicalDbService.SaveAsync();
          
            return Result.New(originalRuleEntity);
        }
        #endregion

        private IIncludableQueryable<RuleEntity, ApplicationEntity> _GetRuleIncludableQueryable()
        {

             return ClinicalDbService.RuleRepository.Queryable()
                         .Include(r => r.RuleSegment)
                             .ThenInclude(s => s.Segment)
                         .Include(r => r.RuleContract)
                             .ThenInclude(c => c.Contract)
                         .Include(r => r.RulePbp)
                             .ThenInclude(p => p.Pbp)
                         .Include(r => r.RulePbp)
                             .ThenInclude(p => p.Contract)
                         .Include(r => r.RuleTin)
                             .ThenInclude(t => t.Tin)
                         .Include(r => r.RuleMeasure)
                             .ThenInclude(m => m.Measure)
                         .Include(r => r.RuleApplication)
                            .ThenInclude(a => a.Application);
        }

        private RuleEntity _GetReleById(int? ruleId)
        {
            return _GetRuleIncludableQueryable().Where(r => r.RuleId == ruleId).First();
        }

        private IIncludableQueryable<UserEntity, MeasureEntity> _GetUsersIncludableQueryable()
        {
            return ClinicalDbService.UserRepository.Queryable()
                  .Include(u => u.UserApplication)
                       .ThenInclude(a => a.Application)

                  .Include(u => u.UserRule)
                      .ThenInclude(r => r.Rule)
                          .ThenInclude(r => r.RuleApplication)
                              .ThenInclude(r => r.Application)

                  .Include(u => u.UserRule)
                      .ThenInclude(r => r.Rule)
                          .ThenInclude(r => r.RuleSegment)
                              .ThenInclude(r => r.Segment)

                   .Include(u => u.UserRule)
                      .ThenInclude(r => r.Rule)
                          .ThenInclude(r => r.RuleContract)
                              .ThenInclude(r => r.Contract)

                  .Include(u => u.UserRule)
                      .ThenInclude(r => r.Rule)
                          .ThenInclude(r => r.RulePbp)
                              .ThenInclude(r => r.Pbp)

                .Include(u => u.UserRule)
                      .ThenInclude(r => r.Rule)
                          .ThenInclude(r => r.RulePbp)
                              .ThenInclude(r => r.Contract)

                  .Include(u => u.UserRule)
                      .ThenInclude(r => r.Rule)
                          .ThenInclude(r => r.RuleTin)
                              .ThenInclude(r => r.Tin)

                  .Include(u => u.UserRule)
                      .ThenInclude(r => r.Rule)
                          .ThenInclude(r => r.RuleMeasure)
                              .ThenInclude(r => r.Measure);
        }

        private Task<List<UserEntity>> _GetUsers()
        {
            return _GetUsersIncludableQueryable().ToListAsync();
        }

        private UserEntity _GetUserById(int userId)
        {
            return _GetUsersIncludableQueryable().Where(u => u.UserId == userId).First();
        }
    }

    public class IRulePbpEntityComparer : IEqualityComparer<RulePbpEntity>
    {
        public int GetHashCode(RulePbpEntity co)
        {
            if (co == null)
            {
                return 0;
            }
            return co.PbpId.GetHashCode();
        }

        public bool Equals(RulePbpEntity x1, RulePbpEntity x2)
        {
            if (ReferenceEquals(x1, x2))
            {
                return true;
            }
            if (ReferenceEquals(x1, null) ||
                ReferenceEquals(x2, null))
            {
                return false;
            }

            return x1.PbpId == x2.PbpId && x1.ContractId == x2.ContractId;
        }
    }

}
