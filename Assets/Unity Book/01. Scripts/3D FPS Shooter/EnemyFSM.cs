using System.Collections;
using UnityEngine;

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

    EnemyState m_State;
    Transform player;
    CharacterController cc;


    public float findDistance = 8.0f;  // Ž�� ���� �Ÿ�
    public float attackDistance = 3f;  // ���� ���� �Ÿ�
    public float moveSpeed = 5f;       // �̵� �ӵ�
    public float currentTime = 0f;     // �ð�
    public float attackDelay = 2f;     // ���� ������
    public int attackPower = 3;        // ���ݷ�
    public int hp = 15;                // ü��
    private Vector3 originPos;         // ���� ��ġ
    public float moveDistance = 20f;   // �߰� ���� �Ÿ�
    private void Start()
    {
        m_State = EnemyState.Idle;

        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();

        originPos = transform.position;
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
                Die();
                break;
        }
    }
    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move;
            Debug.Log("������ȯ: Idle->Move");
        }
    }
    private void Move()
    {
        if(Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("���� ��ȯ: Move->Return");
        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;

            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            m_State=EnemyState.Attack;
            Debug.Log("���� ��ȯ: Move -> Attack");

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
                Debug.Log("����");
                currentTime = 0;
            }
        }
        else
        {
            m_State = EnemyState.Move;
            Debug.Log("���� ��ȯ: Attack->Move");
            currentTime = 0;
        }
    }

    private void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);

        }
        else
        {
            transform.position = originPos;
            hp = 15;
            m_State = EnemyState.Idle;
            Debug.Log("���� ��ȯ: Return->Idle");
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    private void Die()
    {

    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);
        m_State = EnemyState.Move;
        Debug.Log("���� ��ȯ: Damaged->Move");
    }
    public void HitEnemy(int hitPower)
    {
        hp-=hitPower;
        if(hp > 0)
        {
            m_State = EnemyState.Damaged;
            Debug.Log("���� ��ȯ : AnyState -> Damaged");
            Damaged();
        }
        else
        {
            m_State = EnemyState.Die;
            Debug.Log("���� ��ȯ : AnyState->Die");
            Die();
        }
    }
}
