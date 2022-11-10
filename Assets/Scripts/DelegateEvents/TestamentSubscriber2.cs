using System.Text;
using UnityEngine;

namespace Scripts.DelegateEvent
{
    public class TestamentSubscriber2 : MonoBehaviour
    {
        [SerializeField] private Person person;

        private void Start()
        {
            Debug.Log("Start of 2");
            person.onDied += OnDied;
            person.onDied2 += OnDied;
        }

        private void OnDied(int age, string[] instructions)
        {
            var willText = new StringBuilder();
            willText.Append("His last will: ");
            willText.Append("\n");
            foreach (var instruction in instructions)
            {
                willText.Append(instruction);
                willText.Append("\n");
            }

            Debug.Log(willText);
        }
    }
}