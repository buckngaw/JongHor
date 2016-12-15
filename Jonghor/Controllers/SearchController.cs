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
using Jonghor.ViewModel;

namespace Jonghor.Controllers
{
    public class SearchController : Controller
    {
        private JongHorDBEntities1 db = new JongHorDBEntities1();


       

        ////// GET: Serach
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
        public ActionResult ViewSearch(string dname , string Dormoption)
        {
            DormLayer DormDB = new DormLayer();
            List<Dorm> DormList = DormDB.GetDorm();
            List<Dorm> DormSearch = new List<Dorm>();

            foreach (Dorm dorm in DormList)
            {
                if (dorm.Name.Contains(dname))
                {

                    DormSearch.Add(dorm);
               

                }
            }

            List<DormDetailViewModel> Dormviewmodel = new List<DormDetailViewModel>();

            foreach (Dorm dorm in DormSearch)
            {
                DormDetailViewModel dormview = new DormDetailViewModel();
                dormview.SetDorm(dorm.Dorm_ID);
                Dormviewmodel.Add(dormview);
            }

            return View("Searchpage", Dormviewmodel);

        }


        // Search Page MuMu Dont Touch = - =--------------------------------------
        public ActionResult Index(string dname)
        {
            DormLayer DormDB = new DormLayer();
            List<Dorm> DormList = DormDB.GetDorm();
            List<DormDetailViewModel> Dormviewmodel = new List<DormDetailViewModel>();

            foreach(Dorm dorm in DormList)
            {
                DormDetailViewModel dormview = new DormDetailViewModel();
                dormview.SetDorm(dorm.Dorm_ID);
                Dormviewmodel.Add(dormview);
            }

            return View("Searchpage", Dormviewmodel);

        }

        public ActionResult Dormdetail(int dorm)
        {

            return View("Dormdetail");
        }

        //---------------------------------------------------------------------------



        /* public ActionResult ViewSearch1()
         {
             Room_TypeLayer RoomTypeDB = new Room_TypeLayer();
             List<Room_Type> Room_TypeList = RoomTypeDB.GetRoom_Type();

                 Array.Sort<List<Room_Type>>(Room_TypeList);
                 foreach (Room_Type room in Room_TypeList)
                 {
                     //if(room.Price)
                     /*int[] array = new int[] { 3, 1, 4, 5, 2 };
                     Array.Sort<int>(array,
                                     new Comparison<int>(
                                             (i1, i2) => i2.CompareTo(i1)
                                     ));



                 }           
             return View("Searchprice", Room_TypeList);
         }*/


    }
}
