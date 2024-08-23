using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVisibilityController : MonoBehaviour
{
    private bool isCursorVisible = true;

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0)) // 0 是左键点击
        {
            ToggleCursorVisibility(false);
        }

        // 检测按下 Esc 键
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
