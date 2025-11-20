using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DekstopApp.Extensions
{
    public static class NavigationStackExtensions
    {
        public static void ClearNavigationStack(this Shell currentShell)
        {
            var stack = currentShell.Navigation.NavigationStack.ToArray();
            for (int i = stack.Length - 1; i > 0; i--)
            {
                currentShell.Navigation.RemovePage(stack[i]);
            }
        }
    }
}
