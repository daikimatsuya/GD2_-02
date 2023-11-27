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
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Lazer")
        {
            AddCookTime(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cookTime = 0;
        bestTimeBuff = bestTime * 60;
        coalTimeBuff = coalTime * 60;
    }

    // Update is called once per frame
    void Update()
    {
        Cook();
    }
}
