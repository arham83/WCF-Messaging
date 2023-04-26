``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2846/21H2/November2021Update)
Intel Xeon CPU E5-1620 0 3.60GHz, 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4614.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8 (4.8.4614.0), X86 LegacyJIT


```
|                        Method |         Mean |      Error |     StdDev |       Median |
|------------------------------ |-------------:|-----------:|-----------:|-------------:|
|     ProtoBufSerialization_SOM |     7.329 μs |  0.1449 μs |  0.3765 μs |     7.243 μs |
| TransmissionTime_UsingWCF_SOM | 1,924.476 μs | 37.9621 μs | 86.4590 μs | 1,890.784 μs |
|   ProtoBufDeserialization_SOM |     8.985 μs |  0.0653 μs |  0.0545 μs |     8.989 μs |
|     ProtoBufSerialization_BOM |    87.445 μs |  1.7230 μs |  3.7821 μs |    86.591 μs |
| TransmissionTime_UsingWCF_BOM | 2,175.961 μs | 17.9610 μs | 14.0228 μs | 2,177.434 μs |
|   ProtoBufDeserialization_BOM |    97.104 μs |  1.8496 μs |  3.8198 μs |    95.597 μs |
