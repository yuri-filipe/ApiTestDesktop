using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ApiTest.Desktop.Services;
using ApiTest.Domain.Data.Models;
using LiteDB;

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
                Date = DateTime.Now,
                Id = ObjectId.NewObjectId() // Ensure new ID is generated
            };

            AddTestCommand = new RelayCommand(async () => await AddTestAsync());
        }

        private async Task AddTestAsync()
        {
            if (NewTest != null)
            {
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
                    Date = DateTime.Now,
                    Id = ObjectId.NewObjectId() // Ensure new ID is generated
                };

                OnPropertyChanged(nameof(NewTest));
            }
        }
    }
}
