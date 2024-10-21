using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")] // përcakton se ky kontrollues i përket zonës Admin.
    [Authorize(Roles = SD.Role_Admin)]    //specifikon që vetëm përdoruesit me rolin Admin (përcaktuar në SD.Role_Admin) mund të
                                          //aksesojnë veprimet në këtë kontrollue
    public class CategoryController : Controller   //Klase
    {
        private readonly IUnitOfWork _unitOfWork;  //të aksesuar metodat e repositorive përkatëse.
       //perdoret me menaxhu relacione t'databazes
        
        public CategoryController(IUnitOfWork unitOfWork)
        {//Konstruktor qe merr nje parameter "IUnitOfWork" dhe e cakton ne variablen private "_unitOfwork"
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() //deklarimi i metodes "Index"
        {//"IActionResult" eshte tip i kthimit te metodes, nenkupton qe do te kthej nje rezultat veprimi.
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList(); //thirrja e metodes
            //tip i variables                 //merr te gjith kategorin nga databaza  
            //"objCategoryList" emri i variables qe run listen e kategorive    //"ToList" metod qe e konverton rezultatin ne nje list

            return View(objCategoryList);

        }

        public IActionResult Create()//metod
        {     //tip i kthimit te metodes
            return View();//kthen pamje
        }
        
        [HttpPost]// atribut qe sherben per shenime tdhenave ne databaz
       
        public IActionResult Create(Category obj) //Ky objekt obj përfaqëson të dhënat e kategorisë që përdoruesi ka futur në formë.
        {                           //objekt "Category" si parameter
            
            
            if (obj.Name == obj.DisplayOrder.ToString())//Ky është renditja e shfaqjes e konvertuar në string.
            { //Ky rresht kontrollon nëse emri i kategorisë është i njëjtë me renditjen e shfaqjes të konvertuar në string.

                //"name" -> emri i fushës së modelit që ka gabim.
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }// nese ky kusht o i vertet del qeky mesazh 

            
            
            
            
            if (ModelState.IsValid)//kontrollon nëse modeli është i vlefshëm
            { // pra nese osht e kthen "true"
                _unitOfWork.Category.Add(obj);//shton kategorinë në repozitori.
                _unitOfWork.Save();//ruan ndryshimet në databaz
                TempData["success"] = "Category Created Succesfully";
                return RedirectToAction("Index");
            }//kthen pamjen Create nëse modeli nuk është i vlefshëm.
            return View();
        }

        public IActionResult Edit(int? id)
        {//është metoda për të marrë një kategori për redaktim.
            if (id == null || id == 0)
            {//kontrollon nëse ID-ja është null ose 0 dhe kthen NotFound() nëse është.
                return NotFound();
            }//variabel e tipit Category
            Category categoryfromDb = _unitOfWork.Category.Get(u => u.Id == id);
            //merr kategorinë nga baza e të dhënave.
            if (categoryfromDb == null)
            {//kontrollon nëse kategoria është gjetur dhe kthen NotFound() nëse nuk është.
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)// kontrollon nëse modeli është i vlefshëm.
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Succesfully";
            return RedirectToAction("Index");
        }

    }
}
