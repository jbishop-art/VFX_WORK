using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour 
{
	public Transform target;
    public float speed;

    public float duration = 2.5f;
    float endtime;

    
    


    void Start()
    {

        target = GameObject.Find("TargetSphere_Prefab").transform;


        

    }

    void Update() 
	{

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        

        
    }

    // void FixedUpdate()
    // {
    //     rigidbody.rotation = Quaternion.LookRotation(rigidbody.velocity);	
    // }

    
}
