using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastucture.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specification;
using API.Dtos;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IGenericRepository<ProductModel> _productrepo;   
        private readonly IGenericRepository<CampCity> _campcity;
        private readonly IProductRepository _prodrepo;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository prodrepo , IMapper mapper,IGenericRepository<ProductModel> productrepo , IGenericRepository<CampCity> campcity){
            _prodrepo = prodrepo;
            _productrepo = productrepo; 
            _campcity = campcity;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(){
            var productlist = await _prodrepo.GetAllProducts();
            var productListToReturn = _mapper.Map<IReadOnlyList<ProductModel> ,IReadOnlyList< ProductToReturnDto>>(productlist);    
            return  Ok(productListToReturn);
        }
        [HttpGet("getproductwithid/{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductWithId(int id){
            var product =  await _prodrepo.GetProductById(id);
            return _mapper.Map<ProductModel , ProductToReturnDto>(product);
            
            
        }

        [HttpGet("getcampcities")]
        public async Task<ActionResult<IReadOnlyList<CampCity>>>GetCampCity(){
            return Ok(await _campcity.ListAllAsync());
        }
    }
}