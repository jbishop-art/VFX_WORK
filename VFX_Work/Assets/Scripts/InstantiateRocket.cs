using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRocket : MonoBehaviour 
{

	public GameObject projectilePrefab;
	private Vector3 intLocation;

	// Use this for initialization
	void Start () 
	{
		
		Instantiate(projectilePrefab, intLocation, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
