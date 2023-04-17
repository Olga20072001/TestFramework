using Atata;

namespace TestFramework.PageObjects.SkyUpPages
{
    using _ = HomePage;

    public class HomePage: Page<_>
    {

        [FindById]
        [Term("headerLogin")]
        public Button<LoginPage,_> logIn { get; private set; }
        [FindByClass]
        [Term("header__menu-btn")]
        public Button<_> openMainMenu { get; private set; }
        [FindById]
        [Term("headerCabinet")]
        public Button<_> cabinetBtn { get; private set; }
        [FindByClass]
        [Term("cabinet-nav__user-name")]
        public Text<_> cabinetUserName { get; private set; }
        [FindByClass]
        [Term("header__menu-btn")]
        public Button<_> menuBtn { get; private set; }
        [FindById("navList")]
        public UnorderedList<ListItem<_>,_> menuItemList { get; private set; }
        [FindByClass("nav__dropdown")]
        public UnorderedList<ListItem<_>, _> passengersMenuItemList { get; private set; }

    }
}
