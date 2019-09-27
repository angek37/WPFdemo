using FriendOrganizer.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FriendOrganizer.UI.Data;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Friend _selectedFriend;
        private IFriendDataService _friendDataService;

        public MainViewModel(IFriendDataService friendDataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
        }

        public async Task LoadAsync()
        {
            var friends = await _friendDataService.GetAllAsync();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        public ObservableCollection<Friend> Friends { get; set; }

        public Friend SelectedFriend
        {
            get => _selectedFriend;
            set
            {
                _selectedFriend = value; 
                OnPropertyChanged();
            }
        }
    }
}
