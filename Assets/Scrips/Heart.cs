using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    public Sprite BrokenHeart;
    private SpriteRenderer sr;
    public GameObject ExplosionPrefab;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
    private void Die()
    {
        sr.sprite = BrokenHeart;
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(ExplosionPrefab.gameObject, 0.167f);
        PlayerManager.Instance.Isdefeat = true;
    }
}
