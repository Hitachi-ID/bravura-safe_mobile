using Bit.Core;
using Bit.Core.Enums;
using Bit.Core.Models.View;
using Bit.Core.Utilities;

namespace Bit.App.Controls
{
    public class AccountViewCellViewModel : ExtendedViewModel
    {
        private AccountView _accountView;
        private AvatarImageSource _avatar;

        public AccountViewCellViewModel(AccountView accountView)
        {
            AccountView = accountView;
            AvatarImageSource = new AvatarImageSource(AccountView.Name, AccountView.Email);
        }

        public AccountView AccountView
        {
            get => _accountView;
            set => SetProperty(ref _accountView, value);
        }

        public AvatarImageSource AvatarImageSource
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }

        public bool IsAccount
        {
            get => AccountView.IsAccount;
        }

        public bool ShowHostname
        {
            get => !string.IsNullOrWhiteSpace(AccountView.Hostname) && AccountView.Hostname != "vault.hitachi-id.com";
        }

        public bool IsActive
        {
            get => AccountView.IsActive;
        }

        public bool IsUnlocked
        {
            get => AccountView.AuthStatus == AuthenticationStatus.Unlocked;
        }

        public bool IsUnlockedAndNotActive
        {
            get => IsUnlocked && !IsActive;
        }

        public bool IsLocked
        {
            get => AccountView.AuthStatus == AuthenticationStatus.Locked;
        }

        public bool IsLockedAndNotActive
        {
            get => IsLocked && !IsActive;
        }

        public bool IsLoggedOut
        {
            get => AccountView.AuthStatus == AuthenticationStatus.LoggedOut;
        }

        public bool IsLoggedOutAndNotActive
        {
            get => IsLoggedOut && !IsActive;
        }

        public string AuthStatusIconActive
        {
            get => "\uf058"; // fa-check-circle
        }

        public string AuthStatusIconNotActive
        {
            get
            {
                if (IsUnlocked)
                {
                    return "\uf13e"; // fa-unlock-alt
                }
                return "\uf023"; // fa-lock
            }
        }
    }
}
