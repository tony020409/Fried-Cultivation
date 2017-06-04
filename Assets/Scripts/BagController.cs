using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour {


    public static bool isPaintBool;//可種植bool
    public new static string name;//作物名稱
    public static int math; //作物數量

    
    //各作物數量int
    public static int Hamburger_Math = 0;//漢堡數量
    

    void Awake () {
        isPaintBool = false;
        Hamburger_Math = PlayerPrefs.GetInt("漢堡數量");
    }
    void Start()
    {
        
    }


    public void Button_BagClick_Close() {
        gameObject.SetActive(false);
        isPaintBool = false;
    }


    //購買按鈕
    public void ButtonBuy_Click_Hamburger()
    {
        //假如作物數量 > 0
        if (PlayerData.Coin >= 10)
        {
            Hamburger_Math++;
            PlayerData.Coin -= 10;
        }

    }
    public void ButtonBuy_Click_Hamburger2()
    {
        //假如作物數量 > 0
        if (PlayerData.Coin >= 20)
        {
            Hamburger_Math++;
            PlayerData.Coin -= 20;
        }

    }
    public void ButtonBuy_Click_Hamburger3()
    {
        //假如作物數量 > 0
        if (PlayerData.Coin >= 50)
        {
            Hamburger_Math++;
            PlayerData.Coin -= 50;
        }

    }




    //種植按鈕

    //漢堡
    public void ButtonPaint_Click_Hamburger() {
        //假如作物數量 > 0
        if (Hamburger_Math > 0)
        {
            isPaintBool = true;
            name = "漢堡";
            math = Hamburger_Math;
        }

    }
    //漢堡(暫時)
    public void ButtonPaint_Click_Hamburger2()
    {
        //假如作物數量 > 0
        if (Hamburger_Math > 0)
        {
            isPaintBool = true;
            name = "漢堡";
            math = Hamburger_Math;
        }
        else {
            //數量不足
        }
    }
    public void ButtonPaint_Click_Hamburger3()
    {
        //假如作物數量 > 1
        if (Hamburger_Math > 0)
        {
            isPaintBool = true;
            name = "漢堡";
            math = Hamburger_Math;
        }
        else
        {
            //數量不足
        }
    }
    //種植後扣除作物數量
    public static void Math_Pay() {
        switch (name) {
            case "漢堡":
                Hamburger_Math--;
                math = Hamburger_Math;
                break;
        }
        if (math == 0)
        {
            isPaintBool = false;
        }
    }

    //儲存作物數量
    void OnApplicationQuit() {
        PlayerPrefs.SetInt("漢堡數量",Hamburger_Math);
    }





}
