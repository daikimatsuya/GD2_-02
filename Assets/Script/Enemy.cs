using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp;
    public float attackCooltime;
    private bool isAttack;
    private int rand;
    private int time;
    private int shoot;
    private float meatShotRad;
    private bool isMove;
    private float enemyVectorX;
    private float moveLimit;
    private float posBuff;

    public GameObject meat;
    Transform tf;
    Rigidbody rb;

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
            EnemyMove(5);
            if (isMove == false)
            {
                SetCooltime(2);
            }
        
        }
        if(type == 4)
        {
            EnemyMove(-2);
            if(isMove == false)
            {
                SetCooltime(2);
            }
        }
        if( type == 5)
        {
            EnemyMove(3);
            if(isMove == false)
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
            rand = Random.Range(0, 6);
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
  
        if(destination > tf.position.x)
        {
            enemyVectorX += 0.1f;         
        }
        else if(destination < tf.position.x)
        {
            enemyVectorX -= 0.1f;
        }
        else if(destination==tf.position.x) 
        {
            isMove=false;
            enemyVectorX = 0;
            moveLimit = 0;
            rb.velocity = Vector3.zero;
            return;
        }
        if (destination > 0)
        {
            if (moveLimit > destination * 9)
            {
                isMove = false;
                rb.velocity = new Vector3(0, 0, 0);
                moveLimit = 0;
                enemyVectorX = 0;
            }
            else
            {
                moveLimit++;
            }
        }
        if(destination < 0)
        {
            if (moveLimit > -destination * 9)
            {
                isMove = false;
                rb.velocity = new Vector3(0, 0, 0);
                moveLimit = 0;
                enemyVectorX = 0;
            }
            else
            {
                moveLimit++;
            }
        }

            rb.velocity = new Vector3(rb.velocity.x + enemyVectorX, 0, 0);    
        if(rb.velocity.x < 0)
        {
            if(tf.position.x  < destination)
            {
                isMove = false;
                rb.velocity = new Vector3(0, 0, 0);
                tf.position = new Vector3(destination, 0, tf.position.z);
                moveLimit = 0;
            }
        }
        if (rb.velocity.x > 0)
        {
            if(tf.position.x> destination)
            {
                isMove = false;
                rb.velocity = new Vector3(0, 0, 0);
                tf.position = new Vector3(destination, 0, tf.position.z);
                moveLimit = 0;
            }
        }
        
    }
    private int SendHp()
    {
        return hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCooltime(1);
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FlagCheck();
        
    }
}
