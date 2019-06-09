using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {

    public GameObject PlayerPrefab;
    public GameObject[] enemylist;
    public bool Isplayer;

	// Use this for initialization
	void Start () {
        Invoke("BornTank", 1f);
        Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BornTank()
    {
        if (Isplayer)
        {
            Instantiate(PlayerPrefab, transform.position, transform.rotation);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enemylist[num], transform.position, transform.rotation);
        }
    }

}
