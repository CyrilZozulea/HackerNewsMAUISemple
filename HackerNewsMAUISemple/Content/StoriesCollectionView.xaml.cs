using HackerNewsMAUISemple.Firebase;
using HackerNewsMAUISemple.Firebase.Models;
using System.Collections.ObjectModel;
using HackerNewsMAUISemple.Pages.Details;

namespace HackerNewsMAUISemple.Content;

public partial class StoriesCollectionView : ContentView
{
    private StoriesType storiesType { get; set; }

    private IFirebaseManager firebaseManager;
    private GetItemsModel GetItemsResponse;
    private ObservableCollection<ItemSource> CollectionViewItems = new ObservableCollection<ItemSource>();

    public StoriesCollectionView(IFirebaseManager firebaseManager, StoriesType storiesType)
	{
		InitializeComponent();

        this.storiesType = storiesType;
        this.firebaseManager = firebaseManager;

        refresh.Command = new Command(() =>
        {
            CollectionViewItems.Clear();
            GetItemsResponse.Items = null;

            Indicator.IsRunning = true;
            collection.IsVisible = false;
            refresh.IsVisible = false;

            refresh.IsRefreshing = false;
            LoadItems();
        });

        LoadItems();
    }

    async void OnSelected(object obj, EventArgs e)
    {
        if (collection.SelectedItem != null)
        {
            ItemSource item = (ItemSource)collection.SelectedItem;
            await Navigation.PushAsync(new StoryDetails(item, firebaseManager));

            collection.SelectedItem = null;
        }
    }

    async void LoadItems()
    {
        GetItemsResponse = await firebaseManager.GetItems(storiesType);

        if (GetItemsResponse.ErrorCode.Equals(ErrorCode.OK))
        {
            collection.ItemsSource = CollectionViewItems;

            foreach (var item in GetItemsResponse.Items)
            {
                if (GetItemsResponse.Items == null)
                    break;

                var item_response = await firebaseManager.GetItem(item);

                if (item_response.ErrorCode.Equals(ErrorCode.OK))
                    CollectionViewItems.Add(item_response.Item);

                if (CollectionViewItems.Count == 10)
                {
                    Indicator.IsRunning = false;
                    collection.IsVisible = true;
                    refresh.IsVisible = true;
                }
                else if (CollectionViewItems.Count == 30)
                {
                    collection.Scrolled += OnScroll;
                    break;
                }
            }
        }
    }

    async void OnScroll(object obj, ItemsViewScrolledEventArgs e)
    {
        if (e.FirstVisibleItemIndex >= 10 && !up_vector.Scale.Equals(1))
            up_vector.Scale = 1;
        else if (e.FirstVisibleItemIndex <= 5 && !up_vector.Scale.Equals(0))
            up_vector.Scale = 0;

        if ((CollectionViewItems.Count - e.LastVisibleItemIndex) <= 10)
        {
            collection.Scrolled -= OnScroll;
            collection_loader.IsVisible = true;

            List<ItemSource> items = new List<ItemSource>();
            IEnumerable<long> main_items = GetItemsResponse.Items.Skip(CollectionViewItems.Count);

            foreach (var item in main_items)
            {
                var item_response = await firebaseManager.GetItem(item);

                if (GetItemsResponse.Items == null)
                    break;

                if (item_response.ErrorCode.Equals(ErrorCode.OK))
                    items.Add(item_response.Item);

                if (items.Count.Equals(main_items.Count()) || items.Count.Equals(20))
                {
                    foreach (var ready_item in items)
                    {
                        if (GetItemsResponse.Items == null)
                            break;

                        CollectionViewItems.Add(ready_item);
                    }

                    break;
                }
            }

            if (GetItemsResponse.Items != null)
                collection.Scrolled += OnScroll;

            collection_loader.IsVisible = false;
        }
    }

    void ScrollUp(object obj, EventArgs e)
    {
        up_vector.Scale = 0;
        collection.ScrollTo(0);
    }
}