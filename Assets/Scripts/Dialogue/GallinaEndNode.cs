using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newGallinaEndNode", menuName = "Dialogue/EndNodes/DeafultGallinaEndNode", order = 1)]
public class GallinaEndNode : EndNode
{
    public override void OnChosen(GameObject npc)
    {
        npc.GetComponent<MovementController>().Gallina();
    }
}