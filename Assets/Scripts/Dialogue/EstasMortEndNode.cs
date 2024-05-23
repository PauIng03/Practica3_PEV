using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEstasMortEndNode", menuName = "Dialogue/EndNodes/DeafultEstasMortEndNode", order = 1)]
public class EstasMortEndNode : EndNode
{
    public override void OnChosen(GameObject npc)
    {
        npc.GetComponent<MovementController>().EstasMort();
    }
}
