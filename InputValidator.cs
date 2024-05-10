


public static class InputValidator
{
    public static bool ValidateItem(string name, decimal price, int quantity, string category)
    {
        // Add your validation logic here
        return !string.IsNullOrEmpty(name) && price > 0 && quantity > 0 && !string.IsNullOrEmpty(category);
    }
}