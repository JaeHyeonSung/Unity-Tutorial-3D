using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Observer
{
    public class Player : MonoBehaviour, ISubject
    {
        private int score;

        

        public List<IObserver> Observers { get; set; }

        public int GetScore()
        {
            return score;
        }

        public void AddScore(int score)
        {
            this.score += score;
            Debug.Log("현재점수는 :" + score);
            NotifyObservers();
        }

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach(var observer in Observers)
            {
                observer.Notify(score);
            }
        }
    }
}
