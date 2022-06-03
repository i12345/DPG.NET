namespace DPG.NET;

public abstract partial record class ValueDimension(
        NodeID Context,
        DimensionDefinition Definition,
        bool IsVirtual
    ) :
    ICompilable<ValueDimension, ValueDimension.Compiled, ValueDimension.CompilerContext> {
    
    public abstract Compiled Compile(CompilerContext context);

    public record class Compiled(
            Node.Compiled Context,
            DimensionDefinition.Compiled Definition,
            bool IsVirtual
        ) {
        // public record Primitive(
        //         Node.Compiled.Output Context,
        //         DimensionDefinition.Compiled.Primitive Definition,
        //         bool IsVirtual
        //     );

        // public IEnumerable<Primitive> Expand() =>
        //     Definition
        //         .Expand()
        //         .Select(primitive_definition =>
        //                 new Primitive(
        //                         Context,
        //                         primitive_definition,
        //                         IsVirtual
        //                     )
        //             );

        public bool CutFrom(
                IList<ValueDimension.Compiled> dimensions,
                CompilerContext context
            ) {
            //TODO: how can subdimensions be specified for a ValueDimensionOperation?

            return dimensions.Remove(this);
        }
    }

    // public record class Primitive(
    //         DimensionDefinition.Compiled Definition_compiled,
    //         bool IsVirtual
    //     ) :
    //     Compiled(
    //             Definition_compiled,
    //             IsVirtual,
    //             new ValueDimension.Compiled[0]
    //         ) {

    //     public override Compiled Compile(GraphCompilerContext context) => this;
    // }
}