using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class CustomersController : Controller
    {
        private DPSportStoreEntities database = new DPSportStoreEntities();

        // GET: Customers
        public ActionResult Index()
        {
            // Lấy danh sách khách hàng từ cơ sở dữ liệu và trả về view
            var customers = database.Customers.ToList();
            return View(customers);
        }

        // GET: Customers/Create
        [HttpGet]
        public ActionResult Create()
        {
            // Hiển thị form để tạo mới khách hàng
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Thêm khách hàng mới vào cơ sở dữ liệu và chuyển hướng đến trang danh sách
                    database.Customers.Add(customer);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, hiển thị thông báo lỗi
                    ModelState.AddModelError("", "Lỗi tạo mới khách hàng: " + ex.Message);
                }
            }

            // Trả về view tạo mới khách hàng với thông tin và thông báo lỗi (nếu có)
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customer = database.Customers.FirstOrDefault(c => c.IDCus == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            // Hiển thị thông tin chi tiết về khách hàng
            return View(customer);
        }

        // GET: Customers/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = database.Customers.FirstOrDefault(c => c.IDCus == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            // Hiển thị form chỉnh sửa khách hàng
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Cập nhật thông tin khách hàng và chuyển hướng đến trang danh sách
                    database.Entry(customer).State = EntityState.Modified;
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, hiển thị thông báo lỗi
                    ModelState.AddModelError("", "Lỗi chỉnh sửa khách hàng: " + ex.Message);
                }
            }

            // Trả về view chỉnh sửa khách hàng với thông tin và thông báo lỗi (nếu có)
            return View(customer);
        }

        // GET: Customers/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = database.Customers.FirstOrDefault(c => c.IDCus == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            // Hiển thị thông tin khách hàng để xác nhận xóa
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Xóa khách hàng khỏi cơ sở dữ liệu và chuyển hướng đến trang danh sách
                var customer = database.Customers.FirstOrDefault(c => c.IDCus == id);
                database.Customers.Remove(customer);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, hiển thị thông báo lỗi
                ModelState.AddModelError("", "Không xóa được do có liên quan đến bảng khác: " + ex.Message);
                var deletedCustomer = new Customer { IDCus = id };
                return View(deletedCustomer);
            }
        }
    }
}
