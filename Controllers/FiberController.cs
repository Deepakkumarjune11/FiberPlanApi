using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiberPlanAPI.FiberConnection;
using FiberPlanAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiberPlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiberController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(FiberController));
        private readonly IFiberPlanServ<FiberPlan> fp_serv;
        public FiberController(IFiberPlanServ<FiberPlan> _fp_serv)
        {
            fp_serv = _fp_serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFiberPlans()
        {
            _log4net.Info("Getting All Fiber Plans");
            return Ok(await fp_serv.GetFiberPlans());
        }
        [HttpPost]
        public async Task<IActionResult> AddPlanDetails(FiberPlan fp)
        {
            _log4net.Info($"{fp.PlanName} is added to the List");
            return Ok(await fp_serv.AddPlans(fp));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _log4net.Info($"Getting the plan from {id}");
            return Ok(await fp_serv.GetFiberPlansByID(id));
        }
        [HttpPut]
        public async Task<IActionResult> EditPlan(int id,FiberPlan fp)
        {
            _log4net.Info($"{fp.PlanName} is Edited");
            return Ok(await fp_serv.EditPlan(id,fp));
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePlan(int id)
        {
            _log4net.Info($" Plan : {id} is Deleted");
            return Ok(await fp_serv.DeletePlan(id));
        }

    }
}
