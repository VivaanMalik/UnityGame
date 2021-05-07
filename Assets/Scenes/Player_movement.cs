using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using MLAPI.Messaging;

public class Player_movement : NetworkBehaviour
{
    public float speed;
    public int maxx;
    public int minx;
    public int maxz;
    public int minz;
    public float Tempx;
    public float Tempz;
    public Rigidbody rb;
    public Transform Bullet;
    public Camera cam;
    public float damage;
    public float lengthOfLineRenderer=250f;
    public LineRenderer laserLineRenderer;
    public float laserWidth = 10f;
    public float laserMaxLength = 250f;
    public static float posx;
    public static float posz;
    public static float posy;
    public GameObject penta_blue;
    public GameObject penta_red;
    public GameObject penta;
    public int i=0;
    //CharacterController cc;
     
    //public static Vector3 campos;
//blue red pentain strt
    // Start is called before the first frame update
    void Start()
    {
        
        int initx=Random.Range(minx, maxx+1);
        int initz=Random.Range(minz, maxz+1);
        transform.position=new Vector3(initx, 100, initz);
        Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
         laserLineRenderer.SetPositions( initLaserPositions );
         laserLineRenderer.SetWidth( laserWidth, laserWidth );
         if(IsLocalPlayer){
             //cc=GetComponent<CharacterController>();
 penta=GameObject.Instantiate(penta_blue, new Vector3(transform.position.x, 15f, transform.position.z), transform.rotation);            
        }else{
 penta=GameObject.Instantiate(penta_red, new Vector3(transform.position.x, 15f, transform.position.z), transform.rotation);        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation=  Quaternion.Euler (new Vector3(0f,transform.rotation.y,0f));
        if(IsLocalPlayer){
           Penta_blue();
            Moveplayer();
        }else{
           Penta_red();
        }
        
        }
        void Penta_red(){
            
            penta.transform.position=new Vector3(transform.position.x, 0.5f, transform.position.z);
            
            
        }
        void Penta_blue(){
            
penta.transform.position=new Vector3(transform.position.x, 0.5f, transform.position.z);
            
        }
        void Moveplayer(){
        posx=transform.position.x;
        posz=transform.position.z;
        posy=transform.position.y;
        //Tamp var
        Tempx=transform.position.x;
        Tempz=transform.position.z;

        //Movement
        if (transform.position.y<=10.7){
        if (Input.GetKey("w")){
            transform.position=transform.position+new Vector3(-speed*Time.deltaTime, 0, -speed*Time.deltaTime);

        }
        if (Input.GetKey("s")){
            transform.position=transform.position+new Vector3(speed*Time.deltaTime, 0, speed*Time.deltaTime);

        }
        if (Input.GetKey("a")){
            transform.position=transform.position+new Vector3(speed*Time.deltaTime, 0, -speed*Time.deltaTime);

        }
        if (Input.GetKey("d")){
            transform.position=transform.position+new Vector3(-speed*Time.deltaTime, 0, speed*Time.deltaTime);

        }
        if (Input.GetKeyDown("space")){

                rb.velocity=Vector3.up*speed;
            }
        
        

            //Airmovement
        }else if(transform.position.y>=10.7){
        if (Input.GetKey("w")){
            transform.position=transform.position+new Vector3(-speed*Time.deltaTime/2, 0, -speed*Time.deltaTime/2);

        }
        if (Input.GetKey("s")){
            transform.position=transform.position+new Vector3(speed*Time.deltaTime/2, 0, speed*Time.deltaTime/2);

        }
        if (Input.GetKey("a")){
            transform.position=transform.position+new Vector3(speed*Time.deltaTime/2, 0, -speed*Time.deltaTime/2);

        }
        if (Input.GetKey("d")){
            transform.position=transform.position+new Vector3(-speed*Time.deltaTime/2, 0, speed*Time.deltaTime/2);

        }
        }

        //Boundaries
        if (transform.position.x>maxx){
            transform.position=new Vector3(maxx, 10.5f, Tempz);
        }
        if (transform.position.x<minx){
            transform.position=new Vector3(minx, 10.5f, Tempz);
        }
        if (transform.position.z>maxz){
            transform.position=new Vector3(Tempx, 10.5f, maxz);
        }
        if (transform.position.z<minz){
            transform.position=new Vector3(Tempx, 10.5f, minz);
        }

        //Shooting
        
        
    

    }}
