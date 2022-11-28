using IleriRepository.Data;
using IleriRepository.DTO;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class CountyController : Controller
    {
        IUnit _uow;
        CountyModel _model;
        public CountyController(IUnit uow, CountyModel model)
        {
            _uow = uow;
            _model = model;
        }

        public IActionResult List()
        {
            var plist = _uow._countyRep.Set().Select(x => new CountyDTO
            {
                Id = x.Id,
                CountyName = x.CountyName,
                CityName = x.City.CityName
            }).ToList();
            return View(plist);
        }

        public IActionResult Create()
        {
            _model.Head = "Create";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.County = new County();
            _model.Cities = _uow._cityRep.Set().ToList();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(CountyModel model)
        {
            _uow._countyRep.Add(model.County);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            _model.Head = "Update";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-success";
            _model.County = _uow._countyRep.Find(Id);
            _model.Cities = _uow._cityRep.Set().ToList();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(CountyModel model)
        {
            _uow._countyRep.Update(model.County);
            _uow.Commit();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Delete";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            _model.County = _uow._countyRep.Find(Id);
            _model.Cities = _uow._cityRep.Set().ToList();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(CountyModel model)
        {
            _uow._countyRep.Delete(model.County);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
