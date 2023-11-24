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

        // rb.velocity = new Vector3(2.0f * (Input.GetAxis("leftStickX")+Input.GetAxis("rightStickX")), rb.velocity.y, -2.0f * (Input.GetAxis("leftStickY")+Input.GetAxis("rightStickY")));
        float leftDegree = Mathf.Atan2(Input.GetAxis("leftStickX"), Input.GetAxis("leftStickY")) * Mathf.Rad2Deg;
        float rightDegree = Mathf.Atan2(Input.GetAxis("rightStickX"), Input.GetAxis("rightStickY")) * Mathf.Rad2Deg;

        if (leftDegree < 0)
        {
            leftDegree += 360;
        }
        if (rightDegree < 0)
        {
            rightDegree += 360;
        }

        llTransform.localRotation= Quaternion.Euler(90,0, leftDegree);
        rlTransform.localRotation = Quaternion.Euler(90, 0, rightDegree);
    }
}
