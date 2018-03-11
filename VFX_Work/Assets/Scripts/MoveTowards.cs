using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour
{

    public Transform target;
    public Transform Projectile;
    public float firingAngle = 45.0f;
    public float speed = 9.8f;

    private Transform myTransform;


    private void Awake()
    {

        myTransform = transform;
        
    }

    private void Start()
    {

        StartCoroutine(SimulateProjectile());


        target = GameObject.Find("TargetSphere_Prefab").transform;
        Projectile = transform;
        
    }

    IEnumerator SimulateProjectile()
    {

        //Adds a delay before projectile is activated.
        yield return new WaitForSeconds(0.0f);

        //Move projectile towards target position.  Add some offset if needed.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        //Calculates distance to the target.
        float target_Distance = Vector3.Distance(Projectile.position, target.position);

        //Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / speed);

        //Extract the X Y componenet of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        //Calculate flight time.
        float flightDuration = target_Distance / Vx;

        //Rotate projectile to face the target.
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        Projectile.rotation = rotation;


        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {

            Projectile.Translate(0, (Vy - (speed * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;

        }

    }

    //private void Update()
    //{
    //    Vector3 direction = target.position - transform.position;
    //    Quaternion rotation = Quaternion.LookRotation(direction);
    //    transform.rotation = rotation;
    //}







}