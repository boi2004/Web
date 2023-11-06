using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class RingController : Controller
    {
        public DPSportStoreEntities db = new DPSportStoreEntities();
        //View để thêm sản phẩm 
        public ActionResult AddRing ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Controler để thêm sản phẩm
        public ActionResult AddRing(Ring ring, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    // Lưu hình ảnh mới nếu được tải lên
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string filePath = "~/Content/Img/" + fileName;
                    string serverPath = Server.MapPath(filePath);
                    imageFile.SaveAs(serverPath);
                    ring.ImagePro = filePath;
                }

                // Thêm sản phẩm mới vào cơ sở dữ liệu
                db.Rings.Add(ring);
                db.SaveChanges();
                return RedirectToAction("SeeRing"); // Chuyển hướng đến trang danh sách sản phẩm
            }

            return View(ring); // Trở lại trang chỉnh sửa nếu ModelState không hợp lệ
        }
        //View để xem sản phẩm
        public ActionResult SeeRing()
        {
            var rings = db.Rings.ToList();
            return View(rings);
        }
        //View để Edit sản phẩm
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ring ring = db.Rings.Find(id);

            if (ring == null)
            {
                return HttpNotFound();
            }

            return View(ring);
        }
        // POST: Sửa sản phẩm Ring
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ring ring, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    // Lưu hình ảnh mới nếu được tải lên
                    string fileName = Path.GetFileName(imageFile.FileName);
                    string filePath = "~/Content/Img/" + fileName;
                    string serverPath = Server.MapPath(filePath);
                    imageFile.SaveAs(serverPath);
                    ring.ImagePro = filePath;
                }

                // Cập nhật thông tin sản phẩm và lưu vào cơ sở dữ liệu
                db.Entry(ring).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("SeeRing");
            }

            return View(ring);
        }
       //Xóa sản phẩm
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ring ring = db.Rings.Find(id);
            if (ring == null)
            {
                return HttpNotFound();
            }
            return View(ring);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Ring ring = db.Rings.Find(id);
            db.Rings.Remove(ring);
            db.SaveChanges();
            return RedirectToAction("SeeRing");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ring ring = db.Rings.Find(id);

            if (ring == null)
            {
                return HttpNotFound();
            }

            return View(ring);
        }
        //Danh sách sản phẩm người dùng
        public ActionResult Gocnhinnguoidung()
        {
            var rings = db.Rings.ToList();
            return View(rings);
        }

        // Giải phóng tài nguyên khi Controller hoàn thành
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //Lọc theo giá tiền:
        public ActionResult FilterByPrice(decimal? minPrice, decimal? maxPrice)
        {
            // Khởi tạo danh sách sản phẩm
            var products = db.Rings.ToList();

            // Lọc sản phẩm theo giá tiền
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice.Value).ToList();
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice.Value).ToList();
            }

            return View("Gocnhinnguoidung", products);
        }
        //Lọc theo giới tính:
        public ActionResult FilterByGender(string gender)
        {
            // Khởi tạo danh sách sản phẩm
            var products = db.Rings.ToList();

            // Lọc sản phẩm theo giới tính
            if (!string.IsNullOrEmpty(gender))
            {
                products = products.Where(p => p.Gender == gender).ToList();
            }

            return View("Gocnhinnguoidung", products);
        }

        //Lọc theo loại:
        public ActionResult FilterByCategory(string category)
        {
            // Khởi tạo danh sách sản phẩm
            var products = db.Rings.ToList();

            // Lọc sản phẩm theo loại
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.JewelryType == category).ToList();
            }

            return View("Gocnhinnguoidung", products);
        }


    }

}
