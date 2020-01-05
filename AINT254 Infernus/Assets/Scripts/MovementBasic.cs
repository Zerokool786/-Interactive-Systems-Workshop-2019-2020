using UnityEngine;
using System.Collections;


public class MovementBasic : MonoBehaviour //Flying
{
    public float chaseVelocity = 20f; //temp variable for ref
    private Rigidbody Aircraft;
    public float acceleration = 2000;
    public float thrust = 0;
    public float rollingSpeed = 100;   //roll
    public float verticalRot = 100;  //pitch 
    public float horizontalRot = 100;    //yaw

    private void Awake()
    {
        Aircraft = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    private void Start()
    {
        Debug.Log("Movement Basic script added to: " + gameObject.name);
        
    }
    private void updateFunction()
    {
         float roll = 0;
         float pitch = 0;
         float yaw = 0;

        roll = Input.GetAxis("Roll") * (Time.deltaTime * rollingSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.deltaTime * verticalRot);
        yaw = Input.GetAxis("Yaw") * (Time.deltaTime * horizontalRot);
        thrust = Input.GetAxis("Throttle") * (Time.deltaTime * acceleration);

        if (Input.GetAxis("Roll") == 0) 
        {
            Aircraft.AddRelativeTorque();
        }
            
        
    }
 
    // Update is called once per frame
    private void FixedUpdate()
    {

        updateFunction(); 
        


        //thrust = Input.GetAxis("Throttle") * (Time.deltaTime * accelerate); //configure Throttle input manager
        //transform.position += transform.forward * Time.deltaTime * 40.0f; //10.0f
        //if (Input.GetButton("Roll"))
        //    transform.position += transform.forward * Time.deltaTime * 40.0f; //10.0f

        //transform.Rotate(Input.GetAxis("Pitch"), 0.0f, -Input.GetAxis("Yaw")); 

        //float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        //if (terrainHeightWhereWeAre > transform.position.y)
        //{
        //    transform.position = new Vector3(transform.position.x,
        //    terrainHeightWhereWeAre,
        //    transform.position.z);
        //}
    }
}
