namespace Benchmark.Tests;

[MemoryDiagnoser]
public class LoopBenchmark
{
    //[Params(10, 100, 1000)]
    [Params(10, 100)]
    public int Iterations { get; set; }

    public List<Apple> Items { get; set; } = new();

    [GlobalSetup]
    public void Setup()
    {
        Items.AddRange(Enumerable.Range(0, Iterations).Select(_ => new Apple()));
    }


    [Benchmark]
    public void ForEachTest()
    {
        Items.ForEach(x => x.ProcessCost());
    }

    [Benchmark]
    public void ForeachTest()
    {
        foreach (var item in Items)
            item.ProcessCost();
    }

    [Benchmark]
    public void ForTest()
    {
        for (var i = 0; i < Items.Count; i++)
            Items[i].ProcessCost();
    }

    [Benchmark]
    public void AsParallelForAllTest()
    {
        Items.AsParallel().ForAll(s => s.ProcessCost());
    }

    [Benchmark]
    public void ParallelForEachTest()
    {
        Parallel.ForEach(Items, s => s.ProcessCost());
    }
}