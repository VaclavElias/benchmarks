using Benchmark.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Tests
{
    [MemoryDiagnoser]
    public class ConvertAllvsSelectBenchmark
    {
        [Params(10, 100)]
        public int Iterations { get; set; }

        public List<Apple> Items { get; set; } = new();

        [GlobalSetup]
        public void Setup()
        {
            Items.AddRange(Enumerable.Range(0, Iterations).Select(_ => new Apple()));
        }

        [Benchmark]
        public void ConvertAllTest()
        {
            var items = Items.ConvertAll(s => s.Color);
        }

        [Benchmark]
        public void SelectTest()
        {
            var items = Items.Select(s => s.Color).ToList();
        }
    }
}
