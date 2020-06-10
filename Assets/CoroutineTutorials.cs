using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTutorials : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoSomething());
        Debug.Log("**************************");
    }

    private IEnumerator DoSomething()
    {
        while (true)
        {
            Debug.Log("Hi");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
