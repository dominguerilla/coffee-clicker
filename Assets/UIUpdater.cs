using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class UIUpdater : MonoBehaviour {

    public Text coffeeBeanCount;
    public Text coffeeCount;
    public Text moneyCount;
    public Text farmerCount;
    public Text baristaCount;

    ResourceManager rManager;
    Baristas baristas;
    Farmers farmers;

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;
        farmers = Farmers.instance;
        baristas = Baristas.instance;
	}
	
	// Update is called once per frame
	void Update () {
        coffeeBeanCount.text = "Coffee Beans: " + rManager.coffeeBeans.ToString("F2");
        coffeeCount.text = "Coffee: " + rManager.coffee.ToString("F2");
        moneyCount.text = "Money: " + rManager.money.ToString("F2");
        farmerCount.text = "Farmer: " + farmers.farmers;
        baristaCount.text = "Baristas: " + baristas.baristas;
	}
}
