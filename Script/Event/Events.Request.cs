using System;
using System.Text.RegularExpressions;
using UnityEngine;
// 请求
namespace TPSShoot
{
    public partial class Events
    {
        
        public static Event<string, string> LoginRequest;// 登陆请求
        public static Event<BaseRequest> LoginResponse; // 登陆响应

        public static Event<int> LoginSuccess; // 登陆成功！

        public static Event<int, string, bool> MatchRequest; // 匹配请求
        public static Event<BaseRequest> MatchResponse; // 匹配响应
    }

}