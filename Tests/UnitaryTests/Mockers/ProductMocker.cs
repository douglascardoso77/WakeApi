
using ComplexFaker;
using Domain.Dtos.Product;
using Domain.Entities;

namespace Test.ServiceTest.Mockers
{
    public class ProductMocker
    {
        public Guid Id { get; set; }
        public static string Name { get; set; }
        public static int Stock { get; set; }
        public static decimal Price  { get; set; }
        
        public ProductEntity ProductEntityMock { get; set; }
        public List<ProductEntity> ProductEntityListMock { get; set; }
        public List<ProductDto> ProductDtoListMock;
        public ProductDto ProductDtoMock;
        public ProductCreateResult ProductDtoCreateResultMock;
        public ProductUpdatedResult ProductDtoUpdateResultMock;
        public ProductDtoCreate  ProductDtoCreateMock;
        public ProductDtoUpdate  ProductDtoUpdateMock;

        public ProductMocker()
        {
            IFakeDataService faker = new FakeDataService();

            ProductDtoListMock = faker.GenerateComplex<List<ProductDto>>(10);
            ProductDtoMock = faker.GenerateComplex<ProductDto>();
            ProductDtoCreateResultMock = faker.GenerateComplex<ProductCreateResult>();
            ProductDtoUpdateResultMock = faker.GenerateComplex<ProductUpdatedResult>();
            ProductDtoUpdateMock = faker.GenerateComplex<ProductDtoUpdate>();
            ProductDtoCreateMock =  faker.GenerateComplex<ProductDtoCreate>();

            ProductEntityMock = faker.GenerateComplex<ProductEntity>();
            ProductEntityListMock = faker.GenerateComplex<List<ProductEntity>>(10);
        }
    }
}