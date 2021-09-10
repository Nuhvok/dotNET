// Brandon Rolfe
// CS 364
// Project #4 (FastFoodOrdering)
// 3/22/21

using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodOrdering
{
    class Order
    {
        public const float BEEF_PRICE = 4.99f,
                           PORK_PRICE = 5.49f,
                           CHICKEN_PRICE = 3.99f,
                           SAUSAGE_PRICE = 4.24f,
                           FRIES_PRICE = 2.49F,
                           DRINK_PRICE = 1.99F,
                           TAX_RATE      = 0.07f;

        // Fields for Order
        Sandwich[] sandwichOrder;
        int fries;
        int drinks;

        public Order()
        {
            SetSandwiches(new Sandwich[0]);
            SetFries(0);
            SetDrinks(0);
        }

        public Order(Sandwich[] newSandwiches, int newFries, int newDrinks)
        {
            SetSandwiches(newSandwiches);
            SetFries(newFries);
            SetDrinks(newDrinks);
        }

        // Gets and sets the Order fields
        public Sandwich[] GetSandwiches() => sandwichOrder;
        public void SetSandwiches(Sandwich[] newSandwiches) => sandwichOrder = newSandwiches;
        public int GetFries() => fries;
        public void SetFries(int newFries)
        {
            if (newFries < 0)
                throw new ArgumentOutOfRangeException("SetFries", "Amount of fries cannot be below 0");
            else
                fries = newFries;
        }
        public int GetDrinks() => drinks;
        public void SetDrinks(int newDrinks)
        {
            if (newDrinks < 0)
                throw new ArgumentOutOfRangeException("SetDrinks", "Amount of drinks cannot be below 0");
            else
                drinks = newDrinks;
        }

        // Adds a snadwich to the sandwich list
        public void AddSandwich(int SandwichType, int[] Toppings)
        {
            Sandwich[] tempSandwichOrder = sandwichOrder;
            sandwichOrder = new Sandwich[tempSandwichOrder.Length + 1];
            for(int i = 0; i < tempSandwichOrder.Length; i++)
            {
                sandwichOrder[i] = tempSandwichOrder[i];
            }
            sandwichOrder[sandwichOrder.Length - 1] = new Sandwich(SandwichType, Toppings);
        }

        // Adds fries or a drink to the Order
        public void AddFries() => fries++;
        public void AddDrink() => drinks++;

        // Gets the subtotal of the Order
        public float GetSubtotal()
        {
            float subtotal = 0.0f;
            foreach (Sandwich item in sandwichOrder)
            {
                subtotal += item.GetPrice();
            }

            subtotal += fries * FRIES_PRICE;
            subtotal += drinks * DRINK_PRICE;

            return subtotal;
        }

        // Gets the tax of the Order
        public float GetTax() => GetSubtotal() * TAX_RATE;

        // Gets the total of the Order
        public float GetTotal() => GetSubtotal() + GetTax();
        
        // Gets the order as a string
        public override string ToString()
        {
            string outputString = "Current Order:\n";
            // Adds the counts to the Order string
            outputString += "Sandwiches: " + sandwichOrder.Length + "\n";
            outputString += "Fries: " + fries + "\n";
            outputString += "Drinks: " + drinks + "\n";

            // Loops for each sandwich, adding it to the Order string
            foreach (Sandwich item in sandwichOrder)
            {
                outputString += "Sandwich Type: " + (Sandwich.SandwichTypeList)item.GetSandwichType() + "\n";
                outputString += "Toppings: ";
                // Loops for each topping, adding it to the Order string
                foreach (int topping in item.GetToppings())
                {
                    outputString += (Sandwich.ToppingsList)topping + " ";
                }
                outputString += "\n";
            }
            return outputString;
        }
    }

    struct Sandwich
    {
        // Fields of a Sandwich
        int sandwichType;
        int[] toppings;
        float price;

        public Sandwich(int SandwichType, int[] Toppings)
        {
            this.sandwichType = SandwichType;
            this.toppings = Toppings;
            price = sandwichType switch
            {
                0 => Order.BEEF_PRICE,
                1 => Order.PORK_PRICE,
                2 => Order.CHICKEN_PRICE,
                _ => Order.SAUSAGE_PRICE,
            };
        }

        // Gets and sets the Sandwich fields
        public int GetSandwichType() => sandwichType;
        public void SetSandwichType(int newType) => sandwichType = newType;
        public int[] GetToppings() => toppings;
        public void SetToppings(int[] newToppings) => toppings = newToppings;
        public float GetPrice() => price;
        public void SetPrice(float newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException("SetPrice", "Price cannot be below 0");
            else
                price = newPrice;
        }

        public enum SandwichTypeList
        {
            Beef,
            Pork,
            Chicken,
            Sausage
        }
        
        public enum ToppingsList
        {
            Cheese,
            Lettuce,
            Tomato,
            Ketchup,
            Mustard,
            Mayo
        }
    }
}
