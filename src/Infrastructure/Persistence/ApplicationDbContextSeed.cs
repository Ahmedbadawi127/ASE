using Shipping.Domain.Entities;
using Shipping.Domain.ValueObjects;
using Shipping.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shipping.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext _context)
        {
            // Seed, if necessary
            if (!_context.TodoLists.Any())
            {
                _context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Colour = Colour.Blue,
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

                await _context.SaveChangesAsync();
            }

            // Seed, if necessary
            if (!_context.States.Any())
            {
                List<State> states = new List<State>
                {
                    new State()
                    {
                        Name = "Alexandria",
                    },
                    new State()
                    {
                        Name = "Aswan",
                    },
                    new State()
                    {
                        Name = "Asyut",
                    },
                    new State()
                    {
                        Name = "Beheira",
                    },
                    new State()
                    {
                        Name = "Beni Suef",
                    },
                    new State()
                    {
                        Name = "Cairo",
                    },
                    new State()
                    {
                        Name = "Dakahlia",
                    },
                    new State()
                    {
                        Name = "Damietta",
                    },
                    new State()
                    {
                        Name = "Faiyum",
                    },
                    new State()
                    {
                        Name = "Gharbia",
                    },
                };

                await _context.States.AddRangeAsync(states);

                await _context.SaveChangesAsync();
            }
        }
    }
}
