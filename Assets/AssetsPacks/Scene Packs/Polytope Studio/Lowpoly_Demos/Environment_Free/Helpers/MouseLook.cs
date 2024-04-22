using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //灵敏度
    public float mouseSensitivity = 100f;
    //依附的对象
    public Transform playerBody;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标在水平方向上的移动量
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //鼠标在垂直方向上的移动量
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //视角进行相应的旋转
        xRotation -= mouseY;
        //限制视角移动角度，防止出现极端情况
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //控制水平方向旋转
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //让绑定的对象旋转
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
