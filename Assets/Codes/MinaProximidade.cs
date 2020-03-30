﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaProximidade : MonoBehaviour
{
    Rigidbody rdb;
    public float bombForce = 1000;
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        print("bati");
        rdb.isKinematic = true;
        
    }
    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.CompareTag("Player") && rdb.isKinematic)
            Explode();
    }
    void Explode()
    {
        print("Boom!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
            }
        }
    }
}
