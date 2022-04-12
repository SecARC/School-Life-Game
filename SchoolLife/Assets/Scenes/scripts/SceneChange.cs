using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerPosition;
    public VectorValue playerStorage;
    public AutoSaveScript manager;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !other.isTrigger)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                playerStorage.initialValue = playerPosition;
                manager.SaveScriptables();
                SceneManager.LoadScene(sceneToLoad);
                manager.LoadScriptables();
            }
        }   
    }
}
