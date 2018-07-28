using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class UIUpdater : MonoBehaviour {

    public static UIUpdater instance = null;

    public GameObject shopGO;
    public GameObject helpGO;

    [Header("Resource Counts")]
    public Text coffeeBeanCount;
    public Text coffeeCount;
    public Text moneyCount;
    public Text farmerCount;
    public Text baristaCount;

    public Text priceText;

    ResourceManager rManager;
    Baristas baristas;
    Farmers farmers;

    UpgradeButton currentlyHoveredButton = null;
    float hoveredButtonCost;

    private void Awake() {
        if (!instance)
            instance = this;
        else if (instance != this) 
            Destroy(this);   
    }

    // Use this for initialization
    void Start () {
	    rManager = ResourceManager.instance;
        farmers = Farmers.instance;
        baristas = Baristas.instance;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateResourceCounts();
        if(currentlyHoveredButton){
            priceText.enabled = true;
            priceText.text = "$" + hoveredButtonCost;
        }else{
            priceText.enabled = false;
        }
    }

    void UpdateResourceCounts() {
        coffeeBeanCount.text = "COFFEE BEANS: " + rManager.coffeeBeans.ToString("F2");
        coffeeCount.text = "COFFEE: " + rManager.coffee.ToString("F2");
        moneyCount.text = "$" + rManager.money.ToString("F2");
        farmerCount.text = "FARMERS: " + farmers.farmers;
        baristaCount.text = "BARISTAS: " + baristas.baristas;
    }

    public void ToggleShop() {
        if(helpGO.activeInHierarchy)
            ToggleHelp();

        bool isActive = shopGO.activeInHierarchy;
        shopGO.SetActive(!isActive);
    }

    public void ToggleHelp() {
        if(shopGO.activeInHierarchy)
            ToggleShop();

        bool isActive = helpGO.activeInHierarchy;
        helpGO.SetActive(!isActive);
    }

    public void SetHoveredButton(UpgradeButton button, float cost){
        if(currentlyHoveredButton != button){
            currentlyHoveredButton = button;
            hoveredButtonCost = cost;
        }
    }

    /// <summary>
    /// Only clears the hovered button if the button specified matches the currently hovered button
    /// Wasn't sure if there were going to be race conditions, so I set this up.
    /// </summary>
    /// <param name="button"></param>
    public void ClearHoveredButton(UpgradeButton button){
        if(button == currentlyHoveredButton){
            currentlyHoveredButton = null;
            hoveredButtonCost = -1f;
        }
    }
    
}
