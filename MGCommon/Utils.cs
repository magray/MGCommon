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
    }
}
