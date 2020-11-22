using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector3 fwd = transform.InverseTransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if (hit.transform.gameObject.tag == "enemy")
            {
                Debug.Log("enemy hit");
            }
        }
    }
}
