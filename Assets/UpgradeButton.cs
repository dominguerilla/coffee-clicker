using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeButton : MonoBehaviour {

    public UpgradeManager.UPGRADE_TYPE UpgradeType;

    UpgradeManager uManager;
	UIUpdater uiUpdater;
    EventTrigger eTrigger;

    // Use this for initialization
	void Start () {
		uManager = UpgradeManager.instance;
        uiUpdater = UIUpdater.instance;
        eTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry updateUIEntry = new EventTrigger.Entry();
        updateUIEntry.eventID = EventTriggerType.PointerEnter;
        updateUIEntry.callback.AddListener((data) => { UpdateUI(); });

        EventTrigger.Entry resetEntry = new EventTrigger.Entry();
        resetEntry.eventID = EventTriggerType.PointerExit;
        resetEntry.callback.AddListener((data) => { ResetPriceText(); });

        eTrigger.triggers.Add(updateUIEntry);
        eTrigger.triggers.Add(resetEntry);
    }

    public void Upgrade() {
        uManager.Upgrade(UpgradeType);
    }

    private void UpdateUI() {
        float cost = uManager.getUpgradePrice(UpgradeType);
        uiUpdater.SetHoveredButton(this, cost);
    }

    private void ResetPriceText() {
        uiUpdater.ClearHoveredButton(this);
    }
}
