using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleScript : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
