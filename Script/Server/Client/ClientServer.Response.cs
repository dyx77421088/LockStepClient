using System;
using System.Collections.Generic;
using Commit.Utils;
using Commit.Config;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using UnityEngine;
using System.Collections;
using System.Text;

namespace TPSShoot
{
    /// <summary>
    /// 处理响应
    /// </summary>
    public partial class ClientServer
    {
        // 开启协程，接收消息
        private void StartReceiving()
        {
            // 使用协程接收数据
            StartCoroutine(ReceiveData());
        }

        // 启动协程
        private IEnumerator ReceiveData()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f); // 限制接收频率，可以调整

                if (udpClient.Available > 0)
                {
                    ReceiveMessages(); // 处理接收的信息
                }
            }
        }
        private void ReceiveMessages()
        {
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, port);
            try
            {
                byte[] receivedData = udpClient.Receive(ref listenEndPoint); // 收到消息
                BaseRequest baseRequest = ProtoBufUtils.DeSerializeBaseRequest(receivedData);
                if (baseRequest.RequestType == RequestType.RtLogin) // 如果收到的消息是登陆
                {
                    if (baseRequest.RequestData == RequestData.RdStatus)
                    {
                        Events.LoginResponse.Call(baseRequest); // 执行登录的订阅
                    }

                }
                else if (baseRequest.RequestType == RequestType.RtMessage)
                {
                    if (baseRequest.RequestData == RequestData.RdMessage)
                    {
                        Console.WriteLine("\n收到一条消息:");
                        Console.WriteLine("发送者:" + baseRequest.Msg.UserName);
                        Console.WriteLine("内容:" + baseRequest.Msg.Msg_);
                    }
                }
                else if (baseRequest.RequestType == RequestType.RtMatch)
                {
                    Events.LoginResponse.Call(baseRequest); // 执行登录的订阅
                }
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("UdpClient已关闭。");
                //break; // 可以选择停止接收
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常: {ex.Message}");
            }
        }

        /// <summary>
        /// 发送消息的线程
        /// </summary>
    }
}
