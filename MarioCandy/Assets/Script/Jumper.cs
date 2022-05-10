using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public int health = 10;
    void Update()
    {

        if (health < 0)
            Destroy(gameObject);

    }
    public void Damage(int dm)
    {
        health -= dm;

    }
}
