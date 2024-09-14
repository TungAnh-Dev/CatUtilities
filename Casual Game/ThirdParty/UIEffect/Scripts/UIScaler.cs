using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Coffee.UIEffects
{
    [AddComponentMenu("UI/UIEffects/UIScaler", 3)]
    public class UIScaler : BaseMaterialEffect
    {
        [Tooltip("Initial scale for the scaling effect.")]
        [Range(0, 2)]
        public float initialScale = 1.0f; // Thêm giá trị scale ban đầu

        [Tooltip("Target scale for the scaling effect.")]
        [Range(0, 2)]
        public float targetScale = 1.5f;

        [Tooltip("Duration for one scale cycle.")]
        [Range(0, 2)]
        public float duration = 0.5f;

        private float _originalScale;
        private Coroutine _scaleCoroutine;

        protected override void OnEnable()
        {
            base.OnEnable();
            _originalScale = initialScale; // Sử dụng giá trị scale ban đầu
            transform.localScale = new Vector3(_originalScale, _originalScale, _originalScale);
            StartScaling();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            StopScaling();
        }

        private void StartScaling()
        {
            if (_scaleCoroutine != null)
            {
                StopCoroutine(_scaleCoroutine);
            }
            _scaleCoroutine = StartCoroutine(ScaleRoutine());
        }

        private void StopScaling()
        {
            if (_scaleCoroutine != null)
            {
                StopCoroutine(_scaleCoroutine);
                _scaleCoroutine = null;
            }
            transform.localScale = new Vector3(_originalScale, _originalScale, _originalScale);
        }

        private IEnumerator ScaleRoutine()
        {
            while (true)
            {
                yield return ScaleTo(targetScale);
                yield return ScaleTo(_originalScale);
            }
        }

        private IEnumerator ScaleTo(float target)
        {
            float currentScale = transform.localScale.x;
            float time = 0f;

            while (time < duration)
            {
                float scale = Mathf.Lerp(currentScale, target, time / duration);
                transform.localScale = new Vector3(scale, scale, scale);
                time += Time.deltaTime;
                yield return null;
            }

            transform.localScale = new Vector3(target, target, target);
        }

        public override void ModifyMesh(VertexHelper vh, Graphic graphic)
        {
            // Implement this method if needed for the scaling effect.
        }

        public override void ModifyMaterial(Material newMaterial, Graphic graphic)
        {
            // Implement this method if needed for the scaling effect.
        }

        public override Hash128 GetMaterialHash(Material material)
        {
            return k_InvalidHash;
        }
    }
}
