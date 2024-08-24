using BlazorCRUD.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUD.Components.Pages.Products
{
    public partial class Products : ComponentBase
    {
        private IEnumerable<Product> products;

        protected override async Task OnInitializedAsync()
        {
            products = await ProductService.GetAllProductsAsync();
        }

        private void CreateNew()
        {
            NavigationManager.NavigateTo("/product/0");
        }

        private void EditProduct(int id)
        {
            NavigationManager.NavigateTo($"/product/{id}");
        }

        private async Task DeleteProduct(int id)
        {
            await ProductService.DeleteProductAsync(id);
            products = await ProductService.GetAllProductsAsync();
        }
    }
}
