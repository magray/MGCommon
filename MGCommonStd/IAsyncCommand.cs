using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MGCommon
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();

        void RaiseCanExecuteChanged();
    }

    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);

        void RaiseCanExecuteChanged();
    }
}
