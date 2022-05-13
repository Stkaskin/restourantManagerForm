
namespace restourantManagerForm.Manager
{
   public class PropertyManagerService
    {
        public void setAllProperties(object itemOrjinal, object itemSet)
        {
            foreach (var item in itemOrjinal.GetType().GetProperties())
                itemOrjinal.GetType().GetProperty(item.Name).SetValue(itemOrjinal, itemSet.GetType().GetProperty(item.Name).GetValue(itemSet));
        }
       

    }
}
