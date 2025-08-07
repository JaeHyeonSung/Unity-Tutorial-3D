using UnityEngine;

namespace Pattern.Command
{
    public class Player : MonoBehaviour
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }
        public void AttackCancel()
        {
            Debug.Log("AttackCancel");
        }

        public void Jump()
        {
            Debug.Log("Jump");
        }

        public void JumpCancel()
        {
            Debug.Log("JumpCancel");
        }

        public void UseSkill(string skillName)
        {
            Debug.Log($"{skillName} 발동");
        }
        public void UseSkillCancel(string skillName)
        {
            Debug.Log($"{skillName} 발동 중지");
        }
    }
}
