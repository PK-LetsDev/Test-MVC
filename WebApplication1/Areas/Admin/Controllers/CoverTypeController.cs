using Microsoft.AspNetCore.Mvc;
using WebApplication.DataAccess;
using WebApplication.DataAccess.Repository.IRepository;
using WebApplication.Models;

namespace WebApplication1.Areas.Admin.Controllers;
[Area("Admin")]

public class CoverTypeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CoverTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverTypesList = _unitOfWork.CoverType.GetAll();
        return View(objCoverTypesList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType created successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFistOrDefault(u => u.Id == id);
        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {


            _unitOfWork.CoverType.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType update successfully";
            return RedirectToAction("Index");
        }

        return View(obj);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFistOrDefault(u => u.Id == id);
        
        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.CoverType.GetFistOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "CoverType delete successfully";
        return RedirectToAction("Index");

    }
}

