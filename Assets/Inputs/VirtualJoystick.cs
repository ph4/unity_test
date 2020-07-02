using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inputs
{
    public class VirtualJoystick : VirtualInput, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public override Vector3 InputVector => _inputVector;

        private Image _bgImg;
        private Image _joyImg;
        private Vector3 _inputVector = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {
            _bgImg = GetComponent<Image>();
            _joyImg = transform.GetChild(0).GetComponent<Image>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            var inRange = RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _bgImg.rectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out var pos
            );
            if (inRange)
            {
                var sizeDelta = _bgImg.rectTransform.sizeDelta;
                pos.x = pos.x / sizeDelta.x;
                pos.y = pos.y / sizeDelta.y;

                _inputVector.x = pos.x * 2 + 1;
                _inputVector.z = pos.y * 2 - 1;

                if (_inputVector.magnitude > 1f)
                    _inputVector.Normalize();

                //Debug.Log(_inputVector);

                _joyImg.rectTransform.anchoredPosition = new Vector2(
                    _inputVector.x * sizeDelta.x / 2,
                    _inputVector.z * sizeDelta.y / 2);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputVector = Vector3.zero;
            _joyImg.rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}