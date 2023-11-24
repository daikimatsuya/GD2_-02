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
    new Transform transform;


    private float leftRad;
    private float rightRad;
    private float playerDegree;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leftLazer = transform.Find("LeftLazer").gameObject;
        rightLazer = transform.Find("RightLazer").gameObject;

        llTransform=leftLazer.GetComponent<Transform>();
        rlTransform=rightLazer.GetComponent<Transform>();
        transform = GetComponent<Transform>();

        playerDegree = transform.localRotation.eulerAngles.z;
    }
    private void Move(float leftDegree,float rightDegree)
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        llTransform.localScale = Vector3.zero;
        rlTransform.localScale= Vector3.zero;
      
        float leftDegree = Mathf.Atan2(Input.GetAxis("leftStickX"), Input.GetAxis("leftStickY")) * Mathf.Rad2Deg;
        float rightDegree = Mathf.Atan2(Input.GetAxis("rightStickX"), Input.GetAxis("rightStickY")) * Mathf.Rad2Deg;
        Move(leftDegree,rightDegree);
       
        llTransform.localRotation= Quaternion.Euler(90,0, leftDegree+180);
        rlTransform.localRotation = Quaternion.Euler(90, 0, rightDegree+180);
        rb.velocity = new Vector3(2.0f * (Input.GetAxis("leftStickX") + Input.GetAxis("rightStickX")), rb.velocity.y, -2.0f * (Input.GetAxis("leftStickY") + Input.GetAxis("rightStickY")));
    }
}
