using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DinoGameMovement : MonoBehaviour
{
    Rigidbody2D playerBody;
    public Animator animator;
    private float moveSpeed;
    private float jump;
    public Text scoreText;
    public Text entry;
    internal float decimalScore;
    internal int scoreInt;
    private bool startBool;
    public GameObject failedButton;
    public GameObject passedButton;
    private float scoreFactor;
    public SceneName number;
    public FloatValue playerKnowledge;
    public CheckResult chkrslt;
    private int winCond;

    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startBool = false;
        scoreText.enabled = false;
        entry.enabled = true;
        failedButton.gameObject.SetActive(false);
        passedButton.gameObject.SetActive(false);
        moveSpeed = 5;
        jump = 7;
        StartGame();
        StartCoroutine(getFaster());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)&&startBool==false)
        {
            startBool = true;
            scoreText.enabled = true;
            entry.enabled = false;
            animator.SetBool("isRun", true);
        }

        if (startBool)
        {
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
            decimalScore += scoreFactor * Time.deltaTime;
            scoreInt = Mathf.RoundToInt(decimalScore);
            scoreText.text = "Score : " + scoreInt.ToString();

            if (animator.GetBool("isJump") && Mathf.Approximately(playerBody.velocity.y, 0))
            {
                animator.SetBool("isRun", true);
                animator.SetBool("isJump", false);
            }

            if (Input.GetButtonDown("Jump") && Mathf.Approximately(playerBody.velocity.y, 0))
            {
                playerBody.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
                animator.SetBool("isRun", false);
                animator.SetBool("isJump", true);
            }
        }
    }

    void StartGame()
    {
        if (playerKnowledge.initialValue >= 0 && playerKnowledge.initialValue < 33)
        {
            scoreFactor = 3;
            winCond = 150;
        }
        else if (playerKnowledge.initialValue >= 33 && playerKnowledge.initialValue < 66)
        {
            scoreFactor = 4;
            winCond = 110;
        }
        else if (playerKnowledge.initialValue >= 66 && playerKnowledge.initialValue <= 100)
        {
            scoreFactor = 5;
            winCond = 80;
        }
    }

    void CheckResult()
    {
        if (scoreInt >= winCond)
        {
            passedButton.gameObject.SetActive(true);
            chkrslt.win();
        }
        else if (scoreInt<winCond)
        {
            failedButton.gameObject.SetActive(true);
            chkrslt.lose();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hurdle")
        {
            Debug.Log("Trigger");
            moveSpeed = 0;
            jump = 0;
            scoreFactor = 0;
            animator.SetBool("die",true);
            startBool = false;
            CheckResult();
        }
    }

    public void FailGame()
    {
        SceneManager.LoadScene("School");
    }

    public IEnumerator getFaster()
    {
        while (true)
        {
            moveSpeed += 0.5f;
            scoreFactor += 0.5f;

            yield return new WaitForSeconds(1f);
        }
    }
}
