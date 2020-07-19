using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float MaxSpeed = 5f;

    public GameObject DeadEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if(collision.relativeVelocity.magnitude > MaxSpeed)
        {
            Instantiate(DeadEffect,transform.transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
