using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5f;   // �ƶ��ٶ�
    public float rotationSpeed = 700f; // ��ת�ٶ�

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ��ȡ����
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �ƶ�����
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize(); // ȷ������λ��

        // �ƶ�
        characterController.Move(transform.TransformDirection(direction) * moveSpeed * Time.deltaTime);

        // ��������ת
        RotateCharacter();
    }

    void RotateCharacter()
    {
        // ��ȡ����ƶ���ˮƽ�ʹ�ֱƫ��
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ��ת��ɫ
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }

}
