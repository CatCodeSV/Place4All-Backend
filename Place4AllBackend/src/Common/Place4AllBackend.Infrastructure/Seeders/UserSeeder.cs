using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Place4AllBackend.Domain.Entities;
using Place4AllBackend.Infrastructure.Identity;

namespace Place4AllBackend.Infrastructure.Seeders;

public class UserSeeder
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        var administratorRole = new IdentityRole("Administrator");
        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        var userRole = new IdentityRole("User");
        if (roleManager.Roles.All(r => r.Name != userRole.Name))
        {
            await roleManager.CreateAsync(userRole);
        }

        var ownerRole = new IdentityRole("Owner");
        if (roleManager.Roles.All(r => r.Name != ownerRole.Name))
        {
            await roleManager.CreateAsync(ownerRole);
        }

        //TODO Añadir usuarios para Sandra y Laura

        //! Admin Users
        var defaultUser = new ApplicationUser
        {
            UserName = "iayti", Email = "test@test.com", Address = new Address()
            {
                Street = "Calle Bernardo",
                Number = 120,
                City = "Madrid",
                ZipCode = "28015",
                Province = "Madrid"
            }
        };
        var userAlex = new ApplicationUser
        {
            UserName = "alecsolace",
            Email = "keevinaguirre@gmail.com",
            Name = "Alexander",
            LastName = "Aguirre",
            Age = 24,
            PhoneNumber = "654939095",
            Address = new Address()
            {
                Street = "Avenida Cesareo Alierta",
                Number = 78,
                City = "Zaragoza",
                ZipCode = "50013",
                Province = "Zaragoza"
            }
        };
        var userLaura = new ApplicationUser
        {
            UserName = "laug13", Email = "lauragilf.13@gmail.com", Address = new Address()
            {
                Street = "Calle Augusto",
                Number = 10,
                City = "Zaragoza",
                ZipCode = "25015",
                Province = "Zaragoza"
            }
        };
        var userSandra = new ApplicationUser
        {
            UserName = "sandra20", Email = "diazmalo@hotmail.com", Address = new Address()
            {
                Street = "Calle Pablo Neruda",
                Number = 17,
                City = "Zaragoza",
                ZipCode = "50018",
                Province = "Zaragoza"
            }
        };

        if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
        {
            await userManager.CreateAsync(defaultUser, "Matech_1850");
            await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
        }

        if (userManager.Users.All(u => u.UserName != userAlex.UserName))
        {
            await userManager.CreateAsync(userAlex, "Test_1");
            await userManager.AddToRolesAsync(userAlex, new[] { administratorRole.Name });
        }

        if (userManager.Users.All(u => u.UserName != userLaura.UserName))
        {
            await userManager.CreateAsync(userLaura, "Test_2");
            await userManager.AddToRolesAsync(userLaura, new[] { administratorRole.Name });
        }

        if (userManager.Users.All(u => u.UserName != userSandra.UserName))
        {
            await userManager.CreateAsync(userSandra, "Test_3");
            await userManager.AddToRolesAsync(userSandra, new[] { administratorRole.Name });
        }

        //! Common User
        var commonUser1 = new ApplicationUser()
        {
            Name = "Jose",
            LastName = "Lopez",
            Age = 25,
            Gender = "M",
            DisabilityDegree = 2,
            HasDisability = true,
            UserName = "pepeLopez",
            Email = "lopezPepe@testing.com",
            Address = new Address()
            {
                Street = "Calle Juventud",
                Number = 12,
                City = "Zaragoza",
                ZipCode = "50019",
                Province = "Zaragoza"
            }
        };

        if (userManager.Users.All(u => u.Name != commonUser1.Name))
        {
            await userManager.CreateAsync(commonUser1, "Test_1");
            await userManager.AddToRoleAsync(commonUser1, userRole.Name);
        }

        //! Owner User
        var userOwner = new ApplicationUser()
        {
            UserName = "miguelAngel12",
            Email = "mangel@tagliatella.com",
            Address = new Address()
            {
                Street = "Calle Rosales",
                Number = 15,
                City = "Zaragoza",
                ZipCode = "50012",
                Province = "Zaragoza"
            },
            Name = "Miguel Angel",
            Age = 45,
            Gender = "M",
            DisabilityDegree = 0,
            HasDisability = false,
            LastName = "Martinez",
        };
        if (userManager.Users.All(u => u.Name != userOwner.Name))
        {
            await userManager.CreateAsync(userOwner, "Test_1");
            await userManager.AddToRoleAsync(userOwner, ownerRole.Name);
        }
    }
}