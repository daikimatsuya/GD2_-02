using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    private int cookTime;
    private int bestTimeBuff;
    private int coalTimeBuff;

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
    private void LazerAcceleration(Vector3 eyePos)
    {
        Vector3 meatPos = GetComponent<Transform>().position;
        Vector3 distance = new Vector3(meatPos.x - eyePos.x, meatPos.z - eyePos.z);
        Vector3 acce = new Vector3((distance.x*distance.x) / (distance.x * distance.x + distance.z * distance.z), (distance.z*distance.z) / (distance.x * distance.x + distance.z * distance.z));
        rb.velocity = new Vector3(rb.velocity.x + acce.x, rb.velocity.y, rb.velocity.z + acce.z);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Lazer")
        {
            AddCookTime(1);
            Vector3 eyeBall = other.GetComponentInParent<Transform>().transform.position;
            LazerAcceleration(eyeBall);
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
