using Core.Entities;

namespace Core.Specifications
{
    // This is going to be calles by the ProductsController to get the "spec"
    // Here we are just passing the values to be used in the Queries in GenericRepository.cs
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        // Remember that x is checking what is already in the database through Entity Framework.
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x =>
            // Here we are passing Product properties to the BaseSpecification class
            // || means or/else We are cheking 1st if it has a value.
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            // 1st parameter is going to be our Skip and 2nd the Take.
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
                productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}