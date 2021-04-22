using EnemyModule.Behaviours;
using GameConfigurationModule.Managers;
using Globals;
using ScriptableObjects;
using UnityEngine;

namespace CharacterModule.Behaviours
{
    public class CharacterMovementBehaviour : MonoBehaviour
    {
        private LayerMask placementLayer;
        private RaycastHit raycastHit;
        private Vector2 nextPosition;
        private Camera cameraComponent;
        private float lateralSpeed;

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if ((Vector2) transform.localPosition == nextPosition)
                return;
            
            transform.position = Vector3.MoveTowards(transform.position, nextPosition,
                lateralSpeed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (!Physics.Raycast(cameraComponent.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity,
                    placementLayer) || !Input.GetMouseButton(0))
                return;

            SetPlayerPosition(raycastHit.point);
        }

        private void SetPlayerPosition(Vector3 position)
        {
            nextPosition = position;
            EnemyAttackBehaviour.playerPosition = nextPosition;
        }

        private void ResetPosition()
        {
            SetPlayerPosition(Vector3.zero);
        }

        private void Initialize()
        {
            placementLayer = LayerMask.GetMask(Layers.PlacementLayer);
            cameraComponent = Camera.main;
            lateralSpeed = ConfigurationManager.Instance.GetConfiguration<CharacterConfiguration>().GetLateralSpeed;
            SetPlayerPosition(transform.localPosition);
            States.IntroGame.AddActionState(ResetPosition);
        }
    }
}
