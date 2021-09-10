// Brandon Rolfe
// CS 364
// Project #4 (FastFoodOrdering)
// 3/22/21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFoodOrdering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Order currentOrder = new Order();
        public MainWindow()
        {
            InitializeComponent();

            // Initializes labels with data from the Order
            First_Item.Content  = ((Sandwich.SandwichTypeList)0) + " Sandwich";
            Second_Item.Content = ((Sandwich.SandwichTypeList)1) + " Sandwich";
            Third_Item.Content  = ((Sandwich.SandwichTypeList)2) + " Sandwich";
            Fourth_Item.Content = ((Sandwich.SandwichTypeList)3) + " Sandwich";
            Fifth_Item.Content  = "Large Fries";
            Sixth_Item.Content  = "Large Coke";

            Tax_Label.Content = "Tax(" + Order.TAX_RATE + "):";

            First_Price.Content  = Order.BEEF_PRICE.ToString("C2");
            Second_Price.Content = Order.PORK_PRICE.ToString("C2");
            Third_Price.Content  = Order.CHICKEN_PRICE.ToString("C2");
            Fourth_Price.Content = Order.SAUSAGE_PRICE.ToString("C2");
            Fifth_Price.Content  = Order.FRIES_PRICE.ToString("C2");
            Sixth_Price.Content  = Order.DRINK_PRICE.ToString("C2");

            First_Sandwich_Choice.Content  = (Sandwich.SandwichTypeList)0;
            Second_Sandwich_Choice.Content = (Sandwich.SandwichTypeList)1;
            Third_Sandwich_Choice.Content  = (Sandwich.SandwichTypeList)2;
            Fourth_Sandwich_Choice.Content = (Sandwich.SandwichTypeList)3;

            First_Topping_Choice.Content  = (Sandwich.ToppingsList)0;
            Second_Topping_Choice.Content = (Sandwich.ToppingsList)1;
            Third_Topping_Choice.Content  = (Sandwich.ToppingsList)2;
            Fourth_Topping_Choice.Content = (Sandwich.ToppingsList)3;
            Fifth_Topping_Choice.Content  = (Sandwich.ToppingsList)4;
            Sixth_Topping_Choice.Content  = (Sandwich.ToppingsList)5;

            UpdateOutputs();
        }

        // Updates the order and cost fields
        public void UpdateOutputs()
        {
            Order_List.Content = currentOrder.ToString();
            Subtotal.Content   = currentOrder.GetSubtotal().ToString("C2");
            Tax.Content        = currentOrder.GetTax().ToString("C2");
            Total.Content      = currentOrder.GetTotal().ToString("C2");
            Status.Content = "All Good";
        }

        // Adds a sandwich to the Order when clicked
        private void Add_Sandwich_Click(object sender, RoutedEventArgs e)
        {
            int sandwichType;
            try
            {
                // Checks which sandwich type was chosen
                if (First_Sandwich_Choice.IsChecked.Value)
                {
                    sandwichType = 0;
                    First_Sandwich_Choice.IsChecked = false;
                }
                else if (Second_Sandwich_Choice.IsChecked.Value)
                {
                    sandwichType = 1;
                    Second_Sandwich_Choice.IsChecked = false;
                }
                else if (Third_Sandwich_Choice.IsChecked.Value)
                {
                    sandwichType = 2;
                    Third_Sandwich_Choice.IsChecked = false;
                }
                else if (Fourth_Sandwich_Choice.IsChecked.Value)
                {
                    sandwichType = 3;
                    Fourth_Sandwich_Choice.IsChecked = false;
                }
                else
                    throw new ArgumentException("Add_Sandwich_Click", "You must choose a type of sandwich to add.");
            }
            catch(ArgumentException ex)
            {
                Status.Content = "You must choose a type of sandwich to add.";
                return;
            }
            // Counts how many toppings were chosen
            int numOfToppings = 0;
            if (First_Topping_Choice.IsChecked.Value)
                numOfToppings++;
            if (Second_Topping_Choice.IsChecked.Value)
                numOfToppings++;
            if (Third_Topping_Choice.IsChecked.Value)
                numOfToppings++;
            if (Fourth_Topping_Choice.IsChecked.Value)
                numOfToppings++;
            if (Fifth_Topping_Choice.IsChecked.Value)
                numOfToppings++;
            if (Sixth_Topping_Choice.IsChecked.Value)
                numOfToppings++;
            
            // Creates topping list and adds the chosen toppings to it
            int[] toppingsList = new int[numOfToppings];
            int nextIndex = 0;
            if (First_Topping_Choice.IsChecked.Value)
            {
                toppingsList[nextIndex] = 0;
                First_Topping_Choice.IsChecked = false;
                nextIndex++;
            }
            if (Second_Topping_Choice.IsChecked.Value)
            {
                toppingsList[nextIndex] = 1;
                Second_Topping_Choice.IsChecked = false;
                nextIndex++;
            }
            if (Third_Topping_Choice.IsChecked.Value)
            {
                toppingsList[nextIndex] = 2;
                Third_Topping_Choice.IsChecked = false;
                nextIndex++;
            }
            if (Fourth_Topping_Choice.IsChecked.Value)
            {
                toppingsList[nextIndex] = 3;
                Fourth_Topping_Choice.IsChecked = false;
                nextIndex++;
            }
            if (Fifth_Topping_Choice.IsChecked.Value)
            {
                toppingsList[nextIndex] = 4;
                Fifth_Topping_Choice.IsChecked = false;
                nextIndex++;
            }
            if (Sixth_Topping_Choice.IsChecked.Value)
            {
                toppingsList[nextIndex] = 5;
                Sixth_Topping_Choice.IsChecked = false;
                nextIndex++;
            }

            currentOrder.AddSandwich(sandwichType, toppingsList);
            UpdateOutputs();
        }

        // Adds one order of fries to the Order on click
        private void Add_Fries_Click(object sender, RoutedEventArgs e)
        {
            currentOrder.AddFries();
            UpdateOutputs();
        }

        // Adds one drink to the Order on click
        private void Add_Drink_Click(object sender, RoutedEventArgs e)
        {
            currentOrder.AddDrink();
            UpdateOutputs();
        }
    }
}
