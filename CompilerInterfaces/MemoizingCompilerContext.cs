using System.Collections.Concurrent;

namespace DPG.NET;

public abstract class MemoizingCompilerContext<T, Compiled, CompilerContext>
    : ICompilerContext<T, Compiled, CompilerContext>
    where T : notnull, ICompilable<T, Compiled, CompilerContext>
    where CompilerContext : MemoizingCompilerContext<T, Compiled, CompilerContext>
    {
    private ConcurrentDictionary<T, Compiled> cache = new();

    public Compiled this[T start] =>
        cache.GetOrAdd(start, _ => _.Compile((CompilerContext)this));
}