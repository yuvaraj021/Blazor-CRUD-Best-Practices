using BlazorCRUD.Application.DTOs;
using BlazorCRUD.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUD.Components.Pages.Products
{
    public partial class ProductForm : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        private ProductDTO product = new ProductDTO();

        protected override async Task OnInitializedAsync()
        {
            var existingProduct = await ProductService.GetProductByIdAsync(Id);
            if (existingProduct != null)
            {

                product = Mapper.Map<ProductDTO>(existingProduct);
            }
        }

        private async Task HandleValidSubmit()
        {
            var productEntity = Mapper.Map<Product>(product);

            if (productEntity.Id == 0)
            {
                await ProductService.AddProductAsync(productEntity);
            }
            else
            {
                await ProductService.UpdateProductAsync(productEntity);
            }

            NavigationManager.NavigateTo("/products");
        }

        private void Cancel()
        {
            NavigationManager.NavigateTo("/products");
        }
    }
}
