using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEAircraft : MonoBehaviour
{
    public float StarTime;
    public float EndTime;
    public Transform _firePos;
    public GameObject _fireobj;

    public float bulletForce = 20f;

    private void Update()
    {
        Shoot();
    }

    private void FixedUpdate()
    {
        StarTime += 0.5f * Time.deltaTime;
    }
    void Shoot()
    {

        if (StarTime >= EndTime)
        {
            GameObject bullshit = Instantiate(_fireobj, _firePos.position, _firePos.rotation);
            Rigidbody rg = bullshit.GetComponent<Rigidbody>();
            rg.AddForce(_firePos.up * bulletForce, ForceMode.Impulse);
        }
        if (StarTime >= EndTime)
        {
            StarTime = 0f;
        }

    }
}
