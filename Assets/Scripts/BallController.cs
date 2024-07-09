using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force;
    public GameObject sparksVFX;

    private void OnCollisionEnter(Collision collision)
    {
        bool hit = false;
        if(collision.gameObject.layer == 6)
        {
            hit = true;
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }

        if (hit)
        {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }



}
