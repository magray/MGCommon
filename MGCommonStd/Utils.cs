using System;
using System.Threading.Tasks;

namespace MGCommon
{
    /// <summary>
    /// Extenstion Utils
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Task extenstion to add a timeout.
        /// </summary>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <param name="task">Task.</param>
        /// <param name="duration">Duration</param>
        /// <returns>The timeout</returns>
        public async static Task<T> WithTimeout<T>(this Task<T> task, int duration)
        {
            var retTask = await Task.WhenAny(task, Task.Delay(duration)).ConfigureAwait(false);

            if (retTask is Task<T>)
                return task.Result;

            return default(T);
        }

        public static async void SafeFireAndForget(this Task task, Action<Exception> onException = null, bool continueOnCaptureContext = false)
        {
            try
            {
                await task.ConfigureAwait(continueOnCaptureContext);
            }
            catch (Exception ex) when (onException != null)
            {
                onException.Invoke(ex);
                
            }
        }
    }
}
