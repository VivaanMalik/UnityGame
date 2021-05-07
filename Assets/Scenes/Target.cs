
using UnityEngine;
using MLAPI.NetworkVariable;
using MLAPI;

public class Target : NetworkBehaviour
{
    public NetworkVariableFloat health = new NetworkVariableFloat(100f);
    public ParticleSystem death;

    public void TakeDamage(float amount){
        if (!IsLocalPlayer){
        health.Value-=amount;
        if(health.Value<=0f){
            Die();
        }}
    }

 

    void Die(){
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}

