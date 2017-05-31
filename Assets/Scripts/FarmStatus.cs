using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {
    //空,種植,收成 狀態
    Null,
    Painting,
    Geting

}

public class FarmStatus : MonoBehaviour {

    private Status status;//狀態


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //第一次點擊田
    public void FarmClick() {
        if (status == Status.Null) {

        }
    }
}
