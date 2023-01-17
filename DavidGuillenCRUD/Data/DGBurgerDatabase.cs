using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidGuillenCRUD.Models;

namespace DavidGuillenCRUD.Data
{
    public class DGBurgerDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly DGAsyncLazy<DGBurgerDatabase> Instance =
            new DGAsyncLazy<DGBurgerDatabase>(async () =>
            {
                var instance = new DGBurgerDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<DGBurger>();
                }
                catch (Exception ex)
                {

                    throw;
                }
                return instance;
            });


        public DGBurgerDatabase()
        {
            Database = new SQLiteAsyncConnection(DGConstants.DatabasePath, DGConstants.Flags);
        }

        public Task<List<DGBurger>> DGGetItemsAsync()
        {
            return Database.Table<DGBurger>().ToListAsync();
        }

        public Task<List<DGBurger>> DGGetItemsNotDoneAsync()
        {
            return Database.QueryAsync<DGBurger>("SELECT * FROM [DGBurger] WHERE [DGWithExtraCheese] = 0");
        }

        public Task<DGBurger> DGGetItemAsync(int id)
        {
            return Database.Table<DGBurger>().Where(i => i.DGId == id).FirstOrDefaultAsync();
        }

        public Task<int> DGSaveItemAsync(DGBurger item)
        {
            if (item.DGId != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DGDeleteItemAsync(DGBurger item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
