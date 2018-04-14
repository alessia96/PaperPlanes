using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Player controlled in each of the scenes
public class PlaneController : MonoBehaviour
{

    public float rotationalSpeed;
    public float speed;

    Rigidbody rigid;
    Vector3 rotation;

    public LayerMask windCollider;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = speed * transform.forward;
    }

    void FixedUpdate()
    {
        RotateMyBoi();
    }

    void RotateMyBoi()
    {
        rotation = new Vector3(Input.GetAxis("Pitch"), Input.GetAxis("Yaw"), Input.GetAxis("Roll"));
        print(rotation);
        transform.Rotate(rotation);
    }

    void OnTriggerStay(Collider col)
    {
        //Wind Collision
        if(col.gameObject.layer == windCollider.value)
        {
            
        }

    }

}