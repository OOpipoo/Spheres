using CodeBase.SoapBubble;
using UnityEngine;

namespace CodeBase.Cubes
{
	public class ComponentsHolder
	{
		public readonly GameObject GameObject;
		public readonly Transform Transform;
		public float Speed;
		public float Radius;
		public float Points;


		public ComponentsHolder(Cube cube)
		{
			GameObject = cube.gameObject;
			Transform = cube.transform;
		}
	}
}