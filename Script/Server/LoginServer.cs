using System;
using TPSShoot;
using UnityEngine;
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
        Events.LoginResponse += LoginRequest; // µÇÂ½ÇëÇó
    }
    private void UnSubScribe()
    {
        Events.LoginResponse -= LoginRequest;
    }

    public void LoginRequest(BaseRequest baseRequest)
    {
        if (baseRequest.Status.St == StatusType.StError)
        {
            message.text = baseRequest.Status.Msg;
        }
        else if (baseRequest.Status.St == StatusType.StSuccess)
        {
            Events.LoginSuccess.Call(baseRequest.UserId);
        }
    }

    public void ClickLogin()
    {
        Events.LoginRequest.Call(userName.text, password.text); // ·¢ËÍµÇÂ½ÇëÇó
    }

    private void OnDestroy()
    {
        UnSubScribe();
    }
}
