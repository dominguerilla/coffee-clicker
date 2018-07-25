using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {

    public UpgradeManager.UPGRADE_TYPE UpgradeType;

    UpgradeManager uManager;
	
    // Use this for initialization
	void Start () {
		uManager = UpgradeManager.instance;
	}

    public void Upgrade() {
        uManager.Upgrade(UpgradeType);
    }
}
