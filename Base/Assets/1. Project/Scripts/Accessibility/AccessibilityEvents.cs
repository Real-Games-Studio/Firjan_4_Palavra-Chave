using System;

namespace _1._Project.Scripts.Accessibility
{
	public static class AccessibilityEvents
	{
		public static Action<Languages> OnChange;
	}

	public enum Languages
	{
		English =1,
		Portuguese =0,
		Libras =2
	}
}