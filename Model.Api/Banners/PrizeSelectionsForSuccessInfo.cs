using System;

namespace FFRKApi.Model.Api.Banners
{
    public class PrizeSelectionsForSuccessInfo
    {
        public int TrialsConducted { get; set; }
        public int MinSelectionsRequired { get; set; }
        public int MaxSelectionsRequired { get; set; }
        public double MedianSelectionsRequired { get; set; }
        public int ModeSelectionsRequired { get; set; }
        public double MeanSelectionsRequired { get; set; }

        public override string ToString()
        {
            return $"TrialsConducted: {TrialsConducted}{Environment.NewLine}" +
                   $"MinPullsRequired: {MinSelectionsRequired}{Environment.NewLine}" +
                   $"MaxPullsRequired: {MaxSelectionsRequired}{Environment.NewLine}" +
                   $"MedianPullsRequired: {MedianSelectionsRequired}{Environment.NewLine}" +
                   $"ModePullsRequired: {ModeSelectionsRequired}{Environment.NewLine}" +
                   $"MeanPullsRequired: {MeanSelectionsRequired}{Environment.NewLine}";
        }
    }
}
