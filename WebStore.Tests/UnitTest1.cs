namespace WebStore.Tests
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using WebStore.Contructs;
    using WebStore.Domain.Entities;
    using WebStore.WebUI.Controllers;
    using WebStore.WebUI.HtmlHelpers;
    using WebStore.WebUI.Models;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanGeneratePageLinks()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;

            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
                                        {
                                            CurrentPage = 2,
                                            TotalItems = 28,
                                            ItemsPerPage = 10
                                        };

            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
        [TestMethod]
        public void CanPaginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                    {
                        new Product { ProductId = Guid.NewGuid(), Name = "P1" },
                        new Product { ProductId = Guid.NewGuid(), Name = "P2" },
                        new Product { ProductId = Guid.NewGuid(), Name = "P3" },
                        new Product { ProductId = Guid.NewGuid(), Name = "P4" },
                        new Product { ProductId = Guid.NewGuid(), Name = "P5" }
                                                                  });

            // create a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object) { pageSize = 3 };

            // Act
            ProductsListViewModel result
                = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}