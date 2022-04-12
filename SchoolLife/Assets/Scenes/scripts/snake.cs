using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class snake : MonoBehaviour
{
    private float timer1, snakeWidth;
    public float timer2;
    private string direction;
    public GameObject apple;
    public int totaltail;
    [HideInInspector]
    public Vector3[] snaketails;
    public GameObject taill;
    private bool tailspawn;
    private string nowdirection;
    public float zaman;
    public GameObject[] nesneler;
    public float speedvalue1, timevalue1, speedvalue2, timevalue2, speedvalue3, timevalue3;
    public Text T;

    void Start()
    {
        zaman = 0;// �lk ba�ta zaman� 0 a e�itle.
        T.text = "" + (int)zaman;//Bunu tex UI a e�itle.
        tailspawn = true;//�lk ba�ta bir kere kuyruk spawnla.
        snakeWidth = gameObject.GetComponent<SpriteRenderer>().size.x;//snakewidth de�ikenini bu objenin size x ine e�itle kare oldu�u i�in x yeterli.
        Debug.Log(snakeWidth);
        //apple = GameObject.FindGameObjectWithTag("Apple");
        snaketails = new Vector3[28 * 28];//y�lan�n max boyutu 28 e 28 olabilir.
    }

    void Update()
    {
        zaman += Time.deltaTime; //Zaman de�i�kenini her delta s�rede artt�r.
        T.text=""+(int)zaman;// ve bunu text UI a bast�r.

        if (zaman>=timevalue1)// e�er zaman timevalue1 de�i�kenine ula��rsa;
        {
            timer2 = speedvalue1;// timer2 yi speedvalue 'e e�itle.
        }

        if (zaman >= timevalue2)
        {
            timer2 = speedvalue2;
        }

        if (zaman >= timevalue3)
        {
            timer2 = speedvalue3;
        }
        if (transform.position.x > 11 * snakeWidth)//E�er bu objenin x posizyonu 11 noktas�n� ge�tiyse ;
        {
            transform.position = new Vector3(-11 * snakeWidth, transform.position.y, transform.position.z);//Objenin x pozisyonunu -11 noktas�na ta��.
        }

        if (transform.position.x < -11 * snakeWidth)
        {
            transform.position = new Vector3(11 * snakeWidth, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -5 * snakeWidth)
        {
            transform.position = new Vector3(transform.position.x, 5 * snakeWidth, transform.position.z);
        }

        if (transform.position.y > 5 * snakeWidth)
        {
            transform.position = new Vector3(transform.position.x, -5 * snakeWidth, transform.position.z);
        }

        if (GameObject.FindGameObjectWithTag("Apple") == null)//E�er sahnede "apple" tagine sahip bir obje yoksa;
        {
            Instantiate(apple, new Vector3(Random.Range(11, -11) * snakeWidth, Random.Range(5, -5) * snakeWidth, apple.transform.position.z), Quaternion.identity);
            //(x,y) format�nda x koordinat�nda 11 ile -11 aras�nda ve y koordinat�nda 5 ile -5 aras�nda herhangi bir noktada apple isimli obje spawnla.
        }

        if (Input.GetKeyDown("w"))//E�er w tu�una bas�ld�ysa;
        {
            if (nowdirection != "down")// nowdirection de�i�keni down de�erini almam��sa yani karakter a�a�� gitmiyorsa;
            {
                direction = "up";//Karakter yukar� gitsin.
            }
        }

        if (Input.GetKeyDown("s"))//Ayn� �eyler bu k�s�mlar i�inde ge�erli.. burdaki ama� y�lan bir misal sa�a do�ru giderken sola bas�ld���nda gidemesin yani z�t y�ne,
                                  //gidemesin yoksa b�yle bir durum oldu�unda aniden ters y�ne gidersek y�lan kendine de�di�i i�in oyun sonlan�r..
        {
            if (nowdirection != "up")
            {
                direction = "down";
            }
        }

        if (Input.GetKeyDown("a"))
        {
            if (nowdirection != "right")
            {
                direction = "left";
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (nowdirection != "left")
            {
                direction = "right";
            }
        }

        if (Time.time > timer1)//E�er oyunun zaman� timer1 den b�y�kse;
        {
            for (int i = 0; i < totaltail; i++)//for d�ng�s� sayesinde bir sonraki kuyru�un �nceki kuyru�u takip etmesini sa�l�yourz.
            {
                snaketails[totaltail - i] = snaketails[totaltail - 1 - i];
            }

            snaketails[0] = transform.position;//dizinin 0 �nc� eleman�n� snakein pozisyonuna e�itle.

            if (direction == "right")//E�er direction de�i�keni right de�eri alm��sa yani sa�a gidiyorsa;
            {
                nowdirection = direction;//nowdirection u directiona e�itle.
                transform.position = new Vector3(transform.position.x + snakeWidth, transform.position.y, transform.position.z);//Ve x posizyonunu snakewidth kadar artt�r yani
            }                                                                                                                   //kendi boyuyu kadar.

            if (direction == "left")//Sola gidiyorsa x pozisyonunu snakewidth de�erinde azalt.
            {
                nowdirection = direction;
                transform.position = new Vector3(transform.position.x - snakeWidth, transform.position.y, transform.position.z);
            }

            if (direction == "up")
            {
                nowdirection = direction;
                transform.position = new Vector3(transform.position.x, transform.position.y + snakeWidth, transform.position.z);
            }

            if (direction == "down")
            {
                nowdirection = direction;
                transform.position = new Vector3(transform.position.x, transform.position.y - snakeWidth, transform.position.z);
            }

            if (tailspawn == true)//E�er tailspawn true ise yani spawna izin verilmi�se;
            {
                Instantiate(taill, transform.position, Quaternion.identity);//tail olarak atanm�� objeyi spawnla.
                tailspawn = false;// Ve spawn� durdur.
            }
            timer1 = timer2 + Time.time;//Timer1 i timer2 ile oyunun zaman�n�n toplam�na e�itle.
        }
    }

    public void eatApple()
    {
        totaltail += 1;//kuyruk say�s�n� artt�r.
        tailspawn = true;//kuyruk spawn�na izin ver.
        Debug.Log(totaltail);
    }
}
