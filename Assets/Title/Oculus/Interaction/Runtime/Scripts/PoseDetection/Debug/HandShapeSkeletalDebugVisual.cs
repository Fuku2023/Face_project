
using Oculus.Interaction.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Oculus.Interaction.PoseDetection.Debug
{
    public class HandShapeSkeletalDebugVisual : MonoBehaviour
    {
        [SerializeField]
        private ShapeRecognizerActiveState _shapeRecognizerActiveState;

        [SerializeField]
        private GameObject _fingerFeatureDebugVisualPrefab;

        protected virtual void Awake()
        {
            this.AssertField(_shapeRecognizerActiveState, nameof(_shapeRecognizerActiveState));
            this.AssertField(_fingerFeatureDebugVisualPrefab, nameof(_fingerFeatureDebugVisualPrefab));
        }

        protected virtual void Start()
        {
            var statesByFinger = AllFeatureStates()
                .GroupBy(s => s.Item1)
                .Select(group => new
                {
                    HandFinger = group.Key,
                    FingerFeatures = group.SelectMany(item => item.Item2)
                });
            foreach (var g in statesByFinger)
            {
                foreach (var feature in g.FingerFeatures)
                {
                    var boneDebugObject = Instantiate(_fingerFeatureDebugVisualPrefab);
                    var skeletalComp = boneDebugObject.GetComponent<FingerFeatureSkeletalDebugVisual>();

                    skeletalComp.Initialize(_shapeRecognizerActiveState.Hand, g.HandFinger, feature);

                    var debugVisTransform = boneDebugObject.transform;

                    debugVisTransform.parent = this.transform;

                    debugVisTransform.localScale = Vector3.one;
                    debugVisTransform.localRotation = Quaternion.identity;
                    debugVisTransform.localPosition = Vector3.zero;
                }
            }
        }

        private IEnumerable<ValueTuple<HandFinger, IReadOnlyList<ShapeRecognizer.FingerFeatureConfig>>> AllFeatureStates()
        {
            foreach (ShapeRecognizer shapeRecognizer in _shapeRecognizerActiveState.Shapes)
            {
                foreach (var handFingerConfigs in shapeRecognizer.GetFingerFeatureConfigs())
                {
                    yield return handFingerConfigs;
                }
            }
        }
    }
}
