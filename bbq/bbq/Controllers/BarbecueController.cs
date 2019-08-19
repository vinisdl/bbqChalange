using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bbq.Application.Filters;
using bbq.Domain.Entities;
using bbq.Domain.ViewModel;
using bbq.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bbq.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbecueController : ControllerBase
    {
        private readonly IBarbecueServices _barbecueServices;

        public BarbecueController(IBarbecueServices barbecueServices)
        {
            this._barbecueServices = barbecueServices;
        }

        [HttpPost]
        [TypeFilter(typeof(TokenAuthFilterAttribute))]
        public ActionResult<Barbecue> Create([FromBody] Barbecue barbecue)
        {
            return _barbecueServices.Add(barbecue);
        }

        [HttpPost("{id}/AddParticipant")]
        [TypeFilter(typeof(TokenAuthFilterAttribute))]
        public ActionResult<Barbecue> AddParticipant([FromRoute]int id, [FromBody] BarbecueParticipant barbecueParticipant)
        {
            return _barbecueServices.AddParticipant(id, barbecueParticipant);
        }

        [HttpPost("{idBarbecue}/RemoveParticipant/{idBarbecueParticipant}")]
        [TypeFilter(typeof(TokenAuthFilterAttribute))]
        public ActionResult<Barbecue> RemoveParticipant([FromRoute]int idBarbecue, [FromRoute] int idBarbecueParticipant)
        {
            return _barbecueServices.RemoveParticipant(idBarbecue, idBarbecueParticipant);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(TokenAuthFilterAttribute))]
        public ActionResult<BarbecueDetailsViewModel> GetBarbecueDetails([FromRoute]int id)
        {
            return _barbecueServices.GetBarbecueDetails(id);
        }
    }
}