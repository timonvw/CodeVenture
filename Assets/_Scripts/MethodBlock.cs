using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeVenture
{
    public class MethodBlock : MonoBehaviour
    {
        public Text TextObj;
        private Canvas myCanvas;

        [SerializeField]private Vector3 startPos;

        private void Awake()
        {
            // Subscrive ChangeColor method
            CodeEditor.OnCompleted += ChangeColor;
        }

        // Use this for initialization
        private void Start ()
        {
            string objName = this.gameObject.name;
            string objNewName = String.Empty;

            if (objName.Contains("Input"))
            {
                objNewName = objName.Remove(objName.IndexOf("Input"), "Input".Length);
                TextObj.text = objNewName;
            }
            else
            {
                TextObj.text = objName;
            }

            try
            {
                myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetStartPos()
        {
            startPos = this.GetComponent<RectTransform>().localPosition;
        }

        public void OnDrag()
        {
            Vector2 posXY;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out posXY);

            transform.position = myCanvas.transform.TransformPoint(posXY);
        }

        public void OnDrop()
        {
            RectTransform thisRect = GetComponent<RectTransform>();

            if (thisRect.localPosition.x > 3.35f && thisRect.localPosition.x < 5.95f && thisRect.localPosition.y < 1.86f && thisRect.localPosition.y > -9.16f)
            {
                if (CodeEditor.Instance.ListCodeObjects.Contains(this.gameObject))
                {
                    CodeEditor.Instance.ListCodeObjects.Remove(this.gameObject);
                }

                CodeEditor.Instance.ListCodeObjects.Add(this.gameObject);
                CodeEditor.Instance.OrderScript();
            }
            else
            {
                GetComponent<RectTransform>().transform.localPosition = startPos;

                if (CodeEditor.Instance.ListCodeObjects.Contains(this.gameObject))
                {
                    CodeEditor.Instance.ListCodeObjects.Remove(this.gameObject);
                }

                CodeEditor.Instance.OrderScript();
            }
        }

        private void OnDisable()
        {
            if (CodeEditor.Instance.ListCodeObjects.Contains(this.gameObject))
            {
                CodeEditor.Instance.ListCodeObjects.Remove(this.gameObject);
            }

            // Unsubscribe method
            CodeEditor.OnCompleted -= ChangeColor;
        }

        private void ChangeColor(Color color)
        {
            this.GetComponent<Image>().color = color;
        }
    }
}
