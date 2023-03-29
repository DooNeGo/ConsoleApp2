abstract class Menu<T>
{
    protected Dictionary<int, T>? childrens;
    protected string? menuItem;
    protected abstract void UpdateChildrens();
    protected abstract void ShowMenuItems();
    public abstract void Process();
}