using System.Collections;
using System.Collections.Generic;
using TPSShoot;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 匹配相关的服务
/// </summary>
public class MatchServer : MonoBehaviour
{
    [Header("匹配")]public Text matchText;

    private bool isMathch; // 是否在匹配中了
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 点击匹配按钮
    /// </summary>
    public void OnClickMatch()
    {
        //Events.MatchRequest.Call(); // 发送匹配请求
        isMathch = !isMathch;
        if (isMathch)
        {
            matchText.text = "匹配中.......";
        }
        else
        {
            matchText.text = "匹配";
        }
    }
}
