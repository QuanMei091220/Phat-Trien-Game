using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour {

    private gameMaster GM;
    void Start () {
        GM = GameObject.Find("gameMaster").GetComponent<gameMaster>();
        transform.position = GM.lastCheckPointPos;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
