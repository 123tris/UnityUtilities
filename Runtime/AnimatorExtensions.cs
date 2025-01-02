using UnityEngine;

namespace Utilities
{
    public static class AnimatorExtensions
    {
        public static float GetClipLength(this Animator animator, string clipName)
        {
            return GetClipLength(animator, Animator.StringToHash(clipName));
        }

        public static float GetClipLength(this Animator animator, int clipHash)
        {
            foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.GetHashCode() == clipHash)
                {
                    return clip.length;
                }
            }

            Debug.LogError("Couldn't find clip");
            return 0;
        }

    }
}