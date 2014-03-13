using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        
        // позволит Ninject внедрять зависимость хранилища товаров при созда­нии экземпляра класса контроллера
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}
