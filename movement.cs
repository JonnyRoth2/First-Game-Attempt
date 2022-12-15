using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public bool jumping;
    private float move;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move= Input.GetAxis("Horizontal");
        body.velocity=new Vector2(speed*move,body.velocity.y);
        if (Input.GetButtonDown("Jump") && jumping==false)
        {
            body.AddForce(new Vector2(body.velocity.x,jump));
            Debug.Log("jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            jumping=false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            jumping=true;
        }
    }
}
