using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FiberPlanAPI.FiberConnection
{
    public partial class FiberPlan: IFiberPlan<FiberPlan>
    {
        private readonly fiber_connectionContext fcc = new fiber_connectionContext();
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string PlanPrice { get; set; }
        public string PlanSpeed { get; set; }
        public string Validity { get; set; }
        public int? OfferId { get; set; }
        public string Image { get; set; }

        public virtual Offer Offer { get; set; }
        public async Task<int> AddPlans(FiberPlan fp)
        {
            fcc.FiberPlans.Add(fp);
            return await fcc.SaveChangesAsync();
        }

        public async Task<List<FiberPlan>> GetFiberPlans()
        {
            return await fcc.FiberPlans.ToListAsync();
        }
        public async Task<FiberPlan> GetFiberPlansByID(int id)
        {
            return await fcc.FiberPlans.FindAsync(id);
        }
        public async Task<int> EditPlan(int id, FiberPlan fp)
        {
            using (var fccc = new fiber_connectionContext())
            {
                fccc.Entry(fp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await fccc.SaveChangesAsync();
            }
        }
        public async Task<int> DeletePlan(int id)
        {
            FiberPlan fp = fcc.FiberPlans.Find(id);
            fcc.FiberPlans.Remove(fp);
            
            return await fcc.SaveChangesAsync();
        }
            

    }
}
