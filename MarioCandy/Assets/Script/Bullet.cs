using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bulletTank myPC;
    public GameObject bulletExpction;

    public void Awake()
    {
        myPC = GetComponentInParent<bulletTank>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)//chạy 1 lần bullet nếu layer còn
    {
        if (other.gameObject.tag == "Enemy"){//vật thể va chạm mang tag Enemy thì code chạy ở dưới
            myPC.removeForce();
            Instantiate(bulletExpction, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
    public void OnTriggerStay2D(Collider2D other)// chạy tiếp diễn bulet nếu layer còn
    {
        if (other.gameObject.tag == "Enemy")
        {
            myPC.removeForce();
            Instantiate(bulletExpction, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
