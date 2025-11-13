using UnityEngine;

public class EtatAttaque : EtatPoule
{
    public override EtatPoule ExecuterEtat(PouleTourelle poule)
    {
        poule.DemarrerTire();

        return this;
    }
}
