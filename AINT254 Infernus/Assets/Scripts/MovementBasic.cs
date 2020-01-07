using UnityEngine;
using System.Collections;


public class MovementBasic : MonoBehaviour //Flying
{
    public float chaseVelocity = 20f; //temp variable for ref
    private Rigidbody Aircraft;
    public float acceleration = 2000;
    public float thrust = 10.0f;
    public float rollingSpeed = 100;   //roll speed 
    public float verticalRot = 100;  //pitch speed 
    public float horizontalRot = 100;    //yaw speed
    public float stability = 0.9f;
    public float speed = 2f;



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


        //roll = Input.GetAxis("Roll") * (Time.deltaTime * rollingSpeed);
        //pitch = Input.GetAxis("Pitch") * (Time.deltaTime * verticalRot);
        //yaw = Input.GetAxis("Yaw") * (Time.deltaTime * horizontalRot);
        //thrust = Input.GetAxis("Throttle") * (Time.deltaTime * acceleration);

        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //rb.AddTorque(0f, 0f, 10f);
                Aircraft.AddTorque(0f, 0f, 10f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space pressed");
                Aircraft.AddTorque(0f, 0f, -10f); //AddRelativeTorque
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A pressed");
                //rb.AddTorque(0f, -10f, 0f);
                Aircraft.AddTorque(0f, -10f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("D pressed");
                Aircraft.AddTorque(0f, 10f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("k pressed");
                Aircraft.AddTorque(-10f, 0f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("i pressed");
                Aircraft.AddTorque(10f, 0f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                Aircraft.AddForce(transform.forward * thrust, ForceMode.Acceleration);
            }

            Vector3 manipulateVerticalPitch = Quaternion.AngleAxis(Aircraft.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed, Aircraft.angularVelocity) * transform.up; //stabilise aircraft so it returns to an allignment 
            Vector3 manipulateHorizontalYaw = Quaternion.AngleAxis(Aircraft.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed, Aircraft.angularVelocity) * transform.right;

            Vector3 stabilizeThePitch = Vector3.Cross(manipulateVerticalPitch, Vector3.up); //stabilizePitch
            Vector3 stabilizeRudder = Vector3.Cross(manipulateHorizontalYaw, Vector3.left); //stabilizeRudder
            //stabilizeThePitch = Vector3.Project(stabilizeThePitch, transform.forward);
            //stabilizeRudder = Vector3.Project(stabilizeRudder, transform.right);

            Aircraft.AddTorque(stabilizeThePitch * speed * speed);  //* speed);
            //Aircraft.AddTorque(stabilizeRudder * speed * speed);

            

        }

        //float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        //if (terrainHeightWhereWeAre > transform.position.y)
        //{
        //    transform.position = new Vector3(transform.position.x,
        //    terrainHeightWhereWeAre,
        //    transform.position.z);
        //}



        // Update is called once per frame

    }
    private void FixedUpdate()
    {

        updateFunction();



        //thrust = Input.GetAxis("Throttle") * (Time.deltaTime * accelerate); //configure Throttle input manager
        //transform.position += transform.forward * Time.deltaTime * 40.0f; //10.0f
        //if (Input.GetButton("Roll"))
        //    transform.position += transform.forward * Time.deltaTime * 40.0f; //10.0f

        //transform.Rotate(Input.GetAxis("Pitch"), 0.0f, -Input.GetAxis("Yaw")); 

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
            terrainHeightWhereWeAre,
            transform.position.z);
        }
    }
}
