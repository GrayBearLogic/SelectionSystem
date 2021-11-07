using SelectionSystem;
using UnityEngine;

namespace Examples
{

    [RequireComponent(typeof(SelectableComponent))]
    public class MagicCard : MonoBehaviour
    {
        [SerializeField] private float highlightedCardScale = 1.2f;
        [SerializeField] private SpriteRenderer outline;

        public void ShowOutline()
        {
            outline.gameObject.SetActive(true);
        }

        public void HideOutline()
        {
            outline.gameObject.SetActive(false);
        }

        public void Grow()
        {
            transform.localScale = Vector3.one * highlightedCardScale;
        }

        public void Shrink()
        {
            transform.localScale = Vector3.one;
        }

    }
}