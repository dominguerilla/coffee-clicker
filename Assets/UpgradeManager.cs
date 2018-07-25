using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Has to look like this, to hook up to the UI.
/// </summary>
public class UpgradeManager : MonoBehaviour {

    public static UpgradeManager instance = null;

    public enum UPGRADE_TYPE {
        CLICK_HARVEST,
        CLICK_BREW,
        CLICK_SELL,
        FARMER_HARVEST,
        FARMER_COST,
        BARISTA_BREW,
        BARISTA_SELL,
        BARISTA_COST
    }

    public CoffeePlant plant;
    public CoffeeMaker cMaker;
    public Register register;
    public Farmers farmerManager;
    public Baristas baristaManager;

    // there's probably a better way to link the emitters to the manager classes but w/e
    public PrefabEmitter beanEmitter;
    public PrefabEmitter coffeeEmitter;
    public PrefabEmitter moneyEmitter;

    ResourceManager rManager;

	void Awake () {
        if(!plant)
            Debug.LogError("No coffee plant set!");
        if(!cMaker)
            Debug.LogError("No coffee maker set!");
        if(!register)
            Debug.LogError("No register set!");
        if(!farmerManager)
            Debug.LogError("No Farmers object set!");
        if(!baristaManager)
            Debug.LogError("No Baristas object set!");

        if (!instance)
            instance = this;
        else if (instance != this) 
            Destroy(this);   

	}

    private void Start() {
        rManager = ResourceManager.instance;
    }

    float calculateBonus(float original) {
        return original * 1.5f;
    }

    public void Upgrade(UPGRADE_TYPE upgrade) {
        switch(upgrade) {
            case UPGRADE_TYPE.CLICK_HARVEST:
                if(rManager.BuyUpgrade(plant.upgradeCost)) {
                    plant.beansPerClick += 1;
                    plant.upgradeCost *= 2f;
                    if(beanEmitter)
                        beanEmitter.prefabsPerEmit +=1;
                }
                break;
            case UPGRADE_TYPE.CLICK_BREW:
                if(rManager.BuyUpgrade(cMaker.upgradeCost)) {
                    cMaker.coffeePerClick += 1;
                    cMaker.upgradeCost *= 2f;
                    if(coffeeEmitter)
                        coffeeEmitter.prefabsPerEmit += 1;
                }
                break;
            case UPGRADE_TYPE.CLICK_SELL:
                if(rManager.BuyUpgrade(register.upgradeCost)) {
                    register.coffeeSoldPerClick += 1;
                    register.upgradeCost *= 2f;
                    if(moneyEmitter)
                        moneyEmitter.prefabsPerEmit += 1;
                }
                break;
            case UPGRADE_TYPE.FARMER_HARVEST:
                if(rManager.BuyUpgrade(farmerManager.harvestUpgradeCost)) {
                    farmerManager.beanHarvestSpeed = calculateBonus(farmerManager.beanHarvestSpeed);
                    farmerManager.harvestUpgradeCost *= 3f;
                }
                break;
            case UPGRADE_TYPE.FARMER_COST:
                if(rManager.BuyUpgrade(farmerManager.costUpgradeCost)) {
                    farmerManager.farmerCost = calculateBonus(farmerManager.farmerCost);
                    farmerManager.costUpgradeCost *= 3f;
                }
                break;
            case UPGRADE_TYPE.BARISTA_BREW:
                if(rManager.BuyUpgrade(baristaManager.brewUpgradeCost)) {
                    baristaManager.coffeeBrewSpeed = calculateBonus(baristaManager.coffeeBrewSpeed);
                    baristaManager.brewUpgradeCost *= 3f;
                }
                break;
            case UPGRADE_TYPE.BARISTA_SELL:
                if(rManager.BuyUpgrade(baristaManager.sellUpgradeCost)) {
                    baristaManager.coffeeSellSpeed = calculateBonus(baristaManager.coffeeSellSpeed);
                    baristaManager.sellUpgradeCost *= 3f;
                }
                break;
            case UPGRADE_TYPE.BARISTA_COST:
                if(rManager.BuyUpgrade(baristaManager.costUpgradeCost)) {
                    baristaManager.baristaCost = calculateBonus(baristaManager.baristaCost);
                    baristaManager.costUpgradeCost *= 3f;
                }
                break;
            default:
                break;
        }
    }
}
