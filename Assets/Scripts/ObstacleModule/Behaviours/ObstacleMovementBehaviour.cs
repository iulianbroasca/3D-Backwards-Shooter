using StateModule.Managers;
using UnityEngine;

namespace ObstacleModule.Behaviours
{
    public class ObstacleMovementBehaviour : MonoBehaviour
    {
        private Vector3 targetPosition;
        private float speed;

        private void Update()
        {
            if (!GameManager.Instance.IsInGameMode())
                return;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        public void InitializeObstacleMovement(float obstacleSpeed)
        {
            speed = obstacleSpeed;
            targetPosition = transform.localPosition + Vector3.back * 30;
        }
    }
}
