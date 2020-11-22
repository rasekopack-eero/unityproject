using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 fwd = transform.InverseTransformDirection(Vector3.forward);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("enemy hit");
                }
            }
        }
    }
}
