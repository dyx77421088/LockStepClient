using System;
using TPSShoot;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginServer : MonoBehaviour
{
    public InputField userName;
    public InputField password;
    public Text message;

    private void Awake()
    {
        SubScribe();
    }

    private void SubScribe()
    {
        Events.LoginResponse += LoginResponse; // 登陆请求
        Events.LoginSuccess += OnLoginSuccess; // 登陆成功
    }
    private void UnSubScribe()
    {
        Events.LoginResponse -= LoginResponse;
        Events.LoginSuccess -= OnLoginSuccess;
    }

    /// <summary>
    /// 获得登陆消息的响应信息
    /// </summary>
    /// <param name="baseRequest">响应信息</param>
    public void LoginResponse(BaseRequest baseRequest)
    {
        if (baseRequest.Status.St == StatusType.StError)
        {
            message.text = baseRequest.Status.Msg;
        }
        else if (baseRequest.Status.St == StatusType.StSuccess)
        {
            Events.LoginSuccess.Call(baseRequest.UserId); // 绑定用户id
        }
    }

    /// <summary>
    /// 用户登录成功！
    /// </summary>
    public void OnLoginSuccess(int userId)
    {
        SceneManager.LoadScene(SceneConst.MATCH);
    }

    public void ClickLogin()
    {
        Events.LoginRequest.Call(userName.text, password.text); // 发送登陆请求
    }

    private void OnDestroy()
    {
        UnSubScribe();
    }
}
