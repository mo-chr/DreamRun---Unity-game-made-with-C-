using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class infiniteRunner : MonoBehaviour
{   //particles
    public ParticleSystem particle;
    //WallSliding
    public bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    bool wallJumping;
    public float xWallForce;
    public float yWallforce;
    public float wallJumpTime ;
    //Dash

    bool canDash;
    public float dashSpeed=90f;
    public float dashTime=1f;
    public float cooldowntime=0.3f;
    float nextFireTime=0f;
    
    //Character select
    GameObject gm;
    levelGenerator level;
    SettingsMenu settings;
  


    //pause Menu
    public int highestscore;
    int i;
    int totalScore=0;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    
    //HighScore
    
    
    public  TextMeshProUGUI highScore;

    public AudioSource coinSound;
    public AudioSource obstacleSound;
    public AudioSource jumpSound;
    public static int coinNumber;
    
    public int coinBonus;
    public TextMeshProUGUI coinsText;
    //Score
    public int score = 0;
    public TextMeshProUGUI scoreText ;
    public int ScoreTotal;
  
    //gameLost
    GameOver endGame;
    public GameObject gameOverPanel;
    private Animator anim;
    public float moveSpeed = 2f;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool canDoubleJump;

    // Movement (if holding left or right arrow keys)

    private float moveInput;

    /// <Jump>
    bool canJump;
    public float doubleJumpForce = 6f;
    public float jumpForce = 4f;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isGrounded ;
    public bool isJumping,isDoubleJumping, isFalling,isRunning;
    private Rigidbody2D rb;
    

    /// <Jump>

    // Start is called before the first frame update
    void Start()
    {
        
        // PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("Coins",400);
        canJump = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
        coinNumber = PlayerPrefs.GetInt("Coins");
        UpdateCoins();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        isRunning = true;

   

    }

    void Update()
    {
  

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (rb.velocity.x > 0.01 && isGrounded)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
        }


        Jump();
        Vector3 movement = new Vector3(1, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
      
        //coins / scores / highscores

        totalScore = (int)rb.position.x * 10;

        HighScore();

        scoreText.text = "Score :" + totalScore;

        highestscore = PlayerPrefs.GetInt("HighScore", 1);
        highScore.text = "Highscore : " + PlayerPrefs.GetInt("HighScore", 1).ToString();
        UpdateCoins();

        coinsText.SetText("Coins : " + coinNumber);

        //Spawning TIles stuff




        //Pause menu

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
        //wallJump
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);
        if (isTouchingFront == true && isGrounded == false)
        {
            wallSliding = true;

        }
        else
        {
            wallSliding = false;

        }
        if (wallSliding)
        {   
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Mouse0)) && wallSliding == true)

        {

            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);

        }
        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce,yWallforce);

        }
//Dashing
      /*  if(isGrounded == false && Time.time> nextFireTime && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canDash == true)
            {
                Debug.Log("Dash!");

                transform.position += movement * Time.deltaTime * dashSpeed;
                nextFireTime = Time.time + cooldowntime;
                Invoke("disableDash",3);
            }

        }
        if (isGrounded==true)
        {

            canDash = true;
        }*/
    
    



    }
    public void HighScore()
    {   if (totalScore > PlayerPrefs.GetInt("HighScore", 1))
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
            
        }

    }
    
    void Jump()
    {

        if (isGrounded)
        {
            isJumping = false;
            anim.SetBool("isDoubleJumping", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isGrounded", true);
            canDoubleJump = true;
           
        }

        if (Input.GetKeyDown(KeyCode.Space)&& canJump|| Input.GetMouseButtonDown(0) && canJump)
        {
            if (isGrounded)
            {

                rb.velocity = Vector2.up * jumpForce;
                isJumping = true;
                anim.SetBool("isJumping", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isGrounded", false);
                jumpSound.Play();
                CreateParticle();
            }
            else
            {
                if (canDoubleJump)
                {
                   
                        rb.velocity = Vector2.up * doubleJumpForce;
                        canDoubleJump = false;
                        isDoubleJumping = true;
                        anim.SetBool("isJumping", true);
                        anim.SetBool("isRunning", false);
                        anim.SetBool("isGrounded", false);
                        jumpSound.Play();
                        CreateParticle();

                }
             

            }


        }
       


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
         {


             rb.isKinematic = true;
             rb.GetComponent<Animator>().enabled = false;
             canJump = false;
             moveSpeed = 0;
             obstacleSound.Play();
             Time.timeScale = 0f;
             gameOverPanel.SetActive(true);
             obstacleSound.Play();

         }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinSound.Play();
            coinNumber+=1;
            Destroy(other.gameObject);

        }
    }
    public void Resume()

    {
        canJump = true;
        Time.timeScale = 1.0f;    
        pauseMenu.SetActive(false);
        GameIsPaused = false;
        

    }
   
    private void Pause()
    {
        canJump = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public static void UpdateCoins()
    {
        
        PlayerPrefs.SetInt("Coins", coinNumber);
       
        PlayerPrefs.Save();

    }
    void SetWallJumpingToFalse()
    {

        wallJumping = false;
    }
    void disableDash()
    {
        canDash = false;

    }
    void CreateParticle() 
    {
        particle.Play();
    
    }
    public void RewardCoins() 
    {

        coinNumber += 30;
        PlayerPrefs.SetInt("Coins", coinNumber);
    
    }
 


}
    


