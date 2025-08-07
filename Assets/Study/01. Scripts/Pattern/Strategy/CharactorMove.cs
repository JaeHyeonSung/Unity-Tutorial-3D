using UnityEngine;

namespace Pattern
{
    public class CharactorMove : MonoBehaviour
    {
        private IMovement movement;

        private void Start()
        {
            movement = new MoveWalk(3f);
        }
        private void Update()
        {
           
            Move();

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                movement = new MoveWalk(3f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                movement = new MoveRun(5f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                movement = new MoveFly(7f);
            }
        }

        private void Move()
        {
            movement.Move(transform);
        }
    }
}
