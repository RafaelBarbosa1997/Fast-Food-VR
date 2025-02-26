using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty leftGripAnimationAction;
    [SerializeField]
    private InputActionProperty rightGripAnimationAction;

    [SerializeField]
    private Animator leftHandAnimator;
    [SerializeField]
    private Animator rightHandAnimator;

    private float gripValue;

    private void Update()
    {
        // Hand animations.
        // Close hand when pressing grip button, open when releasing it.
        gripValue = leftGripAnimationAction.action.ReadValue<float>();
        leftHandAnimator.SetFloat("Grip", gripValue);

        gripValue = rightGripAnimationAction.action.ReadValue<float>();
        rightHandAnimator.SetFloat("Grip", gripValue);
    }
}
