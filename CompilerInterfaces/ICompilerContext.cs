namespace DPG.NET;

public interface ICompilerContext<T, Compiled, Context>
    where T : ICompilable<T, Compiled, Context>
    where Context : ICompilerContext<T, Compiled, Context>
{
    Compiled this[T start] { get; }
}