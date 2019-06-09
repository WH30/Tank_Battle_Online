using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_player : MonoBehaviour
{
     public float speed = 3;
    public Vector3 BulletEulerAngles;
    public float Timeall;   //攻击时间间隔
    public  float ChangeDirectionTime ;
    private float h;
    private float v;
    public SpriteRenderer sr;
    public GameObject BulletFabs;
    public GameObject ExplosionPrefab;

    public Queue<string> queue;
    public string Enemy_name;

    private static Enemy_player instance;

    public static Enemy_player Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }
  


    public Sprite[] tankerSprite;//上右下左
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    // Use this for initialization
    void Start()
    {
        queue =new Queue<string> ();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        while(queue.Count!=0)
        {
            string s=(string)queue.Dequeue();
            if(s=="a") Attack();
            else
            {
                float h=0,v=0;
                if(s=="u") h=1;
                else if(s=="d") h=-1;
                else if(s=="l") v=-1;
                else if(s=="r") v=1;
                Move(h,v);
            }

        }
       //  Move();
    }

    private void Move (float h,float v)
    {
       // float h = Input.GetAxisRaw("Horizontal");
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

     //   float v = Input.GetAxisRaw("Vertical");
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


    //攻击方法
    private void Attack()
    {
        // Instantiate(BulletFabs, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
        CreatBullet(BulletFabs, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
           // Timeall = 0;
        
    }

    private void CreatBullet(GameObject gameObject, Vector3 creatposition, Quaternion creatrotation)
    {
        GameObject item = Instantiate(gameObject, creatposition, creatrotation);
       // item.transform.SetParent(gameObject.transform);
    }

    //移动方法
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirectionTime = 4;
        
    }

    //死亡方法
    private void Die()
    {
        //触发爆炸特效
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        PlayerManager.Instance.playerDict.Remove(Enemy_name);
        //销毁对象
        Destroy(gameObject);

    }
}
