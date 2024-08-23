using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVisibilityController : MonoBehaviour
{
    private bool isCursorVisible = true;

    void Update()
    {
        // ��������
        if (Input.GetMouseButtonDown(0)) // 0 ��������
        {
            ToggleCursorVisibility(false);
        }

        // ��ⰴ�� Esc ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorVisibility(true);
        }
    }

    void ToggleCursorVisibility(bool visibility)
    {
        isCursorVisible = visibility;
        Cursor.visible = isCursorVisible;
        Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
