using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PrefabEmitter))]
public class CoffeePlant : MonoBehaviour {

    public int beansPerClick = 1;
    public float upgradeCost = 100f;
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

    private void OnMouseDown() {
        rManager.coffeeBeans += beansPerClick;
        emitter.Emit();
        
    }
    
}
