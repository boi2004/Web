using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using PagedList;
using PagedList.Mvc;


namespace Demo.Controllers
{
    public class RingController : Controller
    {
        public DPSportStoreEntities db = new DPSportStoreEntities();
        //View để thêm sản phẩm 
        public ActionResult AddRing()
        {
            ViewBag.JewelryTypeList = db.Categories.Select(x => new SelectListItem()
            {
                Text = x.NameCate.ToString(),
                Value = x.IDCate.ToString()
            }).ToList();


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Controler để thêm sản phẩm
        public ActionResult AddRing(Ring ring, HttpPostedFileBase imageFile)
        {

            ViewBag.JewelryTypeList = db.Categories.Select(x => new SelectListItem()
            {
                Text = x.NameCate.ToString(),
                Value = x.IDCate.ToString()
            }).ToList();
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
        //Danh sách sản phẩm người dùng&& Phân trang
        //public ActionResult Gocnhinnguoidung(int? page)
        //{
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);

        //    var rings = db.Rings.ToList();
        //    IPagedList<Ring> pagedRings = rings.ToPagedList(pageNumber, pageSize);

        //    return View(pagedRings);
        //}


        // Giải phóng tài nguyên khi Controller hoàn thành
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // Lọc theo Nhẫn
        public ActionResult LocNhan()
        {
            // Lấy danh sách sản phẩm từ bảng Rings, bao gồm thông tin Category liên quan
            var danhSachLoc = db.Rings.Include(r => r.Category).Where(r => r.JewelryType == "1").ToList();

            // Chuyển kết quả lọc đến view "Gocnhinnguoidung" để hiển thị danh sách sản phẩm cho người dùng
            return View("Gocnhinnguoidung", danhSachLoc);
        }

        // Lọc theo Bông tai
        public ActionResult LocBongTai()
        {
            var danhSachLoc = db.Rings.Include(r => r.Category).Where(r => r.JewelryType == "2").ToList();
            return View("Gocnhinnguoidung", danhSachLoc);
        }

        // Lọc theo Dây cổ
        public ActionResult LocDayCo()
        {
            var danhSachLoc = db.Rings.Include(r => r.Category).Where(r => r.JewelryType == "3").ToList();
            return View("Gocnhinnguoidung", danhSachLoc);
        }

        // Lọc theo Vòng
        public ActionResult LocVong()
        {
            var danhSachLoc = db.Rings.Include(r => r.Category).Where(r => r.JewelryType == "4").ToList();
            return View("Gocnhinnguoidung", danhSachLoc);
        }

        // Lọc theo Đồng hồ
        public ActionResult LocDongHo()
        {
            var danhSachLoc = db.Rings.Include(r => r.Category).Where(r => r.JewelryType == "5").ToList();
            return View("Gocnhinnguoidung", danhSachLoc);
        }

        // Lọc theo Thương hiệu
        public ActionResult LocThuongHieu()
        {
            var danhSachLoc = db.Rings.Include(r => r.Category).Where(r => r.JewelryType == "6").ToList();
            return View("Gocnhinnguoidung", danhSachLoc);
        }

        // Lọc theo Quà tặng
        public ActionResult LocQuaTang()
        {
            var danhSachLoc = db.Rings.Include(r => r.Category).Where(r => r.JewelryType == "7").ToList();
            return View("Gocnhinnguoidung", danhSachLoc);
        }
        // Sắp xếp sản phẩm theo thứ tự tăng dần theo giá
        public ActionResult SortByPriceAsc()
        {
            var rings = db.Rings.OrderBy(r => r.Price).ToList();
            return View("Gocnhinnguoidung", rings);
        }

        // Sắp xếp sản phẩm theo thứ tự giảm dần theo giá
        public ActionResult SortByPriceDesc()
        {
            var rings = db.Rings.OrderByDescending(r => r.Price).ToList();
            return View("Gocnhinnguoidung", rings);
        }
        //Tìm kiếm theo keyword
        public ActionResult TimKiem(string keyword)
        {
            // Tìm kiếm các sản phẩm có ít nhất một thuộc tính chứa keyword
            var danhSachTimKiem = db.Rings.Where(r =>
                // Mỗi điều kiện tìm kiếm tương ứng với một thuộc tính của sản phẩm
                r.Brand.Contains(keyword) ||           // Tìm kiếm theo thương hiệu
                r.Material.Contains(keyword) ||        // Tìm kiếm theo chất liệu
                r.Category.NameCate.Contains(keyword) ||    // Tìm kiếm theo loại trang sức đối với bảng category
                r.Collection.Contains(keyword) ||      // Tìm kiếm theo bộ sưu tập
                r.GemType.Contains(keyword) ||         // Tìm kiếm theo loại đá quý
                r.Gender.Contains(keyword) ||           // Tìm kiếm theo giới tính
                r.MaterialColor.Contains(keyword) ||   // Tìm kiếm theo màu chất liệu
                (r.Price.HasValue && r.Price.ToString().Contains(keyword)) || // Tìm kiếm theo giá (nếu có)
                (r.GoldCarat.HasValue && r.GoldCarat.ToString().Contains(keyword)) // Tìm kiếm theo chỉ số carat (nếu có)
            ).ToList();

            return View("Gocnhinnguoidung", danhSachTimKiem);
        }


    }

}
