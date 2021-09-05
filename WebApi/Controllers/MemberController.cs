using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    // This controller may only really get used for dev purposes

    public class MemberController : BaseApiController
    {
        private readonly DataContext _context;

        public MemberController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetMember")]
        public async Task<IActionResult> GetMember(int id)
        {
            return BadRequest("Endpoint GetMember not configured");
        }

        [HttpGet("GetMembers")]
        public async Task<IActionResult> GetMembers()
        {
            return BadRequest("Endpoint GetMember not configured");
        }

        [HttpPost("CreateMember")]
        public async Task<IActionResult> CreateMember()
        {
            return BadRequest("Endpoint CreateMember not configured");
        }

        [HttpPost("DeleteMember")]
        public async Task<IActionResult> DeleteMember()
        {
            return BadRequest("Endpoint DeleteMember not configured");
        }


    }
}
