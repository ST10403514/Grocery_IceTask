


using System.Collections.Generic;

public class Inventory
{
    private List<InventoryItem> items;

    public Inventory()
    {
        items = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }

    public IEnumerable<InventoryItem> GetItems()
    {
        return items;
    }
}