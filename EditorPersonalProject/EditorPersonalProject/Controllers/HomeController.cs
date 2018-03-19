using EditorPersonalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library;
using Library.Client.Repository;

namespace EditorPersonalProject.Controllers
{
    public class HomeController : Controller
    {
        DataRepository _DataRepository;
        public HomeController()
        {
            _DataRepository=new DataRepository();
        }
        public ActionResult Index(IndexViewModels input)
        {
            IndexViewModels result = new IndexViewModels();
            var Single = _DataRepository.GetSingle(0);
            var List = _DataRepository
                    .GetList(String.IsNullOrWhiteSpace(
                        input.SearchCondition)
                        ? ""
                        : input.SearchCondition);

            result.DefaultSingle =ModelToViewModels.PersonalInfoToViewModels(Single);
            result.List = List;

            return View(result);
        }

        
        public ActionResult _EditInfo(int id)
        {
            var Single = _DataRepository.GetSingle(id);
            return PartialView(ModelToViewModels.PersonalInfoToViewModels(Single));
        }

        public ActionResult InsertUpdate(PersonalViewModels input)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors =
                    ModelState.Values
                              .SelectMany(e => e.Errors);

                TempData["message"] = String.Join(" , ", allErrors.Select(e => e.ErrorMessage));


            }
            else
            {
                _DataRepository.InsertUpdate(ViewModelToModel.PersonalViewModelsToModel(input));
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _DataRepository.Delete(id);
            return null;
        }
    }
}