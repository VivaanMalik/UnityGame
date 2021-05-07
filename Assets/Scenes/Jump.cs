using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public float fall_multi=2.5f;
    public float low_jump=2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y<0){
            rb.velocity+=Vector3.up*Physics.gravity.y*(fall_multi-1.5f)*Time.deltaTime;
        } else if(rb.velocity.y>0 && !Input.GetKey("space")){
            rb.velocity+=Vector3.up*Physics.gravity.y*(low_jump-1.5f)*Time.deltaTime;
        }
    }
}
