﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApplication.DataAccess;
using WebApplication.DataAccess.Repository.IRepository;
using WebApplication.Models;

namespace WebApplication1.Areas.Customer.Controllers;
[Area("Customer")]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;


    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productsList = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");
        return View(productsList);
    }
    public IActionResult Details(int productId)
    {
        ShoppingCart cartObj = new()
        {
            Count = 1,
            ProductId = productId,
            Product = _unitOfWork.Product.GetFistOrDefault(u => u.Id == productId, includeProperties: "Category,CoverType")
        };
        return View(cartObj);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Details(ShoppingCart shoppingCart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        shoppingCart.ApplicationUserId = claim.Value;
        ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFistOrDefault(u =>
            u.ApplicationUserId == claim.Value && u.ProductId == shoppingCart.ProductId);
        if (cartFromDb == null)
        {
            _unitOfWork.ShoppingCart.Add(shoppingCart);
        }
        else
        {
            _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
        }
        
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
