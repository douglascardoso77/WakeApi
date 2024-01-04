
using System.Data.Common;
using System.Net;
using System.Text;
using Domain.Dtos.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;


namespace Tests.IntegrationTest
{
    public class Product : BaseIntegration
    {
        private readonly Guid _id;
        public Product()
        {
            _id = Guid.NewGuid();
        }
        [Fact]
        public async Task CreateProduct()
        {
            var productDto = new ProductDto()
            {
                Id = _id,
                 Name = Faker.NameFaker.FirstName(),
                 Price = Faker.NumberFaker.Number(),
                 Stock = Faker.NumberFaker.Number()
            };

            var response = await PostAsync(productDto, $"{hostApi}product", client);

            var postResult = await response.Content.ReadAsStringAsync();
            var rowPost = JsonConvert.DeserializeObject<ProductCreateResult>(postResult);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetAll()
        {
            var response = await client.GetAsync($"{hostApi}product");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult);
            Assert.NotNull(result);
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public async Task UpdateProduct()
        {
            var productUpdate = new ProductDtoUpdate()
            {
                 Id = _id,
                 Name = Faker.NameFaker.MaleName(),
                 Price = Faker.NumberFaker.Number(),
                 Stock = Faker.NumberFaker.Number()
            };

            var stringJson = new StringContent(JsonConvert.SerializeObject(productUpdate), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{hostApi}product", stringJson);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProductUpdatedResult>(jsonResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById()
        {
            var response = await client.GetAsync($"{hostApi}product/{_id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProductDto>(jsonResult);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteProduct()
        {
            var response = await client.DeleteAsync($"{hostApi}product/{_id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task GetOrderedByCSolumn()
        {
            var response = await client.GetAsync($"{hostApi}product/orderedbycolumn/name");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult);
            Assert.NotNull(result);
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public async Task GetByName()
        {
            var response = await client.GetAsync($"{hostApi}product/findby/camiseta");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}