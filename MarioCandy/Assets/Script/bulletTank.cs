using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTank : MonoBehaviour
{
    public float speedBullet;
    public Rigidbody2D myBody;
    public Collider2D myCollider;
    public int damage = 40;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if(transform.position.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * speedBullet, ForceMode2D.Impulse); //trái
        } else
        {
            myBody.AddForce(new Vector2(1, 0) * speedBullet, ForceMode2D.Impulse); //phải
        }
    }
    // phai su dung trigger cho bullet, nếu không sẽ đẩy bullet bật ngươc

    void Update()
    {
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        SpiderWalker enemy = collision.GetComponent<SpiderWalker>(); 
        if (enemy != null) // để cho nó va chạm biến enemy
        {
            enemy.TakeDamage(damage);  //viên đạn chạm vào nhân vật biến mất

            Destroy(gameObject);
        }
      
    }
    public void removeForce() // bulllet đứng yên
    {
        myBody.velocity = new Vector2(0, 0); //vận tốc
    }
    

}

