using Microsoft.AspNetCore.Mvc;
using SigerengWeb.Data;
using SigerengWeb.Models;

namespace SigerengWeb.Controllers
{
    	
    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContextcs _db;
         public CatagoryController(ApplicationDbContextcs db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Catagory> listCatagory = _db.Catagories.ToList();

            return View(listCatagory);
        }
       
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // custom validation
                // Error will displayed in   <span asp-validation-for="Name" class="text-danger"></span>

                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }


            // ;
            //    TempData["success"] = "Category created successfully";
            //    return RedirectToAction("Index");
            //}
            if (ModelState.IsValid)
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Data updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Catagory? categoryFromDb = _db.Catagories.Find(id);

                //_unitOfWork.Category.Get(u => u.Id == id);
            //////Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //////Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Catagory obj)
        {
            //if (ModelState.IsValid)
            //{
            //    _unitOfWork.Category.Update(obj);
            //    //_unitOfWork.Save();
            //    //TempData["success"] = "Category updated successfully";

                if(ModelState.IsValid)
            {
                    _db.Catagories.Update(obj);
                    _db.SaveChanges();
                TempData["success"] = "Data updated successfully";
                return RedirectToAction("Index");
                }
                return View(obj);
           // }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Catagory? categoryFromDb = _db.Catagories.Find(id);

            //_unitOfWork.Category.Get(u => u.Id == id);
            //////Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //////Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        
        public IActionResult DeletePost(int id)
        {
            //if (ModelState.IsValid)
            //{
            //    _unitOfWork.Category.Update(obj);
            //    //_unitOfWork.Save();
            //    //TempData["success"] = "Category updated successfully";
            Catagory obj = _db.Catagories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            _db.Catagories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Data deleted successfully";
            return RedirectToAction("Index");
            
            return View(obj);
            // }
            return View();

        }
    }
}
