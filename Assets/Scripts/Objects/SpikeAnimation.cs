using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class SpikeAnimation : MonoBehaviour
{
    private AnimatorController spikeAnimatorController;
    public float upTime;
    public float downTime;
    public void Start()
    {
        Animator spikeAnimator = gameObject.GetComponent<Animator>();
        spikeAnimatorController = spikeAnimator.runtimeAnimatorController as AnimatorController;
        changeTransitionSettings();
    }
    private void changeTransitionSettings()
    {
        AnimatorControllerLayer[] allLayer = spikeAnimatorController.layers;

        for (int i = 0; i < allLayer.Length; i++)
        {
            ChildAnimatorState[] states = allLayer[i].stateMachine.states;

            for (int j = 0; j < states.Length; j++)
            {
                if (states[j].state.name == "isUp")
                {
                    AnimatorStateTransition[] transitions = states[j].state.transitions;

                    foreach (var transition in transitions)
                    {
                        if (transition.name == "isUpTransition")
                        {
                            transition.exitTime = upTime;
                        }
                    }
                }

                if (states[j].state.name == "isDown")
                {
                    AnimatorStateTransition[] transitions = states[j].state.transitions;

                    foreach (var transition in transitions)
                    {
                        if (transition.name == "isDownTransition")
                        {
                            transition.exitTime = downTime;
                        }
                    }
                }

            }
        }
    }
}
