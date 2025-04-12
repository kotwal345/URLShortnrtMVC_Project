using System.Collections.Generic;

namespace URLShortnerMVC_Project.Models
{
    public static class FakeUserStore
    {
        public static List<UserModel> Users = new List<UserModel>
        {
            new UserModel { Username = "admin", Password = "password" }
        };
    }
}
