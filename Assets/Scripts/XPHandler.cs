using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GameEvents_OnBattleConclude;
    }

    private void GameEvents_OnBattleConclude(BattleResultEventData data)
    {
        GainXP(data);

    }

    private void OnDisable()
    {
    }

    public void GainXP(BattleResultEventData data)
    {
        print("works");
        data.player.xp = (int)((data.npc.level / data.player.level) * ((data.player.rhythm / data.player.style) * 10) + data.outcome * 100);

        if (data.player.xp >= data.player.xpneeded)
        {
            data.player.level++;
            data.player.xp = 0;
            data.player.rhythm = data.player.level * 5;
            data.player.style = data.player.level * 3;
        }
    }
}
