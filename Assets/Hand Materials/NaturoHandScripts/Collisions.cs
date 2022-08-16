using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {

        if (collisionInfo.collider.name == "StoneL" || collisionInfo.collider.name == "StoneR")
        {
            print("Dummy Hit!");
        }

    }


    void Update()
    {
        
    }
}
