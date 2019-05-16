using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ASPAngular.Models
{
    public class WordContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DbSet<Symbol> Symbols { get; set; }
    }
    public class SymbolInitializer : DropCreateDatabaseIfModelChanges<WordContext>
    {
        protected override void Seed(WordContext db)
        {
            string s = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            for (int i = 0; i < s.Length; i++)
            {
                int var = s.Length - 1;
                db.Symbols.Add(new Symbol { OSymbol = s.Substring(i, 1), NSymbol = s.Substring(var - i, 1) });

            }
            base.Seed(db);
        }
    }
}