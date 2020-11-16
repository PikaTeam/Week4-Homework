using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLoopMover : MonoBehaviour
{
    public float speed = 3f;
    public float lineLength = 10;

    private bool isGoingLeft = true;
    private Vector3 origin;

    private void Start()
    {
        this.origin = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGoingLeft)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            if (Mathf.Abs(origin.x - transform.position.x) > lineLength)
                isGoingLeft = false;
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

            if (Mathf.Abs(origin.x - transform.position.x) > lineLength)
                isGoingLeft = true;
        }
        
    }
}
