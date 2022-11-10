using System.Text;
using UnityEngine;

namespace Scripts.DelegateEvent
{
    public class TestamentSubscriber1 : MonoBehaviour
    {
       [SerializeField] private Person person;

       private void Start()
       {
           Debug.Log("Start of 1");
           person.onDied += OnDied;
           person.onDied2 += OnDied;
       }

       private void OnDied(int age, string[] instructions)
       {
           Debug.Log($"He died at the age: {age}");
       }
    }
}