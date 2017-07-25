using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BattleEntity : MonoBehaviour
{
	//	Top-level information
	public string entityName;
	public bool isEnemy;

	//	General battle stats
	public uint hp;
	public uint mp;
	public uint attack;
	public uint defense;
	public uint magicAttack;
	public uint magicDefense;
	public uint speed;

	//	Entity-specific affinities
	public PlayerAffinity playerAffinity;
	public EnemyAffinity enemyAffinity;

	[ExecuteInEditMode]
	void OnValidate()
	{
		//	Ensure ranges make sense by enforcing non-zero minimum values for certain stats
		hp = (uint)Mathf.Max(1, hp);
		speed = (uint)Mathf.Max(1, speed);
	}
}
