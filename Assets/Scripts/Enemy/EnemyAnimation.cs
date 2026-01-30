using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void PlayDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("IsDead");
        }
    }
    public float GetDeathAnimationLength()
    {
        if (animator != null)
        {
            RuntimeAnimatorController animController = animator.runtimeAnimatorController;
            for (int i = 0; i < animController.animationClips.Length; i++)
            {
                if (animController.animationClips[i].name.ToLower() == "Death" || animController.animationClips[i].name.ToLower() =="dead")
                {
                    return animController.animationClips[i].length;
                }
            }
        }
        return 0f;
    }
}
