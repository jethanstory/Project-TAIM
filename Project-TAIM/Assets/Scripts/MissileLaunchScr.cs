using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLaunchScr : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject defMissile;

    public float RotationSpeed;
    private Quaternion lookRotation;
    private Vector3 direction;

    public int missileCount;
    // Start is called before the first frame update

    float range = 15f;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MissileRotation();
        if (Input.GetMouseButtonDown(0) && missileCount < 5)//(Input.GetKeyDown(KeyCode.F)) //(Input.GetMouseButtonDown(0)) // && canThrow == true

            {
                missileCount++;
                MissileRotation();
                defMissile.transform.SetParent(null);
                GameObject defMissileInstance = Instantiate(defMissile, spawnPoint.position, transform.rotation);
                //defMissileInstance.GetComponent<Rigidbody2D>().AddForce(transform.right * -range, ForceMode2D.Impulse);
                defMissileInstance.GetComponent<Rigidbody2D>().AddForce(transform.up * range, ForceMode2D.Impulse);
                // defMissileInstance.GetComponent<Rigidbody2D>().AddForce(transform.forward * range);
                
                //spawnPoint.forward
                
                Object.Destroy(defMissileInstance, 1.0f);
                missileCount--;
                
            }
    }

    private void MissileRotation()
    {
        //Get the Screen positions of the object
         Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
         
         //Get the Screen position of the mouse
         Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
         
         //Get the angle between the points
         float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
 
         //Ta Daaa
         transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
 
        

        Debug.Log("Click");
    }

    float AngleBetweenTwoPoints(Vector2 a, Vector2 b) {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
}
