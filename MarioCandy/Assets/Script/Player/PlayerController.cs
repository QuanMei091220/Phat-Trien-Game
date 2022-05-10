using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int point=0;
    public Text txtCandyCoin;
    public float moveForce = 20f;
    public float maxVelocity = 5f;
    public float jumpForce = 700f;
    //public int maxHealth = 100;
    //public int currentHealth;
    public AudioSource audioSource;
    public AudioClip AudioJump;
    //public HealthBar healthBar;
    bool grounded = true;
    public bool spotted = false;
    public Transform startSight,endSight;
    public GameObject bulletplayer;
    public int numberBullet = 10;
    private float timeDelay = 0;

    public GameOverScreen GameOverScreen;    //Màn Hình Game over
    int maxPlatform = 0;
    //public static Vector2 lastCheckPointPos = new Vector2(-60, 0);
    Rigidbody2D myBody;
    Animator anim;
    public void GameOver()//Màn hình game over add vào trong player candy khi nó die hoặc hết thời gian
    {
        GameOverScreen.Setup(maxPlatform);
    }
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    // Start is called before the first frame update
    void Start()
    {   //txtCandyCoin là scrip ăn tiền  nó tìm đến địa chỉ commponent có candy coin
        txtCandyCoin = GameObject.Find("txtCandyCoin").GetComponent<Text>();
        //healthBar.SetMaxHealth(maxHealth);        
        //currentHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWallKeyBoard(); // Điều khiên nhân vật bằng bàn phím

        Debug.DrawLine(startSight.position, endSight.position, Color.red);
        spotted = Physics2D.Linecast(startSight.position, endSight.position, 1 << LayerMask.NameToLayer("Jumper"));
        timeDelay += Time.deltaTime;
        if (timeDelay > 0.5f && spotted && numberBullet > 0)
        {
            Attack();
            timeDelay = 0;
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //}
    }
    //void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    healthBar.SetHealth(currentHealth);
    //}
    void PlayerWallKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal"); // -1 0 -1 // di chuyển nhân vật
        anim.SetFloat("Speed", Mathf.Abs(h));// đổi thành hình ảnh animation di chuyển
        if (vel < maxVelocity) //idle ( nhân vật không di chuyển đứng im)
        {
            Vector3 scale = transform.localScale;
            transform.localScale = scale;
            anim.SetBool("AnimationPlayer", true); //add hình ảnh nhân vật lúc đứng im
            if (h > 0)
            {
                scale.x = 27f;
                if (vel < maxVelocity)
                {
                    if (grounded)
                    {
                        forceX = moveForce;
                    }
                    else
                    {
                        forceX = moveForce * 1.1f;
                    }

                }
            }
            else if (h < 0)
            {
                scale.x = -27f;
                if (vel < maxVelocity)
                {
                    if (grounded)
                    {
                        forceX = moveForce;
                    }
                    else
                    {
                        forceX = moveForce * 1.1f;
                    }

                }

            }
            else if (h == 0)
            {

            }

            transform.localScale = scale;


        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
                myBody.AddForce(new Vector2(0, jumpForce));

            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
        if (Input.GetKey(KeyCode.Space))
        {

            if (grounded)
            {
                forceY = jumpForce;
                grounded = false;
                
                audioSource.PlayOneShot(AudioJump);
                anim.SetBool("AnimationPlayerJump", true);
            }
        }else
        {
            anim.SetBool("AnimationPlayerJump", true);
        }
                myBody.AddForce(new Vector2(forceX, forceY));
    }
    void OnCollisionEnter2D(Collision2D target) // khi va chạm vào collider va chạm vào 1 collider khác 
    {
        if (target.gameObject.tag == "CandyCoin")
        {
            point += 1;
            txtCandyCoin.text = "CandyCoin" + point.ToString();
            Destroy(target.gameObject);
        }
        if (target.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if(target.gameObject.tag == "CandyCoin")
        {
            Destroy(target.gameObject);
        }
    }
    public void Jump() // chiều cao nhảy
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, jumpForce));
        }
    }
    void Attack()
    {
        numberBullet--;
        if (gameObject.transform.localScale.x == 1)
        { // hướng bắn của bullet theo hướng nhân vật di chuyển
            GameObject body = Instantiate(bulletplayer, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            body.GetComponent<bulletplayer>().Shoot(1);
        }
        else
        {
            GameObject body = Instantiate(bulletplayer, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            body.GetComponent<bulletplayer>().Shoot(-1);
        }
    }


}

