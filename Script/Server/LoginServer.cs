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
        Events.LoginResponse += LoginResponse; // ��½����
        Events.LoginSuccess += OnLoginSuccess; // ��½�ɹ�
    }
    private void UnSubScribe()
    {
        Events.LoginResponse -= LoginResponse;
        Events.LoginSuccess -= OnLoginSuccess;
    }

    /// <summary>
    /// ��õ�½��Ϣ����Ӧ��Ϣ
    /// </summary>
    /// <param name="baseRequest">��Ӧ��Ϣ</param>
    public void LoginResponse(BaseRequest baseRequest)
    {
        if (baseRequest.Status.St == StatusType.StError)
        {
            message.text = baseRequest.Status.Msg;
        }
        else if (baseRequest.Status.St == StatusType.StSuccess)
        {
            Events.LoginSuccess.Call(baseRequest.UserId); // ���û�id
        }
    }

    /// <summary>
    /// �û���¼�ɹ���
    /// </summary>
    public void OnLoginSuccess(int userId)
    {
        SceneManager.LoadScene(SceneConst.MATCH);
    }

    public void ClickLogin()
    {
        Events.LoginRequest.Call(userName.text, password.text); // ���͵�½����
    }

    private void OnDestroy()
    {
        UnSubScribe();
    }
}
