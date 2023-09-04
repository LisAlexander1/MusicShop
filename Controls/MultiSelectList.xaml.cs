using System.Collections;
using System.Windows.Controls;

namespace MusicShop.Controls;

public partial class MultiSelectList
{
    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
        nameof(SelectedItems),
        typeof(IList),
        typeof(MultiSelectList)
    );
    
    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        nameof(ItemsSource),
        typeof(IList),
        typeof(MultiSelectList)
    );
    
    private static readonly DependencyProperty ListItemsProperty = DependencyProperty.Register(
        nameof(ListItems),
        typeof(IList),
        typeof(MultiSelectList)
        );
    

    public IList SelectedItems
    {
        get => (IList)GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }
    public IList ItemsSource
    {
        get => (IList)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }
    
    public IList ListItems
    {
        get => ListItems;
        set => SetValue(ListItemsProperty, value);
    }

    public MultiSelectList()
    {
        DataContext = this;
        InitializeComponent();
        SelectionList.SelectionChanged += SelectionAddHandler;
        SelectedList.SelectionChanged += SelectionRemoveHandler;
    }

    private void SelectionRemoveHandler(object sender, SelectionChangedEventArgs e)
    {
        SelectedItems.Remove(e.AddedItems);
        ListItems.Add(e.AddedItems);
    }


    private void SelectionAddHandler(object sender, SelectionChangedEventArgs e)
    {
        SelectedItems.Add(e.AddedItems);
        ListItems.Remove(e.AddedItems);
    }
}