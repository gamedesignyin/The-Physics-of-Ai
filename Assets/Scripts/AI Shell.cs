using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour
{
    public GameObject explosion;
    Rigidbody rb;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("tank"))
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.linearVelocity != Vector3.zero)
        {
            this.transform.forward = rb.linearVelocity;
        }
    }
}