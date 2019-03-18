using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prjShoppingCar.Models;


namespace prjShoppingCar.Controllers
{
    public class ManagementController : Controller
    {
        dbShoppingCarEntities db = new dbShoppingCarEntities();
        // GET: Home
        public ActionResult Index()
        {
            //var products = db.tProduct.ToList();
            //return View(products); 
            //取得所有產品放入products
            var products = db.tProduct.ToList();
            //若Session["Member"]為空，表示會員未登入
            //if (Session["Member"] == null)
            //{
            //    //指定Index.cshtml套用_Layout.cshtml，View使用products模型
            //    return View("Index", "_Layout", products);
            //}
            ////會員登入狀態
            ////指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            //return View("Index", "_LayoutManger", products);

            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("..//Home//Index", "_Layout", products);
            }
            else 
            {
                string fUserId = (Session["Member"] as tMember).fUserId;
                if (fUserId == "admin")
                {
                    return View("..//Management//Index", "_LayoutManager", products);
                }              
            }

            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            //Role=0  user
            //Role=1  admin
            //others role to be continue
            //if (Session["Role"].ToString() == "0")  
            //{ 
            //return View("Index", "_LayoutMember", products);
            //}

            return View("Index", "_LayoutMember", products);
        }

        public ActionResult Delete(int fId)
        {
            //依網址傳來的fId編號取得要刪除的產品記錄
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            string fileName = product.fImg;  //取得要刪除產品的圖檔
            if (fileName != "")
            {
                //刪除指定圖檔
                System.IO.File.Delete(Server.MapPath("~/Images") + "/" + fileName);
            }
            db.tProduct.Remove(product);
            db.SaveChanges();  //依編號刪除產品記錄
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string fPId, string fName, int? fPrice, HttpPostedFileBase fImg)
        {
            try
            {
                //上傳圖檔
                string fileName = "";
                //檔案上傳
                if (fImg != null)
                {
                    if (fImg.ContentLength > 0)
                    {
                        //取得圖檔名稱
                        fileName =
                           System.IO.Path.GetFileName(fImg.FileName);
                        var path = System.IO.Path.Combine(Server.MapPath("~/Images"), fileName);
                        fImg.SaveAs(path); //檔案儲存到Images資料夾下
                    }
                }
                //新增記錄
                tProduct product = new tProduct();
                product.fPId = fPId;
                product.fName = fName;
                product.fPrice = fPrice;
                product.fImg = fileName;
                db.tProduct.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index"); //導向Index的Action方法
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }


        public ActionResult Edit(int fId)
        {
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int fId, string fName, int? fPrice, HttpPostedFileBase fImg, string oldImg)
        {
            string fileName = "";
            //檔案上傳
            if (fImg != null)
            {
                if (fImg.ContentLength > 0)
                {
                    //取得圖檔名稱
                    fileName = System.IO.Path.GetFileName(fImg.FileName);
                    var path = System.IO.Path.Combine(Server.MapPath("~/Images"), fileName);
                    fImg.SaveAs(path);
                }
            }
            else
            {
                fileName = oldImg; //若無上傳圖檔，則指定hidden隱藏欄位的資料
            }
            // 修改資料
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = fileName;
            db.SaveChanges();
            return RedirectToAction("Index"); //導向Index的Action方法
        }

        public ActionResult AutoPage()
        {
            return View("AutoPage");
        }
    }
}