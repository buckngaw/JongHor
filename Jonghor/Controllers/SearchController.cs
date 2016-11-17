using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jonghor.Models;

namespace Jonghor.Controllers
{
    public class SearchController : Controller
    {
        private JongHorDBEntities1 db = new JongHorDBEntities1();


        public ActionResult Index(string Dormname)
        {
            var dorm_name = from d in db.Dorm
                         select d;
            
            if (!String.IsNullOrEmpty(Dormname))
            {
                dorm_name = dorm_name.Where(s => s.Name.Contains(Dormname));
            }
            System.Diagnostics.Debug.WriteLine(Dormname);
            return Content(dorm_name.ToString());
        }

        //// GET: Serach
        //public async Task<ActionResult> Index()
        //{
        //    var dorm = db.Dorm.Include(d => d.Dorm_Label).Include(d => d.Person).Include(d => d.Dorm_Picture);
        //    return View(await dorm.ToListAsync());
        //}

        // GET: Serach/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorm dorm = await db.Dorm.FindAsync(id);
            if (dorm == null)
            {
                return HttpNotFound();
            }
            return View(dorm);
        }

        // GET: Serach/Create
        public ActionResult Create()
        {
            ViewBag.Dorm_ID = new SelectList(db.Dorm_Label, "Dorm_ID", "Label_text");
            ViewBag.M_username = new SelectList(db.Person, "Username", "Password");
            ViewBag.Dorm_ID = new SelectList(db.Dorm_Picture, "Dorm_ID", "URL_Picture");
            return View();
        }

        // POST: Serach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Dorm_ID,Name,M_username,Lat,Long,information,Line,Facebook,Instagram,Tel,Address,Deposit,W_minimum,W_Per_Unit,Internet,E_Minimum,E_Per_Unit")] Dorm dorm)
        {
            if (ModelState.IsValid)
            {
                db.Dorm.Add(dorm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Dorm_ID = new SelectList(db.Dorm_Label, "Dorm_ID", "Label_text", dorm.Dorm_ID);
            ViewBag.M_username = new SelectList(db.Person, "Username", "Password", dorm.M_username);
            ViewBag.Dorm_ID = new SelectList(db.Dorm_Picture, "Dorm_ID", "URL_Picture", dorm.Dorm_ID);
            return View(dorm);
        }

        // GET: Serach/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorm dorm = await db.Dorm.FindAsync(id);
            if (dorm == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dorm_ID = new SelectList(db.Dorm_Label, "Dorm_ID", "Label_text", dorm.Dorm_ID);
            ViewBag.M_username = new SelectList(db.Person, "Username", "Password", dorm.M_username);
            ViewBag.Dorm_ID = new SelectList(db.Dorm_Picture, "Dorm_ID", "URL_Picture", dorm.Dorm_ID);
            return View(dorm);
        }

        // POST: Serach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Dorm_ID,Name,M_username,Lat,Long,information,Line,Facebook,Instagram,Tel,Address,Deposit,W_minimum,W_Per_Unit,Internet,E_Minimum,E_Per_Unit")] Dorm dorm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dorm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Dorm_ID = new SelectList(db.Dorm_Label, "Dorm_ID", "Label_text", dorm.Dorm_ID);
            ViewBag.M_username = new SelectList(db.Person, "Username", "Password", dorm.M_username);
            ViewBag.Dorm_ID = new SelectList(db.Dorm_Picture, "Dorm_ID", "URL_Picture", dorm.Dorm_ID);
            return View(dorm);
        }

        // GET: Serach/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorm dorm = await db.Dorm.FindAsync(id);
            if (dorm == null)
            {
                return HttpNotFound();
            }
            return View(dorm);
        }

        // POST: Serach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dorm dorm = await db.Dorm.FindAsync(id);
            db.Dorm.Remove(dorm);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // Search Page MuMu Dont Touch = - =--------------------------------------
        public ActionResult ViewSearch()
        {
            DormLayer DormDB = new DormLayer();
            List<Dorm> DormList = DormDB.GetDorm();

            foreach (Dorm dorm in DormList)
            {


            }
          
            return View("Searchpage", DormList);
        }
        //---------------------------------------------------------------------------
    }
}
