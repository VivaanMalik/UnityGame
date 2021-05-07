using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resize : MonoBehaviour
{
    float i=100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (i>=0){
            transform.localScale = new Vector3(i,i,i);
            i-=0.5f;
        }
    }
}
