using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightOfHands : MonoBehaviour
{
    public float cutoff = 100f;

    public bool TestCone(Vector3 inputPoint)
    {
        float cosAngle = Vector3.Dot((inputPoint - this.transform.position).normalized, this.transform.forward);

        float angle = Mathf.Acos(cosAngle) * Mathf.Rad2Deg;
        return angle > cutoff;
    }
}
