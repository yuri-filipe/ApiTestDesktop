using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ApiTest.Domain.Data.Models;
using ApiTest.Infrastructure.Services;

namespace ApiTest.Desktop.ViewModels
{
    public class AddTestPageViewModel : ViewModelBase
    {
        private readonly ITestService _testService;
        private Test _newTest;

        public ObservableCollection<Test> Tests { get; set; }
        public Test NewTest
        {
            get => _newTest;
            set
            {
                _newTest = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddTestCommand { get; }

        public AddTestPageViewModel(ITestService testService)
        {
            _testService = testService;
            Tests = new ObservableCollection<Test>();
            NewTest = new Test
            {
                Date = DateTime.Now
            };

            AddTestCommand = new RelayCommand(async () => await AddTestAsync());
        }

        private async Task AddTestAsync()
        {
            if (NewTest != null)
            {
                await _testService.AddTestAsync(NewTest);

                Tests.Add(new Test
                {
                    Id = NewTest.Id,
                    ConfigurationId = NewTest.ConfigurationId,
                    Configuration = NewTest.Configuration,
                    Date = NewTest.Date,
                    Result = NewTest.Result,
                    ErrorMessage = NewTest.ErrorMessage
                });

                // Clear the new test entry form
                NewTest = new Test
                {
                    Date = DateTime.Now
                };

                OnPropertyChanged(nameof(NewTest));
            }
        }
    }
}
