using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoffeePlant : MonoBehaviour {

    public int beansPerClick = 1;
    public float upgradeCost = 100f;
    ResourceManager rManager;

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;	
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject()) {
            rManager.coffeeBeans += beansPerClick;
        }
    }
    
}
