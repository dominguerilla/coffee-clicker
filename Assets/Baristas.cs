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
            if (rManager.coffeeBeans >= baristas * rManager.beansPerCoffee) {
                rManager.coffeeBeans -= (baristas * rManager.beansPerCoffee) / 5;
                rManager.coffee += (baristas * coffeeBrewSpeed) / 5;
                yield return new WaitForSeconds(1.0f);
            }else {
                Debug.Log("Not enough coffee beans!");
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    public void HireBarista() {
        if(rManager.money >= baristaCost) {
            rManager.money -= baristaCost;
            baristas += 1;
        }
    }

}
