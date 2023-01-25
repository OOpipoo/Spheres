using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.UI.TapToStart
{
	[RequireComponent(typeof(Canvas))]
	public class TapToStartService : MonoBehaviour
	{
		[SerializeField] private Transform _text;
		[SerializeField] private float _showDelay = .5f;
		[SerializeField] private float _pongDelay = .2f;
		[SerializeField] private float _scaleModifier = 1.5f;
		[SerializeField] private float _duration = 0.5f;
		private Canvas _canvas;
		private Vector3 _shownPosition;
		private Vector3 _hidePosition;

		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
			_canvas.enabled = false;
			_shownPosition = _text.position;
			_hidePosition = _shownPosition - Vector3.up * _shownPosition.y * 2;
		}

		public void Show()
		{
			Reset();
			StartCoroutine(Showing());
		}

		public void Hide()
		{
			Reset();
			_text
				.DOMoveY(_hidePosition.y, _showDelay)
				.SetEase(Ease.InOutBack)
				.OnComplete(() =>
				{
					_canvas.enabled = false;
				});
		}

		private IEnumerator Showing()
		{
			_text.localScale = Vector3.one;
			_canvas.enabled = true;
			_text.position = _hidePosition;
			yield return _text
				.DOMoveY(_shownPosition.y, _showDelay)
				.SetDelay(_showDelay)
				.SetEase(Ease.OutBack)
				.WaitForCompletion();
			_text
				.DOScale(Vector3.one * _scaleModifier, _duration)
				.SetDelay(_pongDelay)
				.SetEase(Ease.InOutSine)
				.SetLoops(-1, LoopType.Yoyo);
		}

		private void Reset()
		{
			StopAllCoroutines();
			DOTween.Kill(_text);
		}
	}
}