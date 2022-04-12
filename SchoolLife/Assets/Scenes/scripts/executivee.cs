using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class executivee : MonoBehaviour
{
    public movement2 s;
    public GameObject player;
    public GameObject panel;

    void Update()
    {
        if (s.ýcame==true)
        {
            panel.SetActive(true);
        }

        if (s.ýcame==false)
        {
            panel.SetActive(false);

        }
    }
}
