using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Die
    }

    private EnemyState m_State;
    private Transform player;
    private CharacterController cc;
    public Slider enemyHPBar;
    private Animator anim;

    public float findDistance = 8.0f;  // 탐지 가능 거리
    public float attackDistance = 3f;  // 공격 가능 거리
    public float moveSpeed = 5f;       // 이동 속도
    public float currentTime = 0f;     // 시간
    public float attackDelay = 2f;     // 공격 딜레이
    public int attackPower = 3;        // 공격력
    public int hp = 15;                // 체력
    private int maxHp = 15;
    private Vector3 originPos;         // 원래 위치
    private Quaternion originRot;
    public float moveDistance = 20f;   // 추격 가능 거리
    private void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();

        originPos = transform.position;
        originRot = transform.rotation;
        anim = transform.GetComponentInChildren<Animator>();
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }
    }
    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            anim.SetTrigger("IdleToMove");
            Debug.Log("상태전환: Idle->Move");
        }
    }
    private void Move()
    {
        if(Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("상태 전환: Move->Return");
        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;

            cc.Move(dir * moveSpeed * Time.deltaTime);

            transform.forward = dir;
        }
        else
        {
            m_State=EnemyState.Attack;
            Debug.Log("상태 전환: Move -> Attack");

            currentTime = attackDelay;
        }
    }
    private void Attack()
    {
        if(Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                player.GetComponent<FPSPlayerMove>().DamageAction(attackPower);
                Debug.Log("공격");
                currentTime = 0;
            }
        }
        else
        {
            m_State = EnemyState.Move;
            Debug.Log("상태 전환: Attack->Move");
            currentTime = 0;
        }
    }

    private void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        else
        {
            transform.position = originPos;
            transform.rotation = originRot;
            hp = maxHp;
            m_State = EnemyState.Idle;
            anim.SetTrigger("MoveToIdle");
            Debug.Log("상태 전환: Return->Idle");
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    private void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);
        m_State = EnemyState.Move;
        Debug.Log("상태 전환: Damaged->Move");
    }
    public void HitEnemy(int hitPower)
    {
        hp-=hitPower;

        enemyHPBar.value = (float)hp / (float)maxHp;
        if(hp > 0)
        {
            m_State = EnemyState.Damaged;
            Debug.Log("상태 전환 : AnyState -> Damaged");
            Damaged();
        }
        else
        {
            m_State = EnemyState.Die;
            Debug.Log("상태 전환 : AnyState->Die");
            Die();
        }
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("소멸");
        Destroy(gameObject);
    }
}
