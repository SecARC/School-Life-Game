using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryDialogs : MonoBehaviour
{
    public GameObject DiyalogPenceresi;
    public Text BotAdi;
    public Text KonusmaMetni;
    public List<string> Metinler;
    public int MetinNumarasi;
    public InventoryItem book;
    
    private int count;

    private void Start()
    {
        DiyalogPenceresi = GameObject.FindGameObjectWithTag("KonusmaKutusu");
        BotAdi = GameObject.FindGameObjectWithTag("BotAdi").GetComponent<Text>();
        KonusmaMetni = GameObject.FindGameObjectWithTag("KonusmaMetini").GetComponent<Text>();
        DiyalogPenceresi.SetActive(false);
    }

    public void MetiniGoster()
    {
        KonusmaMetni.text = Metinler[MetinNumarasi];
    }

    public void SonrakiMetin()
    {
        if (MetinNumarasi < Metinler.Count - 1)
        {
            MetinNumarasi++;
            MetiniGoster();
        }
    }

    public void KonusmayiSonlandir()
    {
        DiyalogPenceresi.SetActive(false);
        if (count == 0)
        {
            book.numberHeld++;
            count++;
        }
    }

    public void KonusmayaBasla(string BotIsimi, List<string> Metin)
    {
        BotAdi.text = BotIsimi;
        Metinler = new List<string>(Metin);
        DiyalogPenceresi.SetActive(true);
        MetinNumarasi = 0;
        MetiniGoster();
    }
}
