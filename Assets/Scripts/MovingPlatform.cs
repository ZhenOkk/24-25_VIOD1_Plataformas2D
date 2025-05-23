using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject ObjetoAmover;

    public Transform StartPoint;
    public Transform FinishPoint;

    public float Speed;

    private Vector3 MoveUp;

    // Start is called before the first frame update
    void Start()
    {
        MoveUp = FinishPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoveUp, Speed * Time.deltaTime);

        if (ObjetoAmover.transform.position == FinishPoint.position)
        {
            MoveUp = StartPoint.position;
        }
        if (ObjetoAmover.transform.position == StartPoint.position)
        {
            MoveUp = FinishPoint.position;
        }
    }
}
