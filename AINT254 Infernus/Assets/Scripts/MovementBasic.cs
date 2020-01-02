using UnityEngine;
using System.Collections;

public class MovementBasic : MonoBehaviour //Flying
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("Movement Basic script added to: " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10.0f;
        if (Input.GetButton("Roll"))
            transform.position += transform.forward * Time.deltaTime * 40.0f;

        transform.Rotate(Input.GetAxis("Pitch"), 0.0f, -Input.GetAxis("Yaw"));

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
            terrainHeightWhereWeAre,
            transform.position.z);
        }
    }
}
