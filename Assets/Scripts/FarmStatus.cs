using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Status {
    //空,種植,收成 狀態
    Null,
    Painting,
    Geting

}

public class FarmStatus : MonoBehaviour {

    private Status status;//狀態
    private GameObject bag;//包包
    public UISprite Painter;//作物圖片
    private int PaintTime;//作物所需時間
    private DateTime StartPaintTime;//作物種植的時間點;
    private TimeSpan AfterPaintTime;//作物經過的時間;

	// Use this for initialization
	void Awake () {
        bag = GameObject.Find("Bag");
        
       
	}
	
	// Update is called once per frame
	void Update () {
        if (BagController.isPaintBool == true && status == Status.Null)
        {
            gameObject.GetComponent<UISprite>().color = Color.green;
        }
        else if (BagController.isPaintBool == true && status == Status.Painting)
        {
            gameObject.GetComponent<UISprite>().color = Color.red;
        }
        else if (BagController.isPaintBool == true && status == Status.Geting)
        {
            gameObject.GetComponent<UISprite>().color = Color.red;
        }
        else {
            gameObject.GetComponent<UISprite>().color = Color.white;
        }

        //
        if (status == Status.Painting) {
            if ((DateTime.Now - StartPaintTime).TotalMinutes >= 1) {
                print("成熟了");
            }
        }
    }
    //第一次點擊田
    public void FarmClick() {
        if (status == Status.Null)//無作物 狀態
        {
            if (BagController.isPaintBool == false)//不是種植bool
            {
                bag.SetActive(true);
            }
            else if(BagController.isPaintBool == true)//是種植bool
            {
                Painter.spriteName = BagController.name;
                StartPaintTime = DateTime.Now;
                status = Status.Painting;
            }
        }
        else if (status == Status.Painting)//種植中 狀態
        {

        }
        else if (status == Status.Geting)//可收成 狀態
        {

        }
    }
    
}
