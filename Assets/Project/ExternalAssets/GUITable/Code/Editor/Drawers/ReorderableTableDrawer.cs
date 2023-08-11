using UnityEditor;

namespace EditorGUITable
{

    [CustomPropertyDrawer(typeof(ReorderableTableAttribute))]
    public class ReorderableTableDrawer : TableDrawer
    {

        protected override GUITableOption[] forcedTableOptions => new GUITableOption[] { GUITableOption.AllowScrollView(false), GUITableOption.Reorderable(true) };

    }

}
