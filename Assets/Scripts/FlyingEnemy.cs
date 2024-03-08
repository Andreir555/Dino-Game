using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    [SerializeField] private float movementX;
    private string FLY_ANIMATION = "fly";

    public float speed = -2f;

    public Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool(FLY_ANIMATION, true);
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
