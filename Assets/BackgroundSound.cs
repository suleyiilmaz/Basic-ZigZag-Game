using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    // Start is called before the first frame update
    static BackgroundSound instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance); //ilk instance asla yok olmuyor 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
