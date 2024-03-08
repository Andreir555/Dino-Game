using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Dinosaur : MonoBehaviour
{
    private float movementX, movementY = -0.2f;
    public float moveForce = 10f;

    public ShowGameOver showGameOver;
    public ShowHighScore showHighScore;

    [SerializeField]
    private float jumpForce = 300f;
    private float jumpImpulse = 1f;

    [SerializeField]
    public GamePoints puncte;

    [SerializeField]
    private float downForce = -2f;

    [SerializeField]
    private float speed = 5f;

    public Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    private string WALK_ANIMATION = "walk";
    private string JUMP_ANIMATION = "jump";
    private string DOWN_ANIMATION = "down";

    [SerializeField]
    private AudioClip jumpClip;
    [SerializeField]
    private AudioSource audioSource;

    public float volume = 0.5f;

    private bool isGrounded = true;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool(WALK_ANIMATION, true);
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S))
         {
            anim.SetBool(DOWN_ANIMATION, true);
        }
        if(Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool(DOWN_ANIMATION, false);
        }
        PlayerMoveKeyboard();
        //PlayerAnimation();
        myBody.velocity = new Vector2(speed, myBody.velocity.y);

        if (!isGrounded) anim.SetBool(JUMP_ANIMATION, true);
        else anim.SetBool(JUMP_ANIMATION, false);
        
        //PlayerMoveKeyboard();
    }
    private void LateUpdate()
    {
        SpeedUpdate();  
    }
    private void FixedUpdate()
    {
        playerJump();
        playerDown();
    }
    /*void holdingDownAnimation()
    {
        if (Input.GetKeyDown("down"))
        {
            anim.SetBool(DOWN_ANIMATION, true);
        }
        if (Input.GetKeyUp("down"))
        {
            anim.SetBool(DOWN_ANIMATION, false);
        }
    }*/
    void playerJump()
    {
        if ((Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isGrounded == true)
        {
            if(myBody.position.y > 0.4)
            {
                isGrounded = false;
                audioSource.Play();
                myBody.AddForce(new Vector2(0f, jumpForce * jumpImpulse), ForceMode2D.Impulse);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jumpImpulse += Time.deltaTime;
        }
        else jumpImpulse = 1f;

    }
    void playerDown()
    {
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            myBody.AddForce(new Vector2(0f, downForce), ForceMode2D.Impulse);
        }
    }
    void PlayerAnimation()
    {

        if (movementY > -0.12)
        {
            anim.SetBool(JUMP_ANIMATION, true);
        }
        else
        {
            anim.SetBool(JUMP_ANIMATION, false);
        }


    }

    void PlayerMoveKeyboard()
    {
        
        movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime / 4;
    }
    /*void PlayerMoveRight()
    {
        transform.position += new Vector3(1f, 0f, 0f) * moveForce * Time.deltaTime / 4;
    }*/
    void SpeedUpdate()
    {
        speed += (puncte.time/50);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") == true)
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy") == true)
        {
            Destroy(gameObject);
            puncte.freeze = true;
            float cucu = puncte.time;
            //Debug.Log(cucu);
            showGameOver.Setup();
            float highscore = PlayerPrefs.GetFloat("highscore", 0f);
            Debug.Log(highscore);
            if(highscore < cucu)
            {
                showHighScore.Setup();
                PlayerPrefs.SetFloat("highscore", cucu);
            }
            
            
        }
    }
}
