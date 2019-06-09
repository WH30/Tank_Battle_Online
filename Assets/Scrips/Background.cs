using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Background : MonoBehaviour {

    //0.老家  1，墙 2，障碍 3，出生效果 4，河流 5，草 6，空气墙
    public GameObject[] Items;
    //用于存放位置
    private List<Vector3> itemPoisitionList = new List<Vector3>();

    //初始化的环境
    private void Awake()
    {
        //产生家的方法
        CreatItem(Items[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreatItem(Items[2], new Vector3(-1, -8, 0), Quaternion.identity);
        CreatItem(Items[2], new Vector3(1, -8, 0), Quaternion.identity);
        for(int i=-1;i<2;i++)
        {
            CreatItem(Items[2], new Vector3(i, -7, 0), Quaternion.identity); 
        }

        //产生空气墙的方法
        for (int i = -10; i < 11; i++)
        {
            CreatItem(Items[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -10; i < 11; i++)
        {
            CreatItem(Items[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -8; i <9 ; i++)
        {
            CreatItem(Items[6], new Vector3(-11,i, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreatItem(Items[6], new Vector3(11, i, 0), Quaternion.identity);
        }

     //产生玩家的方法

        //GameObject play = Instantiate(Items[3], new Vector3(-2, -8, 0), Quaternion.identity);
        //GameObject play = Instantiate(Items[3], Randomposition(), Quaternion.identity);
        //play.GetComponent<Born>().Isplayer = true;


/* 
        //初始化敌人的方法
        CreatItem2(Items[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreatItem2(Items[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreatItem2(Items[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreatEnemy", 4, 5);
*/
       //0.老家  1，墙 2，障碍 3，出生效果 4，河流 5，草 6，空气墙
      //产生其他场景
      //随机产生场景的方法
      /* 
      for(int i=0;i<100;i++)
        {    
            int num = Random.Range(1, 6);
            if(num!=3)
            {
                CreatItem(Items[num], Randomposition(), Quaternion.identity);
            }
        }
        */
        
        for(int i = -6;i<-1;i++)
        {
            CreatItem(Items[5], new Vector3(i, 1, 0), Quaternion.identity);
            CreatItem(Items[4], new Vector3(i, 0, 0), Quaternion.identity);
            CreatItem(Items[5], new Vector3(i, -1, 0), Quaternion.identity);
        }
        for(int i=2;i<=6;i++)
        {
            CreatItem(Items[5], new Vector3(i, 1, 0), Quaternion.identity);
            CreatItem(Items[4], new Vector3(i, 0, 0), Quaternion.identity);
            CreatItem(Items[5], new Vector3(i, -1, 0), Quaternion.identity);
        }
        for(int i=-1;i<=1;i++)
        {
             CreatItem(Items[5], new Vector3(i, 0, 0), Quaternion.identity);
        }

        for(int i=-10;i<=-5;i++)
        {
            CreatItem(Items[2], new Vector3(i, -5, 0), Quaternion.identity);
            CreatItem(Items[2], new Vector3(i, 5, 0), Quaternion.identity);
            CreatItem(Items[2], new Vector3(-i, -5, 0), Quaternion.identity);
            CreatItem(Items[2], new Vector3(-i, 5, 0), Quaternion.identity);
        }
        for(int i=2;i<5;i++)
        {
            CreatItem(Items[1], new Vector3(-5, i, 0), Quaternion.identity);
            CreatItem(Items[1], new Vector3(5, -i, 0), Quaternion.identity);
        }
        /* 
        for(int i=-8;i<=8;i++)
        {
            for(int j=-6;j<8;j++)
            {
                int k=0;
                k=Math.Abs(i%7+j%18);
                if(k<6&&k!=0&&k!=3)
                {
                    Debug.Log("k="+k);
                    CreatItem(Items[k], new Vector3(i, j, 0), Quaternion.identity);
                }

            }
        }
        */
        
        
        

    }




    //产生item的方法
    private void CreatItem(GameObject gameObject, Vector3 creatposition, Quaternion creatrotation)
    {
        GameObject item = Instantiate(gameObject, creatposition, creatrotation);
        item.transform.SetParent(this.gameObject.transform,true);
        itemPoisitionList.Add(creatposition);
    }

    private void CreatItem2(GameObject gameObject, Vector3 creatposition, Quaternion creatrotation)
    {
        GameObject item = Instantiate(gameObject, creatposition, creatrotation);
        item.transform.SetParent(this.gameObject.transform, true);
    }


    //判断位置是否已经有
    private bool HasPosition(Vector3 position)
    {
        for (int i = 0; i < itemPoisitionList.Count; i++)
        {
            if (position == itemPoisitionList[i])
            {
                return true;
            }
           
        } 
               return false;
    }
    //随机产生不重复的位置
    private Vector3 Randomposition()
    {
        while(true)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-9, 10), UnityEngine.Random.Range(-7, 8), 0);
            if (!HasPosition(position))
            {
                return position;
            }
        }
    }

    //产生敌人的方法
    private void CreatEnemy()
    {
        int num = UnityEngine.Random.Range(0, 3);
        Vector3 enemypos = new Vector3();
        if (num == 0)
            enemypos = new Vector3(-10, 8, 0);
        else if (num == 1)
            enemypos = new Vector3(0, 8, 0);
        else
            enemypos = new Vector3(10, 8, 0);
        CreatItem2(Items[3], enemypos, Quaternion.identity);
    }
}
