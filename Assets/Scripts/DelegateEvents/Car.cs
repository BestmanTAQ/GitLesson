using System;
using UnityEngine;

namespace Scripts.DelegateEvent
{
    public class Car : MonoBehaviour
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        private bool _carIsDead;

        public Car(){}
        public Car(int currentSpeed, int maxSpeed, string petName)
        {
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
            PetName = petName;
        }

        public delegate void CarEngineHandler(string msgForCaller);

        private CarEngineHandler _listOfHandler;

        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            _listOfHandler += methodToCall;
        }

        public void Accelerate(int delta)
        {
            if (_carIsDead)
            {
                if (_listOfHandler != null)
                {
                    _listOfHandler("Sorry, this car is dead!....");
                }
            }
            else
            {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) && _listOfHandler != null)
                {
                    _listOfHandler("Careful buddy! Gonna blow!");
                }

                if (CurrentSpeed >= MaxSpeed)
                {
                    _carIsDead = true;
                }
                else
                {
                    Debug.Log($"CurrentSpeed = {CurrentSpeed}");
                }
            }
        }
    }
}