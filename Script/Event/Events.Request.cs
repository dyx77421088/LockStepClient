using System;
using System.Text.RegularExpressions;
using UnityEngine;
// ����
namespace TPSShoot
{
    public partial class Events
    {
        
        public static Event<string, string> LoginRequest;// ��½����
        public static Event<BaseRequest> LoginResponse; // ��½��Ӧ

        public static Event<int> LoginSuccess; // ��½�ɹ���

        public static Event<int, string, bool> MatchRequest; // ƥ������
        public static Event<BaseRequest> MatchResponse; // ƥ����Ӧ
    }

}