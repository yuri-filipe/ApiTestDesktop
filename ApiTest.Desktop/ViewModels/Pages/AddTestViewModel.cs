using ApiTest.Desktop.Services;
using ApiTest.Domain.Data.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ApiTest.Desktop.ViewModels
{
    public class AddTestPageViewModel : ViewModelBase
    {
        private readonly LiteDbCacheService _dbService;
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

        public AddTestPageViewModel(LiteDbCacheService dbService)
        {
            _dbService = dbService;
            Tests = new ObservableCollection<Test>(_dbService.GetTests());
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
                NewTest.Id = Tests.Count + 1; // Simplified ID assignment
                _dbService.AddTest(NewTest);

                Tests.Add(new Test
                {
                    Id = NewTest.Id,
                    ConfigurationId = NewTest.ConfigurationId,
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
