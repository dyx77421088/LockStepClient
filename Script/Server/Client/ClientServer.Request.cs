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
    /// <summary>
    /// 处理请求
    /// </summary>
    public partial class ClientServer
    {
        private const int port = 12345;
        // 谁在发送，发送请求的udp
        private UdpClient udpClient = new UdpClient(); 
        // 发送给谁， NetConfig.IP port
        private IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(NetConfig.IP), port); 

        public void RequestSubScribe()
        {
            Events.LoginRequest += Login; // 登陆
        }
        public void RequestUnSubScribe()
        {
            Events.LoginRequest -= Login;
        }

        private void InitUdpClient()
        {
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 0)); // 0：自己分配端口号 也可以指定具体的端口
        }
        // 登陆的订阅
        private void Login(string userName, string password)
        {
            User user = new User();
            user.Name = userName;
            user.Password = password;
            // 序列化
            byte[] message = ProtoBufUtils.SerializeBaseRequest(user, RequestType.RtLogin, RequestData.RdUser);

            udpClient.Send(message, message.Length, serverEndPoint);
        }
        /// <summary>
        /// 是否进入匹配
        /// </summary>
        /// <param name="userId">用户的id</param>
        /// <param name="isMatch">是否匹配（为false就是退出匹配队列）</param>
        public void Matching(int userId, string userName, bool isMatch)
        {
            Matching match = new Matching()
            {
                UserId = userId,
                Name = userName,
                IsMatch = isMatch,
            };
            // 序列化
            byte[] message = ProtoBufUtils.SerializeBaseRequest(match);

            udpClient.Send(message, message.Length, serverEndPoint);
        }
        
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        private void SendMsg(string str, int userId, string name)
        {
            BaseRequest br = new BaseRequest()
            {
                UserId = userId,
                RequestType = RequestType.RtMessage,
                RequestData = RequestData.RdMessage,
                Msg = new Msg()
                {
                    UserId = userId,
                    UserName = name,
                    Msg_ = str,
                }
            };
            byte[] msg = ProtoBufUtils.SerializeBaseRequest(br);
            udpClient.Send(msg, msg.Length, serverEndPoint);
            //Console.WriteLine($"发送的消息: {str}");

            //清理资源
            //udpClient.Close();
        }
    } 
}
