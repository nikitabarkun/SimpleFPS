using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private readonly int IS_AIMING = Animator.StringToHash("isAiming");
    private readonly int SHOOT = Animator.StringToHash("shoot");

    [SerializeField]
    private AnimationClip alternativeAim;
    [SerializeField]
    private AnimationClip alternativeShoot;

    private AnimatorOverrideController _defaultController;
    private AnimatorOverrideController _alternativeController;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        var runtimeAnimatorController = _animator.runtimeAnimatorController;
        _defaultController = new AnimatorOverrideController(runtimeAnimatorController);
        _alternativeController = new AnimatorOverrideController(runtimeAnimatorController);

        _alternativeController["Aim"] = alternativeAim;
        _alternativeController["Shoot"] = alternativeShoot;
    }

    public void Aim()
    {
        _animator.SetBool(IS_AIMING, true);
    }

    public void Unaim()
    {
        _animator.SetBool(IS_AIMING, false);
    }

    public void Shoot()
    {
        _animator.SetTrigger(SHOOT);
    }

    public void SetAlternativeAiming(bool isAlternative)
    {
        _animator.runtimeAnimatorController = isAlternative
                                                  ? _alternativeController
                                                  : _defaultController;
    }
}
