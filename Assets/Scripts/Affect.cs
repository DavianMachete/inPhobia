using UnityEngine.Events;

public class Affect
{
    public InPhobiaBahaviour inPhobia;


    public Affect()
    {
        if (inPhobia != null)
            inPhobia = null;
        inPhobia = new InPhobiaBahaviour();
    }
    public Affect(UnityAction onAction, InPhobiaEventType eventType)
    {
        if (inPhobia != null)
            inPhobia = null;
        inPhobia = new InPhobiaBahaviour();

        switch (eventType)
        {
            case InPhobiaEventType.OnStepStart:
                inPhobia.OnStepStart = onAction;
                break;
            case InPhobiaEventType.OnStepEnd:
                inPhobia.OnStepEnd = onAction;
                break;
            case InPhobiaEventType.OnEveryStepStart:
                inPhobia.OnEveryStepStart = onAction;
                break;
            case InPhobiaEventType.OnEveryStepEnd:
                inPhobia.OnEveryStepEnd = onAction;
                break;
            case InPhobiaEventType.OnEnemyStepStart:
                inPhobia.OnEnemyStepStart = onAction;
                break;
            case InPhobiaEventType.OnEnemyStepEnd:
                inPhobia.OnEnemyStepEnd = onAction;
                break;
            case InPhobiaEventType.OnEnemyEveryStepStart:
                inPhobia.OnEnemyEveryStepStart = onAction;
                break;
            case InPhobiaEventType.OnEnemyEveryStepEnd:
                inPhobia.OnEnemyEveryStepEnd = onAction;
                break;
            case InPhobiaEventType.OnEveryAttack:
                inPhobia.OnEveryAttack = onAction;
                break;
            case InPhobiaEventType.OnEveryDefense:
                inPhobia.OnEveryDefense = onAction;
                break;
            default:
                break;
        }
    }
    private Affect(InPhobiaBahaviour inPhobia)
    {
        this.inPhobia = inPhobia;
    }
    private Affect(Affect affect, int multiplier)
    {
        for (int i = 0; i < multiplier; i++)
        {
            affect += affect;
        }
        this.inPhobia = affect.inPhobia;
    }


    public static Affect operator +(Affect firstAffect, Affect secondAffect) =>
        new Affect(firstAffect.inPhobia + secondAffect.inPhobia);
    public static Affect operator *(Affect affect, int number) => 
        new Affect(affect, number);
    public static Affect operator *(int number, Affect affect) =>
        new Affect(affect, number);

    //private 
}