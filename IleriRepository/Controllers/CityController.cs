using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class CityController : Controller
    {
        IUnit _uow;
        CityModel _model;
        public CityController(IUnit uow, CityModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uow._cityRep.List();
            return View(clist);
        }

        public IActionResult Create()
        {
            _model.Head = "Create";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.City = new City();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(CityModel model)
        {
            _uow._cityRep.Add(model.City);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            _model.Head = "Update";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-success";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(CityModel model)
        {
            _uow._cityRep.Update(model.City);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Delete";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(CityModel model)
        {
            _uow._cityRep.Delete(model.City);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
