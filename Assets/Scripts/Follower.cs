using UnityEngine;

namespace Scripts.GitLesson
{ 
    public class Follower : MonoBehaviour
 {
     [SerializeField] private Transform targetTransform;
     [SerializeField] private Vector3 offset;
     [SerializeField] private float smoothing = 1f;
 
  private void FixedUpdate()
  {
      Move();  
  }

  private void Move()
  {
      Vector3 nextPosition = Vector3.Lerp(transform.position, 
                                          targetTransform.position + offset, 
                                          Time.fixedDeltaTime * smoothing);

      transform.position = nextPosition;
  }
 }
}
