using Prometheus;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace WebService.Metrics
{
    public class Summaries
    {
        private readonly ConcurrentDictionary<string, Summary> summaries;

        public Summaries()
        {
            summaries = new ConcurrentDictionary<string, Summary>();
        }

        public void Report(string metric, double value)
        {
            var summary = summaries.GetOrAdd(metric, Prometheus.Metrics.CreateSummary(metric, metric + "_help"));

            summary.Observe(value);
        }
    }
}
