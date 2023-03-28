abstract class Menu
{
    private protected string menuItem;
    protected Dictionary<int, MainMenu> childrens;
    private protected abstract void MakeChildrens();
    public abstract void Process(List<User> users, List<Person> people);
}
