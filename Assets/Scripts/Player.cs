using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    [SerializeField] 
    private Canvas customButton;

    private float movementX;
    private float movementY;
    public Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string JUMP_ANIMATION = "jump";
    private bool isGrounded = true;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerJump();

    }
    void Update()
    {
        PlayerMoveKeyBoard();
        PlayerAnimation();


    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f)  * moveForce * Time.deltaTime / 4;

    }

    void PlayerAnimation()
    {
        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

        if (movementY > 0)
        {
            anim.SetBool(JUMP_ANIMATION, true);
        }
        else
        {
            anim.SetBool(JUMP_ANIMATION, false);
        }
       
    }

    void playerJump()
    {
        if (Input.GetButton("Jump") && isGrounded == true)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            Destroy(gameObject);
            customButton.enabled = true;
        }
    }

}
