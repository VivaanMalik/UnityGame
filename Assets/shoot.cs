using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class shoot : NetworkBehaviour
{
    public GameObject projectile;
    public TrailRenderer Attack;
    public Transform shoot_start;

 public int i=0;
    // Start is called before the first frame update

    

    // Update is called once per frame
    void Update()
    {if (IsLocalPlayer){
        if (Input.GetMouseButtonDown(0)){
            //GameObject shot = GameObject.Instantiate(projectile, transform.position+transform.forward*30, transform.rotation);
            ShootServerRpc();
         
        }
        }
    }
    [ServerRpc]
    void ShootServerRpc(){
        ShootClientRpc();
    }
    [ClientRpc]
    void ShootClientRpc(){
        var bullet=Instantiate(Attack, shoot_start.position, Quaternion.identity);
        bullet.AddPosition(shoot_start.position);
        if (Physics.Raycast(shoot_start.position, shoot_start.forward, out RaycastHit hit, 250f)){
            bullet.transform.position=hit.point;
        }else{
            bullet.transform.position=shoot_start.position+(shoot_start.forward*250f);
        }
    }
        }

