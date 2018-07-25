using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour{

    public int coffeeSoldPerClick = 1;
    public float upgradeCost = 300f;

    ResourceManager rManager;
    [SerializeField]
    Customer currentCustomer;

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;	
	}

    private void OnMouseDown() {
        rManager.SellCoffee(currentCustomer);
    }
}
