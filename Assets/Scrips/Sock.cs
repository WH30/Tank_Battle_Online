using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System.Text;

public class Sock : MonoBehaviour
{
    private static Sock instance;
    public Queue<string> enemy_queue;
    private bool Is_connect =false;
    Socket newclient;
    byte[] data;
    public static Sock Instance
    {
        get{
            return instance;
        }
        set{
            instance = value;
        }
    }
    public void Awake()
    {
        enemy_queue=new Queue<string>();
        data=new byte[1024];
    }
    void Start()
    {
        newclient=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        string ipadd="47.101.223.4"; // ip
        int port=5055;       // 端口
        IPEndPoint ie=new IPEndPoint(IPAddress.Parse(ipadd),port);
        Debug.Log(ipadd);
        try
        {
            //因为客户端只是用来向特定的服务器发送信息，所以不需要绑定本机的IP和端口。不需要监听。
            newclient.Connect(ie);
            Debug.Log("connect");
            Is_connect=true;
        }
        catch(SocketException e)
        {
            Debug.Log("unable to connect to server");
            Debug.Log(e.ToString());
            return;
        }
    }
    private void FixedUpdate()
    {
        if(!Is_connect) return ;
        /* 读取本地quene  发送信息  */
        if(PlayerManager.Instance.queue.Count!=0)
        {
            Queue<string> queue=PlayerManager.Instance.queue;
            while(queue.Count!=0)
            {
                string send_message=queue.Dequeue();
                newclient.Send(Encoding.ASCII.GetBytes(send_message));
            }
        }
        /* 读取服务器的数据，写进Enemy_quene */
        //判断当前detaT  结束
        data=new byte[1024];
        int recv=newclient.Receive(data);
        string recv_messgae=Encoding.ASCII.GetString(data,0,recv);
        enemy_queue.Enqueue(recv_messgae);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
