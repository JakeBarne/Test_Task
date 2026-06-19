using System.Collections.ObjectModel;
using System.Windows.Input;
using TestTask.Common;
using TestTask.Infrastructure.Repository;

namespace TestTask.ViewModel
{
    public abstract class CrudViewModel<T> : ObservableObject where T : class
    {
        private readonly IRepository<T> _repo;
        protected readonly IDialogService Dialogs;

        private ObservableCollection<T> _items;
        private T _selected;

        public ObservableCollection<T> Items
        {
            get => _items;
            private set { _items = value; RaisePropertyChanged(nameof(Items)); }
        }

        public T Selected
        {
            get => _selected;
            set
            {
                if (ReferenceEquals(_selected, value)) return;
                _selected = value;
                RaisePropertyChanged(nameof(Selected));
            }
        }

        public ICommand AddCommand    { get; }
        public ICommand EditCommand   { get; }
        public ICommand DeleteCommand { get; }

        protected CrudViewModel(IRepository<T> repo, IDialogService dialogs)
        {
            _repo   = repo;
            Dialogs = dialogs;
            AddCommand    = new RelayCommand(_ => Execute(Add));
            EditCommand   = new RelayCommand(_ => Execute(Edit),   _ => Selected != null);
            DeleteCommand = new RelayCommand(_ => Execute(Delete), _ => Selected != null);
            Items = new ObservableCollection<T>(_repo.GetAll());
        }

        protected abstract T NewEntity();
        protected abstract bool ShowDialog(T entity);
        protected abstract string GetDeleteMessage(T entity);

        private void Refresh() => Items = new ObservableCollection<T>(_repo.GetAll());
        private void Add()    { var e = NewEntity(); if (ShowDialog(e)) { _repo.Save(e); Refresh(); } }
        private void Edit()   { var entity = Selected; if (ShowDialog(entity)) { _repo.Update(entity); Refresh(); } }
        private void Delete() { var entity = Selected; if (Dialogs.Confirm(GetDeleteMessage(entity))) { _repo.Delete(entity); Refresh(); } }

        private void Execute(Action action)
        {
            try { action(); }
            catch (Exception ex) { Dialogs.ShowError(ExceptionHelper.RootMessage(ex)); }
        }
    }
}
