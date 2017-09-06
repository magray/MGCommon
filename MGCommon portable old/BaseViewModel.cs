namespace MGCommon
{
    public class BaseViewModel : ObservableObject
    {
        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string subTitle = string.Empty;

        public string SubTitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value); }
        }

        string icon = string.Empty;

        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        bool isNotBusy = true;

        public bool IsNotBusy
        {
            get { return isNotBusy; }
            set { SetProperty(ref isNotBusy, value); }
        }

        bool canLoadMore = true;

        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value); }
        }
    }
}
