﻿using System;
using System.Diagnostics;
using BenchmarkDotNet.Running;

namespace SimdLecture
{
    internal class Program
    {
        private static void EstimateTime<T>(Func<T> sumFunc)
        {
            Console.WriteLine($"Test method: {sumFunc.Method.Name}");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = sumFunc();
            stopwatch.Stop();
            Console.WriteLine($"Result: {result}, Elapsed milliseconds: {stopwatch.ElapsedMilliseconds}");
        }

        private static void TestAllSumImplementations()
        {
            var instance = new SumLoopBenchmark();
            EstimateTime(instance.SimdForSum);
            EstimateTime(instance.ForeachSum);
            EstimateTime(instance.SimpleForSum);
        }

        private static void TestAllSegmentCheckImplementations()
        {
            var instance = new SegmentCheckBenchmark();
            EstimateTime(instance.SimdOptimizedForCountInRange);
            EstimateTime(instance.SimdForCountInRange);
            EstimateTime(instance.ForeachCountInRange);
            EstimateTime(instance.SimpleForCountInRange);
        }

        private static void Main(string[] args)
        {
            //TestAllSumImplementations();
            //TestAllSegmentCheckImplementations();
            //BenchmarkRunner.Run<SumLoopBenchmark>();
            BenchmarkRunner.Run<SegmentCheckBenchmark>();
        }
    }
}