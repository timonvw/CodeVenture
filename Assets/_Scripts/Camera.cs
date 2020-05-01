using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]private GameObject player;
	// Use this for initialization

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
	    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);

	}
}
