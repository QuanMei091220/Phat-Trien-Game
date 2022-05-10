using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private gameMaster GM;
    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("gameMaster").GetComponent<gameMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jumper"))
        {
            Debug.Log("Player cham spider");
            GM.lastCheckPointPos = transform.position;
        }
    }
}

