namespace DPG.NET;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Type"></param>
/// <param name="SubDefinitions">
/// This is used to represent an XYZ dimension definition with a distinct X, Y,
/// and Z subdimension. Having 1 or 0 subdefinitions would be redundant except
/// for abstracting the definition of a dimension. A null value means the
/// dimension definition is to be taken as a primitive. 
/// </param>
public partial record DimensionDefinition(
        string Name,
        ValueType Type,
        DimensionDefinition[]? SubDefinitions
    )
    : ICompilable<
            DimensionDefinition,
            DimensionDefinition.Compiled,
            DimensionDefinition.CompilerContext
        > {
    public virtual Compiled Compile(CompilerContext context) =>
        new Compiled(
                Name,
                context.Parent.ValueTypes[Type],
                SubDefinitions?
                    .Select(subdefinition => context[subdefinition])
                    .ToArray()
            );

    public record Compiled(
            string Name,
            ValueType.Compiled Type,
            Compiled[]? SubDefinitions
        ) {
        // public record Primitive(
        //         string Name,
        //         ValueType.Compiled.Primitive Type
        //     );

        // public IEnumerable<Primitive> Expand() =>
        //     Type.Expand()
        //         .SelectMany(
        //                 type_primitives =>
        //                 type_primitives.Item1
        //                     new Primitive(
        //                             Name,
        //                             type_primitive.Item2
        //                         )
        //             );
    }
}