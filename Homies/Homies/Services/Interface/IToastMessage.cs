using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homies.Services.Interface
{
    public interface IToastMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
        void ShowSnackbar(string message, int duration = 300);
    }
}
