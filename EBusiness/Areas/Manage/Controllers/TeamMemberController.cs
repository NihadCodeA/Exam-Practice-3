using EBusiness.Helpers;
using EBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamMemberController : Controller
    {
        private readonly Database _context;
        private readonly IWebHostEnvironment _env;
        public TeamMemberController(Database context,IWebHostEnvironment env) {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            List<TeamMember> list = _context.TeamMembers.ToList();
            var query = _context.TeamMembers.AsQueryable();
            var paginatedList = PaginatedList<TeamMember>.Create(query, page, 5);
            return View(paginatedList);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamMember teamMember)
        {
            if (teamMember == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (teamMember.ImageFile != null)
            {
                teamMember.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/teammembers",teamMember.ImageFile);
            }
            else
            {
                ModelState.AddModelError("ImageFile","The Image field is required!");
                return View();
            }
            _context.TeamMembers.Add(teamMember);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            TeamMember teamMember = _context.TeamMembers.FirstOrDefault(x => x.Id == id);
            if (teamMember == null) return NotFound();
            if (!ModelState.IsValid) return View();
            return View(teamMember);
        }
        [HttpPost]
        public IActionResult Update(TeamMember teamMember)
        {
            TeamMember existTeamMember = _context.TeamMembers.FirstOrDefault(x => x.Id == teamMember.Id);
            if (existTeamMember == null) return NotFound();
            if (!ModelState.IsValid) return View();
            if (teamMember.ImageFile != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/teammembers",existTeamMember.Image);
                existTeamMember.Image = FileManager.SaveFile(_env.WebRootPath, "uploads/teammembers", teamMember.ImageFile);
            }
            existTeamMember.Fullname = teamMember.Fullname;
            existTeamMember.Positon = teamMember.Positon;
            existTeamMember.Order = teamMember.Order;
            existTeamMember.SocialMediaAccountUrl1 = teamMember.SocialMediaAccountUrl1;
            existTeamMember.SocialMediaAccountIcon1 = teamMember.SocialMediaAccountIcon1;
            existTeamMember.SocialMediaAccountUrl2 = teamMember.SocialMediaAccountUrl2;
            existTeamMember.SocialMediaAccountIcon2 = teamMember.SocialMediaAccountIcon2;
            existTeamMember.SocialMediaAccountUrl3 = teamMember.SocialMediaAccountUrl3;
            existTeamMember.SocialMediaAccountIcon3 = teamMember.SocialMediaAccountIcon3;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            TeamMember teamMember = _context.TeamMembers.FirstOrDefault(x => x.Id == id);
            if (teamMember == null) return NotFound();
            if (teamMember.Image != null)
            {
                FileManager.DeleteFile(_env.WebRootPath, "uploads/teammembers", teamMember.Image);
            }
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
