
using AutoMapper;
using Domain.Dtos.Product;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Product;
using Domain.Models;
using Moq;
using Service.Services;
using Test.ServiceTest.Mockers;
using Tests;

namespace Test.ServiceTest
{
    public class ProducctServiceTest : BaseTestService
    {
        private readonly ProductMocker _productMocker;
        private  IProductService _service;
        private  Mock<IProductRepository> _productRepositoryMock;

        public ProducctServiceTest()
        {
            _productMocker = new ProductMocker();
            _productRepositoryMock = new Mock<IProductRepository>();
            _service = new ProductService(_productRepositoryMock.Object, this.Mapper);
        }

        [Fact(DisplayName = "Success to get product")]
        public async Task WhenSuccessToGetProduct()
        {
            _productRepositoryMock.Setup(p=>p.SelectAsync(It.IsAny<Guid>())).ReturnsAsync(_productMocker.ProductEntityMock);
            
            var result = await _service.Get(_productMocker.ProductEntityMock.Id);
            
            Assert.NotNull(result);
            Assert.True(result.Id == _productMocker.ProductEntityMock.Id);
        }

        [Fact(DisplayName = "Error to get product")]
        public async Task WhenErrorToGetProduct()
        {
            _productRepositoryMock.Setup(p=>p.SelectAsync(It.IsAny<Guid>())).Throws(new Exception("It broke"));

            Exception exception = await Assert.ThrowsAsync<Exception>(async () => await _service.Get(_productMocker.ProductEntityMock.Id));
            Assert.Equal("It broke", exception.Message);
        }

        [Fact(DisplayName = "Success to get all products")]
        public async Task WhenSuccessToGetAllProducts()
        {
            _productRepositoryMock.Setup(p=>p.SelectAllAsync()).ReturnsAsync(_productMocker.ProductEntityListMock);
            
            var result = await _service.GetAll();
            
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
        }

        [Fact(DisplayName = "Error to getAll products")]
        public async Task WhenErrorToGetAllProducts()
        {
            _productRepositoryMock.Setup(p=>p.SelectAllAsync()).Throws(new Exception("It broke"));

            Exception exception = await Assert.ThrowsAsync<Exception>(async () => await _service.GetAll());
            Assert.Equal("It broke", exception.Message);
        }

        [Fact(DisplayName = "Success to create product")]
        public async Task WhenSuccessToCreateProduct()
        {
            _productRepositoryMock.Setup(p=>p.InsertAsync(It.IsAny<ProductEntity>())).ReturnsAsync(_productMocker.ProductEntityMock);

            var model = Mapper.Map<ProductModel>(_productMocker.ProductEntityMock);
            
            var result = await _service.Insert(Mapper.Map<ProductDtoCreate>(model));
            
            Assert.NotNull(result);
            Assert.True(result.Name == _productMocker.ProductEntityMock.Name);
            Assert.True(result.Id == _productMocker.ProductEntityMock.Id);
        }

        [Fact(DisplayName = "Error to create product")]
        public async Task WhenErrorToCreateProduct()
        {
            _productRepositoryMock.Setup(p=>p.InsertAsync(It.IsAny<ProductEntity>())).Throws(new Exception("It broke"));
            var model = Mapper.Map<ProductModel>(_productMocker.ProductEntityMock);

            Exception exception = await Assert.ThrowsAsync<Exception>(async () => await _service.Insert(Mapper.Map<ProductDtoCreate>(model)));
            Assert.Equal("It broke", exception.Message);
        }

        [Fact(DisplayName = "Success to update product")]
        public async Task WhenSuccessToUpdateProduct()
        {
            _productRepositoryMock.Setup(p=>p.UpdateAsync(It.IsAny<ProductEntity>())).ReturnsAsync(_productMocker.ProductEntityMock);

            var model = Mapper.Map<ProductModel>(_productMocker.ProductEntityMock);
            
            var result = await _service.Update(Mapper.Map<ProductDtoUpdate>(model));
            
            Assert.NotNull(result);
            Assert.True(result.Name == _productMocker.ProductEntityMock.Name);
            Assert.True(result.Id == _productMocker.ProductEntityMock.Id);
        }

        [Fact(DisplayName = "Error to update product")]
        public async Task WhenErrorToUpdateProduct()
        {
            _productRepositoryMock.Setup(p=>p.UpdateAsync(It.IsAny<ProductEntity>())).Throws(new Exception("It broke"));
            var model = Mapper.Map<ProductModel>(_productMocker.ProductEntityMock);

            Exception exception = await Assert.ThrowsAsync<Exception>(async () => await _service.Update(Mapper.Map<ProductDtoUpdate>(model)));
            Assert.Equal("It broke", exception.Message);
        }

         [Fact(DisplayName = "Success to delete product")]
        public async Task WhenSuccessToDeleteProduct()
        {
            _productRepositoryMock.Setup(p=>p.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var model = Mapper.Map<ProductModel>(_productMocker.ProductEntityMock);
            
            var result = await _service.Delete(Guid.NewGuid());
            
            Assert.True(result);
        }

        [Fact(DisplayName = "Error to delete product")]
        public async Task WhenErrorToDeleteProduct()
        {
            _productRepositoryMock.Setup(p=>p.DeleteAsync(It.IsAny<Guid>())).Throws(new Exception("It broke"));
            var model = Mapper.Map<ProductModel>(_productMocker.ProductEntityMock);

            Exception exception = await Assert.ThrowsAsync<Exception>(async () => await _service.Delete(Guid.NewGuid()));
            Assert.Equal("It broke", exception.Message);
        }

    }
}