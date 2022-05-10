using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour {

    private static gameMaster instance;
    public Vector2 lastCheckPointPos;
    public int Score = 0;
	// Use this for initialization
	void Awake() {
		if(instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
	}

}
