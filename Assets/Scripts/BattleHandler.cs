using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
        float outcome = 1;

        data.npc.level = Random.Range(data.player.level - 2, data.player.level + 3);

        if (data.player.level < 3)
        {
            data.npc.level = 1;
        }
        
              if (data.player.totalstats > data.npc.totalstats)
              {
                  outcome = Random.Range(0f, 1f);
              }

              if (data.player.totalstats < data.npc.totalstats)
              {
                  outcome = Random.Range(-1f, 0f);
              }

        Debug.Log(outcome);
        Debug.Log("level" + " " + data.player.level);
        Debug.Log(data.player.luck);
        Debug.Log(data.player.rhythm);
        Debug.Log(data.player.style);
        Debug.Log("playerxp" + " " + data.player.xp);
        Debug.Log(outcome);
        Debug.Log("level" + " " + data.npc.level);
        Debug.Log(data.npc.luck);
        Debug.Log(data.npc.rhythm);
        Debug.Log(data.npc.style);
        Debug.Log("npcxp" + " " + data.npc.xp);


        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);
    }
}
