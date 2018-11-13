using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{



    private ScrollBackground _scrollBackground;
    private UIManager _uiManager;
    private SavePosition _savePosition;
    public GameObject player;
    private Rigidbody2D TheBody = null;
    public float MaxSpeed = -7.0f;
  //  private Transform TheTransform = null;
    public float xMovement = 0.0f;
    public float yMovement = 0.0f;
    public bool moveBackgroundLeft = false;
    public bool moveBackgroundRight = false;
    [SerializeField]
    private int _lives;
    [SerializeField]
    private int _totalCoin = 0;
  //  Vector3  pos = new Vector3(12f, -5.6f, 0);

    public AudioClip JumpAudio = null;
    public AudioClip DamageSound = null;
    public float Volume = 1.0f;
    protected Transform Posicion = null;
    public bool jumpReady = false;

    public float alturaSalto;
    public float velocidadMovimineto;





    private void Awake()
    {
        TheBody = GetComponent<Rigidbody2D>();
      //  TheTransform = GetComponent<Transform>();

    }

    // Use this for initialization
    void Start()
    {
        Posicion = transform;
        //current pos = new position
        transform.position = new Vector3(12f, -5.6f, 0);


        _savePosition = GameObject.Find("savePosition").GetComponent<SavePosition>();
        _scrollBackground = GameObject.Find("Background").GetComponent<ScrollBackground>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
       
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(_lives);
        }


    }

    // Update is called once per frame
    void Update()
    {

        limitTop();


    }



    private void FixedUpdate()
    {
      //  float H = Input.GetAxis("Horizontal");
      //  float v = Input.GetAxis("Vertical");

        Vector3 Direction = new Vector3(xMovement, yMovement, 0);
        TheBody.AddForce(Direction.normalized * MaxSpeed * Time.deltaTime);

      
    }


    public void Xmovement(float X)
    {
        xMovement = X;


    }

    public void Ymovement(float Y)
    {
        yMovement = Y;

    }


    public void limitTop()
    {



        if (transform.position.x > 12f || transform.position.x < 12f)
        {
            transform.position = new Vector3(12f, transform.position.y, 0);
        }

       



        if (transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x, 5f);
        }
    }



    public void moveRight()

    {
       

        if (GetComponent<SpriteRenderer>().flipX == true)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        GetComponent<Animator>().SetBool("isRun", true);

        GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMovimineto, GetComponent<Rigidbody2D>().velocity.y);



            moveBackgroundRight = true;
       
       


    }

    public void moveLeft()
    {
       

        if (GetComponent<SpriteRenderer>().flipX == false)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        GetComponent<Animator>().SetBool("isRun", true);

        GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadMovimineto, GetComponent<Rigidbody2D>().velocity.y);

       
        moveBackgroundLeft = true;

      

    }

    public void moveUp()
    {
       
        if (GetComponent<SpriteRenderer>().flipY == true)
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }

        //direction jump control

        if (GetComponent<SpriteRenderer>().flipX == false)
        {
            GetComponent<Animator>().SetBool("isJump", true);
          //  transform.Translate(0, 7f, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,alturaSalto);
            _scrollBackground.backgroundRight();
            //Sonido
           if(JumpAudio) AudioSource.PlayClipAtPoint(JumpAudio, Posicion.position, Volume);

            jumpReady = true;

        }

       

    
        else{
            GetComponent<Animator>().SetBool("isJump", true);
            // transform.Translate(0, 7f, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, alturaSalto);
            _scrollBackground.backgroundLeft();
            if (JumpAudio) AudioSource.PlayClipAtPoint(JumpAudio, Posicion.position, Volume);
        }
    }


    public void moveStop()
    {
        jumpReady = false;
        GetComponent<Animator>().SetBool("isRun", false);
        GetComponent<Animator>().SetBool("isJump", false);
     
        moveBackgroundLeft = false;
        moveBackgroundRight = false;

    }



    public void Tochange()
    {
        StartCoroutine(waitToChange());
    }


    // Wait 3 second
    IEnumerator waitToChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            _uiManager.ShowPlayStartScreen();

        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        //  Debug.Log("collision" + other.name);

        if (other.tag == "Water" || other.tag == "Saw" || other.tag == "Mace" || other.tag == "Ball")
        {


            if (_savePosition.savePositionActive == true)
            {
                //New Save position
                transform.position = new Vector3(xMovement, yMovement, 0);
               
            }
            else
            {
                //comback player to current position
                transform.position = new Vector3(12f, -5.6f, 0);
                _scrollBackground.backgroundCollider();
            }

          
            Damage();
        }

        //Coin Collider + point
        if (other.tag == "Coin")
        {
            _totalCoin++;

            _uiManager.UpdateScore();

        }


        //make player mini
        if (other.tag == "PlayerMini")
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);

        }

        //make player big
        if (other.tag == "PlayerBig")
        {
            transform.localScale = new Vector3(3, 3, 1);

        }

        //Finish
        if (other.tag == "Door")
        {
            _uiManager.FinishScreen();
            transform.localScale = new Vector3(0, 0, 0);
            Tochange();

        }

        //+ live
        if (other.tag == "Live")
        {
            _lives++;
            _uiManager.UpdateLives(_lives);
        }

       






    }



    public void Damage()
    {
        if (DamageSound) AudioSource.PlayClipAtPoint(DamageSound, Posicion.position, Volume);
        _lives--;
        _uiManager.UpdateLives(_lives);

        if (_lives < 1)
        {
        //    Debug.Log("Game Over");
          //  _gameManager.gameOver = true;
            _uiManager.GameOverScreen();
            //  player.SetActive(false);
            transform.localScale = new Vector3(0, 0, 0);

            // Wait 3 second
            Tochange();




        }


    }

    public void StartPlayerAgain()
    {

        player.SetActive(true);

    }


    //public void StartPlayerAgain()
    //{

    //    player.SetActive(true);

    //}









}
