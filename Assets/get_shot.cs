using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
public class get_shot : NetworkBehaviour
{
        public Rigidbody obj;
        public int i=0;
 public float shootForce;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider collision) {
     

         if (collision.GetComponent<Collider>().tag=="Enemy"){
             Debug.Log("hit");
         Destroy(gameObject);
         var ms = collision.GetComponent<Collider>().GetComponent<Target>();
         if (ms != null){
            ms.TakeDamage(25);
         }
         
     
 }}

    // Update is called once per frame
    void Start(){
        Invoke("Update", 0.5f);
    }
    void Update()
    {
        if (i!=200){
          transform.position=transform.position+(transform.forward*shootForce*Time.deltaTime);
          i+=1;
        }else{
            Destroy(gameObject);
        }
    }}
//}
