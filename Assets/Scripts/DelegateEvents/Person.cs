using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.DelegateEvent
{
    public class Person : MonoBehaviour
    {
        public delegate void Died(int age, string[] instructions);

        public Died onDied;
        public event Died onDied2;

        private IEnumerator Start()
        {
            int age = Random.Range(50, 100);
            int yearsToLive = Random.Range(3, 6);
            yield return new WaitForSeconds(yearsToLive);
            onDied?.Invoke(age + yearsToLive, new []{"sell house", "small funeral", "publish book"});
            onDied2?.Invoke(age + yearsToLive, new []{"sell house", "small funeral", "publish book"});
        }
    }
}