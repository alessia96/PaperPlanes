using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Player controlled in each of the scenes
public class PlaneController : MonoBehaviour
{

    public float rotationalSpeed;

    Rigidbody rigid;
    Vector3 rotation;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
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

}