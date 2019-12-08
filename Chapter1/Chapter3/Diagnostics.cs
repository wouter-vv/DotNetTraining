using System.Diagnostics;

namespace Chapter3
{
    class Diagnostics
    {
        public void addTracers()
        {
            TraceSource trace = new TraceSource("Tracer", SourceLevels.All);
            trace.TraceEvent(TraceEventType.Start, 10000);
            trace.TraceEvent(TraceEventType.Warning, 10001);
            trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
            trace.TraceData(TraceEventType.Information, 1003, new object[] { "Note 1", "Message 2" });
            trace.Flush();
            trace.Close();
        }

        // Make own performance Counter
        // Example copied from the book

        static PerformanceCounter TotalImageCounter;
        static PerformanceCounter ImagesPerSecondCounter;

        enum CreationResult
        {
            CreatedCounters,
            LoadedCounters
        };

        static CreationResult SetupPerformanceCounters()
        {
            string categoryName = "Image Processing";

            if (PerformanceCounterCategory.Exists(categoryName))
            {
                // production code should use using 
                TotalImageCounter = new PerformanceCounter(categoryName: categoryName,
                    counterName: "# of images processed",
                readOnly: false);
                // production code should use using 
                ImagesPerSecondCounter = new PerformanceCounter(categoryName: categoryName,
                    counterName: "# images processed per second",
                readOnly: false);
                return CreationResult.LoadedCounters;
            }

            CounterCreationData[] counters = new CounterCreationData[] {
                new CounterCreationData(counterName:"# of images processed",
                counterHelp:"number of images resized",
                counterType:PerformanceCounterType.NumberOfItems64),
                new CounterCreationData(counterName: "# images processed per second",
                counterHelp:"number of images processed per second",
                counterType:PerformanceCounterType.RateOfCountsPerSecond32)
            };

            CounterCreationDataCollection counterCollection =
            new CounterCreationDataCollection(counters);

            PerformanceCounterCategory.Create(categoryName: categoryName,
                categoryHelp: "Image processing information",
                categoryType: PerformanceCounterCategoryType.SingleInstance,
                counterData: counterCollection);

            return CreationResult.CreatedCounters;
        }
    }
}
