using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    private UILabel Coin_Label;//金錢label

    public static int Coin;//玩家金錢
	// Use this for initialization
	void Awake () {
        Coin_Label = GameObject.Find("Coin_Label").GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        Coin_Label.text = Coin.ToString();
	}
}
