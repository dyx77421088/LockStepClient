using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5f;   // 移动速度
    public float rotationSpeed = 700f; // 旋转速度

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 获取输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 移动方向
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize(); // 确保方向单位化

        // 移动
        characterController.Move(transform.TransformDirection(direction) * moveSpeed * Time.deltaTime);

        // 鼠标控制旋转
        RotateCharacter();
    }

    void RotateCharacter()
    {
        // 获取鼠标移动的水平和垂直偏移
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 旋转角色
        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }

}
