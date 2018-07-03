using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Animator Anime;
    public Rigidbody2D PlayerRigidbody;
    public int forceJump;
    public bool slide;

    public Transform GroundCheck;
    public bool grounded;
    public LayerMask wground;
	// Use this for initialization
	void Start () {
        //PlayerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump")){
            PlayerRigidbody.AddForce(new Vector2(0, forceJump));
        }
        if(Input.GetButtonDown("Slide")){
            slide = true;
        }
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, wground);
        Anime.SetBool("jump", !grounded);
        Anime.SetBool("slide", slide);
	}
}
