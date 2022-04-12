using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleSpawnerScript : MonoBehaviour
{
    public GameObject[] hurdlePrefabs;
    
    void Start()
    {
        StartCoroutine(HurdleSpawner());
    }

    public IEnumerator HurdleSpawner()
    {
        while (true)
        {
            int randomHurdle = Random.Range(0, 3);
            Instantiate(hurdlePrefabs[randomHurdle], new Vector3(transform.position.x, transform.position.y, 1), Quaternion.Euler(0f,-124f,0f));

            yield return new WaitForSeconds(Random.Range(2, 3));
        }
    }
}
