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
        if (s.�came==true)
        {
            panel.SetActive(true);
        }

        if (s.�came==false)
        {
            panel.SetActive(false);

        }
    }
}
