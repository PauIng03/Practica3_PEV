using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newThanksEndNode", menuName = "Dialogue/EndNodes/DeafultThanksEndNode", order = 1)]
public class ThanksEndNode : EndNode
{
    public override void OnChosen(GameObject npc)
    {
        npc.GetComponent<MovementController>().Thanks();
    }
}