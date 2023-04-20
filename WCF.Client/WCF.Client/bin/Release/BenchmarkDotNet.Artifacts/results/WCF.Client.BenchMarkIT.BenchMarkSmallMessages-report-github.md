``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2846/21H2/November2021Update)
Intel Xeon CPU E5-1620 0 3.60GHz, 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4614.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8 (4.8.4614.0), X86 LegacyJIT


```
|                         Method |             Mean |          Error |         StdDev |           Median |
|------------------------------- |-----------------:|---------------:|---------------:|-----------------:|
|   MessagePackSerialization_SFM |     4,025.841 μs |     76.6126 μs |     91.2019 μs |     4,021.531 μs |
| TransmissionTime_UsingWCF_Msg1 |    36,228.714 μs |    944.3915 μs |  2,739.8509 μs |    35,714.980 μs |
| MessagePackDeserialization_SFM |     7,622.124 μs |    152.0886 μs |    270.3373 μs |     7,565.458 μs |
|   MessagePackSerialization_SOM |         9.327 μs |      0.1831 μs |      0.4855 μs |         9.289 μs |
| TransmissionTime_UsingWCF_Msg2 |     2,397.316 μs |     93.0337 μs |    265.4303 μs |     2,316.926 μs |
| MessagePackDeserialization_SOM |        11.075 μs |      0.2212 μs |      0.5710 μs |        10.835 μs |
|   MessagePackSerialization_BFM |   314,904.361 μs |  6,213.1072 μs | 12,408.2465 μs |   309,681.250 μs |
| TransmissionTime_UsingWCF_Msg3 |   894,582.824 μs | 17,228.4834 μs | 45,083.9382 μs |   880,039.150 μs |
| MessagePackDeserialization_BFM | 1,097,184.692 μs | 21,461.1237 μs | 17,921.0103 μs | 1,094,939.800 μs |
|   MessagePackSerialization_BOM |       101.573 μs |      1.7434 μs |      3.4004 μs |       100.472 μs |
| TransmissionTime_UsingWCF_Msg4 |     2,460.328 μs |     53.1328 μs |    153.3002 μs |     2,430.864 μs |
| MessagePackDeserialization_BOM |       131.346 μs |      2.6155 μs |      5.6859 μs |       128.387 μs |
