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
    private void LazerAcceleration(Vector3 eyePos,Vector3 lazerPos)
    {
        Vector3 meatPos = GetComponent<Transform>().position;
        Vector3 distance = new Vector3(meatPos.x - eyePos.x, 0, meatPos.z - eyePos.z);
        Vector3 distance2 = new Vector3(meatPos.x - lazerPos.x, 0, meatPos.z - lazerPos.z);
        Vector3 distance3 = new Vector3(distance.x - distance2.x, 0, distance.z - distance2.z);

        Vector3 acce = new Vector3((distance3.x * distance3.x) / (distance3.x * distance3.x + distance3.z * distance3.z), 0, (distance3.z * distance3.z) / (distance3.x * distance3.x + distance3.z * distance3.z));
       
        rb.velocity = new Vector3(rb.velocity.x + distance.x, rb.velocity.y, rb.velocity.z + distance.z);

    }
    public double ToRadian(double angle)
    {
        return angle * Math.PI / 180f;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "lLazer" || other.tag == "rLazer") 
        {
            AddCookTime(1);
            Vector3 eyeBall = other.transform.parent.gameObject.transform.position;
            Vector3 eyeRotate = new Vector3(other.transform.parent.gameObject.transform.rotation.x, other.transform.parent.gameObject.transform.rotation.y, other.transform.parent.gameObject.transform.rotation.z);
            Vector3 lazerPos = other.GetComponent<Transform>().position;
            LazerAcceleration(eyeBall,lazerPos);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cookTime = 0;
        bestTimeBuff = bestTime * 60;
        coalTimeBuff = coalTime * 60;
  

        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Cook();
    }
}
