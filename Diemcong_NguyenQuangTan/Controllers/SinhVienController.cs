using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diemcong_NguyenQuangTan.Models;
namespace Diemcong_NguyenQuangTan.Controllers
{
    public class SinhVienController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: SinhVien
        public ActionResult ListSinhVien()
        {
            var all_SinhVien = from ss in data.SinhViens select ss;
            return View(all_SinhVien);
        }
        public ActionResult Detail(String id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_MaSV = collection["MaSV"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_MaSV.ToString();
                s.HoTen = E_HoTen.ToString();
                s.GioiTinh = E_GioiTinh.ToString();
                s.NgaySinh = E_NgaySinh;
                s.Hinh = E_Hinh.ToString();
                s.MaNganh = E_MaNganh.ToString();

                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Create();
        }
        public ActionResult Edit(String id)
        {
            var E_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_SinhVien);
        }
        public ActionResult Edit(String id, FormCollection collection)
        {
            var E_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_SinhVien);
        }

    }
}