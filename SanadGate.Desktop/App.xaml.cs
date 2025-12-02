using System.Windows;

namespace SanadGate.Desktop;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Set global RTL flow direction
        FrameworkElement.FlowDirectionProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(FlowDirection.RightToLeft));
    }
}
