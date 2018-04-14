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


    public int windCollider, deadZone, lightZone, waterZone;

    public bool rainTriggered;
    public float forceOfRain;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        initialPos = transform.position;
        initialRot = transform.eulerAngles;
    }

    void FixedUpdate()
    {
        RotateMyBoi();
        AdjustRotation();

        if (rainTriggered)
        {
            AddRainForce();
        }
        else 
        {
            UpdateTheVeloc();
        }
    }

    void RotateMyBoi()
    {
        rotation += new Vector3(Input.GetAxis("Pitch") * rotationalSpeed, Input.GetAxis("Yaw") * rotationalSpeed, Input.GetAxis("Roll") * rotationalSpeed);
        rotation.x = Mathf.Clamp(rotation.x, -rotationLimit.x, rotationLimit.x);
        rotation.y = Mathf.Clamp(rotation.y, -rotationLimit.y, rotationLimit.y);
        rotation.z = Mathf.Clamp(rotation.z, -rotationLimit.z, rotationLimit.z);
        transform.eulerAngles = rotation;
    }

    void AdjustRotation()
    {
        //ToDo: make the plane auto rotate back to zero
    }

    void UpdateTheVeloc()
    {
        rigid.velocity = transform.forward * speed;
    }

    void AddRainForce()
    {
        rigid.AddForce(transform.up * -forceOfRain);
    }


    void OnTriggerEnter(Collider col)
    {
        print("Colliding with" + col.name);
        //Wind Collision
        if(col.gameObject.layer == windCollider)
        {
            
        }

        //Dead Zone
        if (col.gameObject.layer == deadZone)
        {
            transform.position = initialPos;
            rotation = Vector3.zero;
            transform.eulerAngles = rotation;
        }

        //Lamp Effect
        if (col.gameObject.layer == lightZone)
        {
            
        }

        //Water effect
        if (col.gameObject.layer == waterZone)
        {
            rainTriggered = true;
            print("triggered");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.layer == waterZone)
        {
            print("Out of water");
            rainTriggered = false;
        }

        if (col.gameObject.layer == lightZone)
        {
            
        }
    }

}