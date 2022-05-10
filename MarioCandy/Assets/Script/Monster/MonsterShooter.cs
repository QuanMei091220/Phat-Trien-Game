using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MonsterShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 1)); //Từ 2 đến 7s sẽ bắn 1 lần
        Instantiate(Bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
        }
    }
}
