using System;
using System.Collections.Generic;
using Commit.Utils;
using Commit.Config;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using UnityEngine;

namespace TPSShoot
{
    public partial class ClientServer : MonoBehaviour
    {
        private static ClientServer instance; // 单例模式
        
        private static List<User> users = new List<User>();
        private static User clientUser; // 这个在登陆之后赋值，后续需要传

        public static ClientServer Instance { get { return instance; } }
        private void Awake()
        {
            instance = this;
            RequestSubScribe(); // 开启request中的订阅
        }
        /// <summary>
        /// 从这个位置开始网络连接
        /// </summary>
        public void Start()
        {
            InitUdpClient(); // 初始化udpclient
            StartReceiving(); // 开启协程，接收响应的信息
        }

        public void Update()
        {
            
        }

        private void OnDestroy()
        {
            RequestUnSubScribe(); // 销毁request中的订阅
        }
    }
}
