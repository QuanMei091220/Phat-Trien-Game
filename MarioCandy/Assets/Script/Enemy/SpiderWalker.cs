using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPos;
    private bool collision;
    public float speed = 1f;
    private Rigidbody2D myBody;
    // public static Vector2 lastCheckPointPos = new Vector2(-92, 0);
    public int CurrentyHealth;
    public int MaxHealth = 100;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        //CheckPoint
       // GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    void Start()
    {
        CurrentyHealth = MaxHealth;
    }
    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        //Debug.DrawLine(startPos.position, endPos.position, Color.green);
        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f)
            {
                temp.x = -1f;
            }
            else
            {
                temp.x = 1f;
            }
            transform.localScale = temp;
        }
    }
    private void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }
    private void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            Destroy(target.gameObject);
        }
        
    }
    public void TakeDamage(int damage)
    {
        CurrentyHealth -= damage;
        if(CurrentyHealth <=0)
        {
            Destroy(gameObject);
        }
    }

}
