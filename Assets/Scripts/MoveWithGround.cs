using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithGround : MonoBehaviour
{

    public LayerMask layerMask;

    public Rayo[] rayos;

    [Serializable]
    public struct Rayo
    {
        public Vector3 origen;
        public Vector3 direction;
        public float distance;
    }

    public bool grounded;
    void Update()
    {
        grounded = false;
        GameObject MovingGround = null;
        foreach (Rayo rayo in rayos)
        {
            Debug.DrawRay(
             transform.position + rayo.origen,
             rayo.direction.normalized * rayo.distance,
             Color.red);

            RaycastHit2D hit =
                Physics2D.Raycast(
                    transform.position + rayo.origen,
                    rayo.direction.normalized,
                    rayo.distance,
                    layerMask);

            if (hit.collider != null)
            {
                Debug.DrawRay(
                    transform.position + rayo.origen,
                    rayo.direction.normalized * rayo.distance,
                    Color.green);
                grounded = true;

                if (hit.collider.tag == "MovingGround")
                {
                    MovingGround = hit.collider.gameObject;
                }
            }
        }

        if (MovingGround != null)
        {
            transform.parent = MovingGround.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
}
