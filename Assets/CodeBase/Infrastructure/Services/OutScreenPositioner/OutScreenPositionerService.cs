using CodeBase.Cubes;
using CodeBase.SoapBubble;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.OutScreenPositioner
{
	public class OutScreenPositionerService
	{
		private readonly float _borderSize;
		private readonly float _downBorder;
		public OutScreenPositionerService()
		{
			float orthographicSize = Camera.main.orthographicSize;
			_borderSize = orthographicSize * Screen.width / Screen.height;
			_downBorder = - orthographicSize;
		}
		public void SetPosition(ComponentsHolder holder)
		{
			float xPosition = Mathf.Lerp(-_borderSize + holder.Radius, _borderSize - holder.Radius, Random.value);
			float yPosition = _downBorder - holder.Radius;
			holder.Transform.position = new Vector3(xPosition, yPosition);
		}
	}
}