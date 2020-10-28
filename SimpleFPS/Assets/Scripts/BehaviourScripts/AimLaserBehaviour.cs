using UnityEngine;

public class AimLaserBehaviour : StateMachineBehaviour
{
    private const float TIME_TO_TURN_AIM = 1f;

    private const int LAYER_INDEX = 0;
    private readonly int SHOOT = Animator.StringToHash("Shoot");

    [SerializeField]
    private GameObject aimGameObject;

    private float _time = 0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aimGameObject = animator.gameObject.GetComponent<WeaponController>().AimGameObject;

        if (animator.GetCurrentAnimatorStateInfo(LAYER_INDEX).shortNameHash != SHOOT)
        {
            _time = 0f;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _time += Time.deltaTime;

        if (_time >= TIME_TO_TURN_AIM && !aimGameObject.activeSelf)
        {
            aimGameObject.SetActive(true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetCurrentAnimatorStateInfo(LAYER_INDEX).shortNameHash != SHOOT)
        {
            aimGameObject.SetActive(false);
        }
    }
}
