using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopingCart_Script : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        rb.velocity = movementDirection * speed * Time.fixedDeltaTime;
    }
}
