internal class MenuLeaf<T> : Menu
{
    protected readonly ApplicationContext<T> context;
    protected Action<ApplicationContext<T>> action;
    public MenuLeaf(string name, ApplicationContext<T> context, Action<ApplicationContext<T>> action) : base(name)
    {
        this.context = context;
        this.action = action;
    }

    public override void Process()
    {
        action(context);
    }
}