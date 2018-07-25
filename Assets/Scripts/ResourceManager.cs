using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance = null;

    public float coffeeBeans;
    public float coffee;
    public float money;

    public float beansPerCoffee = 10.0f;
    public float pricePerCoffee = 1.0f;

    public float coffeePerClickBrew = 1.0f;

    private void Awake() {
        if(!instance)
            instance = this;
        else if (instance != this) 
            Destroy(this);   
    }

    /// <summary>
    /// If cost is less than/eq to current money, then cost is subtracted from money and returns true.
    /// Else, returns false.
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    public bool BuyUpgrade(float cost) {
        if(cost <= money) {
            money -= cost;
            return true;
        }
        return false;
    }

    public bool BrewCoffeeClick() {
        if(coffeeBeans - beansPerCoffee >= 0) {
            coffeeBeans -= beansPerCoffee;
            coffee += coffeePerClickBrew;
            return true;
        }
        return false;
    }

    public void BrewCoffee(float coffeeAmount) {
        coffeeBeans -= coffeeAmount * beansPerCoffee;
        if(coffeeBeans < 0)
            coffeeBeans = 0;
        coffee += coffeeAmount;
    }

    public void SellCoffee(float coffeeAmount) {
        coffee -= coffeeAmount;
        if (coffee < 0)
            coffee = 0;
        money += coffeeAmount * pricePerCoffee;
    }

    public bool SellCoffeeClick(Customer currentCustomer) {
        if(coffee > 0 && currentCustomer.numberOfCoffees <= coffee) {
            float price = currentCustomer.numberOfCoffees * pricePerCoffee;
            coffee -= currentCustomer.numberOfCoffees;
            money += price;
            return true;
        }
        return false;
    }
   
}
