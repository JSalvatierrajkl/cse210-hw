public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double _totalPrice = 0;
        foreach (Product product in _products)
        {
            _totalPrice += product.GetTotalPrice();
        }

        return _totalPrice + GetShippingCost();
    }

    private int GetShippingCost()
    {
        if (_customer.USAOrNot())
        {
            return 5;
        }
        else
        {
            return 35;
        }
    }

    public string GetPackingLabel()
    {
        string _packingLabel = "Packing Label:\n";
        foreach (Product product in _products)
        {
            _packingLabel += product.GetProductDetails() + "\n";
        }

        return _packingLabel;
    }

    public string GetShippingLabel()
    {
        string _shippingLabel = "Shipping Label:\n";
        _shippingLabel += " Customer:" + _customer.GetName() + "\n";
        _shippingLabel += " Address:" + _customer.GetAddress().GetAddressDetails();

        return _shippingLabel;
    }
}