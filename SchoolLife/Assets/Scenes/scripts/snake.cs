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
        zaman = 0;// Ýlk baþta zamaný 0 a eþitle.
        T.text = "" + (int)zaman;//Bunu tex UI a eþitle.
        tailspawn = true;//Ýlk baþta bir kere kuyruk spawnla.
        snakeWidth = gameObject.GetComponent<SpriteRenderer>().size.x;//snakewidth deðikenini bu objenin size x ine eþitle kare olduðu için x yeterli.
        Debug.Log(snakeWidth);
        //apple = GameObject.FindGameObjectWithTag("Apple");
        snaketails = new Vector3[28 * 28];//yýlanýn max boyutu 28 e 28 olabilir.
    }

    void Update()
    {
        zaman += Time.deltaTime; //Zaman deðiþkenini her delta sürede arttýr.
        T.text=""+(int)zaman;// ve bunu text UI a bastýr.

        if (zaman>=timevalue1)// eðer zaman timevalue1 deðiþkenine ulaþýrsa;
        {
            timer2 = speedvalue1;// timer2 yi speedvalue 'e eþitle.
        }

        if (zaman >= timevalue2)
        {
            timer2 = speedvalue2;
        }

        if (zaman >= timevalue3)
        {
            timer2 = speedvalue3;
        }
        if (transform.position.x > 11 * snakeWidth)//Eðer bu objenin x posizyonu 11 noktasýný geçtiyse ;
        {
            transform.position = new Vector3(-11 * snakeWidth, transform.position.y, transform.position.z);//Objenin x pozisyonunu -11 noktasýna taþý.
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

        if (GameObject.FindGameObjectWithTag("Apple") == null)//Eðer sahnede "apple" tagine sahip bir obje yoksa;
        {
            Instantiate(apple, new Vector3(Random.Range(11, -11) * snakeWidth, Random.Range(5, -5) * snakeWidth, apple.transform.position.z), Quaternion.identity);
            //(x,y) formatýnda x koordinatýnda 11 ile -11 arasýnda ve y koordinatýnda 5 ile -5 arasýnda herhangi bir noktada apple isimli obje spawnla.
        }

        if (Input.GetKeyDown("w"))//Eðer w tuþuna basýldýysa;
        {
            if (nowdirection != "down")// nowdirection deðiþkeni down deðerini almamýþsa yani karakter aþaðý gitmiyorsa;
            {
                direction = "up";//Karakter yukarý gitsin.
            }
        }

        if (Input.GetKeyDown("s"))//Ayný þeyler bu kýsýmlar içinde geçerli.. burdaki amaç yýlan bir misal saða doðru giderken sola basýldýðýnda gidemesin yani zýt yöne,
                                  //gidemesin yoksa böyle bir durum olduðunda aniden ters yöne gidersek yýlan kendine deðdiði için oyun sonlanýr..
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

        if (Time.time > timer1)//Eðer oyunun zamaný timer1 den büyükse;
        {
            for (int i = 0; i < totaltail; i++)//for döngüsü sayesinde bir sonraki kuyruðun önceki kuyruðu takip etmesini saðlýyourz.
            {
                snaketails[totaltail - i] = snaketails[totaltail - 1 - i];
            }

            snaketails[0] = transform.position;//dizinin 0 ýncý elemanýný snakein pozisyonuna eþitle.

            if (direction == "right")//Eðer direction deðiþkeni right deðeri almýþsa yani saða gidiyorsa;
            {
                nowdirection = direction;//nowdirection u directiona eþitle.
                transform.position = new Vector3(transform.position.x + snakeWidth, transform.position.y, transform.position.z);//Ve x posizyonunu snakewidth kadar arttýr yani
            }                                                                                                                   //kendi boyuyu kadar.

            if (direction == "left")//Sola gidiyorsa x pozisyonunu snakewidth deðerinde azalt.
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

            if (tailspawn == true)//Eðer tailspawn true ise yani spawna izin verilmiþse;
            {
                Instantiate(taill, transform.position, Quaternion.identity);//tail olarak atanmýþ objeyi spawnla.
                tailspawn = false;// Ve spawný durdur.
            }
            timer1 = timer2 + Time.time;//Timer1 i timer2 ile oyunun zamanýnýn toplamýna eþitle.
        }
    }

    public void eatApple()
    {
        totaltail += 1;//kuyruk sayýsýný arttýr.
        tailspawn = true;//kuyruk spawnýna izin ver.
        Debug.Log(totaltail);
    }
}
