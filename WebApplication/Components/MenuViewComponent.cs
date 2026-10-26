using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain;
using WebApplication.Infrastructure;

namespace WebApplication.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;
        public MenuViewComponent(DataManager dataManager) { _dataManager = dataManager; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var places = await _dataManager.ShawarmaPlaces.GetShawarmaPlacesAsync();
            var dto = DtoHelper.ShawarmasToDto(places);
            return await Task.FromResult<IViewComponentResult>(View("Default", dto));
        }
    }
}