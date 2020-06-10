using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 diffvector;
    Transform player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        diffvector = player.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - diffvector;

    }
}
