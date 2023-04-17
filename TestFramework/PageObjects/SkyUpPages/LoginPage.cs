using Atata;

namespace TestFramework.PageObjects.SkyUpPages
{
    using _ = LoginPage;

    public class LoginPage: Page<_>
    {
        [FindByClass]
        [Term("btn-4 js-show-log-in")]
        public Button<_> firstLogIn { get; private set; }
        [FindById]
        [Term("logInBtn")]
        public Button<_> secondLogIn { get; private set; }
        [FindById]
        [Term("logInEmail")]
        public EmailInput<_> email { get; private set; }
        [FindByClass]
        [Term("field__input")]
        public PasswordInput<_> password { get; private set; }
    }
}
