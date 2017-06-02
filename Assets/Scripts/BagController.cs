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
        
    }
    void Start()
    {
        Hamburger_Math = 5;
    }


    public void Button_Click_Close() {
        gameObject.SetActive(false);
        isPaintBool = false;
    }
    //漢堡
    public void Button_Click_Hamburger() {
        //假如作物數量 > 0
        if (Hamburger_Math > 0)
        {
            isPaintBool = true;
            name = "漢堡";
            math = Hamburger_Math;
        }

    }
    //漢堡(暫時)
    public void Button_Click_Hamburger2()
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
    public void Button_Click_Hamburger3()
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

}
