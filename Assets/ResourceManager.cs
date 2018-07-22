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

    public void BrewCoffeeClick() {
        if(coffeeBeans - beansPerCoffee >= 0) {
            coffeeBeans -= beansPerCoffee;
            coffee += coffeePerClickBrew;
        }
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

    public void SellCoffee(Customer currentCustomer) {
        if(coffee > 0 && currentCustomer.numberOfCoffees <= coffee) {
            Debug.Log("Selling coffee...");
            float price = currentCustomer.numberOfCoffees * pricePerCoffee;
            coffee -= currentCustomer.numberOfCoffees;
            money += price;
        }else {
            Debug.Log("Not enough coffee!");
        }
    }
   
}
