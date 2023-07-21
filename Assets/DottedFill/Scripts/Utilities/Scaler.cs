using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DottedFill
{
    public class Scaler : MonoBehaviour
    {
        public Vector3 targetScale = new Vector3(1f, 1f,1f);
        public float scalingDuration = 0.5f;

        void Start()
        {
            StartCoroutine(ScaleOverTime());
        }

        IEnumerator ScaleOverTime()
        {
            Vector3 initialScale = transform.localScale;
            float currentTime = 0f;

            while (currentTime < scalingDuration)
            {
                transform.localScale = Vector3.Lerp(initialScale, targetScale, currentTime / scalingDuration);
                currentTime += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScale; // Ensure the target scale is reached
        }
    }

}
