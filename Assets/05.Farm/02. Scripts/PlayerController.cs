using UnityEngine;
using UnityEngine.InputSystem;

namespace Farm
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;
        private CharacterController cc;
        private Vector3 moveInput;

        private float currentSpeed;
        private float walkSpeed = 2f;
        private float turnSpeed = 10f;
        private float runSpeed = 4f;
        private bool isRun;
        private void Start()
        {
            cc = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();

        }

        private void Update()
        {
            
            cc.Move(moveInput * currentSpeed * Time.deltaTime);
            Turn();
            SetAnimation();


        }
        void OnMove(InputValue value)
        {
            var move = value.Get<Vector2>();
            moveInput = new Vector3(move.x,0 ,move.y);
        }
        private void OnSprint(InputValue value)
        {
            isRun = value.isPressed;
        }
        private void Turn()
        {
            if(moveInput != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(moveInput);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed*Time.deltaTime);
            }
        }
        
        private void SetAnimation()
        {
            
            float targetValue = 0f;
            if(moveInput != Vector3.zero)
            {
                targetValue = isRun ? 1f : 0.5f;
                currentSpeed = isRun ? runSpeed : walkSpeed;
            }
            float animValue = anim.GetFloat("Move");
            animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);
            anim.SetFloat("Move", animValue);

        }
    }
}
