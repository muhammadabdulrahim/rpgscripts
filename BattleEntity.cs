using UnityEngine;
using UnityEditor;

public class BattleEntity : MonoBehaviour
{
	//	Top-level information
	public string entityName;
	public bool isEnemy;

	//	General battle stats
	public uint maxHp;
	public uint maxMp;
	public uint attack;
	public uint defense;
	public uint magicAttack;
	public uint magicDefense;
	public uint speed;

	//	Player-specific stats
	public PlayerAffinity playerAffinity;

	//	Enemy-specific stats
	public EnemyAffinity enemyAffinity;
	public uint experience;
	public uint gold;

	//	Private stats
	private uint currentHp;
	private uint currentMp;

	//	Boolean accessors
	public bool IsEnemy { get { return isEnemy; } }
	public bool IsPlayer { get { return !isEnemy; } }
	public bool IsAlive { get { return currentHp > 0; } }
	public bool IsDead { get { return currentHp <= 0; } }
	public bool IsAtFullHealth { get { return currentHp == maxHp; } }
	public bool IsOutOfMp { get { return currentMp <= 0; } }
	public bool IsAtFullMp { get { return currentMp == maxMp; } }

	//	HP and MP accessors
	public uint CurrentHP
	{
		get { return currentHp; }
		private set { currentHp = (uint)Mathf.Clamp(value, 0, maxHp); }
	}

	public uint CurrentMP
	{
		get { return currentMp; }
		private set { currentMp = (uint)Mathf.Clamp(value, 0, maxMp); }
	}

	//	Simple initialization to set the current values to their max values
	public void Initialize()
	{
		currentHp = maxHp;
		currentMp = maxMp;
	}

	//	Basic damage and healing methods
	public void DamageByHp(uint damage)
	{
		CurrentHP -= damage;
	}

	public void HealByHP(uint health)
	{
		CurrentHP += health;
	}

	public void UseMp(uint mp)
	{
		CurrentMP -= mp;
	}

	public void RecoverMp(uint mp)
	{
		CurrentMP += mp;
	}

	//	Ensure ranges make sense by enforcing non-zero minimum values for certain stats
	[ExecuteInEditMode]
	void OnValidate()
	{
		maxHp = (uint)Mathf.Max(1, maxHp);
		speed = (uint)Mathf.Max(1, speed);
	}
}

[CustomEditor(typeof(BattleEntity))]
[CanEditMultipleObjects]
public class BattleEntityEditor : Editor
{
	SerializedProperty entityName,
		isEnemy,
		maxHp,
		maxMp,
		attack,
		defense,
		magicAttack,
		magicDefense,
		speed,
		playerAffinity,
		enemyAffinity,
		experience,
		gold;

	void OnEnable()
	{
		entityName = serializedObject.FindProperty("entityName");
		isEnemy = serializedObject.FindProperty("isEnemy");
		maxHp = serializedObject.FindProperty("maxHp");
		maxMp = serializedObject.FindProperty("maxMp");
		attack = serializedObject.FindProperty("attack");
		defense = serializedObject.FindProperty("defense");
		magicAttack = serializedObject.FindProperty("magicAttack");
		magicDefense = serializedObject.FindProperty("magicDefense");
		speed = serializedObject.FindProperty("speed");
		playerAffinity = serializedObject.FindProperty("playerAffinity");
		enemyAffinity = serializedObject.FindProperty("enemyAffinity");
		experience = serializedObject.FindProperty("experience");
		gold = serializedObject.FindProperty("gold");
	}

	private void ResetPlayerProperties()
	{
		playerAffinity.enumValueIndex = (int)PlayerAffinity.NONE;
	}

	private void ResetEnemyProperties()
	{
		enemyAffinity.enumValueIndex = (int)EnemyAffinity.NONE;
		experience.intValue = 0;
		gold.intValue = 0;
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		//	Show the standard script line
		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((BattleEntity)target), typeof(BattleEntity), false);
		GUI.enabled = true;

		//	Force a warning message if no name is specified
		EditorGUILayout.LabelField("Top-level information", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(entityName);
		if( entityName.stringValue.Length <= 0 )
		{
			EditorGUILayout.LabelField("A name must be specified for the entity!", EditorStyles.centeredGreyMiniLabel);
		}
		EditorGUILayout.Space();

		//	Sanitization of battle stats occurs in BattleEntity.OnValidate
		EditorGUILayout.LabelField("General battle stats", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(maxHp);
		EditorGUILayout.PropertyField(maxMp);
		EditorGUILayout.PropertyField(attack);
		EditorGUILayout.PropertyField(defense);
		EditorGUILayout.PropertyField(magicAttack);
		EditorGUILayout.PropertyField(magicDefense);
		EditorGUILayout.PropertyField(speed);
		EditorGUILayout.Space();

		//	Show/hide enum dropdowns and reset as necessary
		EditorGUILayout.LabelField("Specify if entity is a player or enemy", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(isEnemy);
		EditorGUILayout.Space();

		if( isEnemy.boolValue )
		{
			EditorGUILayout.LabelField("Enemy-specific stats", EditorStyles.boldLabel);
			ResetPlayerProperties();
			EditorGUILayout.PropertyField(enemyAffinity);
			EditorGUILayout.PropertyField(experience);
			EditorGUILayout.PropertyField(gold);
		}
		else
		{
			EditorGUILayout.LabelField("Player-specific stats", EditorStyles.boldLabel);
			ResetEnemyProperties();
			EditorGUILayout.PropertyField(playerAffinity);
		}
		EditorGUILayout.Space();

		serializedObject.ApplyModifiedProperties();
	}
}