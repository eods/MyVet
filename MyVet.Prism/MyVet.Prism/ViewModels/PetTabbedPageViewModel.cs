using MyVet.Common.Helpers;
using MyVet.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace MyVet.Prism.ViewModels
{
    public class PetTabbedPageViewModel : ViewModelBase
    {
        public PetTabbedPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            var Pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
            Title = $"Pet: {Pet.Name}";

        }
    }
}
