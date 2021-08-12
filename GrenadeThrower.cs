using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject hand;
    public GameObject grenadePrefab;
    private float nextFireTime = 0f;
    public float cooldownTime = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown("g"))
            {
                ThrowGrenade();
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, hand.transform.position, hand.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(hand.transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
