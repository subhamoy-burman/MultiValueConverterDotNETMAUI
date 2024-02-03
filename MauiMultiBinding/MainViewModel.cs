using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiMultiBinding.Models;

namespace MauiMultiBinding;

public class MainViewModel : BindableObject
{
    public ObservableCollection<Product> Products { get; private set; } = new ObservableCollection<Product>();
    public ICommand LoadMoreCommand { get; private set; }

    public MainViewModel()
    {
        LoadMoreCommand = new Command(LoadMoreProducts);
        LoadInitialProducts();
    }
    
    private int _totalProducts;
    public int TotalProducts
    {
        get => _totalProducts;
        set
        {
            _totalProducts = value;
            OnPropertyChanged(nameof(TotalProducts));
        }
    }

    private void LoadInitialProducts()
    {
        for (int i = 0; i < 10; i++)
        {
            Products.Add(CreateProduct(i));
        }
        TotalProducts = Products.Count;
    }

    private void LoadMoreProducts()
    {
        int currentCount = Products.Count;
        for (int i = currentCount; i < currentCount + 10; i++)
        {
            Products.Add(CreateProduct(i));
        }
        TotalProducts = Products.Count;
    }

    private Product CreateProduct(int index)
    {
        return new Product
        {
            UniqueId = index,
            Name = $"Product {index}",
            Description = $"Description for product {index}",
            ImageUrl = $"https://example.com/product{index}.jpg",
            IsBoxViewVisible = index % 2 == 0 // Just an example condition for visibility
        };
    }
}