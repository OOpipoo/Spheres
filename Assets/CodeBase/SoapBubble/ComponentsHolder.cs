using CodeBase.GameSphere;
using UnityEngine;

namespace CodeBase.SoapBubble
{
	public class ComponentsHolder
	{
		public readonly GameObject GameObject;
		public readonly Transform Transform;
		public float Speed;
		public float Radius;
		public float Points;


		public ComponentsHolder(Bubble bubble)
		{
			GameObject = bubble.gameObject;
			Transform = bubble.transform;
		}
	}
}