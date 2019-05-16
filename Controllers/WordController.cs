using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPAngular.Models;

namespace ASPAngular.Controllers
{
    public class WordController : Controller
    {
        private readonly WordContext db = null;
        public WordController()
        {
            db = new WordContext(); 
        }
        public JsonResult Index()
        {
            var words = db.Words.ToList();
            return Json(words, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Word word)
        {
            string NewWord = "";
            for (int i = 0; i < word.NewWord.Length; i++)
            {
                var idd = db.Symbols.Select(x => new { x.Id, x.OSymbol }).FirstOrDefault(x => x.OSymbol == word.NewWord.Substring(i, 1));
                var newidd = db.Symbols.Select(x => new { x.Id, x.NSymbol }).FirstOrDefault(x => x.Id == idd.Id);
                NewWord += newidd.NSymbol;
            }
            using (var db = new WordContext())
            {
                word.NewWord = NewWord;
                word.DateTime = DateTime.Now;
                db.Words.Add(word); 
                db.SaveChanges();
                db.Dispose();
            }
            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var word = db.Words.Find(id);
            db.Words.Remove(word);
            db.SaveChanges();
            return Json(null);
        }

        [HttpPost]
        public JsonResult Reverse(int id)
        {
            var word = db.Words.Find(id);
            string NewWord = "";
            for (int i = 0; i < word.NewWord.Length; i++)
            {
                var idd = db.Symbols.Select(x => new { x.Id, x.OSymbol }).FirstOrDefault(x => x.OSymbol == word.NewWord.Substring(i, 1));
                var newidd = db.Symbols.Select(x => new { x.Id, x.NSymbol }).FirstOrDefault(x => x.Id == idd.Id);
                NewWord += newidd.NSymbol;
            }
                word.NewWord = NewWord;
                db.SaveChanges();
            return Json(null);
        }
    }
}