using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    GameSession game_session;
    private void Awake()
    {
        game_session = GetComponent<GameSession>();
        int num_of_same_objects = FindObjectsOfType<ScenePersist>().Length;
        if (num_of_same_objects > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    public void Destroy_on_finale()
    {
        Destroy(gameObject);
    }

}
