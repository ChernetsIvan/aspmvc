using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using SportsStore.WebUI.HtmlHelpers;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            // - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m=> m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name="P1"},
                new Product {ProductID = 2, Name="P2"},
                new Product {ProductID = 3, Name="P3"},
                new Product {ProductID = 4, Name="P4"},
                new Product {ProductID = 5, Name="P5"} 
            }.AsQueryable());

            //create a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Action
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;
            
            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //Arrange - define an HTML helper - we need to do this
            //in order to apply the extension method
            HtmlHelper myHelper = null;

            //Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            //Arrange - set up the delegete using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Action
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //Организация
            //создаем имитированное хранилище
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name="P1"},
                new Product {ProductID = 2, Name="P2"},
                new Product {ProductID = 3, Name="P3"},
                new Product {ProductID = 4, Name="P4"},
                new Product {ProductID = 5, Name="P5"} 
            }.AsQueryable());

            //создаем контроллер и устанавливаем размер страницы = 3
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Действие
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            //Утверждение
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            //Организация - создание имитации хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m=>m.Products).Returns(new Product[]{
                new Product {ProductID = 1, Name="P1", Category = "Cat1"},
                new Product {ProductID = 2, Name="P2", Category = "Cat2"},
                new Product {ProductID = 3, Name="P3", Category = "Cat1"},
                new Product {ProductID = 4, Name="P4", Category = "Cat2"},
                new Product {ProductID = 5, Name="P5", Category = "Cat3"} 
            }.AsQueryable());

            //Организация - создание контроллера и установка 
            //размера страницы равным трем элементам
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Действие
            Product[] result =
                ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();

            //Утверждение
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == "Cat2");
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product {ProductID = 1, Name="P1", Category = "Apples"},
                new Product {ProductID = 2, Name="P2", Category = "Apples"},
                new Product {ProductID = 3, Name="P3", Category = "Plums"},
                new Product {ProductID = 4, Name="P4", Category = "Oranges"}
            }.AsQueryable());

            NavController target = new NavController(mock.Object);

            //Действие - получаем набор категорий
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m=>m.Products).Returns(new Product[]{
                new Product{ProductID = 1, Name = "P1", Category = "Apples"},
                new Product{ProductID = 4, Name = "P2", Category = "Oranges"}
            }.AsQueryable();
            NavController target = new NavController(mock.Object);
            string categoryToSelect = "Apples";

            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            Assert.AreEqual(categoryToSelect, result);

        }
    }
}
