using shootarama.DB;
using shootarama.DB.Tables;

using System.Collections.ObjectModel;
using System.Linq;

namespace shootarama.ViewModels
{
    public class LoadGameVM : BaseViewModel
    {
        private ObservableCollection<Games> _gamesList;

        public ObservableCollection<Games> GamesList
        {
            get { return _gamesList; }

            set {
                _gamesList = value;

                OnPropertyChanged();
            }
        }

        public void LoadData()
        {
            using (var db = new DBManager())
            {
                GamesList = new ObservableCollection<Games>(db.Games.ToList());
            }
        }
    }
}