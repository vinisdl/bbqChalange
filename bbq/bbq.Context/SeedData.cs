using bbq.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bbq.Context
{
    public static class SeedData
    {
        public static void Run(BBQContext ctx)
        {
            ctx.Add(
             new User
             {
                 UserName = "admin",
                 Password = "1q2w3e4r",
                 SecretKey = "1qa2ws3ed4rf5tg6yh7uj8il"
             });

            ctx.Add(
                new User
                {
                    UserName = "alex",
                    Password = "2w3e4r5t",
                    SecretKey = "2ws3ed4rf5tg6yh7uj8ik9ol"
                });

            ctx.Add(
                new User
                {
                    UserName = "steve",
                    Password = "3e4r5t6y",
                    SecretKey = "3ed4rf5tg6yh7uj8ik9ol0pç"
                });

            ctx.Add(
                new User
                {
                    UserName = "alice",
                    Password = "4r5t6y7u",
                    SecretKey = "4rf5tg6yh7uj8ik9ol0pç1qa"
                });
            ctx.SaveChanges();

        }
    }
}
