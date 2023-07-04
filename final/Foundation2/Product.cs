public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalPrice()
    {
        double _totalPrice = _price * _quantity;
        return _totalPrice;
    }

    public string GetProductDetails()
    {
        return $"   {_name} (ID: {_productId})";
    }
}