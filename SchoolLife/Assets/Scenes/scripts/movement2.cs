using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement2 : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;
    public VectorValue startingPosition;
    internal bool ýcame, hehe, icame, pccame, sleep,studycame;
    private bool isKickboard = false;    

    private float speed;
    public float jump;

    public InventoryItem scooter;

    public SceneName sceneNumber;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 7f;
        transform.position = startingPosition.initialValue;
        Debug.Log(SceneManager.GetActiveScene().name);
        sceneNumber.ScreenNumber = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (ýcame == true && Input.GetKeyDown(KeyCode.K))
        {
            hehe = true;
        }
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speed * Time.deltaTime;
        animator.SetBool("isRun", false);

        if (!isKickboard)
        {
            if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))
            {
                rgb.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
                animator.SetBool("isJump", true);
            }
            if (animator.GetBool("isJump") && Mathf.Approximately(rgb.velocity.y, 0))
            {
                animator.SetBool("isJump", false);
            }
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            if (!animator.GetBool("isJump"))
            {
                animator.SetBool("isRun", true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (!animator.GetBool("isJump"))
            {
                animator.SetBool("isRun", true);
            }
        }

        if (scooter.numberHeld == 1 & SceneManager.GetActiveScene().name=="MainScene")
        {
            if (Input.GetKeyDown(KeyCode.E) && isKickboard)
            {
                isKickboard = false;
                animator.SetBool("isKickBoard", false);
                speed = 7f;
            }
            else if (Input.GetKeyDown(KeyCode.E) && !isKickboard)
            {
                isKickboard = true;
                animator.SetBool("isKickBoard", true);
                speed = 13f;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="atari")
        {
            ýcame = true;
        }

        if (collision.gameObject.tag == "libraryexit" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (collision.gameObject.tag == "marketexit" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (collision.gameObject.tag == "market")
        {
            ýcame = true;
        }

        if (collision.gameObject.tag == "library")
        {
            icame = true;
        }

        if (collision.gameObject.tag == "pc")
        {
            pccame = true;
        }

        if (collision.gameObject.tag == "sleep")
        {
            sleep = true;
        }
        if (collision.gameObject.tag == "study")
        {
            studycame = true;
        }
        if (collision.gameObject.tag == "homeexit" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ýcame = false;
        icame = false;
        pccame = false;
        sleep = false;
        studycame = false;
    }
}