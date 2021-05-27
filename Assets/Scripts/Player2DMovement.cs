using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2DMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector2 localScale;

    public float speed = 2.0f;

    public bool isDead = false;
    public bool IsJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("IsJumping", false);
            IsJumping = false;
        }

        if (rb.velocity.y > 0){
            anim.SetBool("IsJumping", true);
            IsJumping = true;
        }

        if (Input.GetKey(KeyCode.DownArrow) && rb.velocity.y == 0 && !isDead){
            anim.SetBool("IsDead", true);
            isDead = true;
        }
            
        if (Input.GetKey(KeyCode.UpArrow) && isDead){
            anim.SetBool("IsDead", false);
            isDead = false;
        }
            
    }

    void FixedUpdate()
    {
        if (dirX==0){
            dirX = -speed;
        }

        if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0){
            anim.SetBool("IsJumping", true);
            IsJumping = true;
            rb.AddForce(Vector2.up * 500f);
        }

        rb.velocity = new Vector2(dirX, rb.velocity.y);

        if(rb.transform.position.x < -10 || rb.transform.position.y < -10){
            Die();
        }
    }

    void LateUpdate()
    {
        if (dirX > 0){
            facingRight = true;
        }   
        else if (dirX < 0){
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        
        transform.localScale = localScale;

    }

    void Die(){
        Debug.Log("Game Over");
    }
}
