namespace DPG.NET;

public abstract class ChildCompilerContext<
        T, Compiled, CompilerContext,
        ParentT, ParentCompiled, ParentCompilerContext
    >
    : IChildCompilerContext<
            T, Compiled, CompilerContext,
            ParentT, ParentCompiled, ParentCompilerContext
        >
    where T : ICompilable<T, Compiled, CompilerContext>
    where CompilerContext : ChildCompilerContext<T, Compiled, CompilerContext, ParentT, ParentCompiled, ParentCompilerContext>
    where ParentT : ICompilable<ParentT, ParentCompiled, ParentCompilerContext>
    where ParentCompilerContext : ICompilerContext<ParentT, ParentCompiled, ParentCompilerContext>
{
    public ParentCompilerContext Parent { get; init; }

    public ChildCompilerContext(ParentCompilerContext parent) {
        Parent = parent;
    }

    public abstract Compiled this[T start] { get; }
}