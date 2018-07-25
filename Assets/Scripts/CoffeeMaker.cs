using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PrefabEmitter))]
public class CoffeeMaker : MonoBehaviour {
    
    public int coffeePerClick = 1;
    public float upgradeCost = 200f;
    ResourceManager rManager;
    PrefabEmitter emitter;

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;	
        emitter = GetComponent<PrefabEmitter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown() {
        if(rManager.BrewCoffeeClick())
            emitter.Emit();
    }
}
