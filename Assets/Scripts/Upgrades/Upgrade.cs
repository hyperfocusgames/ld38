using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade
{
	public bool limited = false;
	public abstract void activate();

	public abstract string title { get; }
	public abstract string description { get; }
}
