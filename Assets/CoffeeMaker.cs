using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : MonoBehaviour {
    
    public int coffeePerClick = 1;
    ResourceManager rManager;

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown() {
        Debug.Log("Coffee Maker clicked!");
        rManager.MakeCoffee();
    }
}
