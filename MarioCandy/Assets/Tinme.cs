using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tinme : MonoBehaviour
{
    Image timeBar;
    public float MaxTime = 5f;
    float timeLeft;
    public GameObject timeUpText;

    // Start is called before the first frame update
    void Start()
    {
        timeUpText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = MaxTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / MaxTime;
        }
        else
        {
            timeUpText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
