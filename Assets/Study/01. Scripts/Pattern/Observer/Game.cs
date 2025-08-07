using UnityEngine;

namespace Pattern.Observer
{
    public class Game : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Player player = new Player();

            player.AddScore(100);
            player.AddScore(500);
            player.AddScore(500);
        }

        
    }
}
