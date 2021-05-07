using UnityEngine;
using MLAPI;
public class Camer_pos : NetworkBehaviour
{
 public Transform target;
 
 void LateUpdate () 
 {

        transform.position=new Vector3(Player_movement.posx+50f, 50f, Player_movement.posz+50f);
     
 
    }}