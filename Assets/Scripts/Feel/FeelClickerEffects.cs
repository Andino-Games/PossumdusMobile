using System;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Feel
{
    public class FeelClickerEffects : MonoBehaviour
    {
        public MMF_Player moveFeedback;
        public static FeelClickerEffects Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayMoveFeedback()
        {
            moveFeedback?.PlayFeedbacks();
        }
    }
}
