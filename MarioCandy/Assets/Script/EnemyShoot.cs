using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    [SerializeField]
    public GameObject bullet;
    Transform player;
	// Use this for initialization
	void Start () {
        StartCoroutine(Attack());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        Instantiate(bullet, transform.position, transform.rotation);
        StartCoroutine(Attack());
    }
}
