using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // 角色的Transform
    public Vector3 offset; // 摄像机位置偏移
    public float smoothSpeed = 0.125f; // 平滑跟随速度

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset; // 计算期望位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 平滑移动
        transform.position = smoothedPosition;

        // 注视角色
        transform.LookAt(player);
    }
}
