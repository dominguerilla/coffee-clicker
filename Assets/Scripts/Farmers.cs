using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmers : MonoBehaviour {

    public static Farmers instance = null;

    public int farmers;
    public float farmerCost = 20f;

    [Header("Upgrade Costs")]
    public float harvestUpgradeCost = 400f;
    public float costUpgradeCost = 600f;

    /// <summary>
    /// The amount of beans harvested per five seconds.
    /// </summary>
    public float beanHarvestSpeed = 3;

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
        StartCoroutine(UpdateBeans());
	}

    IEnumerator UpdateBeans() {
        while(true) {
            rManager.coffeeBeans += (farmers * beanHarvestSpeed) / 5;
            yield return new WaitForSeconds(1.0f);
        } 
    }

    public void HireFarmer() {
        if(rManager.money >= farmerCost) {
            rManager.money -= farmerCost;
            farmers += 1;
        }
    }
}
