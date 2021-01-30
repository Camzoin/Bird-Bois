using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindReceiver : MonoBehaviour
{
    public WindArea windZone;
    public bool inWindZone;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {
            rb.AddForce(windZone.direction * windZone.strength, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            windZone = other.GetComponent<WindArea>();
            inWindZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WindArea"))
        {
            inWindZone = false;
        }
    }
}
