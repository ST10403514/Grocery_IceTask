namespace GroceryStore_IceTask
{
    public partial class Form1 : Form
    {
        private GroceryStore groceryStore;

        public Form1()
        {
            InitializeComponent();
            groceryStore = new GroceryStore();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Remove Item Button Clicked
            string selectedItem = comboBox2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedItem))
            {
                // Find the item to remove from inventory
                InventoryItem itemToRemove = groceryStore.Inventory.GetItems().FirstOrDefault(item => item.Name == selectedItem);

                if (itemToRemove != null)
                {
                    // Remove item from inventory
                    groceryStore.Inventory.RemoveItem(itemToRemove);
                    UpdateInventoryDisplay();
                    textBox4.Text = $"Item '{selectedItem}' removed from inventory.";
                }
                else
                {
                    ErrorHandler.HandleError($"Item '{selectedItem}' not found in inventory.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Add Item Button Clicked
            string name = textBox1.Text;
            decimal price;
            int quantity;
            string category = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(name) && decimal.TryParse(textBox2.Text, out price) && int.TryParse(textBox3.Text, out quantity) && !string.IsNullOrEmpty(category))
            {
                if (InputValidator.ValidateItem(name, price, quantity, category))
                {
                    // Create new InventoryItem and add to inventory
                    InventoryItem newItem = new InventoryItem(name, price, quantity, category);
                    groceryStore.Inventory.AddItem(newItem);
                    UpdateInventoryDisplay();
                    textBox4.Text = $"Item '{name}' added to inventory.";
                }
                else
                {
                    ErrorHandler.HandleError("Please fill in all fields correctly.");
                }
            }
            else
            {
                ErrorHandler.HandleError("Please fill in all fields correctly.");
            }
        }

        private void UpdateInventoryDisplay()
        {
            listBox1.Items.Clear();
            foreach (InventoryItem item in groceryStore.Inventory.GetItems())
            {
                listBox1.Items.Add($"{item.Name} - Price: {item.Price:C}, Quantity: {item.Quantity}, Category: {item.Category}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
