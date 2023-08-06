using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using chessAI.Models; // Replace 'YourApp.Models' with the appropriate namespace for your project

namespace chessAI.Controllers // Replace 'YourApp.Controllers' with the appropriate namespace for your project
{
    public class BasicController : Controller
    {
        private readonly BasicModel _basicModel;

        public BasicController(BasicModel basicModel)
        {
            _basicModel = basicModel;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch GitHub branches data using the BasicModel
            var gitHubBranches = await _basicModel.GetGitHubBranchesAsync();

            // Pass the data to the view
            return View(gitHubBranches);
        }
    }
}

