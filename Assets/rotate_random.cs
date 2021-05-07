using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_random : MonoBehaviour
{
  
    public Quaternion newRotation; 
    public int i =0;
    void Start(){
        newRotation=Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }
    void Update()
    {
        if (i<500){
            i+=1;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1 * Time.deltaTime);
        }
        if (i>=500){
            i=0;
        
        
        newRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        
         //rb.angularVelocity = Random.insideUnitSphere*5;
        }
        
    }
}
