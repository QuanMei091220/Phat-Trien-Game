using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    public float maxVelocity = 4f;
    public float speed = 10f;
    // Use this for initialization
    private Rigidbody2D mybody;

    [SerializeField]
    private GameObject bullet;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();


        if (Input.GetKeyUp(KeyCode.Z))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void Move()
    {

        float forceX = 0f;
        float vel = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < maxVelocity) forceX = speed;
        }
        else if (h < 0)
        {
            if (vel < maxVelocity) forceX = -speed;
        }

        mybody.AddForce(new Vector2(forceX, 0));
    }


}