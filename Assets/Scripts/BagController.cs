using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour {


    public static bool isPaintBool;//可種植bool
    public new static string name;//作物名稱
    public static int PainTime;//此作物種植所需時間
    void Awake () {
        isPaintBool = false;
        
    }



    public void Button_Click_Close() {
        gameObject.SetActive(false);
        isPaintBool = false;
    }
    //漢堡
    public void Button_Click_Hamburger() {
        //假如錢夠
        isPaintBool = true;
        name = "漢堡";
        PainTime = 1;
    }
    //漢堡(暫時)
    public void Button_Click_Hamburger2()
    {
        //假如錢夠
        isPaintBool = true;
        name = "漢堡";
        PainTime = 1;
    }
    public void Button_Click_Hamburger3()
    {
        //假如錢夠
        isPaintBool = true;
        name = "漢堡";
        PainTime = 1;
    }
}
