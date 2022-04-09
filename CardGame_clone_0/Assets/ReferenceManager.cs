using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour {
    static ReferenceManager _instance;
    public static ReferenceManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<ReferenceManager>();
            }
            return _instance;
        }
    }
    [field: SerializeField] public GameObject Table { get; private set; }
    [field: SerializeField] public GameObject PlayerHand { get; private set; }
    [field: SerializeField] public GameObject Card { get; private set; }
    //[field: SerializeField] public GameObject EnemyCard { get; private set; }
    [field: SerializeField] public GameObject CardShadow { get; private set; }
    [field: SerializeField] public BoxCollider2D PlayZone { get; private set; }
}
