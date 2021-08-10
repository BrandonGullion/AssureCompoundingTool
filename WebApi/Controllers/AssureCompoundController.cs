using System.Threading.Tasks;
using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    public class AssureCompoundController : BaseApiController
    {
        private readonly DataContext _context;
        public AssureCompoundController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<string> ValidateMemberAndStore(MemberDTO memberDTO)
        {

            return "hello";

        }
    }
}