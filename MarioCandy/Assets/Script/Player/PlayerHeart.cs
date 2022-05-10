using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeart : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject blood;

    public Slider playerHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if (damage <= 0) return;
        
            currentHealth -= damage;//nhan damage
            playerHealthSlider.value = currentHealth; //giam thanh mau
            //nhan vat die
            if(currentHealth <= 0)
            {
                makeDead();
            }

        
    }
    //làm cho con nhân vật nó chết
    public void makeDead()
    {
        Destroy(gameObject);
        GameObject.Find("GamePlayController").GetComponent<GameplayController>().PlayDie();
    }
}
