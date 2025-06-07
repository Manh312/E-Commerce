﻿using AutoMapper;
using server.Dto;
using server.Entities;
using server.Interface.Repository;
using server.Interface.Service;
using server.Interface.Services;
using Product = server.Entities.Product;

namespace server.Service
{
    public class CatalogService : ICatalogService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoriesRepository _productCategoriesRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public CatalogService(
            IProductRepository productRepository, 
            IProductCategoriesRepository productCategoriesRepository, 
            IBrandRepository brandRepository, 
            IImageService imageService,
            IMapper mapper
            )
        {
            this._productRepository = productRepository;
            this._productCategoriesRepository = productCategoriesRepository;
            this._brandRepository = brandRepository;
            this._imageService = imageService;
            this._mapper = mapper;
        }

        public async Task<Brand> CreateBrand(CreateBrandReq inData)
        {
            Image image = await this._imageService.SaveImageAsync(inData.Image);
            Brand brand = _mapper.Map<Brand>(inData);
            brand.Image = image;
            return await _brandRepository.AddAsync(brand);
        }

        public async Task<ProductCategories> CreateProductCategories(CreateProductCategoriesReq inData)
        {
            Image image = await this._imageService.SaveImageAsync(inData.Image);
            ProductCategories productCategories = _mapper.Map<ProductCategories>(inData);
            productCategories.Image = image;
            return await _productCategoriesRepository.AddAsync(productCategories);
        }

        public async Task<Entities.Product> CreateProduct(CreateProductReq inData)
        {
            ProductCategories? productCategories = await this._productCategoriesRepository.GetByIdAsync(inData.ProductCategoryId);
            Brand? brand = await this._brandRepository.GetByIdAsync(inData.BrandId);

            if (productCategories == null)
            {
                throw new Exception($"Invalid Product Categories Id {inData.ProductCategoryId}");
            }
            if (brand == null)
            {
                throw new Exception($"Invalid Brand Id {inData.BrandId}");
            }

            Image image = await this._imageService.SaveImageAsync(inData.Thumbnail);

            Product newProduct = _mapper.Map<Product>(inData);

            newProduct.ProductCategories = productCategories;
            newProduct.Brand = brand;
            newProduct.Thumbnail = image;

            return await this._productRepository.AddAsync(newProduct);
        }

        public async Task DeleteBrand(int brandId)
        {
            Brand? brand = await this._brandRepository.GetByIdAsync(brandId);
            if (brand == null)
            {
                throw new Exception($"Invalid Brand Id {brandId}");
            }

            await _imageService.DeleteImageAsync(brand.ImageId);

            await _brandRepository.DeleteAsync(brand);
        }

        public async Task DeleteProductCategories(int productCategoriesId)
        {
            ProductCategories? productCategories = await _productCategoriesRepository.GetByIdAsync(productCategoriesId);
            if (productCategories == null)
            {
                throw new Exception($"Invalid Product Categories Id {productCategoriesId}");
            }

            await _imageService.DeleteImageAsync(productCategories.ImageId);

            await _productCategoriesRepository.DeleteAsync(productCategories);
        }

        public async Task DeleteProduct(int productId)
        {
            Product? product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception($"Invalid Product Id {productId}");
            }

            await _imageService.DeleteImageAsync(product.ThumbnailId);
            await _productRepository.DeleteAsync(product);
        }

        public Task<IEnumerable<Product>> GetAllBrand()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
