using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float speed = 0f;
    float yspeed = 0f;
    float mass = 10;
    float force = 1;
    float drag = 1;
    float gravity = -9.8f;
    float gAccel;
    float acceleration;

    void OnCollisionEnter(Collision col)
    {
        // Verifica se colidiu com um objeto tag "tank" (ou "EnemyTank" caso a tag exista)
        if (col.gameObject.CompareTag("tank"))
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed += acceleration; // Corrigido de acceleration1
        gAccel = gravity / mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        yspeed += gAccel * Time.deltaTime;
        this.transform.Translate(0, yspeed, speed);
    }
}