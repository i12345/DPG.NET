namespace DPG.NET;

public interface IChildCompilerContext<
        T, Compiled, CompilerContext,
        ParentT, ParentCompiled, ParentCompilerContext
    >
    : ICompilerContext<T, Compiled, CompilerContext>
    where T : ICompilable<T, Compiled, CompilerContext>
    where CompilerContext : IChildCompilerContext<T, Compiled, CompilerContext, ParentT, ParentCompiled, ParentCompilerContext>
    where ParentT : ICompilable<ParentT, ParentCompiled, ParentCompilerContext>
    where ParentCompilerContext : ICompilerContext<ParentT, ParentCompiled, ParentCompilerContext>
{
    ParentCompilerContext Parent { get; }
}