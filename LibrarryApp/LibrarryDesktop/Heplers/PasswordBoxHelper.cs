using System.Windows;
using System.Windows.Controls;

namespace LibraryDesktop.Helpers
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordLengthProperty =
            DependencyProperty.RegisterAttached(
                "PasswordLength",
                typeof(int),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static void SetPasswordLength(DependencyObject d, int value)
        {
            d.SetValue(PasswordLengthProperty, value);
        }

        public static int GetPasswordLength(DependencyObject d)
        {
            return (int)d.GetValue(PasswordLengthProperty);
        }

        public static readonly DependencyProperty BindPasswordProperty =
            DependencyProperty.RegisterAttached(
                "BindPassword",
                typeof(bool),
                typeof(PasswordBoxHelper),
                new PropertyMetadata(false, OnBindPasswordChanged));

        public static void SetBindPassword(DependencyObject d, bool value)
        {
            d.SetValue(BindPasswordProperty, value);
        }

        public static bool GetBindPassword(DependencyObject d)
        {
            return (bool)d.GetValue(BindPasswordProperty);
        }

        private static void OnBindPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                if ((bool)e.NewValue)
                {
                    passwordBox.PasswordChanged += PasswordChanged;
                    UpdatePasswordLength(passwordBox);
                }
                else
                {
                    passwordBox.PasswordChanged -= PasswordChanged;
                }
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                UpdatePasswordLength(passwordBox);
            }
        }

        private static void UpdatePasswordLength(PasswordBox passwordBox)
        {
            SetPasswordLength(passwordBox, passwordBox.Password.Length);
        }
    }
}