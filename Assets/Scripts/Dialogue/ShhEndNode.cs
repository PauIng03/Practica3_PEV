using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newShhEndNode", menuName = "Dialogue/EndNodes/DeafultShhEndNode", order = 1)]
public class ShhEndNode : EndNode
{
    public override void OnChosen(GameObject npc)
    {
        npc.GetComponent<MovementController>().Shh();
    }
}