using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tail : MonoBehaviour
{
    private GameObject snake;
    private int tailnumber;
    float time;
    public bool dead;
    private GameObject dc;
    public snake SnakeSc;
    public CheckResult chkrslt;
    

    void Start()
    {
        snake = GameObject.Find("Snake");
        dc = GameObject.Find("DeadScreen");
       
        tailnumber = snake.GetComponent<snake>().totaltail;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5f)
        {
            if (new Vector2(transform.position.x, transform.position.y) == new Vector2(snake.transform.position.x, snake.transform.position.y))
            {
                dc.transform.localScale = new Vector3(3, 3, 3);
                Time.timeScale = 0f;
                if (SnakeSc.totaltail >= 15)
                {
                    chkrslt.spacegamewin();
                }
                else if (SnakeSc.totaltail<15)
                {
                    chkrslt.spacegamelose();
                }
                //dead = true;
                //E�er kuyru�un pozisyonu snake in poziyonuna e�it olursa yani y�lan�n kuyru�u kendisine de�erse;
                /*SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/// aktif olan sahneyi tekrar y�kle,yani oyunu tekrar ba�lat.

            }

            
        }
        transform.position = snake.GetComponent<snake>().snaketails[tailnumber];//objenin pozisyonunu 
    }
}
