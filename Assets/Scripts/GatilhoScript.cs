using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoScript : MonoBehaviour
{
    [SerializeField]
    private bool imLeftTrigger;
    [SerializeField]
    private bool imRightTrigger;

    private int restPosition = -35;
    private int pressedPosition = 35;
    private float hitStrenght = 10000f;
    private float triggerDamper = 5000f;

    HingeJoint hinge;



    private bool triggered;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
        if (((!imLeftTrigger) && (!imRightTrigger)) || ((imLeftTrigger) && (imRightTrigger)))
        {
            Debug.Log("ESQUECEU DE CONFIGURAR OS GATILHOS!, SOU GATILHO ESQUERDO OU DIREITO?");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (imLeftTrigger)
        {
            LeftTriggerUpdate();
            //pressedPosition = -35;
            //restPosition = 35;
        }
        else
        {
            RightTriggerUpdate();
            //pressedPosition = 35;
            //restPosition = -35;
        }
    }

    private void RightTriggerUpdate()
    {
        JointSpring mola = new JointSpring();
        mola.spring = hitStrenght;
        mola.spring = triggerDamper;
        if (GameController.Instance.isRightTriggerPressed)
        {
            mola.targetPosition = pressedPosition;
        }
        else
        {
            mola.targetPosition = restPosition;
        }
        hinge.spring = mola;

    }

    private void LeftTriggerUpdate()
    {

        JointSpring mola = new JointSpring();
        mola.spring = hitStrenght;
        mola.spring = triggerDamper;
        if (GameController.Instance.isLeftTriggerPressed)
        {
            mola.targetPosition = pressedPosition;
        }
        else
        {
            mola.targetPosition = restPosition;
        }
        hinge.spring = mola;
    }
}
