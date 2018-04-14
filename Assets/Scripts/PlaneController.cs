using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;



//Player controlled in each of the scenes
public class PlaneController : MonoBehaviour
{

    public float rotationalSpeed;
    public Vector3 rotationLimit;
    public float speed;

    Rigidbody rigid;
    Vector3 rotation;
    Vector3 initialPos;
    Vector3 initialRot;

    bool rainTriggered, windTriggered;

    public int windZone, deadZone, lightZone, waterZone;
    public float forceOfRain, forceOfWind;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        initialPos = transform.position;
        initialRot = transform.eulerAngles;
    }

    void FixedUpdate()
    {
        RotateMyBoi();

        if (rainTriggered)
        {
            AddRainForce();
        }
        else if (windTriggered)
        {
            AddWindForce();
        }
        else
        {
            UpdateTheVeloc();
        }
    }

    void RotateMyBoi()
    {
        rotation += new Vector3(Input.GetAxis("Pitch") * rotationalSpeed, Input.GetAxis("Yaw") * rotationalSpeed, 0);
        rotation.x = Mathf.Clamp(rotation.x, -rotationLimit.x, rotationLimit.x);
        rotation.y = Mathf.Clamp(rotation.y, -rotationLimit.y, rotationLimit.y);
        rotation.z = Mathf.Clamp(rotation.z, -rotationLimit.z, rotationLimit.z);
        transform.eulerAngles = rotation;
    }


    void UpdateTheVeloc()
    {
        if (rotation.x > 30)
        {
            rigid.velocity = transform.forward * speed * 1.25f;
        }
        else if (rotation.x < -30)
        {
            rigid.velocity = transform.forward * speed * 0.75f;
        }
        else
        {
            rigid.velocity = transform.forward * speed;
        }
    }

    void AddRainForce()
    {
        rigid.AddForce(transform.up * -forceOfRain);
    }

    void AddWindForce()
    {
        rigid.AddForce(transform.right * forceOfWind);
    }

    void OnTriggerEnter(Collider col)
    {
        print("Colliding with" + col.name);
        //Wind Collision
        if(col.gameObject.layer == windZone)
        {
            windTriggered = true;
        }

        //Dead Zone
        if (col.gameObject.layer == deadZone)
        {
            transform.position = initialPos;
            rotation = Vector3.zero;
            transform.eulerAngles = rotation;
        }

        //Water effect
        if (col.gameObject.layer == waterZone)
        {
            rainTriggered = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.layer == waterZone)
        {
            rainTriggered = false;
        }

        if(col.gameObject.layer == windZone)
        {
            windTriggered = false;
        }
    }

}