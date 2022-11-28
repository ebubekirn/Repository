using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class GradeController : Controller
    {
        IUnit _uow;
        GradeModel _model;
        public GradeController(IUnit uow, GradeModel model)
        {
            _uow = uow;
            _model = model;
        }

        public IActionResult List()
        {
            var dlist = _uow._gradeRep.List();
            return View(dlist);
        }
        public IActionResult Create()
        {
            _model.Head = "Create";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.Grade = new Grade();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(GradeModel model)
        {
            _uow._gradeRep.Add(model.Grade);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Edit(string Id)
        {
            _model.Head = "Update";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-success";
            _model.Grade = _uow._gradeRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Edit(GradeModel model)
        {
            _uow._gradeRep.Update(model.Grade);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Delete(string Id)
        {
            _model.Head = "Delete";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            _model.Grade = _uow._gradeRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(GradeModel model)
        {
            _uow._gradeRep.Delete(model.Grade);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
