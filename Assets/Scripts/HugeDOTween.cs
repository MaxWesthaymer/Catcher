using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class HugeDOTween : MonoBehaviour {
		public Image _triangle;
		public GameObject _gameOverPrefab;
		private Sequence mySequence;
		public Text _title1;
		public Text _title2;
		public Image _splash;
		public Text _score;
		public Text _bestScore;
		public Image _replayImage;
		public GameObject _helpPrefab;
		public Text[] _bestMAIN;

	// Use this for initialization
	void Start () {
				// Get a usable Sequence and set it to have infinite loops
				_splash.DOFade(0,0.5f).SetUpdate(true);
				_bestMAIN[0].rectTransform.DOScale (new Vector3 (0.8f, 0.8f), 0.5f).SetLoops (-1, LoopType.Yoyo).SetUpdate (true);
				_bestMAIN[1].rectTransform.DOScale (new Vector3 (0.8f, 0.8f), 0.5f).SetLoops (-1, LoopType.Yoyo).SetUpdate (true);
				mySequence = DOTween.Sequence().SetLoops(-1).SetUpdate(true);
				//Append a tween to it
				mySequence.AppendInterval(1);
				mySequence.Append(_triangle.rectTransform.DORotate(new Vector3(0,0,360), 1f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
				mySequence.Append(_triangle.rectTransform.DOPunchPosition(new Vector3 (23,0,0),0.5f,2,1,false));
				Sequence _title = DOTween.Sequence().SetUpdate(true);
				_title.Append(_title1.rectTransform.DOAnchorPosX(-75,1,false));
				_title.Append(_title2.rectTransform.DOAnchorPosX(2.4f,1,false));
				// Add a 1 second pause at the end of the Sequence
				//mySequence.AppendInterval(1);
	
	}
	
		public void TextScale (Text obj, float forse)
				{
				Sequence _textScale = DOTween.Sequence ();
				_textScale.Append(obj.transform.DOScale (forse, 0.2f).SetEase(Ease.InOutQuad));
				_textScale.Append(obj.transform.DOScale (1f, 0.2f));

				}
		public void MoveOnY(GameObject obj, float _setY, float _setDuration)
		{
				obj.transform.DOMoveY (_setY, 0.5f, false);

		}
		public void MoveOnX(Button obj, float _setX, float _setDuration)
		{
				obj.GetComponent<RectTransform> ().DOAnchorPosX (_setX, _setDuration, false);

		}
		public void GameOverAnimation()
		{
				RectTransform _rectTransf = _gameOverPrefab.GetComponent<RectTransform> ();
				Sequence _animGo = DOTween.Sequence ();
				_animGo.Append(_rectTransf.DOAnchorPosY(0,0.5f,false));
				_animGo.Append(_score.rectTransform.DOAnchorPosY(87f, 0.5f, false).SetEase(Ease.Linear));
				_animGo.Join(_bestScore.rectTransform.DOAnchorPosY(160f, 0.6f, false).SetEase(Ease.Linear));
				Sequence _replay = DOTween.Sequence().SetLoops(-1);
				//Append a tween to it
				_replay.AppendInterval(1);
				_replay.Append(_replayImage.rectTransform.DOLocalRotate(new Vector3(0,0,-360), 1f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
				_replay.AppendInterval(1);
				//_replay.Append(_replayImage.rectTransform.DOPunchPosition(new Vector3 (23,0,0),0.5f,2,1,false));
		}
		public void DOHelp()
		{
				_helpPrefab.SetActive (true);
				_helpPrefab.transform.DOScale (new Vector3 (0.8f, 0.8f), 0.5f).SetLoops(5,LoopType.Yoyo)
						.OnComplete(()=>_helpPrefab.SetActive (false));
		}

}
