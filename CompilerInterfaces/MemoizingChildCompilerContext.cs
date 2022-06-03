using System.Collections.Concurrent;

namespace DPG.NET;

public abstract class MemoizingChildCompilerContext<
        T, Compiled, CompilerContext,
        ParentT, ParentCompiled, ParentCompilerContext
    >
    : ChildCompilerContext<
            T, Compiled, CompilerContext,
            ParentT, ParentCompiled, ParentCompilerContext
        >
    where T : ICompilable<T, Compiled, CompilerContext>
    where CompilerContext : MemoizingChildCompilerContext<T, Compiled, CompilerContext, ParentT, ParentCompiled, ParentCompilerContext>
    where ParentT : ICompilable<ParentT, ParentCompiled, ParentCompilerContext>
    where ParentCompilerContext : ICompilerContext<ParentT, ParentCompiled, ParentCompilerContext>
{
    private ConcurrentDictionary<T, Compiled> cache = new();

    public MemoizingChildCompilerContext(ParentCompilerContext parent)
        : base(parent) {}

    public override Compiled this[T start] =>
        cache.GetOrAdd(start, _ => _.Compile((CompilerContext)this));
}