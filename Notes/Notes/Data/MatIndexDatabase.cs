using SQLite;

using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Notes.Models.MatIndex;

namespace Notes.Data
{
    public class MatIndexDatabase
    {
        readonly SQLiteAsyncConnection _database;
        private SQLiteConnection _data;

        public MatIndexDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Vara>().Wait();
            _data = new SQLiteConnection(dbPath);
            _data.CreateTable<Vara>();
        }

        public Task<List<Vara>> GetVaraAsync()
        {
            return _database.Table<Vara>().ToListAsync();
        }

        public Task<Vara> GetVaraAsync(int id)
        {
            return _database.Table<Vara>()
                            .Where(i => i.VaruID == id)
                            .FirstOrDefaultAsync();
        }

        public List<Vara> GetVaran(string text)
        {
            return _data.Table<Vara>()
                            .Where(i => i.Text.Contains(text))
                            .ToList();
        }

        public Task<int> SaveVaraAsync(Vara vara)
        {
            if (vara.VaruID != 0)
            {
                return _database.UpdateAsync(vara);
            }
            else
            {
                return _database.InsertAsync(vara);
            }
        }
        public Task<int> NewVaraAsync(Vara vara)
        {
                return _database.InsertAsync(vara);
        }

        public Task<int> DeleteVaraAsync(Vara vara)
        {
            return _database.DeleteAsync(vara);
        }
    }
}
