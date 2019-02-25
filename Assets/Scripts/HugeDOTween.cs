using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class HugeDOTween : MonoBehaviour 
{	
	#region InspectorFields
	[SerializeField] private Image _triangle;
	[SerializeField] private GameObject _gameOverPrefab;
	
	[SerializeField] private Text _title1;
	[SerializeField] private Text _title2;
	[SerializeField] private Image _splash;
	[SerializeField] private Text _score;
	[SerializeField] private Text _bestScore;
	[SerializeField] private Image _replayImage;
	[SerializeField] private Text[] _bestMAIN;
	#endregion
	
	private Sequence _mySequence;
	
	#region UnityMethods
	private void Start () 
	{		
		_splash.gameObject.SetActive(true);
		_splash.DOFade(0,0.5f);
		_bestMAIN[0].rectTransform.DOScale (new Vector3 (0.8f, 0.8f), 0.5f).SetLoops (-1, LoopType.Yoyo);
		_bestMAIN[1].rectTransform.DOScale (new Vector3 (0.8f, 0.8f), 0.5f).SetLoops (-1, LoopType.Yoyo);
		_mySequence = DOTween.Sequence().SetLoops(-1);
		_mySequence.AppendInterval(1);
		_mySequence.Append(_triangle.rectTransform.DORotate(new Vector3(0,0,360), 1f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
		_mySequence.Append(_triangle.rectTransform.DOPunchPosition(new Vector3 (23,0,0),0.5f,2));
		
		var title = DOTween.Sequence();
		title.Append(_title1.rectTransform.DOAnchorPosX(-100,1));
		title.Append(_title2.rectTransform.DOAnchorPosX(10,1));	
	}
	#endregion
	
	#region PublicMethods
	public void TextScale (Text obj, float forse)
		{
		var textScale = DOTween.Sequence ();
		textScale.Append(obj.transform.DOScale (forse, 0.2f).SetEase(Ease.InOutQuad));
		textScale.Append(obj.transform.DOScale (1f, 0.2f));
		}
	public void MoveOnY(GameObject obj, float setY)
	{
		obj.transform.DOMoveY (setY, 0.5f);
	}
	public void MoveOnX(Button obj, float setX, float setDuration)
	{
		obj.GetComponent<RectTransform> ().DOAnchorPosX (setX, setDuration);
	}
	public void GameOverAnimation()
	{
		var rectTransf = _gameOverPrefab.GetComponent<RectTransform> ();
		
		var animGo = DOTween.Sequence ();
		animGo.Append(rectTransf.DOAnchorPosY(0,0.5f,false));
		animGo.Append(_score.rectTransform.DOAnchorPosY(200f, 0.5f).SetEase(Ease.Linear));
		animGo.Join(_bestScore.rectTransform.DOAnchorPosY(270f, 0.6f).SetEase(Ease.Linear));
		
		var replay = DOTween.Sequence().SetLoops(-1);
		replay.AppendInterval(1);
		replay.Append(_replayImage.rectTransform.DOLocalRotate(new Vector3(0,0,-360), 1f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
		replay.AppendInterval(1);
	}
	#endregion
}
