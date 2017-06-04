using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PaintStatus : MonoBehaviour {

    /*private string paintname;
    private UISprite painter;
    //private Status status;
    //金錢
    public int Coin;
    private UILabel CoinLabel;
    //是否成熟
    private bool IsMature;
    //顯示距離成熟時間Text
    private UILabel MatureTimeText;
    //顯示計時
    private bool isShowTime;
    private int i;*/

    // Use this for initialization
    /*void Start () {
        CoinLabel = GameObject.Find("CoinLabel").GetComponent<UILabel>();
        painter = FarmStatus._instance.painter;
        status = FarmStatus._instance.status;
        MatureTimeText = GameObject.Find("TimeSpan").GetComponent<UILabel>();
        
    }
	
	// Update is called once per frame
	void Update () {
        CoinLabel.text = Coin.ToString();
        if (isShowTime == true) {
            i++;
            MatureTimeText.enabled = true;
            if (i >= 70) {
                isShowTime = false;
                MatureTimeText.enabled = false;
                i = 0;
            }
        }
        print(Coin);

    }
    public void GetPainter() {
        if (painter.spriteName == "漢堡2")
        {
            painter.spriteName = "null";
            Coin += 100;
            
            
        }
        else if (painter.spriteName == "漢堡" && isShowTime == false) {
            if (((int)1 - FarmStatus._instance.AfterPaintTime) >= 1)
            {
                MatureTimeText.text = "還要等" + (Mathf.Floor((int)(1 - FarmStatus._instance.AfterPaintTime))).ToString() + "分鐘";
                isShowTime = true;
            }
            else {
                MatureTimeText.text = "還要等" + ((int)(60 -  (DateTime.Now - FarmStatus._instance.StartPaintTime).TotalSeconds)).ToString() + "秒鐘";
                isShowTime = true;
            }
            
        }
    }*/
}
