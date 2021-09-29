using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Proyectile", menuName = "Stats/Proyectiles/Base", order = 0)]
public class ProyectileStats : ScriptableObject
{
    public float ProyectileLifeTime => proyectileLifeTime;
    [SerializeField] protected float proyectileLifeTime;
    public float ProyectileSpeed => proyectileSpeed;
    [SerializeField] protected float proyectileSpeed;
    public string ProyectileTag => proyectileTag;
    [SerializeField] private string proyectileTag;
    public string ProyectileParticlesTag => proyectileParticlesTag;
    [SerializeField] private string proyectileParticlesTag;
    public float ProyectileDamage => proyectileDamage;
    [SerializeField] private float proyectileDamage;

}
