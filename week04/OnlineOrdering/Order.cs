using System;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public double OrderTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.TotalCost();
        }

        if (_customer.IsFromUS())
        {
            total += 5;
        }

        else
        {
            total += 35;
        }

        return total;
    }

    public string DisplayPackingLabel()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("Packing Label:");
        foreach (Product p in _products)
        {
            stringBuilder.AppendLine(p.GetProductLabel());
        }

        return stringBuilder.ToString();
    }

    public string DisplayShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().CompleteAddress()}";
    }
}
