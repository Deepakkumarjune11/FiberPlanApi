using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiberPlanAPI.FiberConnection;
using FiberPlanAPI.Repository;

namespace FiberPlanAPI.Service
{
    public class FiberPlanServ:IFiberPlanServ<FiberPlan>
    {
        private readonly IFiberPlanRepo<FiberPlan> fp_repo;

        public FiberPlanServ(IFiberPlanRepo<FiberPlan> _fp_repo)
        {
            fp_repo = _fp_repo;
        }

        public async Task<int> AddPlans(FiberPlan fp)
        {
           return await fp_repo.AddPlans(fp);
        }

        public async Task<List<FiberPlan>> GetFiberPlans()
        {
            return await fp_repo.GetFiberPlans();
        }
        public async Task<FiberPlan> GetFiberPlansByID(int id)
        {
            return await fp_repo.GetFiberPlansByID(id);
        }
        public async Task<int> EditPlan(int id, FiberPlan fp)
        {
            return await fp_repo.EditPlan(id, fp);
        }
        public async Task<int> DeletePlan(int id)
        {
            return await fp_repo.DeletePlan(id);
        }
    }
}
