using System.Net;
using Application.Controllers;
using Castle.Core.Logging;
using Domain.Dtos.Product;
using Domain.Interfaces.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Test.ServiceTest.Mockers;

namespace Tests.ApplicationTest
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductService> _productServiceMock;
        private ProductController _productController;
        private readonly ProductMocker _productMocker;

        public ProductControllerTest()
        {
            _productServiceMock = new Mock<IProductService>();
            _productMocker = new ProductMocker();
        }

        [Fact(DisplayName = "success to post new product")]
        public async Task SuccessToPost()
        {
            _productServiceMock.Setup(s=>s.Insert(It.IsAny<ProductDtoCreate>())).ReturnsAsync(_productMocker.ProductDtoCreateResultMock);

            _productController = new ProductController(_productServiceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(u=>u.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("https://localhost:7123");
            _productController.Url = url.Object;

            var result = await _productController.Post(_productMocker.ProductDtoCreateMock);
            Assert.True(result is CreatedResult);
        }

        [Fact(DisplayName = "Badrequest to post new product")]
        public async Task BadRequestToPost()
        {
            _productServiceMock.Setup(s=>s.Insert(It.IsAny<ProductDtoCreate>())).ReturnsAsync((ProductCreateResult)null);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.Post(_productMocker.ProductDtoCreateMock);
            Assert.True(result is BadRequestResult);
        }

        [Fact(DisplayName = "Badrequest when modelstate is invalid")]
        public async Task BadRequestWhenModelStateIsInvalid()
        {
            _productController = new ProductController(_productServiceMock.Object);
            _productController.ModelState.AddModelError("Name", "Nome é um campo obrigatório.");

            var result = await _productController.Post(_productMocker.ProductDtoCreateMock);
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "success to put  product")]
        public async Task SuccessToPut()
        {
            _productServiceMock.Setup(s=>s.Update(It.IsAny<ProductDtoUpdate>())).ReturnsAsync(_productMocker.ProductDtoUpdateResultMock);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.Put(_productMocker.ProductDtoUpdateMock);
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "Badrequest to put product")]
        public async Task BadRequestToPut()
        {
            _productServiceMock.Setup(s=>s.Update(It.IsAny<ProductDtoUpdate>())).ReturnsAsync((ProductUpdatedResult)null);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.Put(_productMocker.ProductDtoUpdateMock);
            Assert.True(result is BadRequestResult);
        }

        [Fact(DisplayName = "Badrequest when modelstate is invalid at put")]
        public async Task BadRequestWhenModelStateIsInvalidPut()
        {
            _productController = new ProductController(_productServiceMock.Object);
            _productController.ModelState.AddModelError("Name", "Nome é um campo obrigatório.");

            var result = await _productController.Put(_productMocker.ProductDtoUpdateMock);
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "success to delete product")]
        public async Task SuccessToDelete()
        {
            _productServiceMock.Setup(s=>s.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
        
         [Fact(DisplayName = "Badrequest when modelstate is invalid at delete")]
        public async Task BadRequestWhenModelStateIsInvalidDelete()
        {
            _productController = new ProductController(_productServiceMock.Object);
            _productController.ModelState.AddModelError("Name", "Nome é um campo obrigatório.");

            var result = await _productController.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "success to get product")]
        public async Task SuccessToGetProduct()
        {
            _productServiceMock.Setup(s=>s.Get(It.IsAny<Guid>())).ReturnsAsync(_productMocker.ProductDtoMock);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            Assert.NotNull(result);
        }
        
         [Fact(DisplayName = "Badrequest when modelstate is invalid at get")]
        public async Task BadRequestWhenModelStateIsInvalidGet()
        {
            _productController = new ProductController(_productServiceMock.Object);
            _productController.ModelState.AddModelError("Name", "Nome é um campo obrigatório.");

            var result = await _productController.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }


        [Fact(DisplayName = "success to getAll product")]
        public async Task SuccessToGetAllProduct()
        {
            _productServiceMock.Setup(s=>s.GetAll()).ReturnsAsync(_productMocker.ProductDtoListMock);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.GetAll();
            Assert.True(result is OkObjectResult);
            Assert.NotNull(result);
        }
        
         [Fact(DisplayName = "Badrequest when modelstate is invalid at getAll")]
        public async Task BadRequestWhenModelStateIsInvalidGetAll()
        {
            _productController = new ProductController(_productServiceMock.Object);
            _productController.ModelState.AddModelError("Name", "Nome é um campo obrigatório.");

            var result = await _productController.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "success to get product by name")]
        public async Task SuccessToGetProductByName()
        {
            _productServiceMock.Setup(s=>s.GetByName("air")).ReturnsAsync(_productMocker.ProductDtoListMock);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.GetByContainName("Air");
            Assert.True(result is OkObjectResult);
            Assert.NotNull(result);
        }
        
        [Fact(DisplayName = "Badrequest when modelstate is invalid at get product by name")]
        public async Task BadRequestWhenModelStateIsInvalidGetByName()
        {
            _productController = new ProductController(_productServiceMock.Object);
            _productController.ModelState.AddModelError("Name", "Nome é um campo obrigatório.");

            var result = await _productController.GetByContainName("air");
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "success to get product ordered")]
        public async Task SuccessToGetProductOrdered()
        {
            _productServiceMock.Setup(s=>s.GetProductsOrderedByColumn("name")).ReturnsAsync(_productMocker.ProductDtoListMock);

            _productController = new ProductController(_productServiceMock.Object);

            var result = await _productController.GetOrderedProductList("name");
            Assert.True(result is OkObjectResult);
            Assert.NotNull(result);
        }
        
        [Fact(DisplayName = "Badrequest when modelstate is invalid at get product ordered")]
        public async Task BadRequestWhenModelStateIsInvalidGetProductOrdered()
        {
            _productController = new ProductController(_productServiceMock.Object);
            _productController.ModelState.AddModelError("Name", "Nome é um campo obrigatório.");

            var result = await _productController.GetOrderedProductList("name");
            Assert.True(result is BadRequestObjectResult);
        }
    }
}