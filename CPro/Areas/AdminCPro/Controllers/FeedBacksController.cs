using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelCPro.EntityFrameWork;
using PagedList;
using PagedList.Mvc;

namespace CPro.Areas.AdminCPro.Controllers
{
    public class FeedBacksController : BaseController
    {
        private CProDbContext db = new CProDbContext();

        // GET: AdminCPro/FeedBacks
        public ActionResult Index( string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortName = string.IsNullOrEmpty(sortBy) ? "name desc" : "";
            ViewBag.SortAddress = string.IsNullOrEmpty(sortBy) ? "address desc" : "";

            var feedback = db.FeedBacks.AsQueryable();
            if (ModelState.IsValid)
            {
                if (search != null)
                {
                    if (searchBy == "Address")
                    {
                        feedback = feedback.Where(x => x.Address.Contains(search));
                    }
                    else if (searchBy == "Name")
                    {
                        feedback = feedback.Where(x => x.Name.Contains(search));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Không có bản ghi nào");
                    }
                }
            }

            switch (sortBy)
            {
                case "name desc":
                    feedback = feedback.OrderByDescending(x => x.Name);
                    break;
                case "address desc":
                    feedback = feedback.OrderByDescending(x => x.Address);
                    break;
                default:
                    feedback = feedback.OrderBy(x => x.Name);
                    break;
            }
            //else
            //{                
            //        return View(db.FeedBacks.ToList());              
            return View(feedback.ToPagedList(page ?? 1,3));
        }

        // GET: AdminCPro/FeedBacks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // GET: AdminCPro/FeedBacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCPro/FeedBacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Phone,Email,Address,Contents,CreatedDate,Status")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.FeedBacks.Add(feedBack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedBack);
        }

        // GET: AdminCPro/FeedBacks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: AdminCPro/FeedBacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Phone,Email,Address,Contents,CreatedDate,Status")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedBack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedBack);
        }

        // GET: AdminCPro/FeedBacks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: AdminCPro/FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FeedBack feedBack = db.FeedBacks.Find(id);
            db.FeedBacks.Remove(feedBack);
            db.SaveChanges();
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
    }
}
