using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoffeePlant : MonoBehaviour {

    public int beansPerClick = 1;
    public Vector3 shrinkSize = new Vector3(0.5f, 0.5f, 0.5f);
    public float shrinkSpeed = 1.0f;
    ResourceManager rManager;
    Vector3 originalScale;

	// Use this for initialization
	void Start () {
	    rManager = ResourceManager.instance;	
        originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject()) {
            rManager.coffeeBeans += beansPerClick;
            SwellDown();
        }
    }
    
    
    private void OnMouseUp() {
        SwellUp();
    }

    void SwellDown() {
        transform.localScale = shrinkSize;
    }

    void SwellUp() {
        transform.localScale = originalScale;
    }
}
