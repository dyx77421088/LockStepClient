using System;
using UnityEngine;
// ����
namespace TPSShoot
{
    public partial class Events
    {
        
        public static Event<string, string> LoginRequest;// ��½����
        public static Event<BaseRequest> LoginResponse; // ��½��Ӧ

        public static Event<int> LoginSuccess; // ��½�ɹ���

    }

}