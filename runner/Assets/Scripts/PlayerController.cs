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

    public float timeTemp;
    public float slideTemp;
	// Use this for initialization
	void Start () {
        //PlayerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump") && grounded){
            PlayerRigidbody.AddForce(new Vector2(0, forceJump));
            slide = false;
        }
        if(Input.GetButtonDown("Slide") && grounded){
            slide = true;
            timeTemp = 0;
        }
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, wground);

        if(slide){
            timeTemp += Time.deltaTime;
            if(timeTemp >= slideTemp){
                slide = false;
            }
        }

        Anime.SetBool("jump", !grounded);
        Anime.SetBool("slide", slide);
	}
}
