using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ��ɫ��Transform
    public Vector3 offset; // �����λ��ƫ��
    public float smoothSpeed = 0.125f; // ƽ�������ٶ�

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset; // ��������λ��
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // ƽ���ƶ�
        transform.position = smoothedPosition;

        // ע�ӽ�ɫ
        transform.LookAt(player);
    }
}
