namespace DPG.NET;

public abstract partial record ValueSpec(
        ValueType Type,
        ValueDimension[] Dimensions
    )
    : ICompilable<ValueSpec, ValueSpec.Compiled, ValueSpec.CompilerContext> {
    public abstract Compiled Compile(CompilerContext context);

    public record class Compiled(
            ValueType.Compiled Type,
            ValueDimension.Compiled[] Dimensions
        );
}