using System.Collections;
using System.Collections.Generic;
using TPSShoot;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ƥ����صķ���
/// </summary>
public class MatchServer : MonoBehaviour
{
    [Header("ƥ��")]public Text matchText;

    private bool isMathch; // �Ƿ���ƥ������
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ���ƥ�䰴ť
    /// </summary>
    public void OnClickMatch()
    {
        //Events.MatchRequest.Call(); // ����ƥ������
        isMathch = !isMathch;
        if (isMathch)
        {
            matchText.text = "ƥ����.......";
        }
        else
        {
            matchText.text = "ƥ��";
        }
    }
}
