using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TPSShoot
{
    public partial class Event<T1, T2, T3> : IEvent
    {
        private readonly List<Action<T1, T2, T3>> subscribers;
        public Event(string name) : base(name)
        {
            subscribers = new List<Action<T1, T2, T3>>();
        }

        /// <summary>
        /// ���ĵĻ����ִ��
        /// </summary>
        public void Call(T1 pram1, T2 pram2, T3 pram3)
        {
            for (int i = subscribers.Count - 1; i >= 0; i--)
            {
                subscribers[i].Invoke(pram1, pram2, pram3); // ִ��
            }
        }

        public static Event<T1, T2, T3> operator +(Event<T1, T2, T3> e, Action<T1, T2, T3> action)
        {
            e.CheckName(action);
            e.subscribers.Add(action);
            return e;
        }

        public static Event<T1, T2, T3> operator -(Event<T1, T2, T3> e, Action<T1, T2, T3> action)
        {
            e.subscribers.Remove(action);
            return e;
        }

        private void CheckName(Action<T1, T2, T3> action)
        {
            // ����Ѿ�������������ֵ�action���׳�
            if (subscribers.Contains(action))
            {
                ThrowNameException();
            }
        }
    }
}