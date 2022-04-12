using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    public int num_of_lives=3 ;
    [SerializeField] TextMeshProUGUI LivesText ;
    [SerializeField] TextMeshProUGUI ScoresText ;
    int num_of_sessions;
    public int score;

    private void Update()
    {
        LivesText.text = num_of_lives.ToString();
        ScoresText.text = score.ToString();
    }
    private void Awake()
    {
        num_of_sessions = FindObjectsOfType<GameSession>().Length;
        if(num_of_sessions > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    public void ProcessPlayerDeath()
    {
        if (num_of_lives > 1)
            TakeLife();
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<ScenePersist>().Destroy_on_finale();
            Destroy(gameObject);
        }
    }

    void TakeLife()
    {
        --num_of_lives ;
        StartCoroutine(LoadLevelAgain());

    }

    IEnumerator LoadLevelAgain()
    {
        yield return new WaitForSecondsRealtime(1);
        int current_lvl = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_lvl);
    }
}
