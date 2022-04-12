using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    int nxt_lvl=0;
    private void Start()
    {
        nxt_lvl = SceneManager.GetActiveScene().buildIndex + 1;
        if (nxt_lvl == SceneManager.sceneCountInBuildSettings)
            nxt_lvl = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {       
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(nxt_lvl);
    }

}
