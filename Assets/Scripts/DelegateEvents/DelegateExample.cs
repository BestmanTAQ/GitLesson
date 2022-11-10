using UnityEngine;

namespace Scripts.DelegateEvent
{
    public class DelegateExample : MonoBehaviour
    {
        private delegate string TestDelegate(int index);
        
        private void OnDelegateTrigger1(){}
        private float OnDelegateTrigger2(int index) { return 1; }
        private float OnDelegateTrigger3(int index, bool flag) { return 1; }
        private string OnDelegateTrigger4(int index) { return string.Empty; } // +

        private void Start()
        {
            TestDelegate internalDelegate;
            TestDelegate instanceDelegate;
            TestDelegate staticDelegate;

            internalDelegate = GetMessageInternal;
            instanceDelegate = new InstanceTest().GetMessageInstance;
            staticDelegate = StaticTest.GetMessageStatic;

            internalDelegate.Invoke(4);
            instanceDelegate(8);
            staticDelegate?.Invoke(16);                            // Проверка делегата на null
            
            

        }

        private string GetMessageInternal(int index)
        {
            return $"Internal for {index}";
        }
        
        private class InstanceTest
        {
            public string GetMessageInstance(int index)
            {
                return $"Instance for {index}";
            }
        }

        private class StaticTest
        {
            public static string GetMessageStatic(int index)
            {
                return $"Static for {index}";
            }
        }
    }
}