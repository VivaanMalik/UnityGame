using UnityEngine;
using MLAPI;

public class Rotation_player : NetworkBehaviour
{
    public static float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer){
        //Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
        
        Vector2 positionOnScreen=new Vector2(0.5f, 0.5f);
         //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
         //Get the angle between the points
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //changeangletoaddoffset
        angle-=135;
 
         //Ta Daaa
        transform.rotation =  Quaternion.Euler (new Vector3(0f,-angle,0f));
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
}}

