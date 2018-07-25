using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baristas : MonoBehaviour {
    
    public static Baristas instance = null;

    public int baristas;
    public float baristaCost = 100f;

    /// <summary>
    /// The amount of coffee each barista makes per five seconds.
    /// </summary>
    public float coffeeBrewSpeed = 1.0f;

    /// <summary>
    /// The amount of coffee each barista can sell per five seconds
    /// </summary>
    public float coffeeSellSpeed = 0.5f;

    [Header("Upgrade Costs")]
    public float brewUpgradeCost = 450f;
    public float sellUpgradeCost = 450f;
    public float costUpgradeCost = 600f;

    ResourceManager rManager;

    private void Awake() {
        if(!instance)
            instance = this;
        else if (instance != this) 
            Destroy(this);   
    }

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;	
        StartCoroutine(UpdateCoffee());
	}

    IEnumerator UpdateCoffee() {
        while(true) {
            BrewCoffee();
            SellCoffee();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void BrewCoffee() {
        float possibleCoffeeToMake = baristas * (rManager.coffeeBeans / rManager.beansPerCoffee);
        float maxCoffeeMade = (baristas * coffeeBrewSpeed) / 5;
        float coffeeAmount = Mathf.Min(maxCoffeeMade, possibleCoffeeToMake);
        rManager.BrewCoffee(coffeeAmount);
    }

    void SellCoffee() {
        float possibleCoffeeToSell = (baristas * rManager.coffee) / 5;
        float maxCoffeeToSell = (baristas * coffeeSellSpeed) / 5;
        float coffeeToSell = Mathf.Min(possibleCoffeeToSell, maxCoffeeToSell);
        rManager.SellCoffee(coffeeToSell);
    }

    public void HireBarista() {
        if(rManager.money >= baristaCost) {
            rManager.money -= baristaCost;
            baristas += 1;
        }
    }

}
