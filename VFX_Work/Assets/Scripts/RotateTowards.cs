using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour 
{
	public Transform target;
    private Vector3 previousPosition;
    public float firingAngle;
    public float speed = 9.8f;


    void Start()
	{
        
		target = GameObject.Find("TargetSphere_Prefab").transform;
        previousPosition = gameObject.transform.position;
        //Time.timeScale = 0.1f;  //changes the time scale.
	}

	private void Update()
	{

        //Calculates distance to the target.
        float target_Distance = Vector3.Distance(transform.position, target.position);

        //Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / speed);

        //Extract the X Y componenet of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        //Calculate flight time.
        float flightDuration = target_Distance / Vx;

        Debug.Log(flightDuration);

       

        if (firingAngle > (flightDuration * 0.5f))
        {
            firingAngle -= (flightDuration * 0.4f);
        }
        

        if (gameObject.transform.position.y > previousPosition.y)
        {
            //Debug.Log("UP UP UP");

            Vector3 direction = (target.position - transform.position) + new Vector3(0, firingAngle, 0);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
        else
        {
            //Debug.Log("Down Down Down");

            Vector3 direction = (target.position - transform.position);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

        }


        

        previousPosition = transform.position;
    }

}
