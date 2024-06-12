using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository;
using WebApplication1.DTO.Identity;
using WebApplication1.Service.TokenServices;

namespace WebApplication1.Repository;


public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var rolemanager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<long>>>();
        var usermanager = serviceProvider.GetRequiredService<UserManager<User>>();
        string[] Roles = { RoleConsts.Moderator, RoleConsts.Administrator, RoleConsts.Member }; ;
        
        var user = new User
        { 
            FirstName = "xxxx", 
            LastName = "xxxx",
            MiddleName = "xxxxx",
            Email = "LiskaLisovsky", 
            UserName = "LiskaLisovsky"
        };
        var result = await usermanager.CreateAsync(user, "LiskaLisovsky#1");
        var findUser = await usermanager.FindByNameAsync("LiskaLisovsky");
        if (findUser == null) throw new Exception($"User LiskaLisovsky not found");
        await rolemanager.CreateAsync(new IdentityRole<long>(RoleConsts.Administrator));
        await rolemanager.CreateAsync(new IdentityRole<long>(RoleConsts.Moderator));
        await rolemanager.CreateAsync(new IdentityRole<long>(RoleConsts.Member));
        await usermanager.AddToRolesAsync(findUser, Roles);

        
    }
}