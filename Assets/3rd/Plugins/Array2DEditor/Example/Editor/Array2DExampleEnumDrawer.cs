using UnityEditor;
using DottedFill;

namespace Array2DEditor
{
    [CustomPropertyDrawer(typeof(Array2DExampleEnum))]
    public class Array2DExampleEnumDrawer : Array2DEnumDrawer<ExampleEnum> {}

    [CustomPropertyDrawer(typeof(Array2DExampleEnum))]
    public class NodeStateEnum : Array2DEnumDrawer<NodeState> { }
}
