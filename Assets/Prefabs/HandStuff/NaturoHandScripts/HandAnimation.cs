using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    public HandJutsu hands; 

    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;

    public GameObject RightHandPosition; 
    public GameObject RightHandAnchor; 

    public GameObject LeftHandPosition;
    public GameObject LeftHandAnchor; 

    public Animator RightHand;
    public Animator LeftHand;

    public bool monkey;
    public bool bird;
    public bool ram;
    public bool serpant;
    public bool tiger;
    public bool rat;
    public bool boar;
    public bool dragon;
    public bool horse;
    public bool ox;
    public bool hare;
    public bool dog; 

    public void MonkeyPose()
    {
        RightHand.SetBool("Monkey", monkey);
        LeftHand.SetBool("Monkey", monkey);

        //Lerps the Right Hand to "bottom" position if monkey = true OR Lerps the Right Hand back to the Right Hand Anchor (starting position) if monkey = false 
        RightHandPosition.transform.position = monkey ? Vector3.Lerp(RightHandPosition.transform.position, bottom.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = monkey ? Vector3.Lerp(LeftHandPosition.transform.position, top.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);

    }

    public void BirdPose()
    {
        RightHand.SetBool("Bird", bird);
        LeftHand.SetBool("Bird", bird);

        RightHandPosition.transform.position = bird ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = bird ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    } 

    public void BoarPose()
    {
        RightHand.SetBool("Boar", boar);
        LeftHand.SetBool("Boar", boar);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    //Dog uses Monkey for Right Hand 
    public void DogPose()
    {
        RightHand.SetBool("Boar", boar);
        LeftHand.SetBool("Monkey", monkey);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, top.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = monkey ? Vector3.Lerp(LeftHandPosition.transform.position, bottom.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    public void DragonPose()
    {
        RightHand.SetBool("Dragon", dragon);
        LeftHand.SetBool("Dragon", dragon);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    public void HarePose()
    {
        RightHand.SetBool("Hare", hare);
        LeftHand.SetBool("Hare", hare);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    public void HorsePose()
    {
        RightHand.SetBool("Horse", horse);
        LeftHand.SetBool("Horse", horse);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    //Ox uses Monkey for Right Hand 
    public void OxPose()
    {
        RightHand.SetBool("Monkey", monkey);
        LeftHand.SetBool("Ox", ox);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, top.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, bottom.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    public void RamPose()
    {
        RightHand.SetBool("Ram", ram);
        LeftHand.SetBool("Ram", ram);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    public void RatPose()
    {
        RightHand.SetBool("Rat", rat);
        LeftHand.SetBool("Rat", rat);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, top.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, bottom.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    public void SerpantPose()
    {
        RightHand.SetBool("Serpant", serpant);
        LeftHand.SetBool("Serpant", serpant);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }

    public void TigerPose()
    {
        RightHand.SetBool("Tiger", tiger);
        LeftHand.SetBool("Tiger", tiger);

        RightHandPosition.transform.position = boar ? Vector3.Lerp(RightHandPosition.transform.position, right.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(RightHandPosition.transform.position, RightHandAnchor.transform.position, 5f * Time.deltaTime);

        LeftHandPosition.transform.position = boar ? Vector3.Lerp(LeftHandPosition.transform.position, left.transform.position, 5f * Time.deltaTime) : Vector3.Lerp(LeftHandPosition.transform.position, LeftHandAnchor.transform.position, 5f * Time.deltaTime);
    }
    
    public void Update() 
    {
        MonkeyPose(); 
        BirdPose(); 
        BoarPose(); 
        DogPose(); 
        DragonPose(); 
        HarePose(); 
        HorsePose(); 
        OxPose(); 
        RamPose(); 
        RatPose(); 
        SerpantPose(); 
        TigerPose(); 
    }
}