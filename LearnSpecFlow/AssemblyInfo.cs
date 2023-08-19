using System.Runtime.InteropServices;
using NUnit.Framework;

[assembly: ComVisible(false)]
[assembly: Guid("d2db690d-115c-4063-b2f8-6af70ecc8325")]

// Parallel Testing...
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]