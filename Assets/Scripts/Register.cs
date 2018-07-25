using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PrefabEmitter))]
public class Register : MonoBehaviour{

    public int coffeeSoldPerClick = 1;
    public float upgradeCost = 300f;

    ResourceManager rManager;
    PrefabEmitter emitter;
    [SerializeField]
    Customer currentCustomer;

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;	
        emitter = GetComponent<PrefabEmitter>();
	}

    private void OnMouseDown() {
        if(rManager.SellCoffeeClick(currentCustomer))
            emitter.Emit();
    }
}
