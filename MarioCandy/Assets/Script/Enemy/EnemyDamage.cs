using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    float damageRate = 0.5f;
    float pushBackForce;
    float nextDamage;
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Enemy chạm vào nhân vật thì mất máu
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHeart thePlayerHeart = collision.gameObject.GetComponent<PlayerHeart>();
            thePlayerHeart.AddDamage(damage);
            nextDamage = damageRate + Time.time;
            pushBack(collision.transform);
        }
    }
    //chạm vào nhân vật cho nó văng
    public void pushBack(Transform pushObject)
    {
        Vector2 pushDrirection = new Vector2(0, (pushObject.position.y - transform.position.y)).normalized;
        pushDrirection *= pushBackForce;
        Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDrirection, ForceMode2D.Impulse);
    }
}
