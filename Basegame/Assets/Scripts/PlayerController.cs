using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;

    private float moveInput;
    public float speed;
    public float jumpForce; 
    
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isJumping;
    private float jumpTimeCounter;
    public float jumpTime;

    private bool isDashing = true;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float direction;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {

        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            isGrounded = false;
            isJumping = true;
            anim.SetBool("IsJumping", true);
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true){
            anim.SetBool("IsJumping", true);
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else{
                isJumping = false;
                anim.SetBool("IsJumping", false);
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            anim.SetBool("IsJumping", false);
            isJumping = false;
        }

        if(transform.rotation.y != 0){
            direction = 1;
        }
        if(transform.rotation.y == 0){
            direction = 2;
        }
        if(dashTime <= 0){
            // direction = 0;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;                
        } 
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(moveInput > 0 || moveInput < 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && direction != 0 && isDashing){
            if(dashTime > 0){
                dashTime -= Time.deltaTime;
                anim.SetBool("Dashing", true);

                if(direction == 1){
                    rb.velocity = Vector2.left * dashSpeed;
                } else{
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
            isDashing = false;
            StartCoroutine(DashWait());
        }
    }

    private IEnumerator DashWait()
    {
        yield return new WaitForSeconds(startDashTime);
        isDashing = true;
        anim.SetBool("Dashing", false);
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        isGrounded = true;
    }
}
