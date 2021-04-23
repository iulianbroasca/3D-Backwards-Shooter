using EnemyModule.Behaviours;
using GameConfigurationModule.Managers;
using Globals;
using InputModule.Interfaces;
using InputModule.Models;
using ScriptableObjects;
using StateModule.Globals;
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

        private IInput input;

        private void Awake()
        {
            InitializeStates();
            InitializeConfigurations();
            InitializeInput();
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
            if (!Physics.Raycast(cameraComponent.ScreenPointToRay(input.GetInput()), out raycastHit, Mathf.Infinity,
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
            SetPlayerPosition(transform.localPosition);
        }

        private void InitializeInput()
        {
#if UNITY_STANDALONE
            input = new MouseInput();
#elif UNITY_ANDROID || UNITY_IOS
            input = new MobileInput();
#endif
        }

        private void InitializeStates()
        {
            States.IntroGame.AddActionState(ResetPosition);
        }

        private void InitializeConfigurations()
        {
            lateralSpeed = ConfigurationManager.Instance.GetConfiguration<CharacterConfiguration>().GetLateralSpeed;
        }
    }
}
