using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiberPlanAPI.FiberConnection
{
    public interface IFiberPlan<FiberPlan>
    {
        public Task<List<FiberPlan>> GetFiberPlans();
        public Task<int> AddPlans(FiberPlan fp);
        public Task<FiberPlan> GetFiberPlansByID(int id);
        public Task<int> EditPlan(int id, FiberPlan fp);
        public Task<int> DeletePlan(int id);
    }
}
