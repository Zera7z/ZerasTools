using System.Windows.Controls;

namespace ZerasTools.Models
{
    public class ToolItem
    {
        public string Name { get; set; }
        public UserControl View { get; set; }
        public bool OpensWindow { get; set; } = false;
    }
}
