using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;
    public Camera cum;

    private void Start()
    {
        offset = transform.position - player.position;
    }
    private void Update()
    {
        if(transform != null)
        {
            cum.transform.position = player.position;
        }
    }
    private void FixedUpdate()
    {
        if (transform != null)
        {
            cum.transform.position = player.position;
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
            transform.position = newPos;
        }
     //   Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
    //    transform.position = newPos;
    }
}
