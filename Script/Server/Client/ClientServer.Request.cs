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
            byte[] message = ProtoBufUtils.DeSerializeBaseRequest(user, RequestType.RtLogin, RequestData.RdUser);
            clientUser = user;
            udpClient.Send(message, message.Length, serverEndPoint);
        }

        private void SendMsg(string str)
        {
            BaseRequest br = new BaseRequest()
            {
                UserId = clientUser.Id,
                RequestType = RequestType.RtMessage,
                RequestData = RequestData.RdMessage,
                Msg = new Msg()
                {
                    UserId = clientUser.Id,
                    UserName = clientUser.Name,
                    Msg_ = str,
                }
            };
            byte[] msg = ProtoBufUtils.DeSerializeBaseRequest(br);
            udpClient.Send(msg, msg.Length, serverEndPoint);
            //Console.WriteLine($"发送的消息: {str}");

            //清理资源
            //udpClient.Close();
        }
    }
}
