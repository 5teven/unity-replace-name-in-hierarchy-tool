using UnityEditor;

namespace Project33.Editor
{
    public class BatchRepalce : ScriptableWizard
    {
        public string replaceTarget = "mixamorig:";

        public string replaceWith = "";

        [MenuItem("Edit/Batch replace...")]
        static void CreateWizard() {
            ScriptableWizard.DisplayWizard("Batch Replace", typeof(BatchRepalce), "Replace");
        }

        private void OnEnable() {
            UpdateSelectionHelper();
        }

        private void OnSelectionChange() {
            UpdateSelectionHelper();
        }
        
        private void UpdateSelectionHelper() {
            helpString = "";
            if (Selection.objects != null)
                helpString = "Number of objects selected: " + Selection.objects.Length;
        }
        
        private void OnWizardCreate() {
            if (Selection.objects == null)
                return;
            
            foreach(var obj in Selection.objects)
            {
                if (!obj.name.Contains(replaceTarget)) 
                    continue;
                
                obj.name = obj.name.Replace(replaceTarget, replaceWith);
            }
        }
    }
}
