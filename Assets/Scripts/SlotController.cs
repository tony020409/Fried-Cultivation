using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour {

    private UISprite Icon; //作物圖案
    private UILabel Math_Label; //作物數量label
    private int math;//作物數量

	// Use this for initialization
	void Awake () {
        Icon = transform.Find("Icon").GetComponent<UISprite>();
        Math_Label = transform.Find("Math").GetComponent<UILabel>();
        
	}
	
	// Update is called once per frame
	void Update () {
        GetFoodDate();
        Math_Label.text = "數量 : " + math; 
	}

    private void GetFoodDate() {
        switch (Icon.spriteName) {
            case "漢堡":
                math = BagController.Hamburger_Math;
                break;
        }
        
    }
}
