using GenZBook.DataAccess;
using GenZBook.DataAccess.Repository.IRepository;
using GenZBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenZBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;
        public CategoryController(ICategoryRepository db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
                ModelState.AddModelError("Name", "Thứ tự không thể trùng với tên");
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDbFirst = _db.GetFirstOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
                return NotFound();
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
                ModelState.AddModelError("Name", "Thứ tự không thể trùng với tên");
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDbFirst = _db.GetFirstOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
                return NotFound();
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
                return NotFound();
            _db.Remove(obj);
            _db.Save();
            TempData["success"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index");    
        }
    }
}
