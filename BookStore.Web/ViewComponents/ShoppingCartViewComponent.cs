using System.Security.Claims;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.ViewComponents;

public class ShoppingCartViewComponent : ViewComponent
{
    private readonly IUnitOfWork _unitOfWork;
    public ShoppingCartViewComponent(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public async Task<IViewComponentResult> InvokeAsync() 
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null) {
            if (HttpContext.Session.GetInt32(SD.SessionCart) == null) {
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).Count());
            }
                
            return View(HttpContext.Session.GetInt32(SD.SessionCart) ?? 0);
        }
        else {
            HttpContext.Session.Clear();
            return View(0);
        }
    }
}