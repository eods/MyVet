using MyVet.Common.Helpers;
using MyVet.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace MyVet.Prism.ViewModels
{
    public class PetPageViewModel : ViewModelBase
    {

        private PetResponse _pet;

        public PetPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            Title = "Details";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //if (parameters.ContainsKey("pet"))
            //{
            //    Pet = parameters.GetValue<PetResponse>("pet");
            //    Title = Pet.Name;
            //}
            Pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);

        }

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }

    }
}
