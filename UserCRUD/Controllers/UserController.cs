using Microsoft.AspNetCore.Mvc;
using UserCRUD.Models;



namespace UserCRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("http://localhost:5180/");
        }
       
        // GET: User
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/user");
            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
                return View(users);
            }
            else
            {
                // Handle error
                return View(new List<User>());
            }
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                string getSkillsets = user.Skillsets[0];
                // Split the Skillsets string into an array using comma as delimiter
                user.Skillsets = getSkillsets.Split(", ");

                var response = await _httpClient.PostAsJsonAsync("api/user", user);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle error
                    return View(user);
                }
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"api/user/{id}");
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<User>();
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                // Handle error
                return NotFound();
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string getSkillsets = user.Skillsets[0];
                // Split the Skillsets string into an array using comma as delimiter
                user.Skillsets = getSkillsets.Split(", ");


                var response = await _httpClient.PutAsJsonAsync($"api/user/{id}", user);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle error
                    return View(user);
                }
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.DeleteAsync($"api/user/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle error
                return NotFound();
            }
        }
    }
}
