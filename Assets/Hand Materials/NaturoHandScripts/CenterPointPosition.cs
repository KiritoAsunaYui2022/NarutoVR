using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPointPosition : MonoBehaviour
{
    public GameObject RightHandAnchor;
    public GameObject LeftHandAnchor;
    public GameObject CenterPoint;

    public float x;
    public float y;
    public float z;

    public Vector3 averagePosition;

    void Update()
    {
        x = (RightHandAnchor.transform.position.x + LeftHandAnchor.transform.position.x) / 2f;
        y = (RightHandAnchor.transform.position.y + LeftHandAnchor.transform.position.y) / 2f;
        z = (RightHandAnchor.transform.position.z + LeftHandAnchor.transform.position.z) / 2f;

        averagePosition = new Vector3(x, y, z);

        CenterPoint.transform.position = averagePosition;
    }
}
