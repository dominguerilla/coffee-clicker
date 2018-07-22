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

    public GameObject shopGO;

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
        UpdateResourceCounts();
    }

    void UpdateResourceCounts() {
        coffeeBeanCount.text = "COFFEE BEANS: " + rManager.coffeeBeans.ToString("F2");
        coffeeCount.text = "COFFEE: " + rManager.coffee.ToString("F2");
        moneyCount.text = "$" + rManager.money.ToString("F2");
        farmerCount.text = "FARMERS: " + farmers.farmers;
        baristaCount.text = "BARISTAS: " + baristas.baristas;
    }

    public void ToggleShop() {
        bool isActive = shopGO.activeInHierarchy;
        shopGO.SetActive(!isActive);
    }
}
