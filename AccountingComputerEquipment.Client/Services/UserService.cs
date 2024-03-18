using AccountingComputerEquipment.Client.Data;
using AccountingComputerEquipment.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingComputerEquipment.Client.Services
{
    public class UserService
    {
        public async Task<User?> UserVerification(string email, string password)
        {
            using (ApplicationDbContext context = new())
            {
                var item = await context.Users
                    .FirstOrDefaultAsync(x => x.Email!.Equals(email) && x.Password!.Equals(password));

                if (item is null) return null;

                return item!;
            }
        }
    }
}
