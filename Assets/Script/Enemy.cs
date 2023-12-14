using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp;
    public float attackCooltime;
    private bool isAttack;
    private int rand;
    private int time;
    private int shoot;
    private float meatShotRad;
    private bool isMove;
    private float enemyVectorX;

    public GameObject meat;
    Transform tf;

    private void Attack(int type)
    {
        if(type==0)
        {            
            MeatShot(45);                      
            SetCooltime(2);     
        }
        if(type==1)
        {
            MeatShot(-45);
            SetCooltime(2);
        }
        if (type == 2)
        {

            SetCooltime(2);
        }
        if (type == 3)
        {
            EnemyMove(0);
            if (isMove == false)
            {
                SetCooltime(2);
            }
        
        }
    }
    private void FlagCheck()
    {
        
        if(isAttack)
        {
            Attack(rand);
        }
        else if (attackCooltime > 0)
        {
           CountDown();
        }
    }
    private void CountDown()
    {
        attackCooltime--;
        if (attackCooltime == 0)
        {
            rand = Random.Range(0, 3);
            isAttack = true;
        }
    }
    private void SetCooltime(int time)
    {
        isAttack = false;
        attackCooltime = time * 60;
    }
    private void MeatShot(float rad)
    {
        Object instans = Instantiate(meat, new Vector3(tf.position.x, tf.position.y, tf.position.z - 1.5f), new Quaternion(0, rad, 0, 0));
    }
    private void EnemyMove(float destination)
    {
        isMove = true;
        if(destination < tf.position.x)
        {
            
        }
        else if(destination > tf.position.x)
        {

        }
        else
        {
            isMove=false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCooltime(1);
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FlagCheck();
        
    }
}
