using UnityEditor.Animations;
using UnityEngine;
public class UnitAnimatorController : MonoBehaviour
{
    [SerializeField] Animator unitAnimator;
    private void Awake()
    {
        unitAnimator = GetComponentInChildren<Animator>();
    }
    public Animator GetAnimator()
    {
        return unitAnimator;
    }
    public void SetAnimation(string animationName, bool isRunning)
    {
        GetAnimator().SetBool(animationName, isRunning);
    }
}
