﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PhobiaManager : MonoBehaviour
{
    public static PhobiaManager instance;

    public Phobia phobia;

    [SerializeField]
    private TMP_Text healthTxtp;

    //[SerializeField]
    //private Image healthBarImage;

    [SerializeField]
    private TMP_Text phobiaNextAction;


    public void InitializePhobia()
    {
        MakeInstance();

        phobia.Initialize();

        UpdateHealthBar();

        PrepareAttack();
    }

    public void StartTurn(UnityAction onDone =null)
    {
        if (IStartTurnHelper == null)
        {
            IStartTurnHelper = StartCoroutine(IStartTurn(onDone));
        }
    }

    public void MakeTheDamage(float damage)
    {
        if (phobia.vulnerablityCount > 0)
        {
            damage += damage * 0.5f;
        }
        Debug.Log($"<color=#ffa500ff>phobia's</color> gotten damage is {damage} =>  vulnerablityCount = {phobia.vulnerablityCount}");
        phobia.health -= damage;

        if (phobia.health <= 0)
        {
            phobia.health = 0;
            if (IStartTurnHelper != null)
            {
                StopCoroutine(IStartTurnHelper);
            }

            if (phobia.phobiaPhase == PhobiaPhase.FirstPhase)//Error
                phobia.phobiaPhase = PhobiaPhase.SecondPhase;
            else
                GameManager.instance.LevelCompleted();
        }

        UpdateHealthBar();
    }

    public void AddVulnerablity(int value)
    {
        phobia.vulnerablityCount += value;
        if (phobia.vulnerablityCount < 0)
        {
            Debug.Log($"<color=#ffa500ff>phobia's</color> vulnerablity count is less or equal to 0 ");
            phobia.vulnerablityCount = 0;
        }
    }

    public bool IsPhobiaHaveVulnerablity()
    {
        if (phobia.vulnerablityCount > 0)
            return true;
        else
            return false;
    }

    public void AddWeakness(int value)
    {
        Debug.Log($"<color=#ffa500ff>phobia: </color> AddWeakness called. Value = {value}");
        phobia.weaknessStack += value;
        if (phobia.weaknessStack < 0)
        {
            Debug.Log($"<color=#ffa500ff>phobia's</color> weakness stack is less or equal to 0 ");
            phobia.weaknessStack = 0;
        }
    }



    private void UpdateHealthBar()
    {
        //healthBarImage.fillAmount = Health / maxHealth;
        healthTxtp.text = $"{Mathf.RoundToInt(phobia.health)}/{Mathf.RoundToInt(phobia.maximumHealth)}";
    }

    private void PrepareAttack()
    {
        phobia.PrepareAttack();

        phobiaNextAction.text = $"{phobia.attackCountInAStep}<color=#6b61fe>X</color>{phobia.attackForce}";
    }

    private void AttackATime()
    {
        Debug.Log($"<color=orange>PHOBIA: </color>Attackpatient with {phobia.attackForce} attack force, {phobia.weaknessStack} weaknessStack aaand {phobia.power} power");
        PatientManager.instance.MakeTheDamage(phobia.attackForce - phobia.weaknessStack + phobia.power);
    }


    private Coroutine IStartTurnHelper;
    private IEnumerator IStartTurn(UnityAction onDone)
    {
        Debug.Log($"<color=orange>Turn Started</color>");

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < phobia.attackCountInAStep; i++)
        {
            AttackATime();
            yield return new WaitForSeconds(0.5f);
        }

        onDone?.Invoke();
        PrepareAttack();
        IStartTurnHelper = null;

        Debug.Log($"<color=orange>Turn Ended</color>");
    }


    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
