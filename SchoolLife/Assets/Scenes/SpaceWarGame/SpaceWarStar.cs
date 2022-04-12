using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWarStar : MonoBehaviour
{
    SpriteRenderer showing;

    void Start()
    {
        showing = GetComponent<SpriteRenderer>();
        float random1 = Random.Range(0.05f, 0.1f);
        float random2 = Random.Range(0.02f, 0.05f);
        transform.localScale = new Vector3(random1, random2, 1f);
        if (random1 > 0.07)
        {
            showing.enabled = false;
        }
        InvokeRepeating("showingChange", 0f, 3f);
    }

    void showingChange()
    {
        showing.enabled = !showing.enabled;
    }
}
