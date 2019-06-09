using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 3;
    public Vector3 BulletEulerAngles;
    public float Timeall;   //攻击时间间隔
    public  float ChangeDirectionTime ;
    private float h;
    private float v;
    public SpriteRenderer sr;
    public GameObject BulletFabs;
    public GameObject ExplosionPrefab;
  


    public Sprite[] tankerSprite;//上右下左
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        Timeall = 0;
        ChangeDirectionTime = 0;
        v = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timeall >= 1.5f)
        {
            Attack();
        }
        if(Timeall<1.5f)
        {
            Timeall += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }


    //攻击方法
    private void Attack()
    {
        // Instantiate(BulletFabs, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
        CreatBullet(BulletFabs, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
            Timeall = 0;
        
    }

    private void CreatBullet(GameObject gameObject, Vector3 creatposition, Quaternion creatrotation)
    {
        GameObject item = Instantiate(gameObject, creatposition, creatrotation);
       // item.transform.SetParent(gameObject.transform);
    }

    //移动方法
    private void Move()
    {
        if(ChangeDirectionTime>=1.5f)
        {
            int num = Random.Range(0, 8);
            if (num >= 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                v = 0;
                h = 1;
            }
            else if(num>2&&num<=4)
            {
                v = 0;
                h = -1;
            }
            ChangeDirectionTime = 0;

        }
        else
        {
            ChangeDirectionTime += Time.fixedDeltaTime;
        }


       // h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankerSprite[3];
            BulletEulerAngles = new Vector3(0, 0, 90);
        }
        if (h > 0)
        {
            sr.sprite = tankerSprite[1];
            BulletEulerAngles = new Vector3(0, 0, -90);
        }
        if (h != 0)
            return;

     //   v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);
        if (v > 0)
        {
            sr.sprite = tankerSprite[0];
            BulletEulerAngles = new Vector3(0, 0, 0);
        }
        if (v < 0)
        {
            sr.sprite = tankerSprite[2];
            BulletEulerAngles = new Vector3(0, 0, 180);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirectionTime = 4;
    }

    //死亡方法
    private void Die()
    {

        //触发爆炸特效
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        //销毁对象
        Destroy(gameObject);
    }
}
