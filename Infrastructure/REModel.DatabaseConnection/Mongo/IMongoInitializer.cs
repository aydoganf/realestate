using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REModel.DatabaseConnection.Mongo
{
    public interface IMongoInitializer
    {
        Task InitializeAsync();

        void Initialize();
    }
}
