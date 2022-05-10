using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgQuadScolling : MonoBehaviour
{
    public float speed = 1f;
    public Material mat;
    private Vector2 offset = Vector2.zero;
    private void Awake()
    {
        mat = GetComponent<Renderer>().material;

    }
     void Start()
    {
        offset = mat.GetTextureOffset("_MainTex");

    }
     void Update()
    {
         offset.x = speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }

}
