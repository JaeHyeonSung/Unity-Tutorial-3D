using UnityEngine;

namespace Pattern.Adapter
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject player;

        private ICharactor charactor;

        private void Start()
        {
            charactor = player.GetComponent<ICharactor>();

            charactor.Move(Vector3.forward);
            charactor.Attack();

            LegacyPlayer legacyPlayer = new LegacyPlayer();
            legacyPlayer.LegacyMove(0, 0, 1);
        }
    }
}
