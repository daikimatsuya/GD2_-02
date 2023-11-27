using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    GameObject leftLazer;
    GameObject rightLazer;

    Transform llTransform;
    Transform rlTransform;



    private float leftRad;
    private float rightRad;
    private float playerMoveSpeed;

    public float playerAcceleration;
    public float MaxPlayerMoveSpeed;
    public int playerHp;
    public int meatDamage;

    private void LazerMove()
    {
        llTransform.localScale = Vector3.zero;
        rlTransform.localScale = Vector3.zero;

        float leftDegree = Mathf.Atan2(Input.GetAxis("leftStickX"), Input.GetAxis("leftStickY")) * Mathf.Rad2Deg;
        float rightDegree = Mathf.Atan2(Input.GetAxis("rightStickX"), Input.GetAxis("rightStickY")) * Mathf.Rad2Deg;

        if (Input.GetAxis("leftStickX") != 0 || Input.GetAxis("leftStickY") != 0)
        {
            llTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            if (leftDegree < 0)
            {
                leftDegree += 360;
            }
            if (leftDegree > 255)
            {
                leftDegree = 255;
            }
            if (leftDegree < 105)
            {
                leftDegree = 105;
            }
        }
        if (Input.GetAxis("rightStickX") != 0 || Input.GetAxis("rightStickY") != 0)
        {
            rlTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            if (rightDegree < 0)
            {
                rightDegree += 360;
            }
            if (rightDegree > 255)
            {
                rightDegree = 255;
            }
            if (rightDegree < 105)
            {
                rightDegree = 105;
            }
        }
        llTransform.localRotation = Quaternion.Euler(90, 0, leftDegree + 180);
        rlTransform.localRotation = Quaternion.Euler(90, 0, rightDegree + 180);
    }
    private void PlayerMove()
    {
        playerMoveSpeed = rb.velocity.x;
        if (Input.GetAxis("MoveLeft") != 0)
        {
            if (playerMoveSpeed > -MaxPlayerMoveSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x - playerAcceleration, rb.velocity.y, rb.velocity.z);
            }
        }
        if (Input.GetAxis("MoveRight") != 0)
        {
            if (playerMoveSpeed < MaxPlayerMoveSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x + playerAcceleration, rb.velocity.y, rb.velocity.z);
            }
        }
        if (Input.GetAxis("MoveLeft") == 0 && Input.GetAxis("MoveRight") == 0)
        {
            rb.velocity=new Vector3(0,rb.velocity.y,rb.velocity.z);
        }
        if(Input.GetAxis("MoveLeft")!= 0 && Input.GetAxis("MoveRight") != 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
    }
    private void EatMeat(int meat)
    {
        if(meat == 0)
        {
            playerHp -= meatDamage;
        }
        if(meat == 1)
        {
            playerHp+= meatDamage;
        }
        if (meat == 2)
        {
            playerHp -= meatDamage * 2;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rawMeat")
        {
            EatMeat(0);
        }
        if(other.tag == "cookedMeat")
        {
            EatMeat(1);
        }
        if (other.tag == "coal")
        {
            EatMeat(2);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leftLazer = transform.Find("LeftLazer").gameObject;
        rightLazer = transform.Find("RightLazer").gameObject;

        llTransform=leftLazer.GetComponent<Transform>();
        rlTransform=rightLazer.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        LazerMove();
    }
}
