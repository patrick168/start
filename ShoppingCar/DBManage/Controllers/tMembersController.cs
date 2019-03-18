using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBManage.Models;

namespace DBManage.Controllers
{
    public class tMembersController : Controller
    {
        private DBManageContext db = new DBManageContext();

        // GET: tMembers
        public ActionResult Index()
        {
            return View(db.tMembers.ToList());
        }

        // GET: tMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tMember tMember = db.tMembers.Find(id);
            if (tMember == null)
            {
                return HttpNotFound();
            }
            return View(tMember);
        }

        // GET: tMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tMembers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fUserId,fPwd,fName,fEmail,fAddress,fPhone")] tMember tMember)
        {
            if (ModelState.IsValid)
            {
                db.tMembers.Add(tMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tMember);
        }

        // GET: tMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tMember tMember = db.tMembers.Find(id);
            if (tMember == null)
            {
                return HttpNotFound();
            }
            return View(tMember);
        }

        // POST: tMembers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fUserId,fPwd,fName,fEmail,fAddress,fPhone")] tMember tMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tMember);
        }

        // GET: tMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tMember tMember = db.tMembers.Find(id);
            if (tMember == null)
            {
                return HttpNotFound();
            }
            return View(tMember);
        }

        // POST: tMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tMember tMember = db.tMembers.Find(id);
            db.tMembers.Remove(tMember);
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
