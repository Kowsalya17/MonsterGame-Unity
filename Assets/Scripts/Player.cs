using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //[SerializeField] - private access but shows in inspector(Couldn't access by other scripts)
    //[HideInInspector] - Public accesss but not show in inspector !!!!


    public float moveForce = 10f;
    public float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    public GameObject gameoverpanel;
    bool _isgameover = false;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }
    void Start()
    {

    }

    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

        if (_isgameover == false)
        {
            gameoverpanel = GameObject.Find("Panel");
            _isgameover = true;
            gameoverpanel.SetActive(false);
        }
       
    }

    // void Update - Execute at each frame 
    // FixedUpdate - Execute at particular frame 
    // LateUpdate - Execute after all func. in update have been executed 



    void PlayerMoveKeyboard()
    {
        //GetAxis - either A or D or arrow buttons
        //GetAxis - -1 to 0 to 1
        //GetAxisRaw - -1.00 to 0 to 1.00
        //Input.GetKey - For space or any keys.....


        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
        //transform.position = transform.position + new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime ;
    }

    void AnimatePlayer()
    {
        if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            // Sprite renderer FlipX to turn or Rotate playe to opp side 
            sr.flipX = true;
        }
        else if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }

    void PlayerJump()
    {
        //GetButton - for space input and works continously while holding thge space 
        //GetButtonDown - for space input and works when holds the space button 
        //GetButtonUp - for space input and works when release the space button 

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            //ForceMode2D.Impulse - More force apply against rigid body to the player

            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) 
        { 
              isGrounded = true;
        }
        else if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            //SceneManager.LoadScene("GameOver");
            gameoverpanel.SetActive(true);
        }
        /*else if(collision.gameObject.tag== "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }*/


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
   // private void LoadGameOverScene()
  //  { SceneManager.LoadScene("GameOver");
    //}
}
