using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiberPlanAPI.FiberConnection;

namespace FiberPlanAPI.Repository
{
    public class FiberPlanRepo:IFiberPlanRepo<FiberPlan>
    {
        private readonly IFiberPlan<FiberPlan> fp_obj;
        public FiberPlanRepo(IFiberPlan<FiberPlan> _fp_obj)
        {
            fp_obj = _fp_obj;
        }

        public FiberPlanRepo()
        {
        }

        public async Task<int> AddPlans(FiberPlan fp)
        {
           return await fp_obj.AddPlans(fp);
        }

        public async Task<List<FiberPlan>> GetFiberPlans()
        {
            return await fp_obj.GetFiberPlans();
        }
        public async Task<FiberPlan> GetFiberPlansByID(int id)
        {
            return await fp_obj.GetFiberPlansByID(id);
        }
        public async Task<int> EditPlan(int id, FiberPlan fp)
        {
            return await fp_obj.EditPlan(id, fp);
        }
        public async Task<int> DeletePlan(int id)
        {
            return await fp_obj.DeletePlan(id);
        }
    }
}
