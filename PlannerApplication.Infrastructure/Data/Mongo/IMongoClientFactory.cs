using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Infrastructure.Data.Mongo
{
    public interface IMongoClientFactory
    {
        public async Task Create()
    }
}
