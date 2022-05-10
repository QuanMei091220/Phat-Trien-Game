using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaformFLPath : MonoBehaviour
{
    public Path thePath;
    public float speed;
    private Transform point;

    // Start is called before the first frame update
    void Start()
    {
        if (thePath == null)
            return;

        transform.position = thePath.getPoint(0).position;
        point = thePath.getNextPoint();

       //transform.position = thePath.getPoint(0).position; //bo dong nay
        //point = thePath.getPoint(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (thePath == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

        var distanceTarge = (transform.position - point.position).sqrMagnitude;
        if (distanceTarge < 0.1f)
        {
            //di chuyen den diem tiep theo
            point = thePath.getNextPoint();
        }
    }
}
