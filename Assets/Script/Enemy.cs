using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float attackCooltime;
    private bool isAttack;

    public GameObject meat;

    private void Attack(int type)
    {
        if(type==0)
        {

        }
    }
    private void CountDown()
    {
        if(!isAttack&&attackCooltime>0)
        {
            attackCooltime--;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
