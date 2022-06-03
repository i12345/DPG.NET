namespace DPG.NET;

public abstract partial record ValueType(string Name)
    : ICompilable<ValueType, ValueType.Compiled, ValueType.CompilerContext> {
    /// <summary>
    /// Constructs a new compiled ValueType with associated dimensions
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="AssociatedDimensions"></param>
    /// <remarks>The associated dimensions should be combined into the parent ValueSpec's dimensions</remarks>
    public record Compiled(
            string Name,
            ValueDimension.Compiled[] AssociatedDimensions
        ) {
        //public record Primitive(string Name);
        // public IEnumerable<(ValueDimension.Compiled.Primitive, Primitive)> Expand() {
        //     var primitive_type = new Primitive(Name);
        //     var primitive_dimensions = AssociatedDimensions.SelectMany(dimension => dimension.Expand());

        //     foreach(var primitive_dimension in primitive_dimensions)
        //         yield return (primitive_dimension, primitive_type);
        // }
    }

    public record Alias(
            string Name,
            IDictionary<string, ValueType> Parameters
        )
        : ValueType(Name) {
        public override Compiled Compile(CompilerContext context) {
            throw new NotImplementedException();
        }
    }

    public abstract Compiled Compile(CompilerContext context);
}