using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float rotspeed;
    public GameObject head;
    Vector3 rotate;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float H = Input.GetAxis("Horizontal") * speed;
        float V = Input.GetAxis("Vertical") * speed;
        float mH = Input.GetAxis("Mouse Y");
        float mV = Input.GetAxis("Mouse X");
        rotate = new Vector3(mH * rotspeed, mV * rotspeed * -1, 0);

        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel.x = H;
        locVel.z = V;
        rb.velocity = transform.TransformDirection(locVel);
        
        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0f, rotspeed * Input.GetAxis("Mouse X"), 0f));

        head.transform.eulerAngles = head.transform.eulerAngles -= new Vector3(rotate.x, 0, 0);
    }
}
