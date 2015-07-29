namespace NewsClient.Tests
{
	using System;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

	public static class AssertEx
	{
		public static async Task ThrowsExceptionAsync<TException>(Func<Task> asyncFunction) where TException : class
		{
			await ThrowsExceptionAsync<TException>(asyncFunction, exception => { });
		}

		public static async Task ThrowsExceptionAsync<TException>(Func<Task> asyncFunction, Action<TException> action)
			where TException : class
		{
			var exception = default(TException);
			var expected = typeof (TException);
			Type actual = null;
			try
			{
				await asyncFunction();
			}
			catch (Exception e)
			{
				exception = e as TException;
				actual = e.GetType();
			}

			Assert.AreEqual(expected, actual);
			action(exception);
		}
	}
}