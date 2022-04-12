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
        if (new Vector2(transform.position.x,transform.position.y)==new Vector2(snake.transform.position.x,snake.transform.position.y))//Eðer elmanýn pozisyonu
        {                                                                                                                              //snake in pozisyonuna eþit olursa 
            Destroy(gameObject);                                                                                                       //
            snake.GetComponent<snake>().eatApple();//snake scriptine ulaþ ve içindeki eataplle fonsiyonunu çalýþtýr.Yani yýlan elma yediðinde kuyruðunu 1 arttýr.
        }
    }
}
