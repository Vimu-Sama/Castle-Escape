using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    GameSession game_session;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Player")
        {
            //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            other.gameObject.GetComponent<AudioSource>().Play();
            game_session = FindObjectOfType<GameSession>();
            game_session.score+= 100;
            Destroy(gameObject);
        }
    }
}
