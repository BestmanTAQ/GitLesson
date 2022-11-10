using System;
using UnityEngine;

namespace Scripts.DelegateEvent
{
    public class FakePerson : MonoBehaviour
    {
        [SerializeField] private Person _person;

        private void Update()
        {
            _person.onDied(0, null);      // Нарушение событийное модели
            _person.onDied = null;

          //  _person.onDied2(0, null);                // события нельзя вызвать или занулить
          //  _person.onDied2 = null;
        }
    }
}