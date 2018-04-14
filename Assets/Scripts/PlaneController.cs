using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Player controlled in each of the scenes
public class PlaneController : MonoBehaviour
{

    public float rotationalSpeed;
    public Vector3 rotationLimit;
    public float speed;

    Rigidbody rigid;
    Vector3 rotation;
    Vector3 initialPos;
    Quaternion initialRot;

    public LayerMask windCollider;
    public LayerMask deadZone;
    public LayerMask lightZone;
    public LayerMask waterZone;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    void FixedUpdate()
    {
        RotateMyBoi();
        UpdateTheVeloc();
    }

    void RotateMyBoi()
    {
        rotation += new Vector3(Input.GetAxis("Pitch") * rotationalSpeed, Input.GetAxis("Yaw") * rotationalSpeed, Input.GetAxis("Roll") * rotationalSpeed);
        rotation.x = Mathf.Clamp(rotation.x, -rotationLimit.x, rotationLimit.x);
        rotation.y = Mathf.Clamp(rotation.y, -rotationLimit.y, rotationLimit.y);
        rotation.z = Mathf.Clamp(rotation.z, -rotationLimit.z, rotationLimit.z);
        transform.eulerAngles = rotation;

    }

    void UpdateTheVeloc()
    {
        rigid.velocity = transform.forward * speed;
    }
    void OnTriggerStay(Collider col)
    {
        //Wind Collision
        if(col.gameObject.layer == windCollider.value)
        {
            
        }

        //Dead Zone
        if (col.gameObject.layer == deadZone.value)
        {
            transform.position = initialPos;
            transform.rotation = initialRot;
        }

        if (col.gameObject.layer == lightZone.value)
        {

        }

        if (col.gameObject.layer == waterZone.value)
        {
            rigid.AddForce(new Vector3(0f, 5f, 0f));
        }
    }

}