using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using Domain.Dtos.Product;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Product;
using Domain.Models;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        // private readonly IRepository<ProductEntity> _repository;
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProductDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var entityList = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(entityList);
        }

        public async Task<ProductCreateResult> Insert(ProductDtoCreate product)
        {
            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _repository.InsertAsync(entity);

             return _mapper.Map<ProductCreateResult>(result);
        }

        public async Task<ProductUpdatedResult> Update(ProductDtoUpdate product)
        {
            var model = _mapper.Map<ProductModel>(product);
            var entity = _mapper.Map<ProductEntity>(model);
            var result = await _repository.UpdateAsync(entity);

             return _mapper.Map<ProductUpdatedResult>(result);
        }

        public async Task<IEnumerable<ProductDto>> GetByName (string name)
        {
            var result = await _repository.GetByName(name); 
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<IEnumerable<ProductDto>>GetProductsOrderedByColumn(string column)
        {
            var columnName = ToTitleCase(column);
            if(typeof(ProductEntity).GetProperty(columnName) != null)
            {
                var result = await _repository.GetProductsOrderedByColumn(columnName); 
                return _mapper.Map<IEnumerable<ProductDto>>(result); 
            }
            else
                throw new InvalidFilterCriteriaException();
        }  
        private string ToTitleCase(string str)
        {
            var firstword = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.Split(' ')[0].ToLower());
            str = str.Replace(str.Split(' ')[0],firstword);
            return str;
        }
    }
}