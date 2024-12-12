// Script by : Nanatchy

using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TurretsManager : MonoBehaviour
{
    #region Attributs

    [SerializeField] private List<Damage> turrets;
    [SerializeField] private GameObject win;
    [SerializeField] private TextMeshProUGUI numbTurret;

    #endregion

    #region Methods

    private void AddChildren()
    {
	    turrets.Clear();
	    
	    for (int i = 0; i < transform.childCount; i++)
	    {
		    var child = transform.GetChild(i);
		    
		    var script = child.GetComponent<Damage>();
		    if (script != null) 
		    {
			    turrets.Add(script);
		    }
	    }
    }
    #endregion

    #region Behaviors

    private void Start()
    {
        AddChildren();
    }

	private void Update()
	{
		numbTurret.text = "Turrets : " + turrets.Count;
		
		foreach (var turret in turrets.ToList().Where(turret => turret.isDead))
		{
			turrets.Remove(turret);
		}

		if (turrets.Count < 1)
		{
			win.SetActive(true);
		}
	}
	
	#endregion
}
