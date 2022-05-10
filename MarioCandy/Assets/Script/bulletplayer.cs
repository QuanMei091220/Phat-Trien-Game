using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletplayer : MonoBehaviour
{
    public int direction = 1; // hướng nhìn của nhân vật
    private bool shooted = false;

    private void Update()
    {
        if (shooted)
            Attack();

    }
    public void Shoot(int dir)
    {
        direction = dir;
        shooted = true;
    }
    void Attack()
    {
        Vector2 temp = transform.position; //lấy giá trị biến đứng của máy bắn súng
        temp.x += direction * 5 * Time.deltaTime; //di chuyển vật thể
        transform.position = temp;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Jumper")
        {
            collision.gameObject.SendMessageUpwards("Damage", 1f);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
