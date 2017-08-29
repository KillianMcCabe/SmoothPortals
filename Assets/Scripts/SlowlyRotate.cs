using UnityEngine;
using System.Collections;

public class SlowlyRotate : MonoBehaviour {

    [SerializeField] float rotSpeed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
	}
}
