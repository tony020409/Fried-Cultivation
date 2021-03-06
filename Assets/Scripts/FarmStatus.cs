﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public enum Status {
    //空,種植,收成 狀態
    Null,
    Painting,
    Geting

}


public class FarmStatus : MonoBehaviour {

    private Status status;//田中作物狀態
    private GameObject bag;//包包
    public UISprite Painter;//作物圖片
    private int PaintTime;//作物所需時間
    private DateTime StartPaintTime;//作物種植的時間點;
    private TimeSpan AfterPaintTime;//作物經過的時間;

    
    private int FoodNeedTime;//食物成熟所需時間
    private int FoodCoin;//食物可獲得金錢
    private string FoodGroupSprite;//作物成熟圖名稱

    private TweenScale tweenscale;//作物大小變化
    //提示剩餘時間
    private UILabel Time_Label;//剩餘時間label
    private bool IsShowLabel;//showlabel bool;
    private int Timer_ForLabel;//label倒數計時器

    // Use this for initialization
    void Awake () {
        bag = GameObject.Find("Bag");
        tweenscale = transform.Find("Painter").GetComponent<TweenScale>();
        Time_Label = transform.Find("Label").GetComponent<UILabel>();

    }
    void Start()
    {
        if (PlayerPrefs.GetString(gameObject.name + "作物名稱") == "")
        {
            Painter.spriteName = "null";
        }
        else
        {
            
            Painter.spriteName = PlayerPrefs.GetString(gameObject.name + "作物名稱");
            GetFoodData();//取得食物資料
        }
        if (PlayerPrefs.GetString(gameObject.name + "開始種植時間") == "")
        {

        }
        else
        {
            StartPaintTime = System.DateTime.FromBinary(System.Convert.ToInt64(PlayerPrefs.GetString(gameObject.name + "開始種植時間")));
            
        }
        if (PlayerPrefs.GetString(gameObject.name + "田狀態") == "")
        {
            status = Status.Null;

        }
        else
        {
            status = (Status)System.Enum.Parse(typeof(Status), PlayerPrefs.GetString(gameObject.name + "田狀態"));
        }
        

 
    }

    // Update is called once per frame
    void Update () {
        
        if (BagController.isPaintBool == true && status == Status.Null)//農田為空,可種植
        {
            gameObject.GetComponent<UISprite>().color = Color.green;
        }
        else if (BagController.isPaintBool == true && status == Status.Painting)//農田為種植狀態,不可種植
        {
            gameObject.GetComponent<UISprite>().color = Color.red;
        }
        else if (BagController.isPaintBool == true && status == Status.Geting)//農田為可採收狀態
        {
            gameObject.GetComponent<UISprite>().color = Color.red;
        }
        else {
            gameObject.GetComponent<UISprite>().color = Color.white;
        }

        //
        if (status == Status.Painting) {
            //剩下5秒的時候
            if ((FoodNeedTime * 60) - (DateTime.Now - StartPaintTime).TotalSeconds <= 1)   {
                tweenscale.PlayForward();
            }
            if ((DateTime.Now - StartPaintTime).TotalMinutes >= FoodNeedTime) {
                //進入成熟狀態
                tweenscale.PlayReverse();
                Painter.spriteName = FoodGroupSprite;//取得成熟圖
                GetFoodData();//取得食物資料
                status = Status.Geting;//轉換為成熟狀態
                
                
            }
        }

        //提示剩餘時間
        if (IsShowLabel == true) {
            Timer_ForLabel++;

                if ((DateTime.Now - StartPaintTime).TotalMinutes > 1)
                {
                    Time_Label.enabled = true;
                    Time_Label.text = "離成熟還有" + (60 - Mathf.Floor((int)(DateTime.Now - StartPaintTime).TotalMinutes)).ToString() + "分";


                }

                if ((DateTime.Now - StartPaintTime).TotalMinutes <= 1)
                {
                    Time_Label.enabled = true;
                    Time_Label.text = "離成熟還有" + (60 - Mathf.Floor((int)(DateTime.Now - StartPaintTime).TotalSeconds)).ToString() + "秒";
                }

            if (Timer_ForLabel >= 70) {
                IsShowLabel = false;
                Time_Label.enabled = false;
                Timer_ForLabel = 0;
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
            else if (BagController.isPaintBool == true)//是種植bool
            {

                if (BagController.math > 0)
                {
                    Painter.spriteName = BagController.name;//取得種植名稱資料
                    GetFoodData();//取得食物資料
                    StartPaintTime = DateTime.Now;//種植起始時間 為 現在時間
                    status = Status.Painting;//轉換為種植狀態
                    BagController.Math_Pay();

                }


            }
        }
        else if (status == Status.Painting)//種植中 狀態
        {

            //顯示 距離可收成時間還有多久
            IsShowLabel = true;
        }
        else if (status == Status.Geting)//可收成 狀態
        {
            GetFoodCoinData();
            PlayerData.Coin += FoodCoin; //玩家金幣增加+=;
            Painter.spriteName = "null"; //圖片轉換為 空照片
            status = Status.Null;//轉換為空狀態
            

            
        }
    }
    //取得作物資料
    private void GetFoodData() {
        string foodname;
        foodname = Painter.spriteName;
        switch (foodname) {
            case "漢堡":
            FoodNeedTime =  1;
            FoodGroupSprite = "漢堡2";
            break;
        }
    }
    //取得作物金錢資料
    private void GetFoodCoinData() {
        string foodname;
        foodname = Painter.spriteName;
        switch (foodname) {
            case "漢堡2":
            FoodCoin = 10;
            break;
        }
        

    }



    //儲存資料
    void OnApplicationQuit()
    {

        PlayerPrefs.SetString(gameObject.name + "作物名稱", Painter.spriteName);
        PlayerPrefs.SetString(gameObject.name + "田狀態", status.ToString());
        PlayerPrefs.SetString(gameObject.name + "開始種植時間", StartPaintTime.ToBinary().ToString());
        
    }
}
