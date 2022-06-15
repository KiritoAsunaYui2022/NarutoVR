using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JutsuScroll : MonoBehaviour
{

    public HandJutsu hands;
    public string astra = "";
    public string astra_check = "";


    public Transform transPos;

    public Transform playerBody;


    //Game Logic 
    //Jutsu
    public bool shadowCloneJutsu = false;
    public bool earthStyleStoneFistJutsu = false;
    public bool firePhoenixFlowerStyleJutsu = false;
    public bool earthBarrierJutsu = false;
    public bool earthStyleMudWallJutsu = false;
    public bool fireStyleFireballJutsu = false;
    public bool windStyleVacuumBulletJutsu = false;
    public bool woodStyleTreeDomeJutsu = false; 


    public bool moveOn = true;
    public float count = 10f;

    //Fire Phoenix Flower Style
    public float spreadAngle = 10f;
    public GameObject phoenix;
    public Transform fist;
    List<Quaternion> phoenixFlock;
    public float phoenixFireVel = 1000f;
    public List<GameObject> phoenixClones = new List<GameObject>();


    //Earth Style Stone Fist Jutsu
    public GameObject stoneFistRight;
    public GameObject stoneFistLeft;
    public GameObject rightHand;
    public GameObject leftHand;


    //Shadow Clone Jutsu 
    public Transform playerHead;
    public GameObject shadowClone;
    public float shadowCloneCount = 0f;
    public bool limitShadowClone = false;


    //Earth Style Earth Barrier 
    //Uses playerHead;
    public GameObject earthBarrier;


    //Earth Style Mud Wall
    public GameObject mudWall;
    public bool touchGround = false;



    //Fire Style Fireball Jutsu 
    public Transform fireballPoint;
    public GameObject fireball;
    public float fireBallVel = 1000f;



    //Wind Style Vaccume Bullet Jutsu 
    public float windBulletGust = 0f;
    public GameObject windBullet;
    public float windBulletVelocity = 3000f;



    //Wood Style Tree Dome Jutsu 
    public GameObject woodDomeR;
    public GameObject woodDomeL;
    public Vector3 woodRight;
    public Vector3 woodLeft; 


    void Awake()
    {
        phoenixFlock = new List<Quaternion>();
        for (int i = 0; i < 10; i++)
        {
            phoenixFlock.Add(Quaternion.Euler(Vector3.zero));
        }

        woodRight = new Vector3(-270f, 0f, 0f);
        woodLeft = new Vector3(-270f, 7000f, 0f);
    }


    public void alphabet()
    {
        if (astra_check != astra)
        {
            print("Astra: " + astra);
            astra_check = astra;
        }

    }

    public void Jutsu()
    {

        if (firePhoenixFlowerStyleJutsu)
        {//&& OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger)
            while (count >= 0f && OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                count -= .1f;
                int i = 0;

                foreach (Quaternion quat in phoenixFlock)
                {
                    //GameObject b = new GameObject();
                    GameObject b;
                    phoenixFlock[i] = Random.rotation;
                    b = Instantiate(phoenix, fist.position, fist.rotation) as GameObject;
                    b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, phoenixFlock[i], spreadAngle);
                    b.GetComponent<Rigidbody>().AddForce(b.transform.forward * phoenixFireVel);
                    //phoenixFireVel
                    print(phoenixFireVel);
                    Destroy(b, .7f);
                    break;
                }

                astra = "";


                if (count <= 0f)
                {
                    firePhoenixFlowerStyleJutsu = false;
                    count = 10f;
                }
                break;


            }
        }

        if (earthStyleStoneFistJutsu)
        {
            var stoneFistLBreak = 0f;
            var stoneFistRBreak = 0f;



            //          child                          parent
            rightHand.transform.parent = GameObject.Find("Sphere").transform; 


            //while (stoneFistRBreak <= 5f && stoneFistLBreak <= 5f)
            //{

            //rightHand.SetActive(false);
            //leftHand.SetActive(false);


            //stoneFistRight.SetActive(true);
            //stoneFistLeft.SetActive(true);

            //if(collided x amount of times with high velocity)
            //{
            //StoneFistL(and)RBreak = StoneFistL(and)RBreak + 1f;
            //}
            //}

            astra = "";
            earthStyleStoneFistJutsu = false;
        }


        if (shadowCloneJutsu)
        {
            Vector3 flatAngleForward = new Vector3(playerHead.forward.x, 0f, playerHead.forward.z);
            Quaternion newFacing = Quaternion.LookRotation(flatAngleForward, Vector3.up);
            Vector3 flatAngleRight = new Vector3(flatAngleForward.z, 0f, -flatAngleForward.x);

            Vector3 spawnLocationA = playerHead.transform.position + (flatAngleForward) + (flatAngleRight * 4f);
            Vector3 spawnLocationB = playerHead.transform.position + (flatAngleForward) + (flatAngleRight * 2f);
            Vector3 spawnLocationC = playerHead.transform.position + (flatAngleForward) + (flatAngleRight * -2f);
            Vector3 spawnLocationD = playerHead.transform.position + (flatAngleForward) + (flatAngleRight * -4f);
            spawnLocationA.y = playerBody.position.y;
            spawnLocationB.y = playerBody.position.y;
            spawnLocationC.y = playerBody.position.y;
            spawnLocationD.y = playerBody.position.y;

            GameObject shadowCloneA = Instantiate(shadowClone, spawnLocationA, newFacing);
            GameObject shadowCloneB = Instantiate(shadowClone, spawnLocationB, newFacing);
            GameObject shadowCloneC = Instantiate(shadowClone, spawnLocationC, newFacing);
            GameObject shadowCloneD = Instantiate(shadowClone, spawnLocationD, newFacing);

            //shadowCloneCount = shadowCloneCount + 4f;

            astra = "";
            shadowCloneJutsu = false;
        }



        //EARTH STYLE EARTH BARRIER JUTSU 
        if (earthBarrierJutsu)
        {
            Vector3 flatAngleForward = new Vector3(playerHead.forward.x, 0f, playerHead.forward.z);
            Quaternion newFacing = Quaternion.LookRotation(flatAngleForward, Vector3.up);
            Vector3 flatAngleRight = new Vector3(flatAngleForward.z, 0f, -flatAngleForward.x);

            Vector3 spawnLocationA = playerHead.transform.position + (flatAngleForward * 3f) + (flatAngleRight * 1.5f);
            Vector3 spawnLocationB = playerHead.transform.position + (flatAngleForward * 4f) + (flatAngleRight * 1.2f);
            Vector3 spawnLocationC = playerHead.transform.position + (flatAngleForward * 4f) + (flatAngleRight * -1.2f);
            Vector3 spawnLocationD = playerHead.transform.position + (flatAngleForward * 3f) + (flatAngleRight * -1.5f);
            Vector3 spawnLocationE = playerHead.transform.position + (flatAngleForward * 3.5f) + (flatAngleRight * 0f);
            Vector3 spawnLocationF = playerHead.transform.position + (flatAngleForward * 4.5f) + (flatAngleRight * 0f);
            Vector3 spawnLocationG = playerHead.transform.position + (flatAngleForward * 3.5f) + (flatAngleRight * 2.8f);
            Vector3 spawnLocationH = playerHead.transform.position + (flatAngleForward * 3.5f) + (flatAngleRight * -2.8f);
            spawnLocationA.y = -2.3f;
            spawnLocationB.y = -2.3f;
            spawnLocationC.y = -2.3f;
            spawnLocationD.y = -2.3f;
            spawnLocationE.y = -2.3f;
            spawnLocationF.y = -2.3f;
            spawnLocationG.y = -2.3f;
            spawnLocationH.y = -2.3f;

            GameObject earthBarrierA = Instantiate(earthBarrier, spawnLocationA, newFacing);
            GameObject earthBarrierB = Instantiate(earthBarrier, spawnLocationB, newFacing);
            GameObject earthBarrierC = Instantiate(earthBarrier, spawnLocationC, newFacing);
            GameObject earthBarrierD = Instantiate(earthBarrier, spawnLocationD, newFacing);
            GameObject earthBarrierE = Instantiate(earthBarrier, spawnLocationE, newFacing);
            GameObject earthBarrierF = Instantiate(earthBarrier, spawnLocationF, newFacing);
            GameObject earthBarrierG = Instantiate(earthBarrier, spawnLocationG, newFacing);
            GameObject earthBarrierH = Instantiate(earthBarrier, spawnLocationH, newFacing);


            astra = "";
            earthBarrierJutsu = false;
        }


        if (earthStyleMudWallJutsu)
        {
            Vector3 flatAngleForward = new Vector3(playerHead.forward.x, 0f, playerHead.forward.z);
            Quaternion newFacing = Quaternion.LookRotation(flatAngleForward, Vector3.up);
            Vector3 flatAngleRight = new Vector3(flatAngleForward.z, 0f, -flatAngleForward.x);

            Vector3 spawnLocationA = playerHead.transform.position + (flatAngleForward * 1.5f) + (flatAngleRight * 0f);
            spawnLocationA.y = -2.7f;

            GameObject mudWallA = Instantiate(mudWall, spawnLocationA, newFacing);


            astra = "";
            earthStyleMudWallJutsu = false;
        }


        if (fireStyleFireballJutsu)
        {
            if (hands.tigerPos && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                //Instantiate Fireball Jutsu and set to false  
                GameObject fireBall1;
                fireBall1 = Instantiate(fireball, fireballPoint.position, fireballPoint.rotation) as GameObject;
                fireBall1.GetComponent<Rigidbody>().AddForce(fireBall1.transform.forward * phoenixFireVel);
                //print(fireball.transform.forward * fireballvelocity);

                astra = "";
                fireStyleFireballJutsu = false;
            }
        }


        if(windStyleVacuumBulletJutsu)
        {
            if (OVRInput.GetUp(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                astra = ""; 
                windBulletGust = windBulletGust + 1f;

                print(windBulletGust);

                GameObject windBulletA;
                windBulletA = Instantiate(windBullet, fist.position, fist.rotation) as GameObject;
                windBulletA.GetComponent<Rigidbody>().AddForce(windBulletA.transform.forward * windBulletVelocity); 
                
                if (windBulletGust == 5f) 
                {
                    print("Windbullets Done: " + windBulletGust);
                    windBulletGust = 0f;
                    windStyleVacuumBulletJutsu = false; 
                }
                
            }
        }



        if(woodStyleTreeDomeJutsu)
        {
            Vector3 flatAngleForward = new Vector3(playerHead.forward.x, 0f, playerHead.forward.z);
            Quaternion newFacingR = Quaternion.LookRotation(-flatAngleForward, woodRight);
            Quaternion newFacingL = Quaternion.LookRotation(-flatAngleForward, woodLeft);
            Vector3 flatAngleRight = new Vector3(flatAngleForward.z, 0f, -flatAngleForward.x);

            Vector3 spawnLocationA = playerHead.transform.position + (flatAngleForward * .5f) + (flatAngleRight * 0f);
            Vector3 spawnLocationB = playerHead.transform.position + (flatAngleForward * .5f) + (flatAngleRight * 0f);
            spawnLocationA.y = -3.6f;
            spawnLocationB.y = -3.68f;

            GameObject TreeDomeR = Instantiate(woodDomeR, spawnLocationA, newFacingR);
            GameObject TreeDomeL = Instantiate(woodDomeL, spawnLocationB, newFacingL);

            astra = "";
            woodStyleTreeDomeJutsu = false; 
        }
    }



    void FixedUpdate()
    {
        //rightHand.transform.position = TEMPsphere.transform.position; 

        stoneFistLeft.transform.position = leftHand.transform.position;
        stoneFistLeft.transform.rotation = leftHand.transform.rotation;

        Jutsu();
        alphabet();
        //print("Clone Count: " + shadowCloneCount);
        //print("Pos: " + playerBody.position);
        //print("Player Head: " + playerHead.position);


        if (shadowCloneCount == 8f)
        {
            limitShadowClone = true;
        }

        if (moveOn == true)
        {
            if (astra_check != astra)
            {
                print("Astra: " + astra);
                //print("S: " + buttonS);
                //print("A: " + buttonA);
                astra_check = astra;
            }
        }

        if (hands.disAreaThree == false)
        {
            astra = "";
        }

        if (astra == "MonkeyMonkeyMonkey")
        {
            print("Fire Phoenix Jutsu"); 
            phoenixClones.Clear();
            astra_check = "";
            moveOn = true;
            firePhoenixFlowerStyleJutsu = true;

        }

        if (astra == "BirdBirdBird" && limitShadowClone == false)
        {
            print("Shadow Clone Jutsu");
            astra_check = "";
            moveOn = true;
            shadowCloneJutsu = true;
        }

        else
        {
            //print("No More Shadow Clones");
            //astra_check = "";
            //astra = "";
            //moveOn = true;
        }

        //SerpantRamRatSerpantTiger
        if (astra == "MonkeyBirdMonkey")
        {
            print("Earth Style Stone Fist Jutsu");
            //Something?
            astra_check = "";
            moveOn = true;
            earthStyleStoneFistJutsu = true;
        }

        //RamTigerSerpantDogRatOxHorse 
        if (astra == "BirdMonkeyBird")
        {
            print("Earth Style Earth Barrier Jutsu");
            //Something?
            astra_check = "";
            moveOn = true;
            earthBarrierJutsu = true;
        }


        if (astra == "SerpantSerpantSerpant" && touchGround == true)
        {
            print("Earth Style Mud Wall Jutsu");
            //Something?
            astra_check = "";
            moveOn = true;
            earthStyleMudWallJutsu = true;
        }


        if (astra == "DogDogDog")
        {
            print("Fireball Jutsu");
            //Something?
            astra_check = "";
            moveOn = true;
            fireStyleFireballJutsu = true;
        }

        if(astra == "DogSerpantDog")
        {
            print("Wind Bullet Jutsu");
            //Something?
            astra_check = "";
            moveOn = true;
            windStyleVacuumBulletJutsu = true;
        }


        if(astra == "MonkeyDogMonkey")
        {
            print("Wood Dome Jutsu");
            //Something?
            astra_check = "";
            moveOn = true;
            woodStyleTreeDomeJutsu = true;
        }


        print("Astra: " + astra);
        //print("Astra_Check: " + astra_check);
    }
}
