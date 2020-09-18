using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REModel.DatabaseConnection.Mongo
{
    public interface IDatabaseSeeder
    {
        void Seed();

        Task SeedAsync();
    }
}
