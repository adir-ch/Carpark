using Carpark.Engine.RateRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.ParkingRateRepository.Data
{
    public class DbContext
    {
        Dictionary<int, decimal> _db;

        private static readonly Lazy<DbContext> _instance = new Lazy<DbContext>(() => CreateAndSeedMemoryDB());

        private static DbContext CreateAndSeedMemoryDB()
        {
            var db = new DbContext();
            var seed = new DbDataSeed();
            seed.SeedDb(db);
            return db;
        }

        public static DbContext Instance
        {
            get { return _instance.Value; }
        }

        private DbContext()
        {
            _db = new Dictionary<int, decimal>();
        }

        public bool Create(int key, decimal entity)
        {
            _db.Add(key, entity);
            return true;
        }

        public bool CreateOrUpdate(int key, decimal entity)
        {
            if (Read(key) != null)
            {
                Update(key, entity);
            }
            else
            {
                Create(key, entity);
            }

            return true;
        }

        public decimal Read(int key)
        {
            decimal entity = (decimal)0;
            _db.TryGetValue(key, out entity);
            return entity;
        }

        public bool Update(int key, decimal entity)
        {
            _db[key] = entity;
            return true;
        }

        public bool Delete(int key)
        {
            return _db.Remove(key);
        }
    }
}
