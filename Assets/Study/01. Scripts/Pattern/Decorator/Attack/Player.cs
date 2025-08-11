using UnityEngine;

namespace Pattern.Decorator{
    public class Player : MonoBehaviour
    {
        private void Start()
        {
            IAttack attack = new BasicAttack();


            attack = new FireAttack(attack);
            attack.Execute();

            attack = new IceAttack(attack);
            attack.Execute();
        }
    }
}
