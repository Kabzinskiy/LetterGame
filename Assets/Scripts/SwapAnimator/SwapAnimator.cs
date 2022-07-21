using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SwapAnimator
{
    public class SwapAnimator
    {
        private MonoBehaviour MonoBehaviour { get; set; }
        public float AnimationTime { get; set; }

        const float TimeStep = 0.01f;
        public Action OnAnimationStart;
        public Action OnAnimationEnd;


        public SwapAnimator(MonoBehaviour monoBehaviour, float animationTime = 2f) 
        {
            MonoBehaviour = monoBehaviour;
            AnimationTime = animationTime;
        }

        /// <summary>
        /// Function for swapping element positions.
        /// </summary>
        /// <param name="firstValue">First element</param>
        /// <param name="secondValue">Second element</param>
        public void SwapElements(GameObject firstValue, GameObject secondValue)
        {
            OnAnimationStart?.Invoke();
            MonoBehaviour.StartCoroutine(SwapElementsCoroutine(firstValue, secondValue));
        }

        IEnumerator SwapElementsCoroutine(GameObject firstValue, GameObject secondValue)
        {
            yield return null;
            var firstPosotion = firstValue.transform.position;
            var secondPosotion = secondValue.transform.position;
            for(float i = 0; i <= AnimationTime; i += TimeStep)
            {
                var progress = i / AnimationTime;
                firstValue.transform.position = Vector3.Lerp(firstPosotion, secondPosotion, progress);
                secondValue.transform.position = Vector3.Lerp(secondPosotion, firstPosotion, progress);
                yield return new WaitForSeconds(TimeStep);                
            }
            OnAnimationEnd?.Invoke();
        }

    }
}
