using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scnmngr2 : MonoBehaviour
{
    /*new Vector2(taill.transform.position.x, taill.transform.position.y) == new Vector2(transform.position.x, transform.position.y)*/

    public tail j;
    public GameObject tailll;
    //public GameObject deadscreen;



    void Start()
    {

    }


    void Update()
    {
        if (j.dead == true)
        {
            this.gameObject.transform.localScale = new Vector3(3, 3, 3);
        }
    }
}
