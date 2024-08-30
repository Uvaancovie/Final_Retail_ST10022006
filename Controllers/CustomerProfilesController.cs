using Microsoft.AspNetCore.Mvc;
using Final_Retail.Models;
using Final_Retail.Services;
using System.Threading.Tasks;


namespace Final_Retail.Controllers
{
    public class CustomerProfilesController : Controller
    {
        private readonly CustomerProfileService _customerProfileService;

        public CustomerProfilesController(CustomerProfileService customerProfileService)
        {
            _customerProfileService = customerProfileService;
        }

        // GET: CustomerProfiles
        public async Task<IActionResult> Index()
        {
            var profiles = await _customerProfileService.GetCustomerProfilesAsync("CustomerProfiles");
            return View(profiles);
        }

        // GET: CustomerProfiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _customerProfileService.GetCustomerProfileAsync("CustomerProfiles", id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: CustomerProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,PhoneNumber,Address")] CustomerProfile profile)
        {
            if (ModelState.IsValid)
            {
                await _customerProfileService.AddOrUpdateCustomerProfileAsync(profile);
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        // GET: CustomerProfiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _customerProfileService.GetCustomerProfileAsync("CustomerProfiles", id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: CustomerProfiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RowKey,Name,Email,PhoneNumber,Address")] CustomerProfile profile)
        {
            if (id != profile.RowKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerProfileService.AddOrUpdateCustomerProfileAsync(profile);
                }
                catch
                {
                    if (!await CustomerProfileExists(profile.RowKey))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }

        // GET: CustomerProfiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _customerProfileService.GetCustomerProfileAsync("CustomerProfiles", id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: CustomerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _customerProfileService.DeleteCustomerProfileAsync("CustomerProfiles", id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CustomerProfileExists(string id)
        {
            var profile = await _customerProfileService.GetCustomerProfileAsync("CustomerProfiles", id);
            return profile != null;
        }
    }
}
