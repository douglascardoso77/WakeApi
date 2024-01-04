using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Dtos.Product;
using Domain.Entities;
using Domain.Interfaces.Services.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                return Ok(await _productService.GetAll());
            }
            catch (ArgumentException ex)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<IActionResult> Get(Guid id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                return Ok(await _productService.Get(id));
            }
            catch (ArgumentException ex)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductDtoCreate product)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _productService.Insert(product);

                if(result != null)
                    return Created(new Uri(Url.Link("GetWithId", new {id = result.Id})), result);
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ProductDtoUpdate product)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _productService.Update(product);

                if(result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                return Ok(await _productService.Delete(id));
            }
            catch (ArgumentException ex)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("findby/{name}")]
        public async Task<IActionResult> GetByContainName(string name)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _productService.GetByName(name));
            }
            catch (ArgumentException ex)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("orderedbycolumn/{column}")]
        public async Task<IActionResult> GetOrderedProductList(string column)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _productService.GetProductsOrderedByColumn(column));
            }
            catch (ArgumentException ex)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}