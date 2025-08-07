using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Pattern
{
    public class QuestManager : MonoBehaviour, IObserver
    {
        private bool isQueatClear1 = false;
        private bool isQueatClear2 = false;
        private bool isQueatClear3 = false;
        public ISubject subject;


        private void OnEnable()
        {
            subject.AddObserver(this);
        }

        private void OnDisable()
        {
            subject.RemoveObserver(this);
        }
        public void Notify(int score)
        {
            if (score >= 100 && !isQueatClear1)
            {
                isQueatClear1 = true;
                Debug.Log("100점 달성");
            }
            else if (score >= 500 && !isQueatClear2)
            {
                isQueatClear2 = true;
                Debug.Log("500점 달성");
            }
            else if (score >= 1000 && !isQueatClear3)
            {
                isQueatClear3 = true;
                Debug.Log("1000점 달성");
            }
        }
    }
}
