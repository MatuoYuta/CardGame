using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class AttackButton : MonoBehaviour
{
    // 攻撃対象
    public GameObject target;
    // プレイヤーのステータス
    public PlayerStats playerStats;
    // モンスターのステータス
    public MonsterStats monsterStats; 

    // 攻撃ボタンが押されたときに呼び出される関数
    public void OnAttackButtonClicked()
    {
        if (target != null)
        {
            // 攻撃対象がプレイヤーかモンスターかで処理を分岐
            if (target.CompareTag("Player"))
            {
                // プレイヤーの場合、ライフを1削る
                if (playerStats != null)
                {
                    playerStats.TakeDamage(1);
                }
                else
                {
                    Debug.LogError("PlayerStatsが見つかりませんでした。");
                }
            }
            else if (target.CompareTag("Monster"))
            {
                // モンスターの場合、攻撃力を比較してダメージ処理を行う
                if (playerStats != null && monsterStats != null)
                {
                    if (playerStats.attackPower >= monsterStats.attackPower)
                    {
                        monsterStats.TakeDamage(playerStats.attackPower);
                    }
                    else
                    {
                        playerStats.TakeDamage(monsterStats.attackPower);
                    }
                }
                else
                {
                    Debug.LogError("PlayerStatsまたはMonsterStatsが見つかりませんでした。");
                }
            }
            else
            {
                Debug.LogError("攻撃対象が不明です。");
            }
        }
        else
        {
            Debug.LogError("攻撃対象が設定されていません。");
        }
    }
}*/