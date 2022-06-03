namespace DPG.NET;

public interface ICompilable<T, Compiled, CompilerContext>
    where T : ICompilable<T, Compiled, CompilerContext>
    where CompilerContext : ICompilerContext<T, Compiled, CompilerContext> {
    Compiled Compile(CompilerContext context);
}