using System;
using Unity.VisualScripting;
using UnityEngine;

public class StudyState : MonoBehaviour
{
    #region 예전방식 State
    //public enum State { Idle, Move, Attack }
    //public State state;

    //private void Update()
    //{
    //    switch (state)
    //    {
    //        case State.Idle:
    //            OnIdle();
    //            break;
    //        case State.Move:
    //            OnMove();
    //            break;
    //        case State.Attack:
    //            OnAttack();
    //            break;
    //    }
    //}

    //private void OnAttack()
    //{

    //}

    //private void OnMove()
    //{

    //}

    //private void OnIdle()
    //{

    //}
    #endregion

    public IState state;
    private IState idleState, moveState, attackState;
    private void Awake()
    {
        idleState = gameObject.AddComponent<IdleState>();
        moveState = gameObject.AddComponent<MoveState>();
        attackState = gameObject.AddComponent<AttackState>();
        state = idleState;
    }

    private void Start()
    {
        state.StateEnter();
    }
    private void OnDestroy()
    {
        state.StateExit();
    }
    private void Update()
    {
        state?.StateUpdate();
        #region 기능 테스트
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(new IdleState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(new MoveState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(new AttackState());
        }

        #endregion
        
    }

    public void SetState(IState newState)
    {
        if (newState != state)
        {
            state.StateExit();

            state = newState;

            state.StateEnter();

        }
    }
}
