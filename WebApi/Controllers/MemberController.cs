using Classes.DTO;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Gets the current list of members that are associated with said memberId
        /// Then check if they are currently on the plan by using DOB and MemberType
        /// </summary>
        /// <param name="memberDTO"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ValidateMember")]
        public async Task<IActionResult> ValidateMember(MemberDTO memberDTO)
        {
            var members = await _context.Members.Where(m => m.MemberId == memberDTO.MemberId).ToListAsync();

            if (members != null && members.Count > 0)
            {
                var currentMember = members.FirstOrDefault(m => m.DOB == memberDTO.DOB && m.MemberType == memberDTO.MemberType);

                if (currentMember == null)
                    return BadRequest("A member with the provided date of birth and member status could not be found.");

                return Ok();
            }

            return BadRequest("Unable to find any members with the provided Member Id");
        }
    }
}
