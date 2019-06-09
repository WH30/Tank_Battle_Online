using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 6;
    public bool Isplayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * Speed * Time.deltaTime, Space.World);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Tank":
                if (!Isplayer)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                
                break;
            case "Enemy":
                if(Isplayer)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                    PlayerManager.Instance.scores++;
                }
                
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
