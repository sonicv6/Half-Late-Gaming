using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.g)
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = 5 * Vector3.forward;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
