using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    private GameObject snake;

    void Start()
    {
        snake = GameObject.Find("Snake");//Snake isimli objeyi bul.
    }

    void Update()
    {
        if (new Vector2(transform.position.x,transform.position.y)==new Vector2(snake.transform.position.x,snake.transform.position.y))//E�er elman�n pozisyonu
        {                                                                                                                              //snake in pozisyonuna e�it olursa 
            Destroy(gameObject);                                                                                                       //
            snake.GetComponent<snake>().eatApple();//snake scriptine ula� ve i�indeki eataplle fonsiyonunu �al��t�r.Yani y�lan elma yedi�inde kuyru�unu 1 artt�r.
        }
    }
}
