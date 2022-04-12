using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryDialogsManager : MonoBehaviour
{
    public string BotAdi;
    public GameObject DiyalogYoneticisi;
    public LibraryDialogs DiyalogScripti;
    public List<string> BotunMetinleri = new List<string>();

    private void Start()
    {
        DiyalogYoneticisi = GameObject.FindGameObjectWithTag("DiyalogYoneticisi");
        DiyalogScripti = DiyalogYoneticisi.GetComponent<LibraryDialogs>();
    }

    public void OnTriggerEnter2D(Collider2D Kontrol)
    {
        if (Kontrol.gameObject.tag == "Player")
        {
            DiyalogScripti.KonusmayaBasla(BotAdi, BotunMetinleri);
        }
    }

    public void OnTriggerExit2D(Collider2D Kontrol)
    {
        if (Kontrol.gameObject.tag == "Player")
        {
            DiyalogScripti.KonusmayiSonlandir();
        }
    }
}
