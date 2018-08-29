using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb2d.position += new Vector2(Input.GetAxis("Horizontal"),
                                     Input.GetAxis("Vertical")) * speed;
	}
}
