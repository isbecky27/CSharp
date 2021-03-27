using System;

namespace BirthdayChecker
{
	public class BirthdayChecker
	{
		public bool IsBirthday()
		{
			//todo: 完成兩個測試案例
			var today = Today();
			if (today.Month == 10 && today.Day == 10)
			{
				return true;
			}
			return false;
		}

        // 為了測試去更改了 production code
		protected virtual DateTime Today()
        {
            return DateTime.Today;
        }
	}
}