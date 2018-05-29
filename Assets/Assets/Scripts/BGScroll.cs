using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {
    public float scrollspeed;
    public float tilesize;
    private Vector3 StartPos;
	// Use this for initialization
	void Start () {
        StartPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        float newPos = Mathf.Repeat(Time.time * scrollspeed, tilesize);
        //Debug.Log(Time.time * scrollspeed);
        //Debug.Log( newPos);
        //Debug.Log(Vector3.forward);
        transform.position = StartPos + Vector3.forward * newPos;
        //Debug.Log("start pos " + StartPos);

	}
}
