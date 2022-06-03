using DotNetHelpers;

namespace DPG.NET;

partial record ValueDimension {
    public class CompilerContext
        : MemoizingChildCompilerContext<
                ValueDimension, ValueDimension.Compiled, ValueDimension.CompilerContext,
                Graph, Graph.Compiled, Graph.CompilerContext
            > {
        public EqualityClasses<ValueDimension.Compiled> EqualityClasses { get; init; } = new();

        public CompilerContext(Graph.CompilerContext parent)
            : base(parent) { }

        public ValueDimension.Compiled[] CombineDimensionSets(
                ValueDimension.Compiled[][] dimensionSets
            ) =>
            dimensionSets
                .Cast<IEnumerable<ValueDimension.Compiled>>()
                .Aggregate(
                        (A, B) => A.Union(B, EqualityClasses)
                    )
                .ToArray();
    }
}