namespace DPG.NET;

public interface IValueDimensionOperation {
    /// <summary>
    /// Compiles the output value dimensions given input value dimensions in
    /// this IValueDimensionOperation.
    /// </summary>
    /// <param name="inputs">the input value dimensions that haven't been compiled yet.</param>
    /// <param name="outputs">the output value dimensions</param>
    /// <param name="context"></param>
    void Compile(
            IList<ValueDimension.Compiled> inputs,
            IList<ValueDimension.Compiled> outputs,
            ValueDimension.CompilerContext context
        );
}