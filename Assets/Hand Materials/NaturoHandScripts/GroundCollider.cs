using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{

    public JutsuScroll scroll;

    public void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Ground Collider")
        {
            //print("Ground");
            scroll.touchGround = true;
        }
        
    }


    public void OnCollisionExit(Collision collisionInfo)
    {
        scroll.touchGround = false;
    }

    public void Update()
    {
        //print("Touch Ground = " + scroll.touchGround);
    }
}
