using System;
using System.Windows.Input;

namespace CommandPrompter.Helpers
{
    public class RelayCommand : ICommand
    {
        private Action<object> mAction;
        public RelayCommand(Action action)
        {
            mAction = new Action<object>((o)=> action.Invoke());
        }
        public RelayCommand(Action<object> action)
        {
            mAction = action;
        }
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
}
