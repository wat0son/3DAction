using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Player_Anim : MonoBehaviour
{
    Quaternion tragetRotation;
    

    Animator animator;


    void Awake()
    {
        //�R���|�[�l���g�֘A�t
        TryGetComponent(out animator);
        Cursor.lockState = CursorLockMode.Locked;

        //������
        tragetRotation = transform.rotation;
    }

    
    void Update()
    {
        
        

    }

     void OnMove(InputValue value)
    {
        var axis = value.Get<Vector2>();
        
        //�A�N�V�YX�ƃA�N�V�YY��0�Ȃ�~�܂�
        if(axis.x ==0 && axis.y == 0)
        {
            animator.SetFloat("Speed", 0.0f,0.0f,0.0f);

            return;
        }
        
        

        //���̓x�N�g���̏���
        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");

        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        var velocity = horizontalRotation * new Vector3(axis.x, 0,axis.y ).normalized;

        var speed = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        var rotationSpeed = 600 * Time.deltaTime;

        //�ړ�����������
        if (velocity.magnitude > 0.5f)
        {
            tragetRotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
     
        //�ړ����x���A�j���[�^�ɔ��f
        transform.rotation = Quaternion.RotateTowards(transform.rotation, tragetRotation, rotationSpeed);

        
        animator.SetFloat("Speed", velocity.magnitude * speed, 0.1f, Time.deltaTime);

    }

    void Camera0(InputValue value)
    {

    }

}
