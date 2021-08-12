using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    public Health HealthObj = null;
    void OnTriggerEnter(Collider other)
    {
        if(HealthObj != null)
        {
            HealthObj.GiveHealth(5);
            Destroy(gameObject);
        }
    }
}
