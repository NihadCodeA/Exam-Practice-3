using EBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly Database _context;
        public HomeController(Database context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TeamMember> members = _context.TeamMembers.OrderBy(x => x.Order).Take(4).ToList();
            return View(members);
        }
    }
}