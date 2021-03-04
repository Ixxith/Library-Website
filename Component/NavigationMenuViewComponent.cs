using Library_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Component
{
    // This view component is used for navigation menu purposes for book categories. Uses the book repository and passes each distinct book category as a string enumerable
    public class NavigationMenuViewComponent : ViewComponent
    {

        private IBookRepository repository;

        public NavigationMenuViewComponent (IBookRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.books.Select(b => b.Category).Distinct().OrderBy(b => b));
        }
    }
}
