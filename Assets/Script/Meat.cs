using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Meat : MonoBehaviour
{
    private int cookTime;
    private int bestTimeBuff;
    private int coalTimeBuff;
    private Vector2 acceBuff;
    private bool isReachLazer;
    private bool isCharge;
    private bool isDestroy;

    public float maxX;
    public float maxZ;

    public int bestTime;
    public int coalTime;
    

    Rigidbody rb;

    private void Cook()
    {
        if(cookTime < bestTimeBuff)
        {
            return;
        }
        if(cookTime < coalTimeBuff)
        {
            this.tag = "cookedMeat";
            return;
        }
        this.tag = "coal";
    }
    private void AddCookTime(int addTime)
    {
        cookTime += addTime;
    }
    private void LazerAcceleration(Vector3 eyePos, Vector3 lazerPos)
    {
        Vector3 meatPos = GetComponent<Transform>().position;
        Vector3 distance = new Vector3(meatPos.x - eyePos.x, 0, meatPos.z - eyePos.z);
        acceBuff = new Vector2(acceBuff.x + distance.x/10, acceBuff.y + distance.z/10);
       //clamp
        {
            if (acceBuff.x > maxX)
            {
                acceBuff.x = maxX;
            }
            else if (acceBuff.x < -maxX)
            {
                acceBuff.x = -maxX;
            }
            if (acceBuff.y > maxZ)
            {
                acceBuff.y = maxZ;
            }
            else if (acceBuff.y < -maxZ)
            {
                acceBuff.y = -maxZ;
            }
            isCharge = true;
        }
    }
    private void AddAcceleration()
    {
        if (!isReachLazer)
        {
            if (isCharge)
            {
                rb.velocity = new Vector3(acceBuff.x, 0, acceBuff.y);
                acceBuff = Vector2.zero;
            }
            isCharge = false;
        }
    }
    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "lLazer" || other.tag == "rLazer") 
        {
            isReachLazer = true;
            AddCookTime(1);
            Vector3 eyeBall = other.transform.parent.gameObject.transform.position;
            Vector3 eyeRotate = new Vector3(other.transform.parent.gameObject.transform.rotation.x, other.transform.parent.gameObject.transform.rotation.y, other.transform.parent.gameObject.transform.rotation.z);
            Vector3 lazerPos = other.GetComponent<Transform>().position;
            LazerAcceleration(eyeBall,lazerPos);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lLazer" || other.tag == "rLazer")
        {
            rb.velocity= Vector3.zero;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           isDestroy= true;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            isDestroy = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isReachLazer = false;
        cookTime = 0;
        bestTimeBuff = bestTime * 60;
        coalTimeBuff = coalTime * 60;
  

        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDestroy)
        {
            Destroy(this.gameObject);
        }
        Cook();
        AddAcceleration();
   
    }
    private void FixedUpdate()
    {
        isReachLazer = false;
    }
}
