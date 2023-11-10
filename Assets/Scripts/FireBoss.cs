using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss : MonoBehaviour
{
    public float StarTime;
    public float EndTime;
    public Transform[] _firePos;
    public GameObject _fireobj;

    public float bulletForce = 30f;

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
            GameObject bullshit = Instantiate(_fireobj, _firePos[Random.Range(0, _firePos.Length)].position, _firePos[Random.Range(0,_firePos.Length)].rotation);
            Rigidbody rg = bullshit.GetComponent<Rigidbody>();
            rg.AddForce(_firePos[Random.Range(0,_firePos.Length)].up * bulletForce, ForceMode.Impulse);
        }
        if (StarTime >= EndTime)
        {
            StarTime = 0f;
        }

    }
}
