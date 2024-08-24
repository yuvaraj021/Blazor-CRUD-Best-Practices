using BlazorCRUD.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorCRUD.Components.Pages.Products
{
    public partial class Products : ComponentBase
    {
        private IEnumerable<Product> products;

        protected override async Task OnInitializedAsync()
        {
            products = await ProductRepository.GetAllAsync();
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
            await ProductRepository.DeleteAsync(id);
            products = await ProductRepository.GetAllAsync();
        }
    }
}
